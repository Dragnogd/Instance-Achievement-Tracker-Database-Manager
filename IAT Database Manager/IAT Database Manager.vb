Imports System.Data
Imports System.IO
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Imgur.API.Authentication
Imports Imgur.API.Endpoints


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

    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer)
        Dim i As Integer, iHalfSeconds As Integer = iMilliSeconds / 500
        For i = 1 To iHalfSeconds
            Threading.Thread.Sleep(500) : Application.DoEvents()
        Next i
    End Sub
    Private Sub InitalizeChromium(address As String)
    End Sub

    Public Sub LoadWebsite(website)
        Console.WriteLine("Adding site:" & website)
        PreviousSites.Add(website)
        CurrentSite = website
        Dim Address = New Uri(website)
        WebView2.Source = Address
    End Sub

    Private Sub frmIATDatabaseManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AppCenter.Start("b94e3d4b-95fa-4ecd-a878-3c8c72b9c413", GetType(Analytics), GetType(Crashes))

        Dim splash As SplashScreen1 = CType(My.Application.SplashScreen, SplashScreen1)

        splash.UpdateProgress("Setting up Web Browser (1/13)", 1)
        InitalizeChromium("https://www.curseforge.com/wow/addons/instance-achievement-tracker/localization/languages/92/phrases#0")

        splash.UpdateProgress("Loading Expansions (2/13)", 2)
        'Insert Expansions
        Using reader As StreamReader = New StreamReader("expansionsDB.csv")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                Dim strArr() As String = line.Split(",")
                Dim NewExpansion = New Expansion
                NewExpansion.ExpansionID = strArr(0)
                NewExpansion.Name = strArr(1)
                CentralDB.Add(NewExpansion)

                line = reader.ReadLine
            End While
        End Using

        splash.UpdateProgress("Loading Instance Types (3/13)", 3)
        'Insert InstanceTypes
        For Each expansion In CentralDB
            Dim NewRaid = New InstanceType
            NewRaid.Name = "Raids"
            expansion.InstanceTypes.Add(NewRaid)
            Dim NewDungeon = New InstanceType
            NewDungeon.Name = "Dungeons"
            expansion.InstanceTypes.Add(NewDungeon)

            If expansion.ExpansionID = 5 Then
                Dim NewScenario = New InstanceType
                NewScenario.Name = "Scenarios"
                expansion.InstanceTypes.Add(NewScenario)
            End If

            If expansion.ExpansionID = 11 Then
                Dim NewDelve = New InstanceType
                NewDelve.Name = "Delves"
                expansion.InstanceTypes.Add(NewDelve)
            End If
        Next

        splash.UpdateProgress("Loading Instances (4/13)", 4)
        'Insert Instances
        Using reader As StreamReader = New StreamReader("instancesDB.csv")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                Dim strArr() As String = line.Split(",")
                Dim NewInstance = New Instance
                NewInstance.InstanceID = strArr(0)
                NewInstance.Name = strArr(1)
                NewInstance.InstanceNameID = strArr(2)

                'Check if we have a localised instance name to display (Wrath Classic)
                Try
                    If strArr(5) <> Nothing Then
                        NewInstance.NameWrath = strArr(5)
                    Else
                        NewInstance.NameWrath = ""
                    End If
                Catch ex As Exception

                End Try

                'Check what instances are currently avaliable in current Classic Phase
                Try
                    If strArr(6) <> Nothing Then
                        NewInstance.ClassicPhase = strArr(6)
                    Else
                        NewInstance.ClassicPhase = ""
                    End If
                Catch ex As Exception

                End Try

                'Check what instances are currently avaliable in retail only
                Try
                    If strArr(7) <> Nothing Then
                        NewInstance.RetailOnly = strArr(7)
                    Else
                        NewInstance.RetailOnly = ""
                    End If
                Catch ex As Exception

                End Try

                'Check what instances are currently avaliable in classic only
                Try
                    If strArr(8) <> Nothing Then
                        NewInstance.ClassicOnly = strArr(8)
                    Else
                        NewInstance.ClassicOnly = ""
                    End If
                Catch ex As Exception

                End Try

                For Each expansion In CentralDB
                    If expansion.Name = strArr(3) Then
                        For Each instanceType In expansion.InstanceTypes
                            If instanceType.Name = strArr(4) Then
                                instanceType.Instances.Add(NewInstance)
                            End If
                        Next
                    End If
                Next

                line = reader.ReadLine
            End While
        End Using

        splash.UpdateProgress("Loading Bosses (5/13)", 5)
        'Insert Bosses
        Dim lines = IO.File.ReadAllLines("bossesDB.csv")
        BossesTable.Columns.Add(New DataColumn("Order", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("BossName", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("BossNameID", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("BossIDs", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("AchievementID", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("Players", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("Tactics", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("Enabled", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("Track", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("PartialTrack", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("EncounterID", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("EncounterIDWrath", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("DisplayInfoFrame", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("Image", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("BossNameWrath", GetType(String)))
        BossesTable.Columns.Add(New DataColumn("ClassicTactics", GetType(String)))
        For Each line In lines
            If line.Contains(";") Then
                Dim strArr() As String = line.Split(";")
                Dim NewBoss = New Boss
                Dim Counter = 1
                NewBoss.Order = strArr(0)
                If strArr(1).Length > 1 Then
                    NewBoss.BossName = strArr(1)
                Else
                    NewBoss.BossName = "MISSINGNAME" & Counter
                    Counter += 1
                End If
                NewBoss.BossNameID = strArr(2)
                NewBoss.BossIDs = strArr(3)
                NewBoss.AchievementID = strArr(4)
                NewBoss.Players = strArr(5)
                NewBoss.Tactics = strArr(6)
                NewBoss.Enabled = strArr(7)
                NewBoss.Track = strArr(8)
                NewBoss.PartialTrack = strArr(9)
                NewBoss.EncounterID = strArr(10)
                NewBoss.DisplayInfoFrame = strArr(11)


                'Check if we have an image to display for this achievement
                If strArr(14) <> Nothing Then
                    NewBoss.Image = strArr(14)
                Else
                    NewBoss.Image = ""
                End If

                'Check if we have a localised boss name to display (Wrath Classic)
                Try
                    If strArr(15) <> Nothing Then
                        NewBoss.BossNameWrath = strArr(15)
                    Else
                        NewBoss.BossNameWrath = ""
                    End If
                Catch ex As Exception

                End Try

                'Check for classic tactics
                Try
                    If strArr(16) <> Nothing Then
                        NewBoss.ClassicTactics = strArr(16)
                    Else
                        NewBoss.ClassicTactics = ""
                    End If
                Catch ex As Exception

                End Try

                'Check for classic tactics
                Try
                    If strArr(17) <> Nothing Then
                        NewBoss.ImgurLinkClassic = strArr(17)
                    Else
                        NewBoss.ImgurLinkClassic = ""
                    End If
                Catch ex As Exception

                End Try


                'Encounter ID Classic
                Try
                    If strArr(18) <> Nothing Then
                        NewBoss.EncounterIDWrath = strArr(18)
                    Else
                        NewBoss.EncounterIDWrath = ""
                    End If
                Catch ex As Exception

                End Try

                Dim FoundInstance = False
                For Each expansion In CentralDB
                    For Each instanceType In expansion.InstanceTypes
                        For Each instance In instanceType.Instances
                            If instance.Name = strArr(12) And FoundInstance = False Then
                                'If expansion.ExpansionID = "3" Then
                                '    NewBoss.BossNameWrath = "L[""Boss_" + NewBoss.BossName.Replace(" ", "").Replace("'", "").Replace("the", "The").Replace("of", "Of") + """]"
                                '    Dim a = 1
                                'End If

                                instance.Bosses.Add(NewBoss)
                                FoundInstance = True
                            End If
                        Next
                    Next
                Next
                Dim R As DataRow = BossesTable.NewRow
                R("Order") = NewBoss.Order
                R("BossName") = NewBoss.BossName
                R("BossNameID") = NewBoss.BossNameID
                R("BossIDs") = NewBoss.BossIDs
                R("AchievementID") = NewBoss.AchievementID
                R("Players") = NewBoss.Players
                R("Tactics") = NewBoss.Tactics
                R("Enabled") = NewBoss.Enabled
                R("Track") = NewBoss.Track
                R("PartialTrack") = NewBoss.PartialTrack
                R("EncounterID") = NewBoss.EncounterID
                R("DisplayInfoFrame") = NewBoss.DisplayInfoFrame
                R("Image") = NewBoss.Image
                R("BossNameWrath") = NewBoss.BossNameWrath
                R("ClassicTactics") = NewBoss.ClassicTactics
                R("EncounterIDWrath") = NewBoss.EncounterIDWrath
                BossesTable.Rows.Add(R)
            End If
        Next

        BossesTable.DefaultView.Sort = "BossName"
        splash.UpdateProgress("Populating Bosses (6/13)", 6)
        cboBosses.DataSource = BossesTable
        cboBosses.DisplayMember = "BossName"
        cboBosses.ValueMember = "AchievementID"

        splash.UpdateProgress("Loading Localisation (7/13)", 7)
        'Insert Localisation
        If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua") Then
            Try
                File.Delete("Localization.enUS.lua")
                File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua", "Localization.enUS.lua")
            Catch ex As Exception

            End Try
        End If
        Using reader As StreamReader = New StreamReader("Localization.enUS.lua")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                If line.Contains("] =") And line.Contains("[""") Then
                    Dim regex As Regex = New Regex("\[(.*?)\]")
                    Dim match As Match = regex.Match(line)
                    Dim Locale = match.Value.Trim("[".ToCharArray()).Trim("]".ToCharArray())

                    For Each expansion In CentralDB
                        For Each instancetype In expansion.InstanceTypes
                            For Each instance In instancetype.Instances
                                For Each boss In instance.Bosses
                                    If boss.Tactics.Contains(Locale) Then
                                        boss.LocaleText = line.Split("=")(1).Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
                                        boss.LocaleName = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")
                                    End If
                                    If boss.ClassicTactics.Contains(Locale) Then
                                        boss.LocaleTextClassic = line.Split("=")(1).Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
                                        boss.LocaleNameClassic = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")
                                    End If
                                Next
                            Next
                        Next
                    Next

                    Dim NewLocalisation = New Localisation
                    NewLocalisation.Text = line.Split("=")(1).Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
                    NewLocalisation.Name = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")
                    LocalisationDB.Add(NewLocalisation)
                End If
                line = reader.ReadLine
            End While
        End Using

        splash.UpdateProgress("Populating Expansions & Instances (8/13)", 8)
        For Each expansion In CentralDB
            cboExpansions.Items.Add(expansion.Name)
            For Each instancetype In expansion.InstanceTypes
                For Each instance In instancetype.Instances
                    cboInstances.Items.Add(instance.Name)
                    For Each boss In instance.Bosses
                        'cboBosses.Items.Add(boss.BossName)
                    Next
                Next
            Next
        Next

        splash.UpdateProgress("Loading NPC Data (9/13)", 9)
        'Insert NPC's
        lines = IO.File.ReadAllLines("NPCDB.csv")
        NPCTable.Columns.Add(New DataColumn("ID", GetType(String)))
        NPCTable.Columns.Add(New DataColumn("Name", GetType(String)))
        Dim Count = 0
        For Each line In lines
            If line.Contains(";") Then
                Dim strArr() As String = line.Split(";")
                Dim NewNPC = New NPC
                NewNPC.Name = strArr(1)
                NewNPC.ID = strArr(0)
                NPCDB.Add(NewNPC)
                Dim R As DataRow = NPCTable.NewRow
                R("Name") = NewNPC.Name
                R("ID") = NewNPC.ID
                NPCTable.Rows.Add(R)
            End If
            Count += 1
        Next
        Console.WriteLine("Loaded " & Count & " NPC's")

        splash.UpdateProgress("Populating NPC's (10/13)", 10)
        cboNPC.DataSource = NPCTable
        cboNPC.DisplayMember = "Name"
        cboNPC.ValueMember = "ID"

        splash.UpdateProgress("Loading Spell Data (11/13)", 11)
        'Insert Spells
        'lines = IO.File.ReadAllLines("SpellDB.csv")
        'SpellTable.Columns.Add(New DataColumn("ID", GetType(String)))
        'SpellTable.Columns("ID").Unique = True
        'SpellTable.Columns.Add(New DataColumn("Name", GetType(String)))
        'Count = 0
        'For Each line In lines
        '    If line.Contains(";") Then
        '        Dim strArr() As String = line.Split(";")

        '        'DEBUG
        '        If strArr(0).Contains("Pistol Barrage") Then
        '            Console.WriteLine("HERE Barrage")
        '        End If

        '        Dim NewSpell = New Spell
        '        NewSpell.name = strArr(0)
        '        Dim ParseResult As Integer
        '        If Integer.TryParse(strArr(1), ParseResult) Then
        '            NewSpell.id = strArr(1) - 1
        '        Else
        '            NewSpell.id = strArr(1)
        '        End If

        '        SpellDB.Add(NewSpell)
        '        Dim R As DataRow = SpellTable.NewRow
        '        R("ID") = NewSpell.id
        '        R("Name") = NewSpell.name
        '        SpellTable.Rows.Add(R)
        '        Count += 1
        '    End If
        'Next
        'Console.WriteLine("Loaded " & Count & " Spells")

        splash.UpdateProgress("Populating Spell Data (12/13)", 12)
        'cboSpell.DataSource = SpellTable
        'cboSpell.DisplayMember = "Name"
        'cboSpell.ValueMember = "ID"
        'SpellData.DataGridView1.DataSource = SpellTable

        splash.UpdateProgress("Loading NPC Cache (13/13)", 13)
        'Insert NPCCache
        If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua") Then
            Try
                File.Delete("NPCCache.lua")
                File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua", "NPCCache.lua")
            Catch ex As Exception

            End Try
        End If
        Using reader As StreamReader = New StreamReader("NPCCache.lua")
            Dim line = reader.ReadLine
            Dim NpcCacheType = "Retail"

            While Not line Is Nothing
                If line.Contains("core.NPCCacheClassic = {") Then
                    NpcCacheType = "Classic"
                End If
                If line.Contains("] =") Then
                    Dim NewNPCCache = New NPCCache
                    NewNPCCache.Name = line.Split("=")(1).Split(",")(1).Replace("--", "").Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
                    NewNPCCache.ID = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")

                    If NpcCacheType = "Retail" Then
                        NPCCacheDB.Add(NewNPCCache)
                    ElseIf NpcCacheType = "Classic" Then
                        NPCCacheClassicDB.add(NewNPCCache)
                    End If
                End If
                line = reader.ReadLine
            End While
        End Using

        splash.UpdateProgress("Loading Item Cache (14/13)", 13)
        'Insert ItemCache
        If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua") Then
            Try
                File.Delete("ItemCache.lua")
                File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua", "ItemCache.lua")
            Catch ex As Exception

            End Try
        End If
        Using reader As StreamReader = New StreamReader("ItemCache.lua")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                If line.Contains("] =") Then
                    Dim NewItemCache = New ItemCache
                    NewItemCache.Name = line.Split("=")(1).Split(",")(1).Replace("--", "").Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
                    NewItemCache.ID = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")
                    ItemCacheDB.Add(NewItemCache)
                End If
                line = reader.ReadLine
            End While
        End Using

        Me.WindowState = WindowState.Maximized
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

            For Each expansion In CentralDB
                For Each instancetype In expansion.InstanceTypes
                    For Each instance In instancetype.Instances
                        For Each boss In instance.Bosses
                            If cboBosses.SelectedValue = boss.AchievementID Then
                                txtIndex.Text = boss.Order
                                txtAchievement.Text = boss.AchievementID
                                txtBossIDs.Text = boss.BossIDs
                                txtBossName.Text = boss.BossName
                                txtEnabled.Text = boss.Enabled
                                txtEncounterID.Text = boss.EncounterID
                                txtIndex.Text = boss.Order
                                txtInfoFrame.Text = boss.DisplayInfoFrame
                                txtNameID.Text = boss.BossNameID
                                txtPartial.Text = boss.PartialTrack
                                txtPlayers.Text = boss.Players
                                txtTactics.Text = boss.Tactics
                                txtTrack.Text = boss.Track
                                txtInstanceID.Text = instance.InstanceID
                                txtInstanceName.Text = instance.Name
                                txtInstanceNameWrath.Text = instance.NameWrath
                                txtInstanceNameID.Text = instance.InstanceNameID
                                txtInstanceType.Text = instancetype.Name
                                txtExpansion.Text = expansion.Name
                                txtExpansionID.Text = expansion.ExpansionID
                                txtTacticsLocale.Text = boss.LocaleText
                                txtLocaleString.Text = boss.LocaleName
                                txtNewTactics.Text = ""
                                txtInGame.Text = ""
                                txtImgurLink.Text = boss.ImgurLink
                                txtContext.Text = ""
                                txtImage.Text = boss.Image

                                'Classic
                                txtBossNameWrath.Text = boss.BossNameWrath
                                txtInGameClassic.Text = ""
                                txtNewTacticsClassic.Text = ""
                                txtTacticsLocaleClassic.Text = boss.LocaleTextClassic
                                txtClassicTactics.Text = boss.ClassicTactics
                                txtClassicPhase.Text = instance.ClassicPhase
                                txtRetailOnly.Text = instance.RetailOnly
                                txtClassicOnly.Text = instance.ClassicOnly
                                txtLocaleStringClassic.Text = boss.LocaleNameClassic
                                txtImgurLinkClassic.Text = boss.ImgurLinkClassic
                                txtEncounterIDWrath.Text = boss.EncounterIDWrath

                                'Populate NewTactics by reading format string
                                Dim Items As New List(Of String)
                                Dim ItemsID As New List(Of String)
                                Dim ItemType As New List(Of String)
                                If boss.Tactics.Contains("format(") Then
                                    Dim strArr() As String = boss.Tactics.Split(",")
                                    For Each item In strArr
                                        If item.Contains("IAT_") Then
                                            'NPC Found
                                            Dim npcID As String = item.Replace("""", "").Replace("IAT_", "").Trim().Replace(")", "")
                                            For Each npc In NPCDB
                                                If npc.ID = npcID Then
                                                    Items.Add(npc.Name)
                                                    ItemsID.Add(npc.ID)
                                                    ItemType.Add("NPC")
                                                End If
                                            Next
                                        ElseIf item.Contains("C_Spell.GetSpellLink") Then
                                            Dim spellID As String = item.Replace("C_Spell.GetSpellLink(", "").Replace(")", "").Trim()
                                            Items.Add(GetSpellName(spellID))
                                            ItemsID.Add(spellID)
                                            ItemType.Add("Spell")
                                            'For Each spell In SpellDB
                                            '    If spell.id = spellID Then
                                            '        Items.Add(spell.name)
                                            '        ItemsID.Add(spell.id)
                                            '        ItemType.Add("Spell")
                                            '    End If
                                            'Next
                                        End If
                                    Next

                                    Dim PercentFound = False
                                    Dim ListIndex = 0
                                    For Each c As Char In boss.LocaleText
                                        If PercentFound Then
                                            If c = "s" Then
                                                'Insert from list
                                                If ItemType(ListIndex) = "NPC" Then
                                                    txtNewTactics.Text += "{" & ItemsID(ListIndex) & "|" & Items(ListIndex) & "}"
                                                ElseIf ItemType(ListIndex) = "Spell" Then
                                                    txtNewTactics.Text += "[" & ItemsID(ListIndex) & "|" & Items(ListIndex) & "]"
                                                End If
                                                ListIndex += 1
                                            Else
                                                txtNewTactics.Text += "%%"
                                            End If
                                            PercentFound = False
                                        ElseIf c = "%" And PercentFound = False Then
                                            PercentFound = True
                                        Else
                                            txtNewTactics.Text += c
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If

                                'Populate Classic Tactics
                                Items = New List(Of String)
                                ItemsID = New List(Of String)
                                ItemType = New List(Of String)
                                If boss.ClassicTactics.Contains("format(") Then
                                    Dim strArr() As String = boss.ClassicTactics.Split(",")
                                    For Each item In strArr
                                        If item.Contains("IAT_") Then
                                            'NPC Found
                                            Dim npcID As String = item.Replace("""", "").Replace("IAT_", "").Trim().Replace(")", "")
                                            For Each npc In NPCDB
                                                If npc.ID = npcID Then
                                                    Items.Add(npc.Name)
                                                    ItemsID.Add(npc.ID)
                                                    ItemType.Add("NPC")
                                                End If
                                            Next
                                        ElseIf item.Contains("C_Spell.GetSpellLink") Then
                                            Dim spellID As String = item.Replace("C_Spell.GetSpellLink(", "").Replace(")", "").Trim()
                                            Items.Add(GetSpellName(spellID))
                                            ItemsID.Add(spellID)
                                            ItemType.Add("Spell")
                                            'For Each spell In SpellDB
                                            '    If spell.id = spellID Then
                                            '        Items.Add(spell.name)
                                            '        ItemsID.Add(spell.id)
                                            '        ItemType.Add("Spell")
                                            '    End If
                                            'Next
                                        End If
                                    Next

                                    Dim PercentFound = False
                                    Dim ListIndex = 0

                                    If boss.LocaleTextClassic = Nothing Then
                                        Dim localeTextC = InputBox("Please enter Locale Text Classic")
                                        boss.LocaleTextClassic = localeTextC
                                        txtTacticsLocaleClassic.Text = localeTextC
                                    End If

                                    For Each c As Char In boss.LocaleTextClassic
                                        If PercentFound Then
                                            If c = "s" Then
                                                'Insert from list
                                                If ItemType(ListIndex) = "NPC" Then
                                                    txtNewTacticsClassic.Text += "{" & ItemsID(ListIndex) & "|" & Items(ListIndex) & "}"
                                                ElseIf ItemType(ListIndex) = "Spell" Then
                                                    txtNewTacticsClassic.Text += "[" & ItemsID(ListIndex) & "|" & Items(ListIndex) & "]"
                                                End If
                                                ListIndex += 1
                                            Else
                                                txtNewTacticsClassic.Text += "%%"
                                            End If
                                            PercentFound = False
                                        ElseIf c = "%" And PercentFound = False Then
                                            PercentFound = True
                                        Else
                                            txtNewTacticsClassic.Text += c
                                        End If
                                        Application.DoEvents()
                                    Next
                                End If
                            End If
                        Next
                    Next
                Next
            Next

            LoadWebsite("https://www.wowhead.com/achievement=" & txtAchievement.Text & "#comments")
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
        txtTacticsLocale.Text = ""
        txtTactics.Text = ""

        Dim NPCName = ""
        Dim InsideNPC = False
        Dim InsideSpell = False
        Dim SpellName = ""
        Dim FormatStarted = False
        Dim WebpageString = ""
        Dim StopString = False
        Dim NewLineFound = False
        For Each c As Char In txtNewTactics.Text
            If c = "{" Then
                'Start of NPC name
                InsideNPC = True
            ElseIf c = "}" Then
                'End of NPC name
                For Each NPC In NPCDB
                    If NPC.ID = NPCName Then
                        txtTacticsLocale.Text += "%s"
                        WebpageString += NPC.Name

                        'Add to cache if needed
                        Dim foundNPC = False
                        For Each npc2 As NPCCache In NPCCacheDB
                            If npc2.ID = NPC.ID Then
                                foundNPC = True
                            End If
                        Next

                        If foundNPC = False Then
                            Dim NewNPC = New NPCCache
                            NewNPC.Name = NPC.Name
                            NewNPC.ID = NPC.ID
                            NPCCacheDB.add(NewNPC)
                            Console.WriteLine("Added: " & NPC.Name)
                        End If

                        If FormatStarted = False Then
                            FormatStarted = True
                            txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], ""IAT_" & NPC.ID & """"
                            Exit For
                        Else
                            txtTactics.Text += ", ""IAT_" & NPC.ID & """"
                            Exit For
                        End If
                    End If
                Next

                InsideNPC = False
                NPCName = ""
                StopString = False
            ElseIf c = "|" Then
                StopString = True
            ElseIf c = "[" Then
                'Start of Spell name
                InsideSpell = True
            ElseIf c = "]" Then
                'End of spell/item name
                txtTacticsLocale.Text += "%s"

                If SpellName.Contains("ITEM_") Then
                    Dim ItemID = SpellName.Replace("ITEM_", "")
                    WebpageString += "[" & GetItemName(ItemID) & "]"

                    If FormatStarted = False Then
                        FormatStarted = True
                        txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], ""IAT_" & ItemID & """"
                        'Exit For
                    Else
                        txtTactics.Text += ", ""IAT_" & ItemID & """"
                        'Exit For
                    End If
                Else
                    WebpageString += "[" & GetSpellName(SpellName) & "]"

                    If FormatStarted = False Then
                        FormatStarted = True
                        txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], C_Spell.GetSpellLink(" & SpellName & ")"
                        'Exit For
                    Else
                        txtTactics.Text += ", C_Spell.GetSpellLink(" & SpellName & ")"
                        'Exit For
                    End If
                End If

                InsideSpell = False
                SpellName = ""
                StopString = False
            ElseIf InsideSpell Then
                If StopString = False Then
                    SpellName += c
                End If
            ElseIf InsideNPC Then
                If StopString = False Then
                    NPCName += c
                End If
            ElseIf c = "\" Then
                NewLineFound = True
            ElseIf NewLineFound Then
                If c = "n" Then
                    txtTacticsLocale.Text += "\n"
                    WebpageString += vbNewLine
                    NewLineFound = False
                End If
            Else
                txtTacticsLocale.Text += c
                WebpageString += c
            End If
        Next
        If FormatStarted Then
            txtTactics.Text += ")"
        Else
            txtTactics.Text = "L[""" & txtLocaleString.Text & """]"
        End If

        txtInGame.Text = WebpageString.Replace("%%", "%")

        Dim bmp As Bitmap = New Bitmap(txtInGame.Width, txtInGame.Height)
        txtInGame.DrawToBitmap(bmp, New Rectangle(0, 0, txtInGame.Width, txtInGame.Height))
        bmp.Save("Screenshots/" & txtBossName.Text & ".jpg")

        Await Task.Delay(2000)

        Dim apiClient = New ApiClient("3c704f8deefd409", "82cf43f64495b192b1083ed8a59e30139bd4d797")
        Dim httpClient = New HttpClient()
        Dim oAuth2Endpoint = New OAuth2Endpoint(apiClient, httpClient)
        'Dim authUrl = oAuth2Endpoint.GetAuthorizationUrl()

        Dim filePath = "Screenshots/" & txtBossName.Text & ".jpg"
        Using FileStream = File.OpenRead(filePath)
            Dim imageEndpoint = New ImageEndpoint(apiClient, httpClient)
            Dim imageUpload = Await imageEndpoint.UploadImageAsync(FileStream)
            txtImgurLink.Text = "https://imgur.com/" & imageUpload.Id
            txtContext.Text = "*** Notes *** Please don't remove the %s strings or ""\n"" as these refer to names of spells/ npc's in the game or new lines. They can be moved around in the sentence however if that makes more sense in your language.English Text:" & txtImgurLink.Text
            LoadWebsite(txtImgurLink.Text)
        End Using
    End Sub

    Private Async Sub btnGenerateLocalisationClassic_Click(sender As Object, e As EventArgs) Handles btnGenerateLocalisationClassic.Click
        txtTacticsLocaleClassic.Text = ""
        txtClassicTactics.Text = ""

        Dim NPCName = ""
        Dim InsideNPC = False
        Dim InsideSpell = False
        Dim SpellName = ""
        Dim FormatStarted = False
        Dim WebpageString = ""
        Dim StopString = False
        Dim NewLineFound = False
        For Each c As Char In txtNewTacticsClassic.Text
            If c = "{" Then
                'Start of NPC name
                InsideNPC = True
            ElseIf c = "}" Then
                'End of NPC name
                For Each NPC In NPCDB
                    If NPC.ID = NPCName Then
                        txtTacticsLocaleClassic.Text += "%s"
                        WebpageString += NPC.Name

                        'Add to cache if needed
                        Dim foundNPC = False
                        For Each npc2 As NPCCache In NPCCacheClassicDB
                            If npc2.ID = NPC.ID Then
                                foundNPC = True
                            End If
                        Next

                        If foundNPC = False Then
                            Dim NewNPC = New NPCCache
                            NewNPC.Name = NPC.Name
                            NewNPC.ID = NPC.ID
                            NPCCacheClassicDB.add(NewNPC)
                            Console.WriteLine("Added: " & NPC.Name)
                        End If

                        If FormatStarted = False Then
                            FormatStarted = True
                            txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], ""IAT_" & NPC.ID & """"
                            Exit For
                        Else
                            txtClassicTactics.Text += ", ""IAT_" & NPC.ID & """"
                            Exit For
                        End If
                    End If
                Next

                InsideNPC = False
                NPCName = ""
                StopString = False
            ElseIf c = "|" Then
                StopString = True
            ElseIf c = "[" Then
                'Start of Spell name
                InsideSpell = True
            ElseIf c = "]" Then
                'End of spell/item name
                txtTacticsLocaleClassic.Text += "%s"

                If SpellName.Contains("ITEM_") Then
                    Dim ItemID = SpellName.Replace("ITEM_", "")
                    WebpageString += "[" & GetItemName(ItemID) & "]"

                    If FormatStarted = False Then
                        FormatStarted = True
                        txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], ""IAT_" & ItemID & """"
                        'Exit For
                    Else
                        txtClassicTactics.Text += ", ""IAT_" & ItemID & """"
                        'Exit For
                    End If
                Else
                    WebpageString += "[" & GetSpellName(SpellName) & "]"

                    If FormatStarted = False Then
                        FormatStarted = True
                        txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], C_Spell.GetSpellLink(" & SpellName & ")"
                        'Exit For
                    Else
                        txtClassicTactics.Text += ", C_Spell.GetSpellLink(" & SpellName & ")"
                        'Exit For
                    End If
                End If

                InsideSpell = False
                SpellName = ""
                StopString = False
            ElseIf InsideSpell Then
                If StopString = False Then
                    SpellName += c
                End If
            ElseIf InsideNPC Then
                If StopString = False Then
                    NPCName += c
                End If
            ElseIf c = "\" Then
                NewLineFound = True
            ElseIf NewLineFound Then
                If c = "n" Then
                    txtTacticsLocaleClassic.Text += "\n"
                    WebpageString += vbNewLine
                    NewLineFound = False
                End If
            Else
                txtTacticsLocaleClassic.Text += c
                WebpageString += c
            End If
        Next
        If FormatStarted Then
            txtClassicTactics.Text += ")"
        Else
            txtClassicTactics.Text = "L[""" & txtLocaleStringClassic.Text & """]"
        End If

        txtInGameClassic.Text = WebpageString.Replace("%%", "%")

        Dim bmp As Bitmap = New Bitmap(txtInGameClassic.Width, txtInGameClassic.Height)
        txtInGameClassic.DrawToBitmap(bmp, New Rectangle(0, 0, txtInGameClassic.Width, txtInGameClassic.Height))
        bmp.Save("Screenshots/" & txtBossName.Text & "_Classic.jpg")

        Await Task.Delay(2000)

        If My.Settings.ImgurClient Is Nothing OrElse My.Settings.ImgurClient.Length < 1 Then
            Dim clientID As String = InputBox("Enter Client ID")
            My.Settings.ImgurClient = clientID
            My.Settings.Save()
        End If

        If My.Settings.ImgurSecret Is Nothing OrElse My.Settings.ImgurSecret.Length = 0 Then
            Dim secret As String = InputBox("Enter Imgur Secret")
            My.Settings.ImgurSecret = secret
            My.Settings.Save()
        End If

        Dim apiClient = New ApiClient(My.Settings.ImgurClient, My.Settings.ImgurSecret)
        Dim httpClient = New HttpClient()
        Dim oAuth2Endpoint = New OAuth2Endpoint(apiClient, httpClient)
        'Dim authUrl = oAuth2Endpoint.GetAuthorizationUrl()

        Dim filePath = "Screenshots/" & txtBossName.Text & "_Classic.jpg"
        Using FileStream = File.OpenRead(filePath)
            Dim imageEndpoint = New ImageEndpoint(apiClient, httpClient)
            Dim imageUpload = Await imageEndpoint.UploadImageAsync(FileStream)
            txtImgurLinkClassic.Text = "https://imgur.com/" & imageUpload.Id
            txtContextClassic.Text = "*** Notes *** Please don't remove the %s strings or ""\n"" as these refer to names of spells/ npc's in the game or new lines. They can be moved around in the sentence however if that makes more sense in your language.English Text:" & txtImgurLink.Text
            LoadWebsite(txtImgurLinkClassic.Text)
        End Using
    End Sub

    Private Sub btnInsertTactic_Click(sender As Object, e As EventArgs) Handles btnInsertTactic.Click
        save()
    End Sub

    Public Sub save()
        'Save changes to DB
        For Each expansion In CentralDB
            For Each instancetype In expansion.InstanceTypes
                For Each instance In instancetype.Instances
                    For Each boss In instance.Bosses
                        If cboBosses.SelectedValue = boss.AchievementID And cboBosses.SelectedValue <> Nothing And boss.AchievementID <> Nothing Then
                            If cboBosses.SelectedValue.length > 1 And boss.AchievementID.Length > 1 And txtAchievement.Text.Length > 1 Then
                                boss.Order = txtIndex.Text
                                boss.AchievementID = txtAchievement.Text
                                boss.BossIDs = txtBossIDs.Text
                                boss.BossName = txtBossName.Text
                                boss.Enabled = txtEnabled.Text
                                boss.EncounterID = txtEncounterID.Text
                                boss.Order = txtIndex.Text
                                boss.DisplayInfoFrame = txtInfoFrame.Text
                                boss.BossNameID = txtNameID.Text
                                boss.PartialTrack = txtPartial.Text
                                boss.Players = txtPlayers.Text
                                boss.Tactics = txtTactics.Text
                                boss.Track = txtTrack.Text
                                instance.InstanceID = txtInstanceID.Text
                                instance.Name = txtInstanceName.Text
                                instance.NameWrath = txtInstanceNameWrath.Text
                                instance.InstanceNameID = txtInstanceNameID.Text
                                instancetype.Name = txtInstanceType.Text
                                expansion.Name = txtExpansion.Text
                                expansion.ExpansionID = txtExpansionID.Text
                                boss.LocaleText = txtTacticsLocale.Text
                                boss.LocaleName = txtLocaleString.Text
                                boss.ImgurLink = txtImgurLink.Text
                                boss.Image = txtImage.Text

                                'Classic
                                boss.BossNameWrath = txtBossNameWrath.Text
                                boss.ClassicTactics = txtClassicTactics.Text
                                instance.ClassicPhase = txtClassicPhase.Text
                                instance.RetailOnly = txtRetailOnly.Text
                                instance.ClassicOnly = txtClassicOnly.Text
                                boss.LocaleTextClassic = txtTacticsLocaleClassic.Text
                                boss.LocaleNameClassic = txtLocaleStringClassic.Text
                                boss.ImgurLinkClassic = txtImgurLinkClassic.Text
                                boss.EncounterIDWrath = txtEncounterIDWrath.Text

                                'Update LocaleDB
                                For Each locale In LocalisationDB
                                    If locale.Name = boss.LocaleName Then
                                        locale.Text = txtTacticsLocale.Text
                                    End If
                                    If locale.Name = boss.LocaleNameClassic Then
                                        locale.Text = txtTacticsLocaleClassic.Text
                                    End If
                                Next
                            End If
                        End If

                        'Generate HTML
                        Dim Items As New List(Of String)
                        Dim ItemsID As New List(Of String)
                        Dim ItemType As New List(Of String)
                        Console.WriteLine(boss.Tactics)
                        If boss.Tactics.Contains("format(") Then
                            Dim strArr() As String = boss.Tactics.Split(",")
                            For Each item In strArr
                                If item.Contains("IAT_") Then
                                    'NPC Found
                                    Dim npcID As String = item.Replace("""", "").Replace("IAT_", "").Trim()
                                    For Each npc In NPCDB
                                        If npc.ID = npcID Then
                                            Items.Add(npc.Name)
                                            ItemsID.Add(npc.ID)
                                            ItemType.Add("NPC")
                                        End If
                                    Next
                                ElseIf item.Contains("C_Spell.GetSpellLink") Then
                                    Dim spellID As String = item.Replace("C_Spell.GetSpellLink(", "").Replace(")", "").Trim()
                                    For Each spell In SpellDB
                                        If spell.id = spellID Then
                                            Items.Add(spell.name)
                                            ItemsID.Add(spell.id)
                                            ItemType.Add("Spell")
                                        End If
                                    Next
                                End If
                            Next

                            'Dim PercentFound = False
                            'Dim NewLineFound = False
                            'Dim ListIndex = 0
                            'Dim HTMLString = "<html><body><p>"
                            'For Each c As Char In boss.LocaleText
                            '    If PercentFound Then
                            '        If c = "s" Then
                            '            'Insert from list
                            '            If ItemType(ListIndex) = "NPC" Then
                            '                HTMLString += Items(ListIndex)
                            '            ElseIf ItemType(ListIndex) = "Spell" Then
                            '                HTMLString += "<a href=""GetSpellLink(" & ItemsID(ListIndex) & ")"">GetSpellLink(" & ItemsID(ListIndex) & ")</a>"
                            '            End If
                            '            ListIndex += 1
                            '        Else
                            '            HTMLString += "%"
                            '        End If
                            '        PercentFound = False
                            '    ElseIf NewLineFound Then
                            '        If c = "n" Then
                            '            'Insert new line
                            '            HTMLString += "<br />"
                            '        End If
                            '        NewLineFound = False
                            '    ElseIf c = "%" And PercentFound = False Then
                            '        PercentFound = True
                            '    ElseIf c = "/" And NewLineFound = False Then
                            '        NewLineFound = True
                            '    Else
                            '        HTMLString += c
                            '    End If
                            'Next
                            'boss.HTMLTactics = HTMLString
                        End If
                    Next
                Next
            Next
        Next

        'Backup Files
        File.Copy("expansionsDB.csv", "Backup\expansionsDB" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        File.Copy("instancesDB.csv", "Backup\instancesDB" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        File.Copy("bossesDB.csv", "Backup\bossesDB" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        File.Delete("expansionsDB.csv")
        File.Delete("instancesDB.csv")
        File.Delete("bossesDB.csv")
        If Not File.Exists("bossesDB.csv") And Not File.Exists("instancesDB.csv") And Not File.Exists("expansionsDB.csv") Then
            For Each expansion In CentralDB
                Using writer As StreamWriter = New StreamWriter("expansionsDB.csv", True)
                    writer.WriteLine(expansion.ExpansionID & "," & expansion.Name)
                End Using
                For Each instancetype In expansion.InstanceTypes
                    For Each instance In instancetype.Instances
                        Using writer As StreamWriter = New StreamWriter("instancesDB.csv", True)
                            writer.WriteLine(instance.InstanceID & "," & instance.Name & "," & instance.InstanceNameID & "," & expansion.Name & "," & instancetype.Name & "," & instance.NameWrath & "," & instance.ClassicPhase & "," & instance.RetailOnly & "," & instance.ClassicOnly)
                        End Using
                        For Each boss In instance.Bosses
                            Using writer As StreamWriter = New StreamWriter("bossesDB.csv", True)
                                writer.WriteLine(boss.Order & ";" & boss.BossName & ";" & boss.BossNameID & ";" & boss.BossIDs & ";" & boss.AchievementID & ";" & boss.Players & ";" & boss.Tactics & ";" & boss.Enabled & ";" & boss.Track & ";" & boss.PartialTrack & ";" & boss.EncounterID & ";" & boss.DisplayInfoFrame & ";" & instance.Name & ";" & boss.ImgurLink & ";" & boss.Image & ";" & boss.BossNameWrath & ";" & boss.ClassicTactics & ";" & boss.ImgurLinkClassic & ";" & boss.EncounterIDWrath)
                            End Using
                        Next
                    Next
                Next
            Next
        Else
            MsgBox("Error: Cannot delete DB files")
        End If


        'Generate Instances.lua
        File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances.lua", "Backup\Instances.lua" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances.lua") = True Then
            File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances.lua")
        End If
        Using writer As StreamWriter = New StreamWriter("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Instances.lua", True)
            writer.WriteLine("--------------------------------------")
            writer.WriteLine("-- Last Auto Generated: " & DateTime.Now)
            writer.WriteLine("--------------------------------------")
            writer.WriteLine("local _, core = ...")
            writer.WriteLine("local L = core.L")
            writer.WriteLine("local instances = {}")
            writer.WriteLine()
            writer.WriteLine("core.Instances = {")

            Dim firstExpansion = False
            Dim firstInstance = False
            For Each expansion In CentralDB
                If firstExpansion = False Then
                    firstExpansion = True
                Else
                    writer.WriteLine()
                End If
                writer.WriteLine(vbTab & "--" & expansion.Name)
                writer.WriteLine(vbTab & "[" & expansion.ExpansionID & "] = {")
                For Each instancetype In expansion.InstanceTypes
                    If instancetype.Name = "Dungeons" Or instancetype.Name = "Scenarios" Or instancetype.Name = "Delves" Then
                        writer.WriteLine()
                    End If
                    writer.WriteLine(vbTab & vbTab & instancetype.Name & " = {")
                    For Each instance In instancetype.Instances
                        If firstInstance = False Then
                            firstInstance = True
                        Else
                            writer.WriteLine()
                        End If
                        If instance.InstanceID.Contains("-") Then
                            writer.WriteLine(vbTab & vbTab & vbTab & "[""" & instance.InstanceID & """] = { --" & instance.Name)
                        Else
                            writer.WriteLine(vbTab & vbTab & vbTab & "[" & instance.InstanceID & "] = { --" & instance.Name)
                        End If
                        writer.WriteLine(vbTab & vbTab & vbTab & vbTab & "name = " & instance.InstanceNameID & ",")

                        If Not instance.NameWrath Is Nothing Then
                            If instance.NameWrath.Length > 1 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & "nameLocalised = " & instance.NameWrath & ",")
                            End If
                        End If


                        If expansion.ExpansionID = 3 Or expansion.ExpansionID = 4 Then
                            If instance.ClassicPhase.Length > 0 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & "classicPhase = " & instance.ClassicPhase & ",")
                            Else
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & "classicPhase = 1,")
                            End If
                        End If

                        If expansion.ExpansionID = 3 Or expansion.ExpansionID = 4 Then
                            If instance.RetailOnly.Length > 0 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & "retailOnly = " & instance.RetailOnly & ",")
                            End If
                        End If

                        If expansion.ExpansionID = 3 Or expansion.ExpansionID = 4 Then
                            If instance.ClassicOnly.Length > 0 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & "classicOnly = " & instance.ClassicOnly & ",")
                            End If
                        End If

                        For Each boss In instance.Bosses
                            writer.WriteLine(vbTab & vbTab & vbTab & vbTab & boss.Order & " = {")
                            writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "name = " & boss.BossNameID & ", --" & boss.BossName)
                            writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "bossIDs = " & boss.BossIDs & ",")
                            If boss.AchievementID.Length > 0 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "achievement = " & boss.AchievementID & ",")
                            Else
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "achievement = 6,")
                            End If
                            writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "players = " & boss.Players & ",")
                            writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "tactics = " & boss.Tactics & ",")
                            'writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "tacticsHTML = " & boss.HTMLTactics & ",")
                            writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "enabled = " & boss.Enabled & ",")
                            writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "track = " & boss.Track & ",")

                            If boss.PartialTrack.Length > 1 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "partial = " & boss.PartialTrack & ",")
                            Else
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "partial = false,")
                            End If

                            If boss.EncounterID.Length > 1 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "encounterID = " & boss.EncounterID & ",")
                            End If

                            If expansion.ExpansionID = 3 And boss.EncounterIDWrath.Length > 1 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "encounterIDWrath = " & boss.EncounterIDWrath & ",")
                            End If

                            If boss.DisplayInfoFrame = "true" Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "displayInfoFrame = " & boss.DisplayInfoFrame & ",")
                            End If

                            If boss.Image.Length > 1 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "image = " & boss.Image & ",")
                            End If

                            If boss.BossNameWrath.Length > 1 Then
                                writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "nameWrath = " & boss.BossNameWrath & ",")
                            End If

                            If expansion.ExpansionID = 3 Or expansion.ExpansionID = 4 Then
                                If boss.ClassicTactics.Length > 1 Then
                                    writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "tacticsClassic = " & boss.ClassicTactics & ",")
                                Else
                                    writer.WriteLine(vbTab & vbTab & vbTab & vbTab & vbTab & "tacticsClassic = """",")
                                End If
                            End If

                            writer.WriteLine(vbTab & vbTab & vbTab & vbTab & "},")

                            'Check if localisation is new
                            Dim localeFound = False
                            For Each locale In LocalisationDB
                                If boss.Tactics.Contains(locale.Name) Then
                                    localeFound = True
                                End If
                            Next
                            If localeFound = False Then
                                Dim newLocale As New Localisation
                                newLocale.Name = boss.Tactics.Replace("L[""", "").Replace("""]", "")
                                newLocale.Text = ""
                                LocalisationDB.Add(newLocale)
                            End If
                        Next
                        writer.WriteLine(vbTab & vbTab & vbTab & "},")
                    Next
                    writer.WriteLine(vbTab & vbTab & "},")
                    firstInstance = False
                Next
                writer.WriteLine(vbTab & "},")
            Next
            writer.WriteLine("}")
        End Using

        'Generate Localization.enUS.lua
        File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua", "Backup\Localization.enUS.lua" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua") = True Then
            File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua")
        End If
        Using writer As StreamWriter = New StreamWriter("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua", True)
            writer.WriteLine("local _, core = ...")
            writer.WriteLine("local baseLocale = {")
            For Each locale In LocalisationDB
                writer.WriteLine(vbTab & "[""" & locale.Name & """] = """ & locale.Text & """,")
            Next
            writer.WriteLine("}")
            writer.Write("core:RegisterLocale('enUS', baseLocale)")
        End Using

        'Generate NPCCache.lua
        File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua", "Backup\NPCCache.lua" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua") = True Then
            File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua")
        End If
        Using writer As StreamWriter = New StreamWriter("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua", True)
            writer.WriteLine("local _, core = ...")
            writer.WriteLine()
            writer.WriteLine("core.NPCCache = {")
            For Each npc In NPCCacheDB
                writer.WriteLine(vbTab & "[" & npc.id & "] =" & npc.id & ", --" & npc.name)
            Next
            writer.Write("}")

            writer.WriteLine()
            writer.WriteLine("core.NPCCacheClassic = {")
            For Each npc In NPCCacheClassicDB
                writer.WriteLine(vbTab & "[" & npc.id & "] =" & npc.id & ", --" & npc.name)
            Next
            writer.Write("}")
        End Using

        'Generate ItemCache.lua
        File.Copy("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua", "Backup\ItemCache.lua" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv")
        If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua") = True Then
            File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua")
        End If
        Using writer As StreamWriter = New StreamWriter("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua", True)
            writer.WriteLine("local _, core = ...")
            writer.WriteLine()
            writer.WriteLine("core.ItemCache = {")
            For Each item In ItemCacheDB
                writer.WriteLine(vbTab & "[" & item.ID & "] = " & item.ID & ", --" & item.Name)
            Next
            writer.Write("}")
        End Using

        MsgBox("Save Successful")
    End Sub

    Private Async Sub btnUploadLocale_Click(sender As Object, e As EventArgs) Handles btnUploadLocale.Click
        LoadWebsite("https://www.curseforge.com/wow/addons/instance-achievement-tracker/localization/languages/92/phrases#0")

        Await Task.Delay(5000)

        Dim script = "document.querySelector('.button.create-phrase').click();"
        WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        'Add Name
        script = "document.getElementById('field-phrase-name').value =""" & txtLocaleString.Text.Replace("""", """""") & """"
        WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        'Add Context
        Dim context = txtContext.Text.Replace("""", "&quot").Replace("\n", "\\n")
        script = "document.getElementById('field-phrase-context').value =""" & context & """"
        WebView2.ExecuteScriptAsync(script)
        Await Task.Delay(1000)
        script = "document.getElementById('field-phrase-context').value = document.getElementById('field-phrase-context').value.split('&quot').join('""')"
        WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        'Add String
        Dim tacticslocale = txtTacticsLocale.Text.Replace("""", "&quot").Replace("\n", "\\n")
        script = "document.getElementById('field-phrase-default-translation').value =""" & tacticslocale & """"
        WebView2.ExecuteScriptAsync(script)
        Await Task.Delay(1000)
        script = "document.getElementById('field-phrase-default-translation').value = document.getElementById('field-phrase-default-translation').value.split('&quot').join('""')"
        WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        save()
    End Sub

    Private Sub frmIATDatabaseManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        WebView2.Dispose()
    End Sub

    'Private Sub cboSpell_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Try
    '        Console.WriteLine(cboSpell.Text.ToString())
    '        Console.WriteLine(cboSpell.SelectedValue)

    '        txtNewTactics.Text += " {" & cboSpell.SelectedValue & "|" & cboSpell.Text.ToString() & "} "
    '        chromeBrowser.Load("https://wowhead.com/spell=" & cboSpell.SelectedValue)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub NPCsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NPCsToolStripMenuItem.Click
        'Insert NPC's

        'Using reader As StreamReader = New StreamReader("C:\Program Files (x86)\World of Warcraft\_retail_\WTF\Account\DRAGNOG657\SavedVariables\NPCDump.lua")
        '    Dim line = reader.ReadLine

        '    While Not line Is Nothing
        '        If line.Contains("=") Then
        '            Dim strArr() As String = line.Split("=")
        '            Dim NewNPC = New NPC
        '            NewNPC.Name = strArr(1).Trim().Trim(",".ToCharArray()).Trim("""".ToCharArray())
        '            NewNPC.ID = strArr(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")

        '            Dim dt As DataTable = New DataTable()
        '            Dim dc As DataColumn = New DataColumn("ID", GetType(String))
        '            dt.Columns.Add(dc)
        '            dc = New DataColumn("Name", GetType(String))
        '            dt.Columns.Add(dc)
        '            Dim dr As DataRow = dt.NewRow()
        '            dr(0) = NewNPC.ID
        '            dr(1) = NewNPC.Name

        '            dt.Rows.Add(dr)

        '            '            Using writer As StreamWriter = New StreamWriter("NPCDB.csv", True)
        '            '                writer.WriteLine(NewNPC.Name & ";" & NewNPC.ID)
        '            '            End Using
        '        End If
        '        line = reader.ReadLine
        '    End While
        'End Using
        MsgBox("Complete")
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
        'Found a spell
        If WebView2.CoreWebView2.Source.ToString.Contains("https://www.wowhead.com/spell=") Then
            Dim address = WebView2.CoreWebView2.Source.ToString.Replace("https://www.wowhead.com/spell=", "").Split("/")(0)
            'Dim address = chromeBrowser.Address.Replace("https://www.wowhead.com/spell=", "").Split("/")(0)
            Clipboard.SetText("[" & address & "|" & txtSpellName.Text & "]")

            Dim IDFoundInCache = False
            Using reader As StreamReader = New StreamReader("SpellIDS.csv")
                Dim line = reader.ReadLine

                While Not line Is Nothing
                    If line.Contains(address) Then
                        IDFoundInCache = True
                    End If
                    line = reader.ReadLine
                End While
            End Using

            If IDFoundInCache = False Then
                Using writer As StreamWriter = New StreamWriter("SpellIDS.csv", True)
                    writer.WriteLine(address & "," & txtSpellName.Text)
                End Using
            End If
        ElseIf WebView2.CoreWebView2.Source.ToString.Contains("https://www.wowhead.com/item=") Then
            Dim address = WebView2.CoreWebView2.Source.ToString.Replace("https://www.wowhead.com/item=", "").Split("/")(0)
            Clipboard.SetText("[ITEM_" & address & "|" & txtSpellName.Text & "]")

            Dim IDFoundInCache = False
            Using reader As StreamReader = New StreamReader("ItemIDS.csv")
                Dim line = reader.ReadLine

                While Not line Is Nothing
                    If line.Contains(address) Then
                        IDFoundInCache = True
                    End If
                    line = reader.ReadLine
                End While
            End Using

            If IDFoundInCache = False Then
                Using writer As StreamWriter = New StreamWriter("ItemIDS.csv", True)
                    writer.WriteLine(address & "," & txtSpellName.Text)
                End Using
            End If
        End If

        LoadWebsite("https://www.wowhead.com/achievement=" & txtAchievement.Text & "#comments")
    End Sub

    Private Sub txtSpellName_Enter(sender As Object, e As EventArgs) Handles txtSpellName.Enter
        LoadWebsite("https://www.wowhead.com/search?q=" & txtSpellName.Text)
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        LoadWebsite("https://www.wowhead.com/achievement=" & txtAchievement.Text)
    End Sub

    Private Sub btnGenerateLocaleNoUpload_Click(sender As Object, e As EventArgs) Handles btnGenerateLocaleNoUpload.Click
        txtTacticsLocale.Text = ""
        txtTactics.Text = ""

        Dim NPCName = ""
        Dim InsideNPC = False
        Dim InsideSpell = False
        Dim SpellName = ""
        Dim FormatStarted = False
        Dim WebpageString = ""
        Dim StopString = False
        Dim NewLineFound = False
        For Each c As Char In txtNewTactics.Text
            If c = "{" Then
                'Start of NPC name
                InsideNPC = True
            ElseIf c = "}" Then
                'End of NPC name
                For Each NPC In NPCDB
                    If NPC.ID = NPCName Then
                        txtTacticsLocale.Text += "%s"
                        WebpageString += NPC.Name

                        'Add to cache if needed
                        Dim foundNPC = False
                        For Each npc2 As NPCCache In NPCCacheDB
                            If npc2.ID = NPC.ID Then
                                foundNPC = True
                            End If
                        Next

                        If foundNPC = False Then
                            Dim NewNPC = New NPCCache
                            NewNPC.Name = NPC.Name
                            NewNPC.ID = NPC.ID
                            NPCCacheDB.add(NewNPC)
                            Console.WriteLine("Added: " & NPC.Name)
                        End If

                        If FormatStarted = False Then
                            FormatStarted = True
                            txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], ""IAT_" & NPC.ID & """"
                            Exit For
                        Else
                            txtTactics.Text += ", ""IAT_" & NPC.ID & """"
                            Exit For
                        End If
                    End If
                Next

                InsideNPC = False
                NPCName = ""
                StopString = False
            ElseIf c = "|" Then
                StopString = True
            ElseIf c = "[" Then
                'Start of Spell name
                InsideSpell = True
            ElseIf c = "]" Then
                'End of spell/item name
                txtTacticsLocale.Text += "%s"

                If SpellName.Contains("ITEM_") Then
                    Dim ItemID = SpellName.Replace("ITEM_", "")
                    WebpageString += "[" & GetItemName(ItemID) & "]"

                    If FormatStarted = False Then
                        FormatStarted = True
                        txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], ""IAT_" & ItemID & """"
                        'Exit For
                    Else
                        txtTactics.Text += ", ""IAT_" & ItemID & """"
                        'Exit For
                    End If

                    'Add to cache if needed
                    Dim foundItem = False
                    For Each item2 As ItemCache In ItemCacheDB
                        If item2.ID = ItemID Then
                            foundItem = True
                        End If
                    Next

                    If foundItem = False Then
                        Dim NewItem = New ItemCache
                        NewItem.Name = GetItemName(ItemID)
                        NewItem.ID = ItemID
                        ItemCacheDB.Add(NewItem)
                    End If
                Else
                    WebpageString += "[" & GetSpellName(SpellName) & "]"

                    If FormatStarted = False Then
                        FormatStarted = True
                        txtTactics.Text = "format(L[""" & txtLocaleString.Text & """], C_Spell.GetSpellLink(" & SpellName & ")"
                        'Exit For
                    Else
                        txtTactics.Text += ", C_Spell.GetSpellLink(" & SpellName & ")"
                        'Exit For
                    End If
                End If

                InsideSpell = False
                SpellName = ""
                StopString = False
            ElseIf InsideSpell Then
                If StopString = False Then
                    SpellName += c
                End If
            ElseIf InsideNPC Then
                If StopString = False Then
                    NPCName += c
                End If
            ElseIf c = "\" Then
                NewLineFound = True
            ElseIf NewLineFound Then
                If c = "n" Then
                    txtTacticsLocale.Text += "\n"
                    WebpageString += vbNewLine
                    NewLineFound = False
                End If
            Else
                txtTacticsLocale.Text += c
                WebpageString += c
            End If
        Next
        If FormatStarted Then
            txtTactics.Text += ")"
        Else
            txtTactics.Text = "L[""" & txtLocaleString.Text & """]"
        End If

        txtInGame.Text = WebpageString.Replace("%%", "%")
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
        Dim result = WebView2.ExecuteScriptAsync(script)
        ResponsiveSleep(2000)
        Using writer As StreamWriter = New StreamWriter("ItemIDS.csv", True)
            writer.WriteLine(ItemID & "," & result.Result.Split("\u003")(0).Trim("""").Trim())
        End Using
        Return result.Result.Split("\u003")(0).Trim("""").Trim()
        CheckingSpellName = True
    End Function

    Private Sub LocalisationManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocalisationManagerToolStripMenuItem.Click
        LocalisationImporter.Show()
        LocalisationImporter.Import()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'If PreviousSites.Count > 0 Then
        '    Console.WriteLine("Going back to: " & PreviousSites(PreviousSites.Count))
        '    LoadWebsite(PreviousSites(PreviousSites.Count))
        '    PreviousSites.RemoveAt(PreviousSites.Count)
        'Else
        '    Console.WriteLine("Cannot go back")
        'End If
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
        Dim result = WebView2.ExecuteScriptAsync(script)
        ResponsiveSleep(2000)
        Using writer As StreamWriter = New StreamWriter("SpellIDS.csv", True)
            writer.WriteLine(spellId & "," & result.Result.Split("\u003")(0).Trim("""").Trim())
        End Using
        Return result.Result.Split("\u003")(0).Trim("""").Trim()
        CheckingSpellName = True
    End Function

    Private Sub txtSpellName_TextChanged(sender As Object, e As EventArgs) Handles txtSpellName.TextChanged
        LoadWebsite("https://www.wowhead.com/search?q=" & txtSpellName.Text)
    End Sub

    Private Sub btnTestTranslationClassic_Click(sender As Object, e As EventArgs) Handles btnTestTranslationClassic.Click
        txtTacticsLocaleClassic.Text = ""
        txtClassicTactics.Text = ""

        Dim NPCName = ""
        Dim InsideNPC = False
        Dim InsideSpell = False
        Dim SpellName = ""
        Dim FormatStarted = False
        Dim WebpageString = ""
        Dim StopString = False
        Dim NewLineFound = False
        For Each c As Char In txtNewTacticsClassic.Text
            If c = "{" Then
                'Start of NPC name
                InsideNPC = True
            ElseIf c = "}" Then
                'End of NPC name
                For Each NPC In NPCDB
                    If NPC.ID = NPCName Then
                        txtTacticsLocaleClassic.Text += "%s"
                        WebpageString += NPC.Name

                        'Add to cache if needed
                        Dim foundNPC = False
                        For Each npc2 As NPCCache In NPCCacheClassicDB
                            If npc2.ID = NPC.ID Then
                                foundNPC = True
                            End If
                        Next

                        If foundNPC = False Then
                            Dim NewNPC = New NPCCache
                            NewNPC.Name = NPC.Name
                            NewNPC.ID = NPC.ID
                            NPCCacheClassicDB.add(NewNPC)
                            Console.WriteLine("Added: " & NPC.Name)
                        End If

                        If FormatStarted = False Then
                            FormatStarted = True
                            txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], ""IAT_" & NPC.ID & """"
                            Exit For
                        Else
                            txtClassicTactics.Text += ", ""IAT_" & NPC.ID & """"
                            Exit For
                        End If
                    End If
                Next

                InsideNPC = False
                NPCName = ""
                StopString = False
            ElseIf c = "|" Then
                StopString = True
            ElseIf c = "[" Then
                'Start of Spell name
                InsideSpell = True
            ElseIf c = "]" Then
                'End of spell/item name
                txtTacticsLocaleClassic.Text += "%s"

                If SpellName.Contains("ITEM_") Then
                    Dim ItemID = SpellName.Replace("ITEM_", "")
                    WebpageString += "[" & GetItemName(ItemID) & "]"

                    If FormatStarted = False Then
                        FormatStarted = True
                        txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], ""IAT_" & ItemID & """"
                        'Exit For
                    Else
                        txtClassicTactics.Text += ", ""IAT_" & ItemID & """"
                        'Exit For
                    End If

                    'Add to cache if needed
                    Dim foundItem = False
                    For Each item2 As ItemCache In ItemCacheDB
                        If item2.ID = ItemID Then
                            foundItem = True
                        End If
                    Next

                    If foundItem = False Then
                        Dim NewItem = New ItemCache
                        NewItem.Name = GetItemName(ItemID)
                        NewItem.ID = ItemID
                        ItemCacheDB.Add(NewItem)
                    End If
                Else
                    WebpageString += "[" & GetSpellName(SpellName) & "]"

                    If FormatStarted = False Then
                        FormatStarted = True
                        txtClassicTactics.Text = "format(L[""" & txtLocaleStringClassic.Text & """], C_Spell.GetSpellLink(" & SpellName & ")"
                        'Exit For
                    Else
                        txtClassicTactics.Text += ", C_Spell.GetSpellLink(" & SpellName & ")"
                        'Exit For
                    End If
                End If

                InsideSpell = False
                SpellName = ""
                StopString = False
            ElseIf InsideSpell Then
                If StopString = False Then
                    SpellName += c
                End If
            ElseIf InsideNPC Then
                If StopString = False Then
                    NPCName += c
                End If
            ElseIf c = "\" Then
                NewLineFound = True
            ElseIf NewLineFound Then
                If c = "n" Then
                    txtTacticsLocaleClassic.Text += "\n"
                    WebpageString += vbNewLine
                    NewLineFound = False
                End If
            Else
                txtTacticsLocaleClassic.Text += c
                WebpageString += c
            End If
        Next
        If FormatStarted Then
            txtClassicTactics.Text += ")"
        Else
            txtClassicTactics.Text = "L[""" & txtLocaleStringClassic.Text & """]"
        End If

        txtInGameClassic.Text = WebpageString.Replace("%%", "%")
    End Sub

    Private Async Sub btnUploadLocaleClassic_Click(sender As Object, e As EventArgs) Handles btnUploadLocaleClassic.Click
        LoadWebsite("https://www.curseforge.com/wow/addons/instance-achievement-tracker/localization/languages/92/phrases#0")

        Await Task.Delay(5000)

        Dim script = "document.querySelector('.button.create-phrase').click();"
        WebView2.ExecuteScriptAsync(script)
        'chromeBrowser.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        'Add Name
        script = "document.getElementById('field-phrase-name').value =""" & txtLocaleStringClassic.Text.Replace("""", """""") & """"
        WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        'Add Context
        Dim context = txtContext.Text.Replace("""", "&quot").Replace("\n", "\\n")
        script = "document.getElementById('field-phrase-context').value =""" & context & """"
        WebView2.ExecuteScriptAsync(script)
        Await Task.Delay(1000)
        script = "document.getElementById('field-phrase-context').value = document.getElementById('field-phrase-context').value.split('&quot').join('""')"
        WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        'Add String
        Dim tacticslocale = txtTacticsLocaleClassic.Text.Replace("""", "&quot").Replace("\n", "\\n")
        script = "document.getElementById('field-phrase-default-translation').value =""" & tacticslocale & """"
        WebView2.ExecuteScriptAsync(script)
        Await Task.Delay(1000)
        script = "document.getElementById('field-phrase-default-translation').value = document.getElementById('field-phrase-default-translation').value.split('&quot').join('""')"
        WebView2.ExecuteScriptAsync(script)

        Await Task.Delay(1000)

        save()
    End Sub
End Class
