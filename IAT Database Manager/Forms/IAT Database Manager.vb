Imports System.Data
Imports System.IO
Imports System.Net.Http
Imports System.Runtime.Intrinsics
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Controls
Imports Imgur.API.Authentication
Imports Imgur.API.Endpoints
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports Microsoft.Web.WebView2.WinForms
Imports Serilog
Imports Serilog.Sinks.RichTextBox.WinForms
Imports Serilog.Sinks.RichTextBox.WinForms.Themes

Public Class frmIATDatabaseManager
    Public CentralDB As New List(Of Expansion)
    Public LocalisationDB As New List(Of Localisation)
    Public NPCDB As New List(Of NPC)
    Public SpellDB As New List(Of Spell)
    Public NPCTable = New DataTable
    Public BossesTable As DataTable = New DataTable
    Public SpellTable = New DataTable
    Public CurrentSite = Nothing
    Public PreviousSites As New List(Of String)
    Public CheckingSpellName = False

    Private IATContext As IATDbContext

    ' Add this at class level to remember the clicked link ID or text
    Private lastClickedElementId As String = ""

    Public splash As SplashScreen1 = CType(My.Application.SplashScreen, SplashScreen1)

    Private Sub InitialiseDatabase()
        Using db As New IATDbContext
            'db.Database.EnsureDeleted()
            db.Database.EnsureCreated()
            Log.Information("Database initialised successfully")
        End Using
    End Sub

    Private Sub InitialMigrationImport()

        ' Load Localisation
        splash.UpdateProgress("Migrating Localisation", 1)
        ImportLocalisation()

        ' Import NPC Cache
        splash.UpdateProgress("Migrating NPC Cache", 2)
        ImportNPCCache()

        ' Spell Cache
        splash.UpdateProgress("Migrating Spell Cache", 3)
        ImportSpellIds()

        ' Item Cache
        splash.UpdateProgress("Migrating Item Cache", 4)
        ImportItemCache()

        ' Load Translations
        splash.UpdateProgress("Migrating Translations", 5)
        Dim languageFiles As String() = {"Localization.frFR.lua", "Localization.deDE.lua", "Localization.esES.lua", "Localization.ruRU.lua", "Localization.esMX.lua", "Localization.zhCN.lua", "Localization.zhTW.lua", "Localization.ptBR.lua", "Localization.koKR.lua"}
        Dim languageCodes As String() = {"frFR", "deDE", "esES", "ruRU", "esMX", "zhCN", "zhTW", "ptBR", "koKR"}
        For i As Integer = 0 To languageFiles.Length - 1
            Dim filePath As String = Path.Combine("C:\Users\ryanc\Dropbox\InstanceAchievementTracker", languageFiles(i))
            If File.Exists(filePath) Then
                ImportTranslations(filePath, languageCodes(i))
            End If
        Next

        splash.UpdateProgress("Migrating Expansions", 6)
        'Insert Expansions
        ImportExpansions()

        splash.UpdateProgress("Migrating Instance Types", 7)
        'Insert InstanceTypes
        ImportInstanceTypes()

        splash.UpdateProgress("Migrating Instances", 8)
        'Insert Instances
        ImportInstances()

        splash.UpdateProgress("Migrating Bosses", 9)
        'Insert Bosses
        ImportBosses()
    End Sub

    Public Async Function ImportLocalisationFromCurseforge() As Task
        Log.Information("Importing localisation from CurseForge...")

        Dim curseforgeClient As New CurseForgeClient()
        Dim localisationString As String = Await curseforgeClient.GetLocalizationAsync()

        ' Regex to match ["key"] = "value", handling escaped quotes and multiline values
        Dim pattern As String = "\[\s*""(.*?)""\s*\]\s*=\s*""((?:[^""\\]|\\.)*?)"",?"
        Dim matches = Regex.Matches(localisationString, pattern, RegexOptions.Singleline)

        Dim curseForgeKeys As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        Using db As New IATDbContext()
            ' Mark matching translations from CurseForge as uploaded
            For Each match As Match In matches
                Dim key As String = match.Groups(1).Value
                Dim rawValue As String = match.Groups(2).Value

                If rawValue.Length = 0 Then
                    Continue For ' Skip entries with empty values
                End If

                curseForgeKeys.Add(key)

                Dim existing = db.Localisations.FirstOrDefault(Function(l) l.Key = key)
                If existing IsNot Nothing Then
                    existing.UploadedToCurseForge = True
                End If
            Next

            ' Mark entries not present on CurseForge
            Log.Information("Checking for missing localisation keys not uploaded to CurseForge...")

            Dim missingFromCurseForge = db.Localisations.
            Where(Function(l) Not curseForgeKeys.Contains(l.Key)).
            ToList()

            If missingFromCurseForge.Any() Then
                Log.Warning("The following localisation keys exist in the database but are missing from CurseForge:")
                For Each item In missingFromCurseForge
                    item.UploadedToCurseForge = False
                    Log.Warning("Key: {Key}", item.Key)
                Next
            Else
                Log.Information("No missing keys. All localisations are present in CurseForge.")
            End If

            db.SaveChanges()
        End Using

        Log.Information("Localisation import from CurseForge completed.")
    End Function

    Public Async Function ImportTranslationFromCurseforge(language As String) As Task
        If language = "enUS" Then
            Throw New ArgumentException("Use ImportBaseLocalisationFromCurseforge for enUS.")
        End If

        Log.Information("Importing translations for {Lang}...", language)

        Dim curseforgeClient As New CurseForgeClient()
        Dim localisationString As String = Await curseforgeClient.GetLocalizationAsync(language)

        If String.IsNullOrWhiteSpace(localisationString) Then
            Log.Warning("No data returned from CurseForge for {Lang}.", language)
            Return
        End If

        Dim pattern As String = "\[\s*""(.*?)""\s*\]\s*=\s*""((?:[^""\\]|\\.)*?)"",?"
        Dim matches = Regex.Matches(localisationString, pattern, RegexOptions.Singleline)

        Using db As New IATDbContext()
            For Each match As Match In matches
                Dim key As String = match.Groups(1).Value
                Dim rawValue As String = match.Groups(2).Value
                If rawValue.Length = 0 Then Continue For

                Dim value As String = rawValue.Replace("\\", "\")
                Dim localisation = db.Localisations.FirstOrDefault(Function(l) l.Key = key)

                If localisation Is Nothing Then
                    Log.Warning("Skipping translation for unknown key '{Key}'", key)
                    Continue For
                End If

                Dim existingTranslation = db.Translations.
                    FirstOrDefault(Function(t) t.LocalisationId = localisation.Id AndAlso t.LanguageCode = language)

                If existingTranslation Is Nothing Then
                    Dim newTranslation As New Translation With {
                        .LanguageCode = language,
                        .Value = value,
                        .LocalisationId = localisation.Id
                    }

                    If ValidateTranslation(db, newTranslation) Then
                        db.Translations.Add(newTranslation)
                        Log.Information("Added translation: {Lang}:{Key}", language, key)
                    End If
                ElseIf existingTranslation.Value <> value Then
                    existingTranslation.Value = value
                    If ValidateTranslation(db, existingTranslation) Then
                        Log.Information("Updated translation: {Lang}:{Key}", language, key)
                    End If
                End If
            Next

            db.SaveChanges()
        End Using

        Log.Information("Translation import complete for {Lang}.", language)
    End Function

    Private Async Sub frmIATDatabaseManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize Serilog logger
        Log.Logger = New LoggerConfiguration() _
            .WriteTo.RichTextBox(rtbLog) _
            .CreateLogger()

        ' Load Config
        Settings.LoadConfig()

        ' Make sure SQLite Database is created
        InitialiseDatabase()

        'Initial Migration import
        'InitialMigrationImport()

        ' Setup Data Grid Views
        IATContext = New IATDbContext()
        IATContext.Expansions.Load()
        ExpansionBindingSource.DataSource = IATContext.Expansions.Local.ToBindingList()

        ' Setup Boss Combobox selection
        Using db As New IATDbContext
            Dim bosses As List(Of Boss) = db.Bosses.ToList()
            cboBosses.DataSource = bosses
            cboBosses.DisplayMember = "BossName"
            cboBosses.ValueMember = "Id"
        End Using

        UpdateNPCCacheExpansionIDs()
    End Sub

    Public Sub UpdateNPCCacheExpansionIDs()
        ' Fetch all npcsid from npcdb
        Dim npcIDs As List(Of Integer) = New List(Of Integer)()
        Using db As New IATDbContext
            'Select all NPC IDs from the database where expansionid is 0
            npcIDs = db.NPCs.Where(Function(n) n.ExpansionId = 0).Select(Function(n) n.NPCId).ToList()
        End Using

        For Each npcID In npcIDs
            ' Optional: Skip if expansion already stored in DB

            Dim patchVersion = GetWowheadPatchForNPC(npcID)
            Dim expansionID = PatchToExpansionID(patchVersion)

            ' Store expansionID in your DB for this npcID
            UpdateNPCExpansionInDB(npcID, expansionID)

            Console.WriteLine($"NPC {npcID} stored expansion: {expansionID}")

            ' Wait random time between 2 and 10 seconds
            Dim randomWaitTime = New Random().Next(2000, 10000) ' Between 2 and 10 seconds
            Thread.Sleep(randomWaitTime)
        Next
    End Sub

    ' Implement this to update your DB with expansionID for the NPC
    Private Sub UpdateNPCExpansionInDB(npcID As Integer, expansionID As String)
        Using db As New IATDbContext
            ' Select npcid and update patch added
            Dim npc = db.NPCs.FirstOrDefault(Function(n) n.NPCId = npcID)
            If npc IsNot Nothing Then
                npc.ExpansionID = expansionID
                db.SaveChanges()
            Else
                Log.Warning("NPC with ID {NpcId} not found in database.", npcID)
            End If
        End Using
    End Sub

    Public Function PatchToExpansionID(patch As String) As Integer
        If String.IsNullOrEmpty(patch) OrElse patch = "Unknown" Then Return 0

        Dim major As Integer
        Dim parts = patch.Split("."c)
        If Integer.TryParse(parts(0), major) Then
            Return major
        End If
        Return 0
    End Function

    Private Sub ExpansionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpansionToolStripMenuItem.Click
        InsertExpansion.Show()
    End Sub

    Private Sub InstanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstanceToolStripMenuItem.Click
        InsertInstance.Show()
    End Sub

    Private Sub BossToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BossToolStripMenuItem.Click
        InsertBoss.Show()
    End Sub

    Private Async Sub cboBosses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBosses.SelectedIndexChanged
        Dim selectedBoss As Boss = TryCast(cboBosses.SelectedItem, Boss)
        If selectedBoss IsNot Nothing Then
            Using db As New IATDbContext
                Dim boss = db.Bosses.Find(selectedBoss.Id)

                ' Clear existing tab pages
                tcTactics.TabPages.Clear()

                Dim index As Integer = 1
                For Each tactic As Tactic In boss.Tactics
                    Dim tabPage As New TabPage("Tactic-" & tactic.Id)
                    index += 1

                    ' Prepare parameters ordered by position
                    Dim parameters = tactic.TacticParameter.OrderBy(Function(p) p.Order).ToList()

                    ' Replace %s with clickable NPC/spell links in HTML format
                    Dim tacticText As String = tactic.Localisation.Value
                    For Each param In parameters
                        Dim replacement As String = param.ParameterID

                        If param.ParameterType = "NPC" Then
                            Dim npc = db.NPCs.FirstOrDefault(Function(n) n.NPCId = param.ParameterID)
                            If npc IsNot Nothing Then
                                replacement = $"<a href=""npc:{npc.NPCId}:pos:{param.Id}"" id=""{param.Id}"" >{npc.Name}</a>"
                            Else
                                replacement = "[Unknown NPC]"
                            End If
                        ElseIf param.ParameterType = "Spell" Then
                            Dim spell = db.Spells.FirstOrDefault(Function(n) n.SpellId = param.ParameterID)
                            If spell IsNot Nothing Then
                                replacement = $"<a href=""spell:{spell.SpellId}:pos:{param.Id}"" id=""{param.Id}"" >[{spell.Name}]</a>"
                            Else
                                replacement = "[Unknown Spell]"
                            End If
                        End If

                        tacticText = ReplaceFirst(tacticText, "%s", replacement)
                    Next

                    ' Replace \n\n with <br><br> for HTML new lines
                    tacticText = tacticText.Replace("\n\n", "<br><br>")


                    ' Wrap tacticText in simple HTML body with basic styling
                    Dim html As String = $"<html>
                    <head>
                    <style>body {{ font-family: Segoe UI, Tahoma, Geneva, Verdana, sans-serif; padding: 10px; }}</style>
                    </head>
                    <body><div contenteditable=""true"">{tacticText}</div></body>
                    </html>"

                    ' Create WebView2 control
                    Dim webView As New WebView2 With {
                        .Dock = DockStyle.Fill
                    }

                    tabPage.Controls.Add(webView)
                    tcTactics.TabPages.Add(tabPage)

                    ' Initialize WebView2 and navigate to generated HTML string
                    Await webView.EnsureCoreWebView2Async()

                    ' Hook navigation event to intercept npc: links
                    AddHandler webView.CoreWebView2.NavigationStarting, Sub(sender2, e2)
                                                                            If e2.Uri.StartsWith("npc:") Then
                                                                                e2.Cancel = True

                                                                                ' Split the href into parts: "npc:12345:pos:3"
                                                                                Dim parts = e2.Uri.Substring("npc:".Length).Split(":"c)
                                                                                Dim npcId = parts(0)
                                                                                Dim positionInfo As String = If(parts.Length > 2, parts(2), Nothing)

                                                                                Dim selector As New EntitySelector With {
                                                                                    .TypeToLoad = EntityType.NPC,
                                                                                    .SelectedItemIndex = positionInfo
                                                                                }
                                                                                selector.Show()
                                                                            ElseIf e2.Uri.StartsWith("spell:") Then
                                                                                e2.Cancel = True

                                                                                ' Split the href into parts: "spell:12345:pos:3"
                                                                                Dim parts = e2.Uri.Substring("spell:".Length).Split(":"c)
                                                                                Dim npcId = parts(0)
                                                                                Dim positionInfo As String = If(parts.Length > 2, parts(2), Nothing)

                                                                                ' For example, assume positionInfo is the element ID suffix (e.g., 3)
                                                                                lastClickedElementId = positionInfo

                                                                                ' Open Spell Selector
                                                                                Dim selector As New EntitySelector With {
                                                                                    .TypeToLoad = EntityType.Spell,
                                                                                    .SelectedItemIndex = positionInfo
                                                                                }
                                                                                selector.Show()
                                                                            End If
                                                                        End Sub
                    ' Load HTML content into WebView2
                    webView.NavigateToString(html)

                    ' Open the achievement in the browser on wowhead
                    Browser.wvBrowser.Source = New Uri($"https://www.wowhead.com/achievement={selectedBoss.AchievementID}#comments")
                Next
            End Using
        End If
    End Sub

    Private Sub Tactics_LinkClicked(sender As Object, e As LinkClickedEventArgs)
        Dim link = e.LinkText

        If link.StartsWith("<npc:") AndAlso link.EndsWith(">") Then
            Dim npcId = link.Substring(5, link.Length - 6) ' Remove <npc: and >
            ' Open your NPC form, pass npcId
            MsgBox(npcId)
        End If
    End Sub

    Private Function ConvertTextToRtfWithLinks(template As String, parameters As List(Of TacticParameter), db As IATDbContext) As String
        Dim i = 0
        For Each param In parameters
            Dim replacement As String = param.ParameterID

            If param.ParameterType = "NPC" Then
                Dim npc = db.NPCs.FirstOrDefault(Function(n) n.NPCId = param.ParameterID)
                If npc IsNot Nothing Then
                    ' RTF link format: \v hidden_value \v0 visible_text
                    replacement = $"{{\ul\b\cf1\v<npc:{npc.NPCId}>\v0[{npc.Name}]}}"
                End If
            End If

            template = template.Replace("%s", replacement, 1)
            i += 1
        Next

        ' Wrap in minimal RTF document structure
        Return "{\rtf1\ansi\deff0{\colortbl;\red0\green0\blue255;}" & template & "}"
    End Function

    Private Async Sub btnGenerateLocalisation_Click(sender As Object, e As EventArgs) Handles btnGenerateLocalisation.Click
        'Dim bmp As Bitmap = New Bitmap(txtInGame.Width, txtInGame.Height)
        'txtInGame.DrawToBitmap(bmp, New Rectangle(0, 0, txtInGame.Width, txtInGame.Height))
        'bmp.Save("Screenshots/" & txtBossName.Text & ".jpg")

        'Await Task.Delay(2000)

        'Dim apiClient = New ApiClient("3c704f8deefd409", "82cf43f64495b192b1083ed8a59e30139bd4d797")
        'Dim httpClient = New HttpClient()
        'Dim oAuth2Endpoint = New OAuth2Endpoint(apiClient, httpClient) -
        ''Dim authUrl = oAuth2Endpoint.GetAuthorizationUrl()

        'Dim filePath = "Screenshots/" & txtBossName.Text & ".jpg"
        'Using FileStream = File.OpenRead(filePath)
        '    Dim imageEndpoint = New ImageEndpoint(apiClient, httpClient)
        '    Dim imageUpload = Await imageEndpoint.UploadImageAsync(FileStream)
        '    txtImgurLink.Text = "https://imgur.com/" & imageUpload.Id
        '    txtContext.Text = "*** Notes *** Please don't remove the %s strings or ""\n"" as these refer to names of spells/ npc's in the game or new lines. They can be moved around in the sentence however if that makes more sense in your language.English Text:" & txtImgurLink.Text
        '    LoadWebsite(txtImgurLink.Text)
        'End Using
    End Sub

    Private Sub btnInsertTactic_Click(sender As Object, e As EventArgs) Handles btnInsertTactic.Click
        ' Save changes to the tactics
        SaveTactics()

        ' Retail DB
        GenerateAddonDatabase(12)
        ' Wrath DB
        GenerateAddonDatabase(3, "Wrath")
        ' Cataclysm DB
        GenerateAddonDatabase(4, "Cataclysm")
        ' Mop DB
        GenerateAddonDatabase(5, "Pandaria")

        ' Generatee Localisation.lua
        GenerateLocalisationFiles()

        ' Generate ItemCache.lua
        GenerateItemCache()

        ' Generate NPCCache.lua
        GenerateNPCCacheFile()

        ' Validate translations
        ValidateTranslations()

        ' Generate Translations for other languages
        GenerateTranslations()
    End Sub

    Public Sub ValidateTranslations()
        Log.Information("Validating all translations...")

        Using db As New IATDbContext()
            ' Load English localisation values

            Dim translations = db.Translations.ToList()

            For Each translation In translations
                ' Check that we have a key in the localisation table
                If translation.LocalisationId = 0 Then
                    Log.Error($"Translation {translation.Id} does not have a valid LocalisationId.")
                    translation.IsBroken = True
                    Continue For
                End If

                ' Check that the number of %s placeholders match
                Dim expectedPlaceholders = Regex.Matches(translation.Localisation.Value, "%s").Count
                Dim actualPlaceholders = Regex.Matches(translation.Value, "%s").Count
                If expectedPlaceholders <> actualPlaceholders Then
                    Log.Error($"[{translation.LanguageCode}] Placeholder count mismatch for key '{translation.Localisation.Key}' (%s count {expectedPlaceholders} vs {actualPlaceholders}).")
                    translation.IsBroken = True
                    Continue For
                End If

                ' Check for improper newlines and normalize them to \n
                Dim originalValue = translation.Value
                Dim fixedValue = originalValue.Replace(vbCrLf, "\n").Replace(vbCr, "\n").Replace(vbLf, "\n")

                If fixedValue <> originalValue Then
                    Log.Warning($"[{translation.LanguageCode}] Normalizing newlines for key '{translation.Localisation.Key}'.")
                    translation.Value = fixedValue
                End If

                ' Check that the number of literal % signs matches (i.e., %% in translation vs % not followed by 's' in English)
                Dim englishLiteralPercents = Regex.Matches(translation.Localisation.Value, "%%").Count
                Dim translatedEscapedPercents = Regex.Matches(translation.Value, "%%").Count

                If englishLiteralPercents <> translatedEscapedPercents Then
                    Log.Error($"[{translation.LanguageCode}] Escaped percent mismatch for key '{translation.Localisation.Key}' (Expected {englishLiteralPercents} escaped %% but found {translatedEscapedPercents}).")
                    translation.IsBroken = True
                    Continue For
                End If

                ' If localisation is used for a tactic, check the parameter count
                Dim tactic = db.Tactics.FirstOrDefault(Function(t) t.LocalisationId = translation.LocalisationId)
                If tactic IsNot Nothing Then
                    Dim expectedParamCount = db.TacticParameters.Count(Function(tp) tp.TacticId = tactic.Id)
                    Dim actualParamPlaceholders = Regex.Matches(translation.Value, "%s").Count

                    If expectedParamCount <> actualParamPlaceholders Then
                        Log.Error($"[{translation.LanguageCode}] Tactic param mismatch for key '{translation.Localisation.Key}' (expected {expectedParamCount} parameters, found {actualParamPlaceholders} %s).")
                        translation.IsBroken = True
                        Continue For
                    End If
                End If

                ' Match all \x pairs that are not one of the valid escape sequences
                Dim invalidEscapePattern As String = "\\[^n""\\%]"
                Dim matches = Regex.Matches(translation.Value, invalidEscapePattern)

                If matches.Count > 0 Then
                    Dim invalidSequences = matches.Cast(Of Match).Select(Function(m) m.Value).Distinct()
                    Log.Error($"[{translation.LanguageCode}] Invalid escape sequences {String.Join(", ", invalidSequences)} in key '{translation.Localisation.Key}'.")
                    translation.IsBroken = True
                    Continue For
                End If

                ' Passed all checks for set broken as false
                translation.IsBroken = False
            Next

            db.SaveChanges()
        End Using
    End Sub

    Public Function ValidateTranslation(db As IATDbContext, translation As Translation) As Boolean
        ' Ensure translation is linked to a valid Localisation
        If translation.Localisation Is Nothing Then
            translation.Localisation = db.Localisations.FirstOrDefault(Function(l) l.Id = translation.LocalisationId)
        End If

        If translation.Localisation Is Nothing Then
            Log.Error($"Translation {translation.Id} does not have a valid linked Localisation.")
            translation.IsBroken = True
            Return False
        End If

        Dim key As String = translation.Localisation.Key
        Dim englishValue As String = translation.Localisation.Value
        Dim translatedValue As String = translation.Value

        ' Placeholder count match check (%s)
        Dim expectedPlaceholders = Regex.Matches(englishValue, "%s").Count
        Dim actualPlaceholders = Regex.Matches(translatedValue, "%s").Count
        If expectedPlaceholders <> actualPlaceholders Then
            Log.Error($"[{translation.LanguageCode}] Placeholder count mismatch for key '{key}' (%s count {expectedPlaceholders} vs {actualPlaceholders}).")
            translation.IsBroken = True
            Return False
        End If

        ' Normalize newline characters to \n
        Dim fixedValue = translatedValue.Replace(vbCrLf, "\n").Replace(vbCr, "\n").Replace(vbLf, "\n")
        If fixedValue <> translatedValue Then
            Log.Warning($"[{translation.LanguageCode}] Normalizing newlines for key '{key}'.")
            translation.Value = fixedValue
        End If

        ' Escaped percent signs (%%)
        Dim englishLiteralPercents = Regex.Matches(englishValue, "%%").Count
        Dim translatedEscapedPercents = Regex.Matches(translation.Value, "%%").Count
        If englishLiteralPercents <> translatedEscapedPercents Then
            Log.Error($"[{translation.LanguageCode}] Escaped percent mismatch for key '{key}' (Expected {englishLiteralPercents} escaped %% but found {translatedEscapedPercents}).")
            translation.IsBroken = True
            Return False
        End If

        ' Tactic parameter count check
        Dim tactic = db.Tactics.FirstOrDefault(Function(t) t.LocalisationId = translation.LocalisationId)
        If tactic IsNot Nothing Then
            Dim expectedParamCount = db.TacticParameters.Count(Function(tp) tp.TacticId = tactic.Id)
            If expectedParamCount <> actualPlaceholders Then
                Log.Error($"[{translation.LanguageCode}] Tactic param mismatch for key '{key}' (expected {expectedParamCount} parameters, found {actualPlaceholders} %s).")
                translation.IsBroken = True
                Return False
            End If
        End If

        ' Passed all checks
        translation.IsBroken = False
        Return True
    End Function

    Public Sub GenerateTranslations()
        Log.Information("Generating all localisation files...")

        Using db As New IATDbContext()
            ' Get all translations, then group by LanguageCode (or similar property)
            Dim translationsByLang = db.Translations.GroupBy(Function(t) t.LanguageCode).ToList()

            Dim localisationDir = "C:\Users\ryanc\Dropbox\InstanceAchievementTracker\"

            For Each localeGroup In translationsByLang
                Dim languageCode = localeGroup.Key
                Log.Information($"Generating localisation file Localization.{languageCode}.lua")
                Dim filePath = Path.Combine(localisationDir, $"Localization.{languageCode}.lua")

                Using writer As New StreamWriter(filePath, False)
                    writer.WriteLine($"if(GetLocale() ~= '{languageCode}') then return end")
                    writer.WriteLine()
                    writer.WriteLine("local _, core = ...")
                    writer.WriteLine("local baseLocale = {")

                    ' Write all translations for this language, ordered by key
                    For Each translation In localeGroup.OrderBy(Function(t) t.Id)
                        Dim keySafe = translation.Localisation.Key
                        Dim valSafe = translation.Value

                        If translation.IsBroken Then
                            writer.WriteLine(vbTab & $"--[""{keySafe}""] = ""{valSafe}"",")
                        Else
                            writer.WriteLine(vbTab & $"[""{keySafe}""] = ""{valSafe}"",")
                        End If
                    Next

                    writer.WriteLine("}")
                    writer.WriteLine()
                    writer.WriteLine($"core:RegisterLocale('{languageCode}', baseLocale)")
                End Using
            Next
        End Using

        Log.Information("All localisation files generated successfully.")
    End Sub

    Public Sub GenerateNPCCacheFile()
        Log.Information("Generating NPCCache.lua...")

        Using db As New IATDbContext()
            Dim npcs = db.NPCs.Where(Function(p) p.Cache = True).OrderBy(Function(n) n.NPCId).ToList()

            Dim filePath = "C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua"

            Using writer As New StreamWriter(filePath, False)
                ' Header
                writer.WriteLine("local _, core = ...")
                writer.WriteLine()
                writer.WriteLine("core.NPCCache = {")

                ' Write each NPC in format: [12345] = 12345, --NPC Name
                For Each npc In npcs
                    Dim npcId = npc.NPCId
                    Dim npcName = npc.Name.Replace("--", "-") ' Avoid breaking comments
                    writer.WriteLine(vbTab & $"[{npcId}] = {npc.ExpansionId}, --{npcName}")
                Next

                writer.WriteLine("}")
            End Using
        End Using

        Log.Information("NPCCache.lua generated successfully.")
    End Sub

    Public Sub GenerateItemCache()
        Log.Information("Generating ItemCache.lua...")

        Using db As New IATDbContext()
            Dim items = db.Items.OrderBy(Function(i) i.ItemId).ToList()

            Dim filePath = "C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua"

            Using writer As New StreamWriter(filePath, False)
                ' Header
                writer.WriteLine("local _, core = ...")
                writer.WriteLine()
                writer.WriteLine("core.ItemCache = {")

                ' Write each item in format: [12345] = 12345, --Item Name
                For Each item In items
                    Dim itemId = item.ItemId
                    Dim itemName = item.Name.Replace("--", "-") ' Avoid breaking comments
                    writer.WriteLine(vbTab & $"[{itemId}] = {itemId}, --{itemName}")
                Next

                writer.WriteLine("}")
            End Using
        End Using

        Log.Information("ItemCache.lua generated successfully.")
    End Sub

    Public Sub GenerateLocalisationFiles()
        Log.Information("Generating localisation file...")

        Using db As New IATDbContext()
            Dim localisations = db.Localisations.ToList()

            ' Path to the localisation file
            Dim filePath = "C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua"

            Using writer As New StreamWriter(filePath, False)
                ' Header
                writer.WriteLine("local _, core = ...")
                writer.WriteLine("local baseLocale = {")

                ' Write each localisation key-value pair
                For Each locale In localisations
                    Dim safeKey = locale.Key.Replace("""", "\""")
                    Dim safeValue = locale.Value.Replace("""", "\""")
                    writer.WriteLine(vbTab & $"[""{safeKey}""] = ""{safeValue}"",")
                Next

                ' Close the table
                writer.WriteLine("}")
                ' Register the locale
                writer.WriteLine("core:RegisterLocale('enUS', baseLocale)")
            End Using
        End Using

        Log.Information("Localisation file generated successfully.")
    End Sub

    Private Function Indent(level As Integer) As String
        Return New String(vbTab, level)
    End Function

    Private Async Sub SaveTactics()
        Using db As New IATDbContext()
            For Each tab As TabPage In tcTactics.TabPages
                ' Extract tactic ID from tab name (e.g. "tactics-150")
                Dim idPart = tab.Text.Replace("Tactic-", "")
                ' Load tactic from DB with parameters and localisation
                Dim tactic As Tactic = Nothing
                If idPart.Length > 0 Then
                    tactic = db.Tactics.FirstOrDefault(Function(t) t.Id = idPart)
                End If

                ' If we are adding a new tactic
                Dim newTactic As Boolean = False
                If tactic Is Nothing Then
                    tactic = New Tactic()
                    db.Tactics.Add(tactic)
                    newTactic = True
                End If

                Dim webView = tab.Controls.OfType(Of WebView2).FirstOrDefault()
                If webView Is Nothing OrElse webView.CoreWebView2 Is Nothing Then Continue For

                ' Get the edited HTML content from WebView
                Dim js = "document.querySelector('body > div').innerHTML"
                Dim htmlRaw = Await webView.CoreWebView2.ExecuteScriptAsync(js)
                Dim html = System.Text.RegularExpressions.Regex.Unescape(htmlRaw.Trim(""""c))
                html = html.Replace("&nbsp;", " ")

                ' Decode back to original string with %s
                Dim cleanedText As String = html
                Dim newParams As New ObservableCollectionListSource(Of TacticParameter)

                ' Regex to match: <a href="npc:12345:pos:5" id="5">Name</a>
                Dim linkPattern As String = "<a[^>]+href=""(?<href>[^""]+)""[^>]*id=""(?<id>\d+)""[^>]*>(?<text>.*?)</a>"
                Dim matches = Regex.Matches(html, linkPattern)

                For Each match As Match In matches
                    Dim href = match.Groups("href").Value
                    Dim id = Integer.Parse(match.Groups("id").Value)

                    Dim parts = href.Split(":"c)
                    If parts.Length >= 3 Then
                        Dim type = parts(0).ToLower() ' npc or spell
                        Dim paramId = parts(1)

                        ' Replace this <a> tag with a %s
                        cleanedText = cleanedText.Replace(match.Value, "%s")

                        Dim parameterType As String

                        Select Case type.ToLowerInvariant()
                            Case "npc"
                                parameterType = "NPC"
                            Case "spell"
                                parameterType = "Spell"
                            Case "item"
                                parameterType = "Item"
                            Case Else
                                Throw New ArgumentException($"Unsupported parameter type: {type}")
                        End Select

                        Dim param As New TacticParameter With {
                                .Order = newParams.Count + 1, ' The order needs to start at 1 not 0 so increment each by one
                                .ParameterID = paramId,
                                .ParameterType = parameterType
                            }

                        If parameterType = "NPC" Then
                            ' Add NPC to the database if it doesn't exist
                            Dim npc = db.NPCs.FirstOrDefault(Function(n) n.NPCId = paramId)
                            param.NPC = npc
                        End If

                        ' Add the parameter to the new parameters list
                        newParams.Add(param)
                    End If
                Next

                ' Replace <br> with \n
                cleanedText = cleanedText.Replace("<br>", "\n")

                ' Clean up any excess newlines (more than 2 consecutive) to fix existing damage
                cleanedText = Regex.Replace(cleanedText, "\n{3,}", "\n\n")

                ' Remove left over <div>
                cleanedText = cleanedText.Replace("<div>", "")
                cleanedText = cleanedText.Replace("</div>", "")

                If newTactic Then
                    ' Ask for Expansion ID
                    Dim expansionId As Integer
                    Do
                        Dim input = InputBox("Enter expansion ID for new tactic:")
                        If Integer.TryParse(input, expansionId) Then Exit Do
                        MessageBox.Show("Please enter a valid integer for Expansion ID.")
                    Loop

                    tactic.ExpansionId = expansionId

                    ' Get the current boss
                    Dim selectedBoss As Boss = db.Bosses.Find(cboBosses.SelectedValue)

                    ' Construct initial key
                    Dim rawKey = $"{selectedBoss.Instance.Name}_{selectedBoss.BossName}_{TabIndex + 1}"

                    ' Remove all non-alphanumeric characters
                    Dim localeKey = Regex.Replace(rawKey, "[^a-zA-Z0-9_]", "")

                    ' Assign localisation
                    Dim localisation As New Localisation With {
                            .Key = localeKey,
                            .Value = cleanedText
                        }
                    tactic.Localisation = localisation
                    db.Localisations.Add(localisation)

                    ' Assign tactic parameters
                    tactic.TacticParameter = newParams

                    ' Assign boss
                    tactic.Boss = selectedBoss
                Else
                    ' Save updated values
                    tactic.Localisation.Value = cleanedText

                    ' Replace old parameters
                    db.TacticParameters.RemoveRange(tactic.TacticParameter)
                    tactic.TacticParameter = newParams
                End If
            Next

            db.SaveChanges()
        End Using
    End Sub

    Public Sub GenerateAddonDatabase(maxExpansions As Integer, Optional expansionSuffix As String = "")
        Log.Information("Generating addon database for expansions up to: {MaxExpansions} with expansion suffix {expansionSuffix}", maxExpansions, expansionSuffix)
        ' Connect to database
        Using db As New IATDbContext
            ' Get all expansions sorted by ExpansionGameId descending (highest first)
            Dim Expansions As List(Of Expansion) = db.Expansions.Where(Function(e) e.ExpansionGameId <= maxExpansions).OrderByDescending(Function(e) e.ExpansionGameId).ToList()

            ' Write new file
            Using writer As StreamWriter = New StreamWriter($"C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances{expansionSuffix}.lua")
                writer.WriteLine("--------------------------------------")
                writer.WriteLine("-- Last Auto Generated: " & DateTime.Now & " using https://github.com/Dragnogd/Instance-Achievement-Tracker-Database-Manager")
                writer.WriteLine("--------------------------------------")
                writer.WriteLine("local _, core = ...")
                writer.WriteLine("local L = core.L")
                writer.WriteLine("local instances = {}")
                writer.WriteLine()
                writer.WriteLine("core.Instances = {")

                Dim firstExpansion = False
                Dim firstInstance = False

                ' Loop through each expansion
                For Each expansion In Expansions

                    ' Seperate expansions with a new line
                    If firstExpansion = False Then
                        firstExpansion = True
                    Else
                        writer.WriteLine()
                    End If

                    ' Write expansion name
                    writer.WriteLine($"{Indent(1)}--{expansion.Name}")
                    ' Write expansion ID
                    writer.WriteLine($"{Indent(1)}[{expansion.ExpansionGameId}] = {{")

                    ' Loop through each instance type
                    For Each instancetype In expansion.InstanceTypes


                        ' Seperate instance types with a new line apart from raids as raids appear first in the table
                        If instancetype.Name <> "Raids" Then
                            writer.WriteLine()
                        End If

                        ' Write instance type name
                        writer.WriteLine($"{Indent(2)}{instancetype.Name} = {{")

                        ' Loop through each instance
                        For Each instance In instancetype.Instances
                            ' Check if instance is compatible with ExpansionAddedIn and ExpansionRemovedIn
                            If instance.ExpansionAddedIn <= maxExpansions And (instance.ExpansionRemovedIn = 0 Or instance.ExpansionRemovedIn > maxExpansions) Then
                                ' Seperate instances with a new line
                                If firstInstance = False Then
                                    firstInstance = True
                                Else
                                    writer.WriteLine()
                                End If

                                ' Write instance name
                                If instance.LegacySize > 0 Then
                                    ' Include legacy size as part of id
                                    writer.WriteLine($"{Indent(3)}[{instance.InstanceId}.{instance.LegacySize}] = {{ --{instance.Name}")
                                Else
                                    writer.WriteLine($"{Indent(3)}[{instance.InstanceId}] = {{ --{instance.Name}")
                                End If

                                ' Write wrath instance name if it exists and we are in wrath or cata or just raids for Mists
                                If instance.NameWrath IsNot Nothing AndAlso instance.NameWrath.Length > 1 AndAlso maxExpansions < 5 Then
                                    writer.WriteLine($"{Indent(4)}name = L[""{instance.NameWrath}""],")
                                Else
                                    If maxExpansions = 5 And instancetype.Name = "Raids" And instance.NameWrath IsNot Nothing AndAlso instance.NameWrath.Length > 1 Then
                                        writer.WriteLine($"{Indent(4)}name = L[""{instance.NameWrath}""],")
                                    Else
                                        writer.WriteLine($"{Indent(4)}name = {instance.InstanceNameID},")
                                    End If
                                End If

                                ' Loop through each boss in the instance
                                For Each boss In instance.Bosses

                                    ' Write boss order
                                    writer.WriteLine($"{Indent(4)}boss{boss.Order} = {{")

                                    ' Write boss name id
                                    If boss.BossNameID > 0 Then
                                        ' If we are on wrath, cata or mop (raids) then use the localised name
                                        ' Otherwise use the id as it is a retail boss
                                        If maxExpansions <= 5 Then
                                            If instance.ExpansionAddedIn = 3 Then
                                                writer.WriteLine($"{Indent(5)}name = L[""{boss.BossNameLocale}""], --{boss.BossName}")
                                            Else
                                                ' We have id for boss
                                                writer.WriteLine($"{Indent(5)}name = {boss.BossNameID}, --{boss.BossName}")
                                            End If
                                        Else
                                            ' We have id for boss
                                            writer.WriteLine($"{Indent(5)}name = {boss.BossNameID}, --{boss.BossName}")
                                        End If
                                    Else
                                        ' No id so use localised string
                                        writer.WriteLine($"{Indent(5)}name = L[""{boss.BossNameLocale}""], --{boss.BossName}")
                                    End If

                                    ' Write boss id's
                                    writer.WriteLine($"{Indent(5)}bossIDs = {boss.BossIDs},")

                                    ' Write achievement id
                                    writer.WriteLine($"{Indent(5)}achievement = {boss.AchievementID},")

                                    ' Write players
                                    writer.WriteLine($"{Indent(5)}players = {{}},")

                                    ' Write tactics
                                    If boss.Tactics.Count > 0 Then
                                        ' Write tactics header
                                        writer.WriteLine($"{Indent(5)}tactics = {{")

                                        ' Group tactics by their ExpansionId
                                        Dim groupedTactics = boss.Tactics.Where(Function(t) t.ExpansionId <= maxExpansions) _
                                                                         .GroupBy(Function(t) t.ExpansionId) _
                                                                         .OrderBy(Function(s) s.Key)

                                        ' Loop through each expansion group
                                        For Each group In groupedTactics
                                            ' Write expansion id header
                                            writer.WriteLine($"{Indent(6)}[{group.Key}] = {{")

                                            ' Loop through each tactic in the expansion group
                                            For Each tactic In group

                                                ' Get the tactic parameters and sort by Order
                                                Dim parameters As List(Of TacticParameter) = tactic.TacticParameter.OrderBy(Function(p) p.Order).ToList()
                                                Dim parameterList As New List(Of String)
                                                For Each param In parameters
                                                    Select Case param.ParameterType
                                                        Case "Spell"
                                                            parameterList.Add($"C_Spell.GetSpellLink({param.ParameterID})")
                                                        Case "NPC"
                                                            parameterList.Add($"""IAT_{param.ParameterID}""")
                                                    End Select
                                                Next

                                                ' Join the parameter list in a comma seperated string
                                                Dim parameterString = String.Join(", ", parameterList)

                                                ' If we have parameters then write format string
                                                ' Otherwise just write locale string
                                                If parameterList.Count > 0 Then
                                                    writer.WriteLine($"{Indent(7)}{{ tactic = format(L[""{tactic.Localisation.Key}""], {parameterString}) }},")
                                                Else
                                                    writer.WriteLine($"{Indent(7)}{{ tactic = L[""{tactic.Localisation.Key}""] }},")
                                                End If
                                            Next

                                            ' Close expansion group
                                            writer.WriteLine($"{Indent(6)}}},")
                                        Next

                                        ' Close tactics
                                        writer.WriteLine($"{Indent(5)}}},")
                                    Else
                                        ' Write the tactics localisation string
                                        writer.WriteLine($"{Indent(5)}tactics = L[""{boss.Tactics}""],")
                                    End If

                                    ' Write enabled state
                                    writer.WriteLine($"{Indent(5)}enabled = {boss.Enabled.ToString.ToLower()},")

                                    ' Write tracking function
                                    writer.WriteLine($"{Indent(5)}track = {boss.Track},")

                                    writer.WriteLine($"{Indent(5)}partial = {boss.PartialTrack.ToString.ToLower()},")

                                    If boss.EncounterID > 0 Then
                                        writer.WriteLine($"{Indent(5)}encounterID = {boss.EncounterID},")
                                    End If

                                    If boss.DisplayInfoFrame = "true" Then
                                        writer.WriteLine($"{Indent(5)}displayInfoFrame = {boss.DisplayInfoFrame.ToString.ToLower()},")
                                    End If

                                    If boss.BossNameLocale IsNot Nothing AndAlso boss.BossNameLocale.Length > 1 Then
                                        writer.WriteLine($"{Indent(5)}nameWrath = L[""{boss.BossNameLocale}""],")
                                    End If

                                    If boss.NotTrackableDueToRestrictions Then
                                        writer.WriteLine($"{Indent(5)}restrictions = true,")
                                    End If

                                    ' Close the boss table
                                    writer.WriteLine($"{Indent(4)}}},")

                                    'Check if localisation is new
                                    'Dim localeFound = False
                                    'For Each locale In LocalisationDB
                                    '    If boss.Tactics.Contains(locale.Name) Then
                                    '        localeFound = True
                                    '    End If
                                    'Next
                                    'If localeFound = False Then
                                    '    Dim newLocale As New Localisation
                                    '    newLocale.Name = boss.Tactics.Replace("L[""", "").Replace("""]", "")
                                    '    newLocale.Text = ""
                                    '    LocalisationDB.Add(newLocale)
                                    'End If
                                Next

                                ' Close the instance table
                                writer.WriteLine($"{Indent(3)}}},")
                            Else
                                Log.Information("Skipping instance {InstanceName} (ID: {InstanceId}) for expansion {ExpansionId} due to compatibility with max expansions ({MaxExpansions})", instance.Name, instance.InstanceId, instance.ExpansionAddedIn, maxExpansions)
                            End If
                        Next

                        ' Close the instance type table
                        writer.WriteLine($"{Indent(2)}}},")
                        firstInstance = False
                    Next

                    ' Close the expansion table
                    writer.WriteLine($"{Indent(1)}}},")
                Next

                ' Close table root
                writer.WriteLine("}")
            End Using
        End Using

        ' Log that save was succesffull
        Log.Information("Instances{expansionSuffix}.lua created", expansionSuffix)
    End Sub

    Private Async Sub btnUploadLocale_Click(sender As Object, e As EventArgs) Handles btnUploadLocale.Click
        LoadWebsite("https://www.curseforge.com/wow/addons/instance-achievement-tracker/localization/languages/92/phrases#0")

        Await Task.Delay(5000)

        Dim script = "document.querySelector('.button.create-phrase').click();"
        'WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        'Add Name
        'script = "document.getElementById('field-phrase-name').value =""" & txtLocaleString.Text.Replace("""", """""") & """"
        'WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        'Add Context
        'Dim context = txtContext.Text.Replace("""", "&quot").Replace("\n", "\\n")
        'script = "document.getElementById('field-phrase-context').value =""" & context & """"
        'WebView2.ExecuteScriptAsync(script)
        'Await Task.Delay(1000)
        'script = "document.getElementById('field-phrase-context').value = document.getElementById('field-phrase-context').value.split('&quot').join('""')"
        'WebView2.ExecuteScriptAsync(script)

        'Await Task.Delay(1000)

        ''Add String
        'Dim tacticslocale = txtTacticsLocale.Text.Replace("""", "&quot").Replace("\n", "\\n")
        'script = "document.getElementById('field-phrase-default-translation').value =""" & tacticslocale & """"
        'WebView2.ExecuteScriptAsync(script)
        'Await Task.Delay(1000)
        'script = "document.getElementById('field-phrase-default-translation').value = document.getElementById('field-phrase-default-translation').value.split('&quot').join('""')"
        'WebView2.ExecuteScriptAsync(script)

        'Await Task.Delay(1000)

        'GenerateAddonDatabase()
    End Sub

    Private Sub frmIATDatabaseManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' WebView2.Dispose()
    End Sub

    Private Sub SpellsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Insert Spells
        Using reader = New StreamReader("C:\Program Files (x86)\World of Warcraft\_retail_\WTF\Account\DRAGNOG657\SavedVariables\SpellDump.lua")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                If line.Contains("=") Then
                    Dim strArr = line.Split("=")
                    Dim NewSpell = New Spell
                    NewSpell.Name = strArr(1).Trim.Trim(",".ToCharArray).Trim("""".ToCharArray)
                    NewSpell.Id = strArr(0).Trim.Replace("[", "").Replace("]", "").Replace("""", "")

                    Using writer = New StreamWriter("SpellDB.csv", True)
                        writer.WriteLine(NewSpell.Name & ";" & NewSpell.Id)
                    End Using
                End If

                line = reader.ReadLine
            End While
        End Using
        MsgBox("Complete")
    End Sub

    Private Function GetItemName(ItemID)
        'Check if we have cached the spellId
        Using reader As StreamReader = New StreamReader("ItemIDS.csv")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                Dim strArr As String() = line.Split(",")
                If strArr(0) = ItemID Then
                    Return strArr(1)
                End If
                line = reader.ReadLine
            End While
        End Using

        'No info in cache, load website instead
        LoadWebsite("https://www.wowhead.com/item=" & ItemID)
        ResponsiveSleep(3000)
        Dim script = "document.getElementsByTagName('h1')[0].innerHTML;"
        'Dim result = WebView2.ExecuteScriptAsync(script)
        'ResponsiveSleep(2000)
        'Using writer As StreamWriter = New StreamWriter("ItemIDS.csv", True)
        '    writer.WriteLine(ItemID & "," & result.Result.Split("\u003")(0).Trim("""").Trim())
        'End Using
        'Return result.Result.Split("\u003")(0).Trim("""").Trim()
        'CheckingSpellName = True
    End Function

    Private Sub LocalisationManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocalisationManagerToolStripMenuItem.Click
        LocalisationImporter.Show()
        LocalisationImporter.Import()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        LoadWebsite("https://google.com")
    End Sub

    Public Function GetSpellName(spellId)
        'Check if we have cached the spellId
        Using reader As StreamReader = New StreamReader("SpellIDS.csv")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                Dim strArr As String() = line.Split(",")
                If strArr(0) = spellId Then
                    Return strArr(1)
                End If
                line = reader.ReadLine
            End While
        End Using

        'No info in cache, load website instead
        LoadWebsite("https://www.wowhead.com/spell=" & spellId)
        ResponsiveSleep(3000)
        Dim script = "document.getElementsByTagName('h1')[0].innerHTML;"
        'Dim result = WebView2.ExecuteScriptAsync(script)
        ResponsiveSleep(2000)
        Using writer As StreamWriter = New StreamWriter("SpellIDS.csv", True)
            'writer.WriteLine(spellId & "," & result.Result.Split("\u003")(0).Trim("""").Trim())
        End Using
        'Return result.Result.Split("\u003")(0).Trim("""").Trim()
        CheckingSpellName = True
    End Function

    'Private Sub dgvExpansions_SelectionChanged(sender As Object, e As EventArgs)
    '    Try
    '        If IATContext IsNot Nothing Then
    '            Dim expansion = CType(dgvExpansions.CurrentRow.DataBoundItem, Expansion)

    '            If expansion IsNot Nothing Then
    '                IATContext.Entry(expansion).Collection(Function(f) f.InstanceTypes).Load()
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub dgvInstanceTypes_SelectionChanged(sender As Object, e As EventArgs)
    '    Try
    '        If IATContext IsNot Nothing And dgvInstanceTypes.CurrentRow IsNot Nothing Then
    '            Dim instanceType = CType(dgvInstanceTypes.CurrentRow.DataBoundItem, InstanceType)

    '            If instanceType IsNot Nothing Then
    '                IATContext.Entry(instanceType).Collection(Function(f) f.Instances).Load()
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub dgvInstances_SelectionChanged(sender As Object, e As EventArgs)
    '    Try
    '        If IATContext IsNot Nothing And dgvInstances.CurrentRow IsNot Nothing Then
    '            Dim instance = CType(dgvInstances.CurrentRow.DataBoundItem, Instance)

    '            If instance IsNot Nothing Then
    '                IATContext.Entry(instance).Collection(Function(f) f.Bosses).Load()
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub dgvBosses_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
    '    Try
    '        If IATContext IsNot Nothing And dgvBosses.CurrentRow IsNot Nothing Then
    '            Dim boss = CType(dgvBosses.CurrentRow.DataBoundItem, Boss)

    '            If boss IsNot Nothing Then
    '                IATContext.Entry(boss).Collection(Function(f) f.Tactics).Load()
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Async Sub btnAddNewTactic_Click(sender As Object, e As EventArgs) Handles btnAddNewTactic.Click
        ' If we have a boss selected in the combobox
        If cboBosses.SelectedItem IsNot Nothing Then
            Dim selectedBoss = TryCast(cboBosses.SelectedItem, Boss)
            If selectedBoss IsNot Nothing Then
                ' Add new tab to tactics tabber
                Dim newTab As New TabPage("Tactic-")
                tcTactics.TabPages.Add(newTab)
                ' Create a new WebView2 control for the new tab
                Dim webView As New WebView2 With {
                    .Dock = DockStyle.Fill
                }
                newTab.Controls.Add(webView)
                ' Initialize WebView2 and navigate to a blank HTML page
                Await webView.EnsureCoreWebView2Async
                webView.NavigateToString("<html><body><div contenteditable='true'></div></body></html>")
                ' Add a handler for the navigation starting event to handle links
                AddHandler webView.CoreWebView2.NavigationStarting, Sub(sender2, e2)
                                                                        If e2.Uri.StartsWith("npc:") Then
                                                                            e2.Cancel = True
                                                                            ' Split the href into parts: "npc:12345:pos:3"
                                                                            Dim parts = e2.Uri.Substring("npc:".Length).Split(":"c)
                                                                            Dim npcId = parts(0)
                                                                            Dim positionInfo = If(parts.Length > 2, parts(2), Nothing)
                                                                            Dim selector As New EntitySelector With {
                                                                                .TypeToLoad = EntityType.NPC,
                                                                                .SelectedItemIndex = positionInfo
                                                                            }
                                                                            selector.Show()
                                                                        ElseIf e2.Uri.StartsWith("spell:") Then
                                                                            e2.Cancel = True
                                                                            ' Split the href into parts: "spell:12345:pos:3"
                                                                            Dim parts = e2.Uri.Substring("spell:".Length).Split(":"c)
                                                                            Dim spellId = parts(0)
                                                                            Dim positionInfo = If(parts.Length > 2, parts(2), Nothing)
                                                                            ' For example, assume positionInfo is the element ID suffix (e.g., 3)
                                                                            lastClickedElementId = positionInfo
                                                                            ' Open Spell Selector
                                                                            Dim selector As New EntitySelector With {
                                                                                .TypeToLoad = EntityType.Spell,
                                                                                .SelectedItemIndex = positionInfo
                                                                            }
                                                                            selector.Show()
                                                                        End If
                                                                    End Sub
                ' Set the new tab as the selected tab
                tcTactics.SelectedTab = newTab
            End If
        Else
            MessageBox.Show("Please select a boss first.")
        End If

    End Sub

    Private Sub chkEditTactics_CheckedChanged(sender As Object, e As EventArgs) Handles chkEditTactics.CheckedChanged
        ' Get the selected tab's WebView2
        Dim currentTab = tcTactics.SelectedTab
        If currentTab Is Nothing Then Exit Sub

        Dim webView = currentTab.Controls.OfType(Of Microsoft.Web.WebView2.WinForms.WebView2).FirstOrDefault()
        If webView Is Nothing OrElse webView.CoreWebView2 Is Nothing Then Exit Sub

        ' Toggle contenteditable on the div
        Dim isEditable As Boolean = chkEditTactics.Checked
        Dim js As String = $"document.querySelector('body > div').setAttribute('contenteditable', '{isEditable.ToString().ToLower()}');"

        webView.CoreWebView2.ExecuteScriptAsync(js)
    End Sub

    Private Sub btnInsertNPC_Click(sender As Object, e As EventArgs) Handles btnInsertNPC.Click
        Dim selector As New EntitySelector With {
            .TypeToLoad = EntityType.NPC
        }
        selector.Show()

        ' Set wowhead to correct search page
        selector.wvBrowser.Source = New Uri("https://www.wowhead.com/npcs")

        ' Make the search box the default focus
        selector.txtSearch.Select()
    End Sub

    Private Sub btnInsertSpell_Click(sender As Object, e As EventArgs) Handles btnInsertSpell.Click
        Dim selector As New EntitySelector With {
        .TypeToLoad = EntityType.Spell
            }
        selector.Show()

        ' Set wowhead to correct search page
        selector.wvBrowser.Source = New Uri("https://www.wowhead.com/spells")

        ' Make the search box the default focus
        selector.txtSearch.Select()
    End Sub

    Private Sub btnInsertItem_Click(sender As Object, e As EventArgs) Handles btnInsertItem.Click
        Dim selector As New EntitySelector With {
        .TypeToLoad = EntityType.Item
            }
        selector.Show()

        ' Set wowhead to correct search page
        selector.wvBrowser.Source = New Uri("https://www.wowhead.com/items")

        ' Make the search box the default focus
        selector.txtSearch.Select()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()
    End Sub

    Private Sub LocalisationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocalisationsToolStripMenuItem.Click
        LocalisationTable.Show()
    End Sub

    Private Async Sub btnPullLocalisation_Click(sender As Object, e As EventArgs) Handles btnPullLocalisation.Click
        'Import Localisation from CurseForge for enUS
        Await ImportLocalisationFromCurseforge()

        ' Import translations for other languages
        Dim languages As String() = {"frFR", "deDE", "esES", "ruRU", "esMX", "zhCN", "zhTW", "ptBR", "koKR"}
        For Each lang In languages
            Try
                Await ImportTranslationFromCurseforge(lang)
            Catch ex As Exception
                Log.Error(ex, "Failed to import translation for {Lang}", lang)
            End Try
        Next
    End Sub

    Private Sub BrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowserToolStripMenuItem.Click
        Browser.Show()
    End Sub

    Private Sub btnEditBoss_Click(sender As Object, e As EventArgs) Handles btnEditBoss.Click
        Dim selectedBoss As Boss = TryCast(cboBosses.SelectedItem, Boss)
        If selectedBoss IsNot Nothing Then
            InsertBoss.LoadBossForEdit(selectedBoss.Id)
            InsertBoss.Show()
        Else
            MessageBox.Show("Please select a boss to edit.", "No Boss Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
