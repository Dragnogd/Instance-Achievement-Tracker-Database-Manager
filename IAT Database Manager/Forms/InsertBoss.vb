Imports System.IO
Imports System.Text.RegularExpressions

Public Class InsertBoss
    Public LastClipboard As String = ""
    Public LastBoss As Integer = 1

    Private Sub txtLuaImport_TextChanged(sender As Object, e As EventArgs) Handles txtLuaImport.TextChanged

    End Sub

    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer)
        Dim i As Integer, iHalfSeconds As Integer = iMilliSeconds / 500
        For i = 1 To iHalfSeconds
            Threading.Thread.Sleep(500) : Application.DoEvents()
        Next i
    End Sub

    Private Sub InsertBoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using reader As StreamReader = New StreamReader("instancesDB.csv")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                Dim strArr() = line.Split(",")
                cboSelectInstance.Items.Add(strArr(1))
                line = reader.ReadLine
            End While
        End Using
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
        Using writer As StreamWriter = New StreamWriter("bossesDB.csv", True)
            writer.WriteLine(txtIndex.Text & ";" & txtBossName.Text & ";" & txtNameID.Text & ";" & txtBossIDs.Text & ";" & txtAchievement.Text & ";" & txtPlayers.Text & ";" & txtTactics.Text & ";" & txtEnabled.Text & ";" & txtTrack.Text & ";" & txtPartial.Text & ";" & txtEncounterID.Text & ";" & txtInfoFrame.Text & ";" & cboSelectInstance.SelectedItem & ";;")
            txtStatus.Text = "Added: " & txtBossName.Text

            'Clear Boxes
            txtBossName.Text = ""
            txtAchievement.Text = ""
            txtTactics.Text = ""
            txtEncounterID.Text = ""
            txtNameID.Text = ""

            LastBoss += 1
            txtIndex.Text = "boss" & LastBoss
        End Using
    End Sub

    Private Sub cboSelectInstance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectInstance.SelectedIndexChanged
        LastBoss = 1
        txtIndex.Text = "boss" & LastBoss
    End Sub
End Class