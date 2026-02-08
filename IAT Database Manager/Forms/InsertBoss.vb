Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net

Public Class InsertBoss
    Public LastClipboard As String = ""
    Public LastBoss As Integer = 1
    Private wagoBossData As New Dictionary(Of String, Dictionary(Of String, String))
    Private wagoAchievementData As New Dictionary(Of String, Dictionary(Of String, String))
    Private currentInstanceNameID As String = ""
    Private currentInstanceID As Integer = 0
    Private isEditMode As Boolean = False
    Private editingBossId As Integer = 0
    Private isLoadingBoss As Boolean = False

    Private Sub txtLuaImport_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer)
        Dim i As Integer, iHalfSeconds As Integer = iMilliSeconds / 500
        For i = 1 To iHalfSeconds
            Threading.Thread.Sleep(500) : Application.DoEvents()
        Next i
    End Sub

    Private Sub InsertBoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using db As New IATDbContext()
            For Each instance In db.Instances.OrderBy(Function(i) i.Name).ToList()
                cboSelectInstance.Items.Add(instance.Name)
            Next
        End Using

        LoadWagoBossData()
        LoadWagoAchievementData()
        UpdateButtonText()
    End Sub

    Private Sub UpdateButtonText()
        btnAddInstance.Text = If(isEditMode, "Update Boss", "Add Boss")
    End Sub

    Public Sub LoadBossForEdit(bossId As Integer)
        isLoadingBoss = True

        Using db As New IATDbContext()
            Dim boss = db.Bosses.Find(bossId)
            If boss IsNot Nothing Then
                ' Ensure instances are loaded in the combo box
                If cboSelectInstance.Items.Count = 0 Then
                    For Each instance In db.Instances.OrderBy(Function(i) i.Name).ToList()
                        cboSelectInstance.Items.Add(instance.Name)
                    Next
                End If

                ' Ensure Wago data is loaded
                If wagoBossData.Count = 0 Then
                    LoadWagoBossData()
                End If
                If wagoAchievementData.Count = 0 Then
                    LoadWagoAchievementData()
                End If

                ' Step 1: Select the instance in the dropdown (this will trigger cboSelectInstance_SelectedIndexChanged)
                For i As Integer = 0 To cboSelectInstance.Items.Count - 1
                    If cboSelectInstance.Items(i).ToString() = boss.Instance.Name Then
                        cboSelectInstance.SelectedIndex = i
                        Application.DoEvents() ' Allow UI to process the event
                        Exit For
                    End If
                Next

                ' Step 2: Select the boss in the dropdown (this will trigger cboSelectBoss_SelectedIndexChanged)
                ' which will automatically populate all form fields
                For i As Integer = 0 To cboSelectBoss.Items.Count - 1
                    If cboSelectBoss.Items(i).ToString() = boss.BossName Then
                        cboSelectBoss.SelectedIndex = i
                        Application.DoEvents() ' Allow UI to process the event
                        Exit For
                    End If
                Next

                ' Now set edit mode AFTER the boss has been selected and populated
                ' This prevents the event handler from overwriting our edit mode
                isEditMode = True
                editingBossId = bossId
                UpdateButtonText()

                ' Step 3: Select the achievement if applicable
                If boss.AchievementID > 0 Then
                    For Each kvp In wagoAchievementData
                        Dim achievementData = kvp.Value
                        If achievementData("ID") = boss.AchievementID.ToString() AndAlso achievementData("InstanceID") = boss.Instance.InstanceId.ToString() Then
                            For i As Integer = 0 To cboSelectAchievement.Items.Count - 1
                                If cboSelectAchievement.Items(i).ToString() = achievementData("Title") Then
                                    cboSelectAchievement.SelectedIndex = i
                                    Application.DoEvents() ' Allow UI to process the event
                                    Exit For
                                End If
                            Next
                            Exit For
                        End If
                    Next
                End If

                isLoadingBoss = False

                ' Now set edit mode
                isEditMode = True
                editingBossId = bossId
                UpdateButtonText()

                txtStatus.Text = "Loaded boss for editing: " & boss.BossName
            Else
                isLoadingBoss = False
            End If
        End Using
    End Sub

    Private Sub LoadWagoAchievementData()
        Try
            Dim url As String = "https://wago.tools/db2/Achievement/csv"
            Dim webClient As New WebClient()
            Dim csvData As String = webClient.DownloadString(url)

            Dim lines() As String = csvData.Split(New String() {vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

            wagoAchievementData.Clear()

            For i As Integer = 1 To lines.Length - 1
                Dim line As String = lines(i)
                Dim fields() As String = ParseCsvLine(line)

                If fields.Length >= 5 Then
                    Dim achievementTitle As String = fields(1)
                    Dim achievementID As String = fields(3)
                    Dim instanceID As String = fields(4)

                    Dim key As String = instanceID & "_" & achievementID

                    Dim achievementDataDict As New Dictionary(Of String, String)
                    achievementDataDict("Title") = achievementTitle
                    achievementDataDict("ID") = achievementID
                    achievementDataDict("InstanceID") = instanceID
                    If fields.Length > 0 Then achievementDataDict("Description") = fields(0)

                    wagoAchievementData(key) = achievementDataDict
                End If
            Next
        Catch ex As Exception
            txtStatus.Text = "Error loading achievement data: " & ex.Message
        End Try
    End Sub

    Private Sub LoadWagoBossData()
        Try
            Dim url As String = "https://wago.tools/db2/JournalEncounter/csv"
            Dim webClient As New WebClient()
            Dim csvData As String = webClient.DownloadString(url)

            Dim lines() As String = csvData.Split(New String() {vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

            wagoBossData.Clear()

            For i As Integer = 1 To lines.Length - 1
                Dim line As String = lines(i)
                Dim fields() As String = ParseCsvLine(line)

                If fields.Length >= 8 Then
                    Dim bossName As String = fields(0)
                    Dim bossID As String = fields(4)
                    Dim journalInstanceID As String = fields(5)
                    Dim dungeonEncounterID As String = fields(6)
                    Dim orderIndex As String = fields(7)

                    Dim key As String = journalInstanceID & "_" & bossID

                    Dim bossDataDict As New Dictionary(Of String, String)
                    bossDataDict("Name") = bossName
                    bossDataDict("ID") = bossID
                    bossDataDict("JournalInstanceID") = journalInstanceID
                    bossDataDict("DungeonEncounterID") = dungeonEncounterID
                    bossDataDict("OrderIndex") = orderIndex

                    wagoBossData(key) = bossDataDict
                End If
            Next
        Catch ex As Exception
            txtStatus.Text = "Error loading boss data: " & ex.Message
        End Try
    End Sub

    Private Function ParseCsvLine(line As String) As String()
        Dim fields As New List(Of String)
        Dim inQuotes As Boolean = False
        Dim field As String = ""

        For Each c As Char In line
            If c = """"c Then
                inQuotes = Not inQuotes
            ElseIf c = ","c AndAlso Not inQuotes Then
                fields.Add(field.Trim(""""c))
                field = ""
            Else
                field &= c
            End If
        Next

        fields.Add(field.Trim(""""c))
        Return fields.ToArray()
    End Function

    Private Sub LoadBossesForInstance(instanceNameID As String)
        cboSelectBoss.Items.Clear()
        currentInstanceNameID = instanceNameID

        Dim bossesList As New List(Of KeyValuePair(Of Integer, String))

        For Each kvp In wagoBossData
            Dim bossData = kvp.Value
            If bossData("JournalInstanceID") = instanceNameID Then
                Dim orderIndex As Integer = Integer.Parse(bossData("OrderIndex"))
                bossesList.Add(New KeyValuePair(Of Integer, String)(orderIndex, bossData("Name")))
            End If
        Next

        bossesList.Sort(Function(x, y) x.Key.CompareTo(y.Key))

        For Each boss In bossesList
            cboSelectBoss.Items.Add(boss.Value)
        Next

        If cboSelectBoss.Items.Count > 0 Then
            txtStatus.Text = "Loaded " & cboSelectBoss.Items.Count & " bosses for selected instance"
        End If
    End Sub

    Private Sub LoadAchievementsForInstance(instanceID As Integer)
        cboSelectAchievement.Items.Clear()

        Dim achievementsList As New List(Of KeyValuePair(Of String, String))

        For Each kvp In wagoAchievementData
            Dim achievementData = kvp.Value
            If achievementData("InstanceID") = instanceID.ToString() Then
                achievementsList.Add(New KeyValuePair(Of String, String)(achievementData("ID"), achievementData("Title")))
            End If
        Next

        achievementsList = achievementsList.OrderBy(Function(a) a.Value).ToList()

        For Each achievement In achievementsList
            cboSelectAchievement.Items.Add(achievement.Value)
        Next

        If cboSelectAchievement.Items.Count > 0 Then
            txtStatus.Text = "Loaded " & cboSelectAchievement.Items.Count & " achievements for instance ID " & instanceID
        Else
            txtStatus.Text = "No achievements found for instance ID " & instanceID
        End If
    End Sub

    Private Function FormatTactics(instanceName As String, bossName As String) As String
        Dim cleanInstanceName As String = instanceName.Replace(" ", "").Replace("'", "")
        Dim cleanBossName As String = bossName.Replace(" ", "").Replace("'", "")

        cleanInstanceName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cleanInstanceName.ToLower())
        cleanBossName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cleanBossName.ToLower())

        Return "L[""" & cleanInstanceName & "_" & cleanBossName & """] = """""
    End Function

    Private Sub cboSelectBoss_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectBoss.SelectedIndexChanged
        If cboSelectBoss.SelectedItem IsNot Nothing Then
            Dim selectedBoss As String = cboSelectBoss.SelectedItem.ToString()

            For Each kvp In wagoBossData
                Dim bossData = kvp.Value
                If bossData("Name") = selectedBoss AndAlso bossData("JournalInstanceID") = currentInstanceNameID Then
                    Dim orderIndex As Integer = Integer.Parse(bossData("OrderIndex"))
                    Dim bossNameID As Integer = Integer.Parse(bossData("ID"))

                    ' First, check if this boss already exists in the database
                    Dim existingBoss As Boss = Nothing
                    Using db As New IATDbContext()
                        Dim selectedInstanceName As String = cboSelectInstance.SelectedItem?.ToString()
                        If Not String.IsNullOrEmpty(selectedInstanceName) Then
                            Dim instance = db.Instances.FirstOrDefault(Function(i) i.Name = selectedInstanceName)
                            If instance IsNot Nothing Then
                                existingBoss = db.Bosses.FirstOrDefault(Function(b) b.BossNameID = bossNameID AndAlso b.InstanceId = instance.Id)
                            End If
                        End If
                    End Using

                    ' If boss exists, load existing data, otherwise use wago defaults
                    If existingBoss IsNot Nothing Then
                        ' Load existing data - but don't override if we're already loading
                        If Not isLoadingBoss Then
                            isEditMode = True
                            editingBossId = existingBoss.Id
                            UpdateButtonText()
                        End If

                        txtIndex.Text = "boss" & existingBoss.Order
                        txtBossName.Text = If(String.IsNullOrWhiteSpace(existingBoss.BossName), bossData("Name"), existingBoss.BossName)
                        txtNameID.Text = If(existingBoss.BossNameID = 0, bossData("ID"), existingBoss.BossNameID.ToString())
                        txtBossIDs.Text = If(String.IsNullOrWhiteSpace(existingBoss.BossIDs), "{}", existingBoss.BossIDs)
                        txtPlayers.Text = "{}"
                        txtEnabled.Text = existingBoss.Enabled.ToString().ToLower()
                        txtTrack.Text = If(String.IsNullOrWhiteSpace(existingBoss.Track), "nil", existingBoss.Track)
                        txtTactics.Text = FormatTactics(cboSelectInstance.SelectedItem.ToString(), bossData("Name"))
                        txtPartial.Text = If(existingBoss.PartialTrack, "true", "")
                        txtEncounterID.Text = If(existingBoss.EncounterID = 0, bossData("DungeonEncounterID"), existingBoss.EncounterID.ToString())
                        txtInfoFrame.Text = existingBoss.DisplayInfoFrame.ToString().ToLower()
                        txtAchievement.Text = If(existingBoss.AchievementID = 0, "", existingBoss.AchievementID.ToString())
                        chkRestrictions.Checked = existingBoss.NotTrackableDueToRestrictions

                        LastBoss = existingBoss.Order
                        txtStatus.Text = "Loaded existing boss: " & selectedBoss
                    Else
                        ' Use wago defaults for new boss
                        isEditMode = False
                        editingBossId = 0
                        UpdateButtonText()

                        txtIndex.Text = "boss" & orderIndex + 1
                        txtBossName.Text = bossData("Name")
                        txtNameID.Text = bossData("ID")
                        txtBossIDs.Text = "{}"
                        txtPlayers.Text = "{}"
                        txtEnabled.Text = "false"
                        txtTrack.Text = "nil"
                        txtTactics.Text = FormatTactics(cboSelectInstance.SelectedItem.ToString(), bossData("Name"))
                        txtPartial.Text = ""
                        txtEncounterID.Text = bossData("DungeonEncounterID")
                        txtInfoFrame.Text = "false"
                        txtAchievement.Text = ""
                        chkRestrictions.Checked = False

                        LastBoss = orderIndex
                        txtStatus.Text = "New boss selected: " & selectedBoss
                    End If

                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cboSelectAchievement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectAchievement.SelectedIndexChanged
        If cboSelectAchievement.SelectedItem IsNot Nothing Then
            Dim selectedAchievementTitle As String = cboSelectAchievement.SelectedItem.ToString()

            For Each kvp In wagoAchievementData
                Dim achievementData = kvp.Value
                If achievementData("Title") = selectedAchievementTitle AndAlso achievementData("InstanceID") = currentInstanceID.ToString() Then
                    txtAchievement.Text = achievementData("ID")
                    txtStatus.Text = "Selected achievement: " & selectedAchievementTitle & " (ID: " & achievementData("ID") & ")"
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Clipboard.GetText <> LastClipboard Then
            txtLuaImport.Text = Clipboard.GetText
            LastClipboard = Clipboard.GetText
            Console.WriteLine("Added New Text")

            Try
                Dim Line = 1
                Dim RunStarted = False
                For Each strLine As String In txtLuaImport.Text.Split(vbNewLine)
                    If Line = 1 Then
                        txtIndex.Text = strLine.Replace(" = {", "").Trim()
                        Line += 1
                    ElseIf Line > 1 Then
                        If strLine.Contains("name =") Then
                            If strLine.Contains("Instances_Other") Then
                                txtBossName.Text = strLine.Split(",")(1).Replace("--", "").Trim()
                                txtNameID.Text = "L[""Instances_Other""]"
                            Else
                                Dim InstanceName = strLine.Split(",")(1).Replace("--", "").Trim()
                                Dim regex As Regex = New Regex("[0-9]+")
                                Dim match As Match = regex.Match(strLine)

                                txtBossName.Text = strLine.Split(",")(1).Replace("--", "").Trim()
                                txtNameID.Text = match.Value
                            End If

                        ElseIf strLine.Contains("bossIDs =") Then
                            txtBossIDs.Text = strLine.Replace("bossIDs = ", "").Trim().Trim(",".ToCharArray())
                            'txtBossIDs.Text.Remove(txtBossIDs.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("achievement =") Then
                            txtAchievement.Text = strLine.Replace("achievement = ", "").Trim().Trim(",".ToCharArray())
                            'txtAchievement.Text.Remove(txtAchievement.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("players =") Then
                            txtPlayers.Text = strLine.Replace("players = ", "").Trim().Trim(",".ToCharArray())
                            'txtPlayers.Text.Remove(txtPlayers.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("tactics =") Then
                            txtTactics.Text = strLine.Replace("tactics = ", "").Trim().Trim(",".ToCharArray())
                            'txtTactics.Text.Remove(txtTactics.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("enabled =") Then
                            txtEnabled.Text = strLine.Replace("enabled = ", "").Trim().Trim(",".ToCharArray())
                            'txtEnabled.Text.Remove(txtEnabled.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("track =") Then
                            txtTrack.Text = strLine.Replace("track = ", "").Trim().Trim(",".ToCharArray())
                            'txtTrack.Text.Remove(txtTrack.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("partial =") Then
                            txtPartial.Text = strLine.Replace("partial = ", "").Trim().Trim(",".ToCharArray())
                            'txtPartial.Text.Remove(txtPartial.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("encounterID =") Then
                            txtEncounterID.Text = strLine.Replace("encounterID = ", "").Trim().Trim(",".ToCharArray())
                            'txtEncounterID.Text.Remove(txtEncounterID.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("displayInfoFrame =") Then
                            txtInfoFrame.Text = strLine.Replace("displayInfoFrame = ", "").Trim().Trim(",".ToCharArray())
                            'txtInfoFrame.Text.Remove(txtInfoFrame.Text.LastIndexOf(","))
                        ElseIf strLine.Contains("},") Then
                            Line = 1

                            Using writer As StreamWriter = New StreamWriter("bossesDB.csv", True)
                                writer.WriteLine(txtIndex.Text & ";" & txtBossName.Text & ";" & txtNameID.Text & ";" & txtBossIDs.Text & ";" & txtAchievement.Text & ";" & txtPlayers.Text & ";" & txtTactics.Text & ";" & txtEnabled.Text & ";" & txtTrack.Text & ";" & txtPartial.Text & ";" & txtEncounterID.Text & ";" & txtInfoFrame.Text & ";" & cboSelectInstance.SelectedItem)
                                txtStatus.Text = "Added: " & txtBossName.Text
                            End Using

                            ResponsiveSleep(1000)

                            txtIndex.Text = ""
                            txtBossName.Text = ""
                            txtNameID.Text = ""
                            txtBossIDs.Text = ""
                            txtAchievement.Text = ""
                            txtPlayers.Text = ""
                            txtTactics.Text = ""
                            txtEnabled.Text = ""
                            txtTrack.Text = ""
                            txtPartial.Text = ""
                            txtEncounterID.Text = ""
                            txtInfoFrame.Text = "false"

                            RunStarted = True
                        End If
                    End If
                Next

                If RunStarted = True Then
                    txtLuaImport.Text = ""
                    cboSelectInstance.SelectedIndex = cboSelectInstance.SelectedIndex + 1
                    RunStarted = False
                End If
            Catch ex As Exception
            End Try
        Else
            Console.WriteLine("No New Text")
        End If
    End Sub

    Private Sub btnAddInstance_Click(sender As Object, e As EventArgs) Handles btnAddInstance.Click
        Try
            Using db As New IATDbContext()
                Dim selectedInstanceName As String = cboSelectInstance.SelectedItem?.ToString()

                If String.IsNullOrEmpty(selectedInstanceName) Then
                    txtStatus.Text = "Error: Please select an instance"
                    Return
                End If

                Dim instance = db.Instances.FirstOrDefault(Function(i) i.Name = selectedInstanceName)

                If instance Is Nothing Then
                    txtStatus.Text = "Error: Instance not found in database"
                    Return
                End If

                Dim bossNameID As Integer = Integer.Parse(txtNameID.Text)

                ' Check if boss already exists in the database
                Dim existingBoss = db.Bosses.FirstOrDefault(Function(b) b.BossNameID = bossNameID AndAlso b.InstanceId = instance.Id)

                If existingBoss IsNot Nothing Then
                    ' Update existing boss
                    existingBoss.Order = Integer.Parse(txtIndex.Text.Replace("boss", ""))
                    existingBoss.BossName = txtBossName.Text
                    existingBoss.BossNameID = bossNameID
                    existingBoss.BossIDs = txtBossIDs.Text
                    existingBoss.AchievementID = If(String.IsNullOrWhiteSpace(txtAchievement.Text), 0, Integer.Parse(txtAchievement.Text))
                    existingBoss.Enabled = Boolean.Parse(txtEnabled.Text)
                    existingBoss.Track = txtTrack.Text
                    existingBoss.PartialTrack = Not String.IsNullOrWhiteSpace(txtPartial.Text)
                    existingBoss.EncounterID = If(String.IsNullOrWhiteSpace(txtEncounterID.Text), 0, Integer.Parse(txtEncounterID.Text))
                    existingBoss.DisplayInfoFrame = Boolean.Parse(txtInfoFrame.Text)
                    existingBoss.NotTrackableDueToRestrictions = chkRestrictions.Checked

                    ' Check if boss has a tactic, if not and tactics text is provided, create one
                    If existingBoss.Tactics.Count = 0 AndAlso Not String.IsNullOrWhiteSpace(txtTactics.Text) AndAlso txtTactics.Text <> """""" Then
                        ' Get expansion ID from the instance's InstanceType
                        Dim expansionId As Integer = instance.InstanceType.Expansion.ExpansionGameId

                        ' Construct localisation key
                        Dim rawKey = $"{instance.Name}_{existingBoss.BossName}_1"
                        Dim localeKey = Regex.Replace(rawKey, "[^a-zA-Z0-9_]", "")

                        ' Check if localisation already exists
                        Dim localisation = db.Localisations.FirstOrDefault(Function(l) l.Key = localeKey)
                        If localisation Is Nothing Then
                            localisation = New Localisation With {
                                .Key = localeKey,
                                .Value = ""
                            }
                            db.Localisations.Add(localisation)
                        End If

                        ' Create tactic
                        Dim tactic As New Tactic With {
                            .ExpansionId = expansionId,
                            .Localisation = localisation,
                            .Boss = existingBoss
                        }
                        existingBoss.Tactics.Add(tactic)

                        txtStatus.Text = "Updated boss: " & txtBossName.Text & " and added tactic for expansion " & expansionId
                    Else
                        txtStatus.Text = "Updated boss: " & txtBossName.Text
                    End If

                    db.SaveChanges()
                Else
                    ' Create new boss
                    Dim newBoss As New Boss With {
                        .Order = Integer.Parse(txtIndex.Text.Replace("boss", "")),
                        .BossName = txtBossName.Text,
                        .BossNameID = bossNameID,
                        .BossIDs = txtBossIDs.Text,
                        .AchievementID = If(String.IsNullOrWhiteSpace(txtAchievement.Text), 0, Integer.Parse(txtAchievement.Text)),
                        .Enabled = Boolean.Parse(txtEnabled.Text),
                        .Track = txtTrack.Text,
                        .PartialTrack = Not String.IsNullOrWhiteSpace(txtPartial.Text),
                        .EncounterID = If(String.IsNullOrWhiteSpace(txtEncounterID.Text), 0, Integer.Parse(txtEncounterID.Text)),
                        .DisplayInfoFrame = Boolean.Parse(txtInfoFrame.Text),
                        .NotTrackableDueToRestrictions = chkRestrictions.Checked,
                        .Instance = instance
                    }

                    ' Create a tactic if tactics text is provided
                    If Not String.IsNullOrWhiteSpace(txtTactics.Text) AndAlso txtTactics.Text <> """""" Then
                        ' Get expansion ID from the instance's InstanceType
                        Dim expansionId As Integer = instance.InstanceType.Expansion.ExpansionGameId

                        ' Construct localisation key
                        Dim rawKey = $"{instance.Name}_{newBoss.BossName}_1"
                        Dim localeKey = Regex.Replace(rawKey, "[^a-zA-Z0-9_]", "")

                        ' Check if localisation already exists
                        Dim localisation = db.Localisations.FirstOrDefault(Function(l) l.Key = localeKey)
                        If localisation Is Nothing Then
                            localisation = New Localisation With {
                                .Key = localeKey,
                                .Value = ""
                            }
                            db.Localisations.Add(localisation)
                        End If

                        ' Create tactic
                        Dim tactic As New Tactic With {
                            .ExpansionId = expansionId,
                            .Localisation = localisation,
                            .Boss = newBoss
                        }
                        newBoss.Tactics.Add(tactic)

                        txtStatus.Text = "Added new boss: " & txtBossName.Text & " with tactic for expansion " & expansionId
                    Else
                        txtStatus.Text = "Added new boss: " & txtBossName.Text & " (no tactic)"
                    End If

                    db.Bosses.Add(newBoss)
                    db.SaveChanges()
                End If

                txtBossName.Text = ""
                txtAchievement.Text = ""
                txtTactics.Text = ""
                txtEncounterID.Text = ""
                txtNameID.Text = ""

                LastBoss += 1
                txtIndex.Text = "boss" & LastBoss
            End Using
        Catch ex As Exception
            txtStatus.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub cboSelectInstance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectInstance.SelectedIndexChanged
        If isLoadingBoss Then
            Return
        End If

        LastBoss = 1
        txtIndex.Text = "boss" & LastBoss

        ' Reset boss and achievement comboboxes
        cboSelectBoss.SelectedIndex = -1
        cboSelectAchievement.SelectedIndex = -1

        ' Clear form fields since no boss is selected
        txtBossName.Text = ""
        txtNameID.Text = ""
        txtBossIDs.Text = "{}"
        txtPlayers.Text = "{}"
        txtEnabled.Text = "false"
        txtTrack.Text = "nil"
        txtTactics.Text = ""
        txtPartial.Text = ""
        txtEncounterID.Text = ""
        txtInfoFrame.Text = "false"
        txtAchievement.Text = ""
        chkRestrictions.Checked = False

        ' Reset edit mode
        isEditMode = False
        editingBossId = 0
        UpdateButtonText()

        Try
            Using db As New IATDbContext()
                Dim selectedInstanceName As String = cboSelectInstance.SelectedItem?.ToString()

                If String.IsNullOrEmpty(selectedInstanceName) Then
                    Return
                End If

                Dim instance = db.Instances.FirstOrDefault(Function(i) i.Name = selectedInstanceName)

                If instance IsNot Nothing Then
                    currentInstanceNameID = instance.InstanceNameID.ToString()
                    currentInstanceID = instance.InstanceId
                    LoadBossesForInstance(currentInstanceNameID)
                    LoadAchievementsForInstance(currentInstanceID)
                End If
            End Using
        Catch ex As Exception
            txtStatus.Text = "Error loading instance data: " & ex.Message
        End Try
    End Sub

    Private Sub btnMarkAllRestrictions_Click(sender As Object, e As EventArgs) Handles btnMarkAllRestrictions.Click
        Try
            Dim selectedInstanceName As String = cboSelectInstance.SelectedItem?.ToString()

            If String.IsNullOrEmpty(selectedInstanceName) Then
                txtStatus.Text = "Error: Please select an instance"
                Return
            End If

            Dim result = MessageBox.Show(
                $"This will mark ALL bosses in '{selectedInstanceName}' as having 12.0.0 Restrictions.{vbCrLf}{vbCrLf}Do you want to continue?",
                "Confirm Bulk Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Using db As New IATDbContext()
                    Dim instance = db.Instances.FirstOrDefault(Function(i) i.Name = selectedInstanceName)

                    If instance Is Nothing Then
                        txtStatus.Text = "Error: Instance not found in database"
                        Return
                    End If

                    ' Get all bosses for this instance
                    Dim bosses = db.Bosses.Where(Function(b) b.InstanceId = instance.Id).ToList()

                    If bosses.Count = 0 Then
                        txtStatus.Text = "No bosses found for this instance"
                        Return
                    End If

                    ' Mark all bosses with restrictions
                    Dim updatedCount As Integer = 0
                    For Each boss In bosses
                        If Not boss.NotTrackableDueToRestrictions Then
                            boss.NotTrackableDueToRestrictions = True
                            updatedCount += 1
                        End If
                    Next

                    db.SaveChanges()

                    txtStatus.Text = $"Updated {updatedCount} of {bosses.Count} bosses in '{selectedInstanceName}' with 12.0.0 Restrictions"

                    ' Refresh the current boss if one is selected
                    If cboSelectBoss.SelectedItem IsNot Nothing Then
                        cboSelectBoss_SelectedIndexChanged(sender, e)
                    End If
                End Using
            Else
                txtStatus.Text = "Bulk update cancelled"
            End If
        Catch ex As Exception
            txtStatus.Text = "Error during bulk update: " & ex.Message
        End Try
    End Sub
End Class