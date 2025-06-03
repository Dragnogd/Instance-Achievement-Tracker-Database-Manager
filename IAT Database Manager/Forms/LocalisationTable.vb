Imports System.ComponentModel
Imports Microsoft.EntityFrameworkCore
Imports Serilog

Public Class LocalisationTable
    Private Sub Localisation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using db As New IATDbContext
            db.Localisations.Load()
            dgvLocalisations.DataSource = db.Localisations.Local.ToBindingList()
        End Using
    End Sub

    Private Async Sub dgvLocalisations_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLocalisations.CellContentClick
        ' Ensure it's a button column and not a header click
        If e.RowIndex < 0 OrElse Not TypeOf dgvLocalisations.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            Return
        End If

        ' Get the Localisation object for the selected row
        Dim localisation As Localisation = TryCast(dgvLocalisations.Rows(e.RowIndex).DataBoundItem, Localisation)
        If localisation Is Nothing Then Return

        ' Upload to CurseForge
        Dim curseforgeClient As New CurseForgeClient()
        Dim success As Boolean = Await curseforgeClient.UploadLocalisationAsync(localisation.Key, localisation.Value)

        If success Then
            Log.Information("Uploaded key '{Key}' to CurseForge", localisation.Key)

            ' Update in database
            Using db As New IATDbContext()
                Dim dbEntry = db.Localisations.FirstOrDefault(Function(l) l.Key = localisation.Key)
                If dbEntry IsNot Nothing Then
                    dbEntry.UploadedToCurseForge = True
                    db.SaveChanges()
                End If
            End Using

            ' Refresh the row visually
            localisation.UploadedToCurseForge = True
            dgvLocalisations.Refresh()
        Else
            Log.Error("Failed to upload key '{Key}' to CurseForge", localisation.Key)
            MessageBox.Show($"Failed to upload key: {localisation.Key}", "Upload Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class