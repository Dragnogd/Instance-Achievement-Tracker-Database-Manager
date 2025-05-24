Imports System.Data
Imports System.IO
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Imgur.API.Authentication
Imports Imgur.API.Endpoints
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking


Public Class frmIATDatabaseManager
    Public CentralDB As New List(Of Expansion)
    Public LocalisationDB As New List(Of Localisation)
    Public NPCDB As New List(Of NPC)
    Public SpellDB As New List(Of Spell)
    Public NPCTable = New DataTable
    Public BossesTable As DataTable = New DataTable
    Public SpellTable = New DataTable
    Public NPCCacheDB = New List(Of NPCCache)
    Public NPCCacheClassicDB = New List(Of NPCCache)
    Public ItemCacheDB = New List(Of ItemCache)
    Public CurrentSite = Nothing
    Public PreviousSites As New List(Of String)
    Public CheckingSpellName = False

    Private IATContext As IATDbContext

    Private Sub InitialiseDatabase()
        Using db As New IATDbContext
            db.Database.EnsureDeleted()
            db.Database.EnsureCreated()
        End Using
    End Sub

    Private Sub frmIATDatabaseManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make sure SQLite Database is created
        InitialiseDatabase()

        Dim splash As SplashScreen1 = CType(My.Application.SplashScreen, SplashScreen1)

        ' Load Localisation
        splash.UpdateProgress("Loading Localisation (0/13)", 1)
        ImportLocalisation()

        ' Import NPC Cache
        ImportNPCCache()

        ' Load Translations
        splash.UpdateProgress("Loading Translations (0/13)", 1)
        Dim languageFiles As String() = {"Localization.frFR.lua", "Localization.deDE.lua", "Localization.esES.lua", "Localization.ruRU.lua", "Localization.esMX.lua", "Localization.zhCN.lua", "Localization.zhTW.lua", "Localization.ptBR.lua", "Localization.koKR.lua"}
        Dim languageCodes As String() = {"frFR", "deDE", "esES", "ruRU", "esMX", "zhCN", "zhTW", "ptBR", "koKR"}
        For i As Integer = 0 To languageFiles.Length - 1
            Dim filePath As String = Path.Combine("C:\Users\ryanc\Dropbox\InstanceAchievementTracker", languageFiles(i))
            If File.Exists(filePath) Then
                ImportTranslations(filePath, languageCodes(i))
            End If
        Next

        splash.UpdateProgress("Loading Expansions (1/13)", 2)
        'Insert Expansions
        ImportExpansions()

        splash.UpdateProgress("Loading Instance Types (2/13)", 3)
        'Insert InstanceTypes
        ImportInstanceTypes()

        splash.UpdateProgress("Loading Instances (3/13)", 4)
        'Insert Instances
        ImportInstances()

        splash.UpdateProgress("Loading Bosses (4/13)", 5)
        'Insert Bosses
        ImportBosses()

        ' Setup Data Grid Views
        IATContext = New IATDbContext()
        IATContext.Expansions.Load()
        ExpansionBindingSource.DataSource = IATContext.Expansions.Local.ToBindingList()

        'Using db As New IATDbContext
        '    Dim expansions = db.Expansions.ToList()
        '    Dim instances = db.Instances.ToList()
        '    Dim instanceTypes = db.InstanceTypes.ToList()
        '    Dim bosses = db.Bosses.ToList()

        '    ' Create a BindingSource for expansions and bind it to a DataGridView
        '    Dim bindingSource As New BindingSource()
        '    bindingSource.DataSource = expansions
        '    dgvExpansions.DataSource = bindingSource

        '    ' Create a BindingSource for instanceTypes and bind it to a DataGridView
        '    bindingSource = New BindingSource()
        '    bindingSource.DataSource = instanceTypes
        '    dgvInstanceTypes.DataSource = bindingSource

        '    ' Create a BindingSource for instances and bind it to a DataGridView
        '    bindingSource = New BindingSource()
        '    bindingSource.DataSource = instances
        '    dgvInstances.DataSource = bindingSource

        '    ' Create a BindingSource for bosses and bind it to a DataGridView
        '    bindingSource = New BindingSource()
        '    bindingSource.DataSource = bosses
        '    dgvBosses.DataSource = bindingSource
        'End Using

        'splash.UpdateProgress("Populating Bosses (6/13)", 6)
        'cboBosses.DataSource = BossesTable
        'cboBosses.DisplayMember = "BossName"
        'cboBosses.ValueMember = "AchievementID"

        'splash.UpdateProgress("Loading Localisation (7/13)", 7)
        ''Insert Localisation
        'If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua") Then
        '    Try
        '        File.Delete("Localization.enUS.lua")
        '        File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua", "Localization.enUS.lua")
        '    Catch ex As Exception

        '    End Try
        'End If
        'Using reader As StreamReader = New StreamReader("Localization.enUS.lua")
        '    Dim line = reader.ReadLine

        '    While Not line Is Nothing
        '        If line.Contains("] =") And line.Contains("[""") Then
        '            Dim regex As Regex = New Regex("\[(.*?)\]")
        '            Dim match As Match = regex.Match(line)
        '            Dim Locale = match.Value.Trim("[".ToCharArray()).Trim("]".ToCharArray())

        '            For Each expansion In CentralDB
        '                For Each instancetype In expansion.InstanceTypes
        '                    For Each instance In instancetype.Instances
        '                        For Each boss In instance.Bosses
        '                            If boss.Tactics.Contains(Locale) Then
        '                                boss.LocaleText = line.Split("=")(1).Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
        '                                boss.LocaleName = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")
        '                            End If
        '                            If boss.ClassicTactics.Contains(Locale) Then
        '                                boss.LocaleTextClassic = line.Split("=")(1).Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
        '                                boss.LocaleNameClassic = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")
        '                            End If
        '                        Next
        '                    Next
        '                Next
        '            Next

        '            Dim NewLocalisation = New Localisation
        '            NewLocalisation.Text = line.Split("=")(1).Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
        '            NewLocalisation.Name = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")
        '            LocalisationDB.Add(NewLocalisation)
        '        End If
        '        line = reader.ReadLine
        '    End While
        'End Using

        'splash.UpdateProgress("Populating Expansions & Instances (8/13)", 8)
        'For Each expansion In CentralDB
        '    cboExpansions.Items.Add(expansion.Name)
        '    For Each instancetype In expansion.InstanceTypes
        '        For Each instance In instancetype.Instances
        '            cboInstances.Items.Add(instance.Name)
        '            For Each boss In instance.Bosses
        '                'cboBosses.Items.Add(boss.BossName)
        '            Next
        '        Next
        '    Next
        'Next

        'splash.UpdateProgress("Loading NPC Data (9/13)", 9)
        ''Insert NPC's
        'lines = IO.File.ReadAllLines("NPCDB.csv")
        'NPCTable.Columns.Add(New DataColumn("ID", GetType(String)))
        'NPCTable.Columns.Add(New DataColumn("Name", GetType(String)))
        'Dim Count = 0
        'For Each line In lines
        '    If line.Contains(";") Then
        '        Dim strArr() As String = line.Split(";")
        '        Dim NewNPC = New NPC
        '        NewNPC.Name = strArr(1)
        '        NewNPC.ID = strArr(0)
        '        NPCDB.Add(NewNPC)
        '        Dim R As DataRow = NPCTable.NewRow
        '        R("Name") = NewNPC.Name
        '        R("ID") = NewNPC.ID
        '        NPCTable.Rows.Add(R)
        '    End If
        '    Count += 1
        'Next
        'Console.WriteLine("Loaded " & Count & " NPC's")

        'splash.UpdateProgress("Populating NPC's (10/13)", 10)
        'cboNPC.DataSource = NPCTable
        'cboNPC.DisplayMember = "Name"
        'cboNPC.ValueMember = "ID"

        'splash.UpdateProgress("Loading NPC Cache (13/13)", 13)
        ''Insert NPCCache
        'If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua") Then
        '    Try
        '        File.Delete("NPCCache.lua")
        '        File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua", "NPCCache.lua")
        '    Catch ex As Exception

        '    End Try
        'End If
        'Using reader As StreamReader = New StreamReader("NPCCache.lua")
        '    Dim line = reader.ReadLine
        '    Dim NpcCacheType = "Retail"

        '    While Not line Is Nothing
        '        If line.Contains("core.NPCCacheClassic = {") Then
        '            NpcCacheType = "Classic"
        '        End If
        '        If line.Contains("] =") Then
        '            Dim NewNPCCache = New NPCCache
        '            NewNPCCache.Name = line.Split("=")(1).Split(",")(1).Replace("--", "").Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
        '            NewNPCCache.ID = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")

        '            If NpcCacheType = "Retail" Then
        '                NPCCacheDB.Add(NewNPCCache)
        '            ElseIf NpcCacheType = "Classic" Then
        '                NPCCacheClassicDB.add(NewNPCCache)
        '            End If
        '        End If
        '        line = reader.ReadLine
        '    End While
        'End Using

        'splash.UpdateProgress("Loading Item Cache (14/13)", 13)
        ''Insert ItemCache
        'If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua") Then
        '    Try
        '        File.Delete("ItemCache.lua")
        '        File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua", "ItemCache.lua")
        '    Catch ex As Exception

        '    End Try
        'End If
        'Using reader As StreamReader = New StreamReader("ItemCache.lua")
        '    Dim line = reader.ReadLine

        '    While Not line Is Nothing
        '        If line.Contains("] =") Then
        '            Dim NewItemCache = New ItemCache
        '            NewItemCache.Name = line.Split("=")(1).Split(",")(1).Replace("--", "").Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
        '            NewItemCache.ID = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")
        '            ItemCacheDB.Add(NewItemCache)
        '        End If
        '        line = reader.ReadLine
        '    End While
        'End Using

        'Me.WindowState = WindowState.Maximized
    End Sub

    Private Sub ExpansionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpansionToolStripMenuItem.Click
        InsertExpansion.Show()
    End Sub

    Private Sub InstanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstanceToolStripMenuItem.Click
        InsertInstance.Show()
    End Sub

    Private Sub BossToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BossToolStripMenuItem.Click
        InsertBoss.Show()
    End Sub

    Private Sub cboBosses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBosses.SelectedIndexChanged
        Try
            Console.WriteLine(cboBosses.Text.ToString())
            Console.WriteLine(cboBosses.SelectedValue)

            'For Each expansion In CentralDB
            '    For Each instancetype In expansion.InstanceTypes
            '        For Each instance In instancetype.Instances
            '            For Each boss In instance.Bosses
            '                If cboBosses.SelectedValue = boss.AchievementID Then
            '                    txtIndex.Text = boss.Order
            '                    txtAchievement.Text = boss.AchievementID
            '                    txtBossIDs.Text = boss.BossIDs
            '                    txtBossName.Text = boss.BossName
            '                    txtEnabled.Text = boss.Enabled
            '                    txtEncounterID.Text = boss.EncounterID
            '                    txtIndex.Text = boss.Order
            '                    txtInfoFrame.Text = boss.DisplayInfoFrame
            '                    txtNameID.Text = boss.BossNameID
            '                    txtPartial.Text = boss.PartialTrack
            '                    txtPlayers.Text = boss.Players
            '                    txtTactics.Text = boss.Tactics
            '                    txtTrack.Text = boss.Track
            '                    txtInstanceID.Text = instance.InstanceID
            '                    txtInstanceName.Text = instance.Name
            '                    txtInstanceNameWrath.Text = instance.NameWrath
            '                    txtInstanceNameID.Text = instance.InstanceNameID
            '                    txtInstanceType.Text = instancetype.Name
            '                    txtExpansion.Text = expansion.Name
            '                    txtExpansionID.Text = expansion.ExpansionGameId
            '                    txtTacticsLocale.Text = boss.LocaleText
            '                    txtLocaleString.Text = boss.LocaleName
            '                    txtNewTactics.Text = ""
            '                    txtInGame.Text = ""
            '                    txtImgurLink.Text = boss.ImgurLink
            '                    txtContext.Text = ""
            '                    txtImage.Text = boss.Image

            '                    'Classic
            '                    txtBossNameWrath.Text = boss.BossNameWrath
            '                    txtInGameClassic.Text = ""
            '                    txtNewTacticsClassic.Text = ""
            '                    txtTacticsLocaleClassic.Text = boss.LocaleTextClassic
            '                    txtClassicTactics.Text = boss.ClassicTactics
            '                    txtClassicPhase.Text = instance.ClassicPhase
            '                    txtRetailOnly.Text = instance.RetailOnly
            '                    txtClassicOnly.Text = instance.ClassicOnly
            '                    txtLocaleStringClassic.Text = boss.LocaleNameClassic
            '                    txtImgurLinkClassic.Text = boss.ImgurLinkClassic
            '                    txtEncounterIDWrath.Text = boss.EncounterIDWrath

            '                    'Populate NewTactics by reading format string
            '                    Dim Items As New List(Of String)
            '                    Dim ItemsID As New List(Of String)
            '                    Dim ItemType As New List(Of String)
            '                    If boss.Tactics.Contains("format(") Then
            '                        Dim strArr() As String = boss.Tactics.Split(",")
            '                        For Each item In strArr
            '                            If item.Contains("IAT_") Then
            '                                'NPC Found
            '                                Dim npcID As String = item.Replace("""", "").Replace("IAT_", "").Trim().Replace(")", "")
            '                                For Each npc In NPCDB
            '                                    If npc.ID = npcID Then
            '                                        Items.Add(npc.Name)
            '                                        ItemsID.Add(npc.ID)
            '                                        ItemType.Add("NPC")
            '                                    End If
            '                                Next
            '                            ElseIf item.Contains("C_Spell.GetSpellLink") Then
            '                                Dim spellID As String = item.Replace("C_Spell.GetSpellLink(", "").Replace(")", "").Trim()
            '                                Items.Add(GetSpellName(spellID))
            '                                ItemsID.Add(spellID)
            '                                ItemType.Add("Spell")
            '                            End If
            '                        Next

            '                        Dim PercentFound = False
            '                        Dim ListIndex = 0
            '                        For Each c As Char In boss.LocaleText
            '                            If PercentFound Then
            '                                If c = "s" Then
            '                                    'Insert from list
            '                                    If ItemType(ListIndex) = "NPC" Then
            '                                        txtNewTactics.Text += "{" & ItemsID(ListIndex) & "|" & Items(ListIndex) & "}"
            '                                    ElseIf ItemType(ListIndex) = "Spell" Then
            '                                        txtNewTactics.Text += "[" & ItemsID(ListIndex) & "|" & Items(ListIndex) & "]"
            '                                    End If
            '                                    ListIndex += 1
            '                                Else
            '                                    txtNewTactics.Text += "%%"
            '                                End If
            '                                PercentFound = False
            '                            ElseIf c = "%" And PercentFound = False Then
            '                                PercentFound = True
            '                            Else
            '                                txtNewTactics.Text += c
            '                            End If
            '                            Application.DoEvents()
            '                        Next
            '                    End If

            '                    'Populate Classic Tactics
            '                    Items = New List(Of String)
            '                    ItemsID = New List(Of String)
            '                    ItemType = New List(Of String)
            '                    If boss.ClassicTactics.Contains("format(") Then
            '                        Dim strArr() As String = boss.ClassicTactics.Split(",")
            '                        For Each item In strArr
            '                            If item.Contains("IAT_") Then
            '                                'NPC Found
            '                                Dim npcID As String = item.Replace("""", "").Replace("IAT_", "").Trim().Replace(")", "")
            '                                For Each npc In NPCDB
            '                                    If npc.ID = npcID Then
            '                                        Items.Add(npc.Name)
            '                                        ItemsID.Add(npc.ID)
            '                                        ItemType.Add("NPC")
            '                                    End If
            '                                Next
            '                            ElseIf item.Contains("C_Spell.GetSpellLink") Then
            '                                Dim spellID As String = item.Replace("C_Spell.GetSpellLink(", "").Replace(")", "").Trim()
            '                                Items.Add(GetSpellName(spellID))
            '                                ItemsID.Add(spellID)
            '                                ItemType.Add("Spell")
            '                            End If
            '                        Next

            '                        Dim PercentFound = False
            '                        Dim ListIndex = 0

            '                        If boss.LocaleTextClassic = Nothing Then
            '                            Dim localeTextC = InputBox("Please enter Locale Text Classic")
            '                            boss.LocaleTextClassic = localeTextC
            '                            txtTacticsLocaleClassic.Text = localeTextC
            '                        End If

            '                        For Each c As Char In boss.LocaleTextClassic
            '                            If PercentFound Then
            '                                If c = "s" Then
            '                                    'Insert from list
            '                                    If ItemType(ListIndex) = "NPC" Then
            '                                        txtNewTacticsClassic.Text += "{" & ItemsID(ListIndex) & "|" & Items(ListIndex) & "}"
            '                                    ElseIf ItemType(ListIndex) = "Spell" Then
            '                                        txtNewTacticsClassic.Text += "[" & ItemsID(ListIndex) & "|" & Items(ListIndex) & "]"
            '                                    End If
            '                                    ListIndex += 1
            '                                Else
            '                                    txtNewTacticsClassic.Text += "%%"
            '                                End If
            '                                PercentFound = False
            '                            ElseIf c = "%" And PercentFound = False Then
            '                                PercentFound = True
            '                            Else
            '                                txtNewTacticsClassic.Text += c
            '                            End If
            '                            Application.DoEvents()
            '                        Next
            '                    End If
            '                End If
            '            Next
            '        Next
            '    Next
            'Next

            ' LoadWebsite("https://www.wowhead.com/achievement=" & txtAchievement.Text & "#comments")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboNPC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNPC.SelectedIndexChanged
        Try
            Console.WriteLine(cboNPC.Text.ToString())
            Console.WriteLine(cboNPC.SelectedValue)

            Clipboard.SetText("{" & cboNPC.SelectedValue & "|" & cboNPC.Text.ToString() & "}")
            LoadWebsite("https://wowhead.com/npc=" & cboNPC.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub btnGenerateLocalisation_Click(sender As Object, e As EventArgs) Handles btnGenerateLocalisation.Click
        'txtTacticsLocale.Text = ""
        'txtTactics.Text = ""

        'Dim NPCName = ""
        'Dim InsideNPC = False
        'Dim InsideSpell = False
        'Dim SpellName = ""
        'Dim FormatStarted = False
        'Dim WebpageString = ""
        'Dim StopString = False
        'Dim NewLineFound = False
        'For Each c As Char In txtNewTactics.Text
        '    If c = "{" Then
        '        'Start of NPC name
        '        InsideNPC = True
        '    ElseIf c = "}" Then
        '        'End of NPC name
        '        For Each NPC In NPCDB
        '            If NPC.ID = NPCName Then
        '                txtTacticsLocale.Text += "%s"
        '                WebpageString += NPC.Name

        '                'Add to cache if needed
        '                Dim foundNPC = False
        '                For Each npc2 As NPCCache In NPCCacheDB
        '                    If npc2.ID = NPC.ID Then
        '                        foundNPC = True
        '                    End If
        '                Next

        '                If foundNPC = False Then
        '                    Dim NewNPC = New NPCCache
        '                    NewNPC.Name = NPC.Name
        '                    NewNPC.ID = NPC.ID
        '                    NPCCacheDB.add(NewNPC)
        '                    Console.WriteLine("Added: " & NPC.Name)
        '                End If

        '                If FormatStarted = False Then
        '                    FormatStarted = True
        '                    txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], ""IAT_" & NPC.ID & """"
        '                    Exit For
        '                Else
        '                    txtTactics.Text += ", ""IAT_" & NPC.ID & """"
        '                    Exit For
        '                End If
        '            End If
        '        Next

        '        InsideNPC = False
        '        NPCName = ""
        '        StopString = False
        '    ElseIf c = "|" Then
        '        StopString = True
        '    ElseIf c = "[" Then
        '        'Start of Spell name
        '        InsideSpell = True
        '    ElseIf c = "]" Then
        '        'End of spell/item name
        '        txtTacticsLocale.Text += "%s"

        '        If SpellName.Contains("ITEM_") Then
        '            Dim ItemID = SpellName.Replace("ITEM_", "")
        '            WebpageString += "[" & GetItemName(ItemID) & "]"

        '            If FormatStarted = False Then
        '                FormatStarted = True
        '                txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], ""IAT_" & ItemID & """"
        '                'Exit For
        '            Else
        '                txtTactics.Text += ", ""IAT_" & ItemID & """"
        '                'Exit For
        '            End If
        '        Else
        '            WebpageString += "[" & GetSpellName(SpellName) & "]"

        '            If FormatStarted = False Then
        '                FormatStarted = True
        '                txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], C_Spell.GetSpellLink(" & SpellName & ")"
        '                'Exit For
        '            Else
        '                txtTactics.Text += ", C_Spell.GetSpellLink(" & SpellName & ")"
        '                'Exit For
        '            End If
        '        End If

        '        InsideSpell = False
        '        SpellName = ""
        '        StopString = False
        '    ElseIf InsideSpell Then
        '        If StopString = False Then
        '            SpellName += c
        '        End If
        '    ElseIf InsideNPC Then
        '        If StopString = False Then
        '            NPCName += c
        '        End If
        '    ElseIf c = "\" Then
        '        NewLineFound = True
        '    ElseIf NewLineFound Then
        '        If c = "n" Then
        '            txtTacticsLocale.Text += "\n"
        '            WebpageString += vbNewLine
        '            NewLineFound = False
        '        End If
        '    Else
        '        txtTacticsLocale.Text += c
        '        WebpageString += c
        '    End If
        'Next
        'If FormatStarted Then
        '    txtTactics.Text += ")"
        'Else
        '    txtTactics.Text = "L[""" & txtLocaleString.Text & """]"
        'End If

        'txtInGame.Text = WebpageString.Replace("%%", "%")

        'Dim bmp As Bitmap = New Bitmap(txtInGame.Width, txtInGame.Height)
        'txtInGame.DrawToBitmap(bmp, New Rectangle(0, 0, txtInGame.Width, txtInGame.Height))
        'bmp.Save("Screenshots/" & txtBossName.Text & ".jpg")

        'Await Task.Delay(2000)

        'Dim apiClient = New ApiClient("3c704f8deefd409", "82cf43f64495b192b1083ed8a59e30139bd4d797")
        'Dim httpClient = New HttpClient()
        'Dim oAuth2Endpoint = New OAuth2Endpoint(apiClient, httpClient)
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

    Private Async Sub btnGenerateLocalisationClassic_Click(sender As Object, e As EventArgs) Handles btnGenerateLocalisationClassic.Click
        'txtTacticsLocaleClassic.Text = ""
        'txtClassicTactics.Text = ""

        'Dim NPCName = ""
        'Dim InsideNPC = False
        'Dim InsideSpell = False
        'Dim SpellName = ""
        'Dim FormatStarted = False
        'Dim WebpageString = ""
        'Dim StopString = False
        'Dim NewLineFound = False
        'For Each c As Char In txtNewTacticsClassic.Text
        '    If c = "{" Then
        '        'Start of NPC name
        '        InsideNPC = True
        '    ElseIf c = "}" Then
        '        'End of NPC name
        '        For Each NPC In NPCDB
        '            If NPC.ID = NPCName Then
        '                txtTacticsLocaleClassic.Text += "%s"
        '                WebpageString += NPC.Name

        '                'Add to cache if needed
        '                Dim foundNPC = False
        '                For Each npc2 As NPCCache In NPCCacheClassicDB
        '                    If npc2.ID = NPC.ID Then
        '                        foundNPC = True
        '                    End If
        '                Next

        '                If foundNPC = False Then
        '                    Dim NewNPC = New NPCCache
        '                    NewNPC.Name = NPC.Name
        '                    NewNPC.ID = NPC.ID
        '                    NPCCacheClassicDB.add(NewNPC)
        '                    Console.WriteLine("Added: " & NPC.Name)
        '                End If

        '                If FormatStarted = False Then
        '                    FormatStarted = True
        '                    txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], ""IAT_" & NPC.ID & """"
        '                    Exit For
        '                Else
        '                    txtClassicTactics.Text += ", ""IAT_" & NPC.ID & """"
        '                    Exit For
        '                End If
        '            End If
        '        Next

        '        InsideNPC = False
        '        NPCName = ""
        '        StopString = False
        '    ElseIf c = "|" Then
        '        StopString = True
        '    ElseIf c = "[" Then
        '        'Start of Spell name
        '        InsideSpell = True
        '    ElseIf c = "]" Then
        '        'End of spell/item name
        '        txtTacticsLocaleClassic.Text += "%s"

        '        If SpellName.Contains("ITEM_") Then
        '            Dim ItemID = SpellName.Replace("ITEM_", "")
        '            WebpageString += "[" & GetItemName(ItemID) & "]"

        '            If FormatStarted = False Then
        '                FormatStarted = True
        '                txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], ""IAT_" & ItemID & """"
        '                'Exit For
        '            Else
        '                txtClassicTactics.Text += ", ""IAT_" & ItemID & """"
        '                'Exit For
        '            End If
        '        Else
        '            WebpageString += "[" & GetSpellName(SpellName) & "]"

        '            If FormatStarted = False Then
        '                FormatStarted = True
        '                txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], C_Spell.GetSpellLink(" & SpellName & ")"
        '                'Exit For
        '            Else
        '                txtClassicTactics.Text += ", C_Spell.GetSpellLink(" & SpellName & ")"
        '                'Exit For
        '            End If
        '        End If

        '        InsideSpell = False
        '        SpellName = ""
        '        StopString = False
        '    ElseIf InsideSpell Then
        '        If StopString = False Then
        '            SpellName += c
        '        End If
        '    ElseIf InsideNPC Then
        '        If StopString = False Then
        '            NPCName += c
        '        End If
        '    ElseIf c = "\" Then
        '        NewLineFound = True
        '    ElseIf NewLineFound Then
        '        If c = "n" Then
        '            txtTacticsLocaleClassic.Text += "\n"
        '            WebpageString += vbNewLine
        '            NewLineFound = False
        '        End If
        '    Else
        '        txtTacticsLocaleClassic.Text += c
        '        WebpageString += c
        '    End If
        'Next
        'If FormatStarted Then
        '    txtClassicTactics.Text += ")"
        'Else
        '    txtClassicTactics.Text = "L[""" & txtLocaleStringClassic.Text & """]"
        'End If

        'txtInGameClassic.Text = WebpageString.Replace("%%", "%")

        'Dim bmp As Bitmap = New Bitmap(txtInGameClassic.Width, txtInGameClassic.Height)
        'txtInGameClassic.DrawToBitmap(bmp, New Rectangle(0, 0, txtInGameClassic.Width, txtInGameClassic.Height))
        'bmp.Save("Screenshots/" & txtBossName.Text & "_Classic.jpg")

        'Await Task.Delay(2000)

        'If My.Settings.ImgurClient Is Nothing OrElse My.Settings.ImgurClient.Length < 1 Then
        '    Dim clientID As String = InputBox("Enter Client ID")
        '    My.Settings.ImgurClient = clientID
        '    My.Settings.Save()
        'End If

        'If My.Settings.ImgurSecret Is Nothing OrElse My.Settings.ImgurSecret.Length = 0 Then
        '    Dim secret As String = InputBox("Enter Imgur Secret")
        '    My.Settings.ImgurSecret = secret
        '    My.Settings.Save()
        'End If

        'Dim apiClient = New ApiClient(My.Settings.ImgurClient, My.Settings.ImgurSecret)
        'Dim httpClient = New HttpClient()
        'Dim oAuth2Endpoint = New OAuth2Endpoint(apiClient, httpClient)
        ''Dim authUrl = oAuth2Endpoint.GetAuthorizationUrl()

        'Dim filePath = "Screenshots/" & txtBossName.Text & "_Classic.jpg"
        'Using FileStream = File.OpenRead(filePath)
        '    Dim imageEndpoint = New ImageEndpoint(apiClient, httpClient)
        '    Dim imageUpload = Await imageEndpoint.UploadImageAsync(FileStream)
        '    txtImgurLinkClassic.Text = "https://imgur.com/" & imageUpload.Id
        '    txtContextClassic.Text = "*** Notes *** Please don't remove the %s strings or ""\n"" as these refer to names of spells/ npc's in the game or new lines. They can be moved around in the sentence however if that makes more sense in your language.English Text:" & txtImgurLink.Text
        '    LoadWebsite(txtImgurLinkClassic.Text)
        'End Using
    End Sub

    Private Sub btnInsertTactic_Click(sender As Object, e As EventArgs) Handles btnInsertTactic.Click
        ' Retail DB
        save(11)
        ' Wrath DB
        save(3, "Wrath")
        ' Cataclysm DB
        save(4, "Cataclysm")
        ' Mop DB
        save(5, "Pandaria")
    End Sub

    Private Function Indent(level As Integer) As String
        Return New String(vbTab, level)
    End Function

    Public Sub save(maxExpansions As Integer, Optional expansionSuffix As String = "")
        'Save changes to DB

        ' Connect to database
        Using db As New IATDbContext
            ' Get all expansions
            Dim Expansions As List(Of Expansion) = db.Expansions.Where(Function(e) e.ExpansionGameId <= maxExpansions).ToList()

            ' Backup File
            'File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances.lua", "Backup\Instances.lua" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
            'If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances.lua") = True Then
            '    File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances.lua")
            'End If

            ' StringBuilder to store Instances.lua content
            Dim sb As New Text.StringBuilder()

            ' Write new file
            Using writer As StreamWriter = New StreamWriter($"C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances{expansionSuffix}.lua", True)
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

                            ' Write instance ID
                            writer.WriteLine($"{Indent(4)}name = {instance.InstanceNameID},")

                            ' Write wrath instance name if it exists
                            If instance.NameWrath IsNot Nothing AndAlso instance.NameWrath.Length > 1 Then
                                writer.WriteLine($"{Indent(4)}nameLocalised = L[""{instance.NameWrath}""],")
                            End If

                            ' Classic only variables
                            If expansion.ExpansionGameId = 3 Or expansion.ExpansionGameId = 4 Then

                                ' Write which classic phase we are in for classic wow instances
                                If instance.ClassicPhase IsNot Nothing Then
                                    writer.WriteLine($"{Indent(4)}classicPhase = {instance.ClassicPhase},")
                                Else
                                    ' Default to phase 1 if not set
                                    writer.WriteLine($"{Indent(4)}classicPhase = 1,")
                                End If

                                ' Write if instance is retail only
                                If instance.RetailOnly Then
                                    writer.WriteLine($"{Indent(4)}retailOnly = {instance.RetailOnly.ToString.ToLower()},")
                                End If

                                ' Write if instance is classic only
                                If instance.ClassicOnly Then
                                    writer.WriteLine($"{Indent(4)}classicOnly = {instance.ClassicOnly.ToString.ToLower()},")
                                End If
                            End If

                            ' Loop through each boss in the instance
                            For Each boss In instance.Bosses

                                ' Write boss order
                                writer.WriteLine($"{Indent(4)}boss{boss.Order} = {{")

                                ' Write boss name id
                                If boss.BossNameID > 0 Then
                                    ' We have id for boss
                                    writer.WriteLine($"{Indent(5)}name = {boss.BossNameID}, --{boss.BossName}")
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
                                    Dim groupedTactics = boss.Tactics.GroupBy(Function(t) t.ExpansionId).OrderBy(Function(s) s.Key)

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

                                'If expansion.ExpansionGameId = 3 And boss.EncounterIDWrath > 0 Then
                                '    writer.WriteLine($"{Indent(5)}encounterIDWrath = " & boss.EncounterIDWrath & ",")
                                'End If

                                If boss.DisplayInfoFrame = "true" Then
                                    writer.WriteLine($"{Indent(5)}displayInfoFrame = {boss.DisplayInfoFrame.ToString.ToLower()},")
                                End If

                                If boss.BossNameLocale.Length > 1 Then
                                    writer.WriteLine($"{Indent(5)}nameWrath = L[""{boss.BossNameLocale}""],")
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

        'Generate HTML
        'Dim Items As New List(Of String)
        '                Dim ItemsID As New List(Of String)
        '                Dim ItemType As New List(Of String)
        '                Console.WriteLine(boss.Tactics)
        '                If boss.Tactics.Contains("format(") Then
        '                    Dim strArr() As String = boss.Tactics.Split(",")
        '                    For Each item In strArr
        '                        If item.Contains("IAT_") Then
        '                            'NPC Found
        '                            Dim npcID As String = item.Replace("""", "").Replace("IAT_", "").Trim()
        '                            For Each npc In NPCDB
        '                                If npc.Id = npcID Then
        '                                    Items.Add(npc.Name)
        '                                    ItemsID.Add(npc.Id)
        '                                    ItemType.Add("NPC")
        '                                End If
        '                            Next
        '                        ElseIf item.Contains("C_Spell.GetSpellLink") Then
        '                            Dim spellID As String = item.Replace("C_Spell.GetSpellLink(", "").Replace(")", "").Trim()
        '                            For Each spell In SpellDB
        '                                If spell.id = spellID Then
        '                                    Items.Add(spell.name)
        '                                    ItemsID.Add(spell.id)
        '                                    ItemType.Add("Spell")
        '                                End If
        '                            Next
        '                        End If
        '                    Next
        '                End If
        '            Next
        '        Next
        '    Next
        'Next

        'Backup Files
        'If Not File.Exists("bossesDB.csv") And Not File.Exists("instancesDB.csv") And Not File.Exists("expansionsDB.csv") Then
        '    For Each expansion In CentralDB
        '        Using writer As StreamWriter = New StreamWriter("expansionsDB.csv", True)
        '            writer.WriteLine(expansion.ExpansionGameId & "," & expansion.Name)
        '        End Using
        '        For Each instancetype In expansion.InstanceTypes
        '            For Each instance In instancetype.Instances
        '                Using writer As StreamWriter = New StreamWriter("instancesDB.csv", True)
        '                    writer.WriteLine(instance.InstanceId & "," & instance.Name & "," & instance.InstanceNameID & "," & expansion.Name & "," & instancetype.Name & "," & instance.NameWrath & "," & instance.ClassicPhase & "," & instance.RetailOnly & "," & instance.ClassicOnly)
        '                End Using
        '                For Each boss In instance.Bosses
        '                    Using writer As StreamWriter = New StreamWriter("bossesDB.csv", True)
        '                        writer.WriteLine(boss.Order & ";" & boss.BossName & ";" & boss.BossNameID & ";" & boss.BossIDs & ";" & boss.AchievementID & ";" & boss.Players & ";" & boss.Tactics & ";" & boss.Enabled & ";" & boss.Track & ";" & boss.PartialTrack & ";" & boss.EncounterID & ";" & boss.DisplayInfoFrame & ";" & instance.Name & ";" & boss.ImgurLink & ";" & boss.Image & ";" & boss.BossNameWrath & ";" & boss.ClassicTactics & ";" & boss.ImgurLinkClassic & ";" & boss.EncounterIDWrath)
        '                    End Using
        '                Next
        '            Next
        '        Next
        '    Next
        'Else
        '    MsgBox("Error: Cannot delete DB files")
        'End If


        'Generate Instances.lua

        'Generate Localization.enUS.lua
        'File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua", "Backup\Localization.enUS.lua" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        'If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua") = True Then
        '    File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua")
        'End If
        'Using writer As StreamWriter = New StreamWriter("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua", True)
        '    writer.WriteLine("local _, core = ...")
        '    writer.WriteLine("local baseLocale = {")
        '    For Each locale In LocalisationDB
        '        'writer.WriteLine(vbTab & "[""" & locale.Name & """] = """ & locale.Text & """,")
        '    Next
        '    writer.WriteLine("}")
        '    writer.Write("core:RegisterLocale('enUS', baseLocale)")
        'End Using

        ''Generate NPCCache.lua
        'File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua", "Backup\NPCCache.lua" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        'If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua") = True Then
        '    File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua")
        'End If
        'Using writer As StreamWriter = New StreamWriter("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua", True)
        '    writer.WriteLine("local _, core = ...")
        '    writer.WriteLine()
        '    writer.WriteLine("core.NPCCache = {")
        '    For Each npc In NPCCacheDB
        '        writer.WriteLine(vbTab & "[" & npc.id & "] =" & npc.id & ", --" & npc.name)
        '    Next
        '    writer.Write("}")

        '    writer.WriteLine()
        '    writer.WriteLine("core.NPCCacheClassic = {")
        '    For Each npc In NPCCacheClassicDB
        '        writer.WriteLine(vbTab & "[" & npc.id & "] =" & npc.id & ", --" & npc.name)
        '    Next
        '    writer.Write("}")
        'End Using

        ''Generate ItemCache.lua
        'File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua", "Backup\ItemCache.lua" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        'If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua") = True Then
        '    File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua")
        'End If
        'Using writer As StreamWriter = New StreamWriter("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua", True)
        '    writer.WriteLine("local _, core = ...")
        '    writer.WriteLine()
        '    writer.WriteLine("core.ItemCache = {")
        '    For Each item In ItemCacheDB
        '        writer.WriteLine(vbTab & "[" & item.ID & "] = " & item.ID & ", --" & item.Name)
        '    Next
        '    writer.Write("}")
        'End Using

        MsgBox("Save Successful")
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

        'save()
    End Sub

    Private Sub frmIATDatabaseManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' WebView2.Dispose()
    End Sub

    Private Sub SpellsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpellsToolStripMenuItem.Click
        'Insert Spells
        Using reader As StreamReader = New StreamReader("C:\Program Files (x86)\World of Warcraft\_retail_\WTF\Account\DRAGNOG657\SavedVariables\SpellDump.lua")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                If line.Contains("=") Then
                    Dim strArr() As String = line.Split("=")
                    Dim NewSpell = New Spell
                    NewSpell.name = strArr(1).Trim().Trim(",".ToCharArray()).Trim("""".ToCharArray())
                    NewSpell.id = strArr(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")

                    Using writer As StreamWriter = New StreamWriter("SpellDB.csv", True)
                        writer.WriteLine(NewSpell.name & ";" & NewSpell.id)
                    End Using
                End If

                line = reader.ReadLine
            End While
        End Using
        MsgBox("Complete")
    End Sub

    Private Sub ViewSpellsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSpellsToolStripMenuItem.Click
        SpellData.Show()
    End Sub

    Private Sub btnAddSpell_Click(sender As Object, e As EventArgs) Handles btnAddSpell.Click
        ''Found a spell
        'If WebView2.CoreWebView2.Source.ToString.Contains("https://www.wowhead.com/spell=") Then
        '    Dim address = WebView2.CoreWebView2.Source.ToString.Replace("https://www.wowhead.com/spell=", "").Split("/")(0)
        '    'Dim address = chromeBrowser.Address.Replace("https://www.wowhead.com/spell=", "").Split("/")(0)
        '    Clipboard.SetText("[" & address & "|" & txtSpellName.Text & "]")

        '    Dim IDFoundInCache = False
        '    Using reader As StreamReader = New StreamReader("SpellIDS.csv")
        '        Dim line = reader.ReadLine

        '        While Not line Is Nothing
        '            If line.Contains(address) Then
        '                IDFoundInCache = True
        '            End If
        '            line = reader.ReadLine
        '        End While
        '    End Using

        '    If IDFoundInCache = False Then
        '        Using writer As StreamWriter = New StreamWriter("SpellIDS.csv", True)
        '            writer.WriteLine(address & "," & txtSpellName.Text)
        '        End Using
        '    End If
        'ElseIf WebView2.CoreWebView2.Source.ToString.Contains("https://www.wowhead.com/item=") Then
        '    Dim address = WebView2.CoreWebView2.Source.ToString.Replace("https://www.wowhead.com/item=", "").Split("/")(0)
        '    Clipboard.SetText("[ITEM_" & address & "|" & txtSpellName.Text & "]")

        '    Dim IDFoundInCache = False
        '    Using reader As StreamReader = New StreamReader("ItemIDS.csv")
        '        Dim line = reader.ReadLine

        '        While Not line Is Nothing
        '            If line.Contains(address) Then
        '                IDFoundInCache = True
        '            End If
        '            line = reader.ReadLine
        '        End While
        '    End Using

        '    If IDFoundInCache = False Then
        '        Using writer As StreamWriter = New StreamWriter("ItemIDS.csv", True)
        '            writer.WriteLine(address & "," & txtSpellName.Text)
        '        End Using
        '    End If
        'End If

        'LoadWebsite("https://www.wowhead.com/achievement=" & txtAchievement.Text & "#comments")
    End Sub

    Private Sub txtSpellName_Enter(sender As Object, e As EventArgs) Handles txtSpellName.Enter
        LoadWebsite("https://www.wowhead.com/search?q=" & txtSpellName.Text)
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs)
        ' LoadWebsite("https://www.wowhead.com/achievement=" & txtAchievement.Text)
    End Sub

    Private Sub btnGenerateLocaleNoUpload_Click(sender As Object, e As EventArgs) Handles btnGenerateLocaleNoUpload.Click
        'txtTacticsLocale.Text = ""
        'txtTactics.Text = ""

        'Dim NPCName = ""
        'Dim InsideNPC = False
        'Dim InsideSpell = False
        'Dim SpellName = ""
        'Dim FormatStarted = False
        'Dim WebpageString = ""
        'Dim StopString = False
        'Dim NewLineFound = False
        'For Each c As Char In txtNewTactics.Text
        '    If c = "{" Then
        '        'Start of NPC name
        '        InsideNPC = True
        '    ElseIf c = "}" Then
        '        'End of NPC name
        '        For Each NPC In NPCDB
        '            If NPC.ID = NPCName Then
        '                txtTacticsLocale.Text += "%s"
        '                WebpageString += NPC.Name

        '                'Add to cache if needed
        '                Dim foundNPC = False
        '                For Each npc2 As NPCCache In NPCCacheDB
        '                    If npc2.ID = NPC.ID Then
        '                        foundNPC = True
        '                    End If
        '                Next

        '                If foundNPC = False Then
        '                    Dim NewNPC = New NPCCache
        '                    NewNPC.Name = NPC.Name
        '                    NewNPC.ID = NPC.ID
        '                    NPCCacheDB.add(NewNPC)
        '                    Console.WriteLine("Added: " & NPC.Name)
        '                End If

        '                If FormatStarted = False Then
        '                    FormatStarted = True
        '                    txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], ""IAT_" & NPC.ID & """"
        '                    Exit For
        '                Else
        '                    txtTactics.Text += ", ""IAT_" & NPC.ID & """"
        '                    Exit For
        '                End If
        '            End If
        '        Next

        '        InsideNPC = False
        '        NPCName = ""
        '        StopString = False
        '    ElseIf c = "|" Then
        '        StopString = True
        '    ElseIf c = "[" Then
        '        'Start of Spell name
        '        InsideSpell = True
        '    ElseIf c = "]" Then
        '        'End of spell/item name
        '        txtTacticsLocale.Text += "%s"

        '        If SpellName.Contains("ITEM_") Then
        '            Dim ItemID = SpellName.Replace("ITEM_", "")
        '            WebpageString += "[" & GetItemName(ItemID) & "]"

        '            If FormatStarted = False Then
        '                FormatStarted = True
        '                txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], ""IAT_" & ItemID & """"
        '                'Exit For
        '            Else
        '                txtTactics.Text += ", ""IAT_" & ItemID & """"
        '                'Exit For
        '            End If

        '            'Add to cache if needed
        '            Dim foundItem = False
        '            For Each item2 As ItemCache In ItemCacheDB
        '                If item2.ID = ItemID Then
        '                    foundItem = True
        '                End If
        '            Next

        '            If foundItem = False Then
        '                Dim NewItem = New ItemCache
        '                NewItem.Name = GetItemName(ItemID)
        '                NewItem.ID = ItemID
        '                ItemCacheDB.Add(NewItem)
        '            End If
        '        Else
        '            WebpageString += "[" & GetSpellName(SpellName) & "]"

        '            If FormatStarted = False Then
        '                FormatStarted = True
        '                txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], C_Spell.GetSpellLink(" & SpellName & ")"
        '                'Exit For
        '            Else
        '                txtTactics.Text += ", C_Spell.GetSpellLink(" & SpellName & ")"
        '                'Exit For
        '            End If
        '        End If

        '        InsideSpell = False
        '        SpellName = ""
        '        StopString = False
        '    ElseIf InsideSpell Then
        '        If StopString = False Then
        '            SpellName += c
        '        End If
        '    ElseIf InsideNPC Then
        '        If StopString = False Then
        '            NPCName += c
        '        End If
        '    ElseIf c = "\" Then
        '        NewLineFound = True
        '    ElseIf NewLineFound Then
        '        If c = "n" Then
        '            txtTacticsLocale.Text += "\n"
        '            WebpageString += vbNewLine
        '            NewLineFound = False
        '        End If
        '    Else
        '        txtTacticsLocale.Text += c
        '        WebpageString += c
        '    End If
        'Next
        'If FormatStarted Then
        '    txtTactics.Text += ")"
        'Else
        '    txtTactics.Text = "L[""" & txtLocaleString.Text & """]"
        'End If

        'txtInGame.Text = WebpageString.Replace("%%", "%")
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

    Private Sub CoordinateBuilderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoordinateBuilderToolStripMenuItem.Click
        CoordinateBulder.Show()
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

    Private Sub txtSpellName_TextChanged(sender As Object, e As EventArgs) Handles txtSpellName.TextChanged
        LoadWebsite("https://www.wowhead.com/search?q=" & txtSpellName.Text)
    End Sub

    Private Sub btnTestTranslationClassic_Click(sender As Object, e As EventArgs) Handles btnTestTranslationClassic.Click
        'txtTacticsLocaleClassic.Text = ""
        'txtClassicTactics.Text = ""

        'Dim NPCName = ""
        'Dim InsideNPC = False
        'Dim InsideSpell = False
        'Dim SpellName = ""
        'Dim FormatStarted = False
        'Dim WebpageString = ""
        'Dim StopString = False
        'Dim NewLineFound = False
        'For Each c As Char In txtNewTacticsClassic.Text
        '    If c = "{" Then
        '        'Start of NPC name
        '        InsideNPC = True
        '    ElseIf c = "}" Then
        '        'End of NPC name
        '        For Each NPC In NPCDB
        '            If NPC.ID = NPCName Then
        '                txtTacticsLocaleClassic.Text += "%s"
        '                WebpageString += NPC.Name

        '                'Add to cache if needed
        '                Dim foundNPC = False
        '                For Each npc2 As NPCCache In NPCCacheClassicDB
        '                    If npc2.ID = NPC.ID Then
        '                        foundNPC = True
        '                    End If
        '                Next

        '                If foundNPC = False Then
        '                    Dim NewNPC = New NPCCache
        '                    NewNPC.Name = NPC.Name
        '                    NewNPC.ID = NPC.ID
        '                    NPCCacheClassicDB.add(NewNPC)
        '                    Console.WriteLine("Added: " & NPC.Name)
        '                End If

        '                If FormatStarted = False Then
        '                    FormatStarted = True
        '                    txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], ""IAT_" & NPC.ID & """"
        '                    Exit For
        '                Else
        '                    txtClassicTactics.Text += ", ""IAT_" & NPC.ID & """"
        '                    Exit For
        '                End If
        '            End If
        '        Next

        '        InsideNPC = False
        '        NPCName = ""
        '        StopString = False
        '    ElseIf c = "|" Then
        '        StopString = True
        '    ElseIf c = "[" Then
        '        'Start of Spell name
        '        InsideSpell = True
        '    ElseIf c = "]" Then
        '        'End of spell/item name
        '        txtTacticsLocaleClassic.Text += "%s"

        '        If SpellName.Contains("ITEM_") Then
        '            Dim ItemID = SpellName.Replace("ITEM_", "")
        '            WebpageString += "[" & GetItemName(ItemID) & "]"

        '            If FormatStarted = False Then
        '                FormatStarted = True
        '                txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], ""IAT_" & ItemID & """"
        '                'Exit For
        '            Else
        '                txtClassicTactics.Text += ", ""IAT_" & ItemID & """"
        '                'Exit For
        '            End If

        '            'Add to cache if needed
        '            Dim foundItem = False
        '            For Each item2 As ItemCache In ItemCacheDB
        '                If item2.ID = ItemID Then
        '                    foundItem = True
        '                End If
        '            Next

        '            If foundItem = False Then
        '                Dim NewItem = New ItemCache
        '                NewItem.Name = GetItemName(ItemID)
        '                NewItem.ID = ItemID
        '                ItemCacheDB.Add(NewItem)
        '            End If
        '        Else
        '            WebpageString += "[" & GetSpellName(SpellName) & "]"

        '            If FormatStarted = False Then
        '                FormatStarted = True
        '                txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], C_Spell.GetSpellLink(" & SpellName & ")"
        '                'Exit For
        '            Else
        '                txtClassicTactics.Text += ", C_Spell.GetSpellLink(" & SpellName & ")"
        '                'Exit For
        '            End If
        '        End If

        '        InsideSpell = False
        '        SpellName = ""
        '        StopString = False
        '    ElseIf InsideSpell Then
        '        If StopString = False Then
        '            SpellName += c
        '        End If
        '    ElseIf InsideNPC Then
        '        If StopString = False Then
        '            NPCName += c
        '        End If
        '    ElseIf c = "\" Then
        '        NewLineFound = True
        '    ElseIf NewLineFound Then
        '        If c = "n" Then
        '            txtTacticsLocaleClassic.Text += "\n"
        '            WebpageString += vbNewLine
        '            NewLineFound = False
        '        End If
        '    Else
        '        txtTacticsLocaleClassic.Text += c
        '        WebpageString += c
        '    End If
        'Next
        'If FormatStarted Then
        '    txtClassicTactics.Text += ")"
        'Else
        '    txtClassicTactics.Text = "L[""" & txtLocaleStringClassic.Text & """]"
        'End If

        'txtInGameClassic.Text = WebpageString.Replace("%%", "%")
    End Sub

    Private Async Sub btnUploadLocaleClassic_Click(sender As Object, e As EventArgs) Handles btnUploadLocaleClassic.Click
        'LoadWebsite("https://www.curseforge.com/wow/addons/instance-achievement-tracker/localization/languages/92/phrases#0")

        'Await Task.Delay(5000)

        'Dim script = "document.querySelector('.button.create-phrase').click();"
        'WebView2.ExecuteScriptAsync(script)
        ''chromeBrowser.ExecuteScriptAsync(script)

        'Await Task.Delay(1000)

        ''Add Name
        'script = "document.getElementById('field-phrase-name').value =""" & txtLocaleStringClassic.Text.Replace("""", """""") & """"
        'WebView2.ExecuteScriptAsync(script)

        'Await Task.Delay(1000)

        ''Add Context
        'Dim context = txtContext.Text.Replace("""", "&quot").Replace("\n", "\\n")
        'script = "document.getElementById('field-phrase-context').value =""" & context & """"
        'WebView2.ExecuteScriptAsync(script)
        'Await Task.Delay(1000)
        'script = "document.getElementById('field-phrase-context').value = document.getElementById('field-phrase-context').value.split('&quot').join('""')"
        'WebView2.ExecuteScriptAsync(script)

        'Await Task.Delay(1000)

        ''Add String
        'Dim tacticslocale = txtTacticsLocaleClassic.Text.Replace("""", "&quot").Replace("\n", "\\n")
        'script = "document.getElementById('field-phrase-default-translation').value =""" & tacticslocale & """"
        'WebView2.ExecuteScriptAsync(script)
        'Await Task.Delay(1000)
        'script = "document.getElementById('field-phrase-default-translation').value = document.getElementById('field-phrase-default-translation').value.split('&quot').join('""')"
        'WebView2.ExecuteScriptAsync(script)

        'Await Task.Delay(1000)

        'save()
    End Sub

    Private Sub dgvExpansions_SelectionChanged(sender As Object, e As EventArgs) Handles dgvExpansions.SelectionChanged
        Try
            If IATContext IsNot Nothing Then
                Dim expansion = CType(dgvExpansions.CurrentRow.DataBoundItem, Expansion)

                If expansion IsNot Nothing Then
                    IATContext.Entry(expansion).Collection(Function(f) f.InstanceTypes).Load()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvInstanceTypes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvInstanceTypes.SelectionChanged
        Try
            If IATContext IsNot Nothing And dgvInstanceTypes.CurrentRow IsNot Nothing Then
                Dim instanceType = CType(dgvInstanceTypes.CurrentRow.DataBoundItem, InstanceType)

                If instanceType IsNot Nothing Then
                    IATContext.Entry(instanceType).Collection(Function(f) f.Instances).Load()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvInstances_SelectionChanged(sender As Object, e As EventArgs) Handles dgvInstances.SelectionChanged
        Try
            If IATContext IsNot Nothing And dgvInstances.CurrentRow IsNot Nothing Then
                Dim instance = CType(dgvInstances.CurrentRow.DataBoundItem, Instance)

                If instance IsNot Nothing Then
                    IATContext.Entry(instance).Collection(Function(f) f.Bosses).Load()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBosses_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBosses.CellContentClick
        Try
            If IATContext IsNot Nothing And dgvBosses.CurrentRow IsNot Nothing Then
                Dim boss = CType(dgvBosses.CurrentRow.DataBoundItem, Boss)

                If boss IsNot Nothing Then
                    IATContext.Entry(boss).Collection(Function(f) f.Tactics).Load()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvTactics_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTactics.CellContentClick
        'Try
        '    If IATContext IsNot Nothing And dgvTactics.CurrentRow IsNot Nothing Then
        '        Dim tactic = CType(dgvTactics.CurrentRow.DataBoundItem, Tactic)

        '        If tactic IsNot Nothing Then
        '            IATContext.Entry(tactic).Collection(Function(f) f.TacticParameter).Load()
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
End Class
