Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net

Public Class InsertInstance
    Private wagoInstancesData As New Dictionary(Of String, Dictionary(Of String, String))
    Private wagoMapData As New Dictionary(Of String, Dictionary(Of String, String))

    Private Sub InsertInstance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using db As New IATDbContext()
            For Each expansion In db.Expansions.OrderBy(Function(exp) exp.ExpansionGameId).ToList()
                cboExpansions.Items.Add(expansion.Name)
            Next
        End Using

        LoadWagoMapData()
        LoadWagoInstances()
    End Sub

    Private Sub LoadWagoMapData()
        Try
            Dim url As String = "https://wago.tools/db2/Map/csv"
            Dim webClient As New WebClient()
            Dim csvData As String = webClient.DownloadString(url)

            Dim lines() As String = csvData.Split(New String() {vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

            wagoMapData.Clear()

            For i As Integer = 1 To lines.Length - 1
                Dim line As String = lines(i)
                Dim fields() As String = ParseCsvLine(line)

                If fields.Length >= 12 Then
                    Dim mapID As String = fields(0)
                    Dim instanceType As String = fields(9)
                    Dim expansionID As String = fields(10)

                    Dim mapData As New Dictionary(Of String, String)
                    mapData("MapID") = mapID
                    mapData("InstanceType") = instanceType
                    mapData("ExpansionID") = expansionID

                    wagoMapData(mapID) = mapData
                End If
            Next
        Catch ex As Exception
            txtStatus.Text = "Error loading Map data: " & ex.Message
        End Try
    End Sub

    Private Sub LoadWagoInstances()
        Try
            Dim url As String = "https://wago.tools/db2/JournalInstance/csv"
            Dim webClient As New WebClient()
            Dim csvData As String = webClient.DownloadString(url)

            Dim lines() As String = csvData.Split(New String() {vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

            cboWagoInstances.Items.Clear()
            wagoInstancesData.Clear()

            For i As Integer = 1 To lines.Length - 1
                Dim line As String = lines(i)
                Dim fields() As String = ParseCsvLine(line)

                If fields.Length >= 2 Then
                    Dim instanceID As String = fields(0)
                    Dim instanceName As String = fields(1)

                    Dim instanceData As New Dictionary(Of String, String)
                    instanceData("ID") = instanceID
                    instanceData("Name") = instanceName
                    If fields.Length > 2 Then instanceData("Description") = fields(2)
                    If fields.Length > 3 Then instanceData("MapID") = fields(3)

                    wagoInstancesData(instanceName) = instanceData
                    cboWagoInstances.Items.Add(instanceName)
                End If
            Next

            If cboWagoInstances.Items.Count > 0 Then
                txtStatus.Text = "Loaded " & cboWagoInstances.Items.Count & " instances from Wago.tools"
            End If
        Catch ex As Exception
            txtStatus.Text = "Error loading Wago data: " & ex.Message
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

    Private Sub cboWagoInstances_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboWagoInstances.SelectedIndexChanged
        If cboWagoInstances.SelectedItem IsNot Nothing Then
            Dim selectedInstance As String = cboWagoInstances.SelectedItem.ToString()

            If wagoInstancesData.ContainsKey(selectedInstance) Then
                Dim instanceData = wagoInstancesData(selectedInstance)

                txtInstanceNameID.Text = instanceData("ID")
                txtInstanceName.Text = instanceData("Name")
                txtInstanceID.Text = instanceData("MapID")

                If instanceData.ContainsKey("MapID") AndAlso wagoMapData.ContainsKey(instanceData("MapID")) Then
                    Dim mapData = wagoMapData(instanceData("MapID"))
                    Dim instanceType As Integer = Integer.Parse(mapData("InstanceType"))
                    Dim expansionID As Integer = Integer.Parse(mapData("ExpansionID"))

                    Select Case instanceType
                        Case 1
                            cboInstanceTypes.SelectedItem = "Dungeons"
                        Case 2
                            cboInstanceTypes.SelectedItem = "Raids"
                        Case 5
                            If expansionID < 10 Then
                                cboInstanceTypes.SelectedItem = "Scenarios"
                            Else
                                cboInstanceTypes.SelectedItem = "Delves"
                            End If
                    End Select
                End If

                txtStatus.Text = "Selected: " & selectedInstance
            End If
        End If
    End Sub

    Private Sub txtLuaImport_TextChanged(sender As Object, e As EventArgs) Handles txtLuaImport.TextChanged
        Try
            Dim Line = 1
            For Each strLine As String In sender.Text.Split(vbNewLine)
                If Line = 1 Then
                    Dim InstanceName = strLine.Split("{")(1).Replace("--", "").Trim()
                    Dim regex As Regex = New Regex("[0-9]+")
                    Dim match As Match = regex.Match(strLine)
                    Dim InstanceID As Integer = match.Value
                    txtInstanceName.Text = InstanceName
                    txtInstanceID.Text = InstanceID

                    Line += 1
                ElseIf Line = 2 Then
                    Dim InstanceNameID = strLine.Replace("name = ", "").Replace(",", "").Trim()
                    txtInstanceNameID.Text = InstanceNameID
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddInstance_Click(sender As Object, e As EventArgs) Handles btnAddInstance.Click
        Using writer As StreamWriter = New StreamWriter("instancesDB.csv", True)
            writer.WriteLine(txtInstanceID.Text & "," & txtInstanceName.Text & "," & txtInstanceNameID.Text & "," & cboExpansions.SelectedItem & "," & cboInstanceTypes.SelectedItem)
            txtStatus.Text = "Added: " & txtInstanceName.Text
        End Using
    End Sub

    Private Sub txtLuaImport_Click(sender As Object, e As EventArgs) Handles txtLuaImport.Click
        sender.text = Clipboard.GetText
    End Sub

    Private Sub txtLuaImport_MouseClick(sender As Object, e As MouseEventArgs) Handles txtLuaImport.MouseClick
        sender.text = Clipboard.GetText
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtLuaImport.Text = Clipboard.GetText
    End Sub
End Class