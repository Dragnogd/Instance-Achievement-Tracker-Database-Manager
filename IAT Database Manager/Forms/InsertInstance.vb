Imports System.IO
Imports System.Text.RegularExpressions

Public Class InsertInstance
    Private Sub InsertInstance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using reader As StreamReader = New StreamReader("expansionsDB.csv")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                Dim strArr As String() = line.Split(",")
                cboExpansions.Items.Add(strArr(1))
                line = reader.ReadLine
            End While
        End Using
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

            Using writer As StreamWriter = New StreamWriter("instancesDB.csv", True)
                writer.WriteLine(txtInstanceID.Text & "," & txtInstanceName.Text & "," & txtInstanceNameID.Text & "," & cboExpansions.SelectedItem & "," & cboInstanceTypes.SelectedItem)
                txtStatus.Text = "Added: " & txtInstanceName.Text
            End Using
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