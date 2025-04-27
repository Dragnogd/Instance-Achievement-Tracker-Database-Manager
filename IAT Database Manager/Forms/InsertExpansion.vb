Imports System.IO

Public Class InsertExpansion
    Private Sub btnAddExpansion_Click(sender As Object, e As EventArgs) Handles btnAddExpansion.Click
        Using writer As StreamWriter = New StreamWriter("expansionsDB.csv", True)
            writer.WriteLine(txtExpansionID.Text & "," & txtExpansionName.Text)
        End Using
        txtStatus.Text = "Added: " & txtExpansionName.Text & " with ID " & txtExpansionID.Text
    End Sub
End Class