Imports System.ComponentModel
Imports Microsoft.EntityFrameworkCore
Imports Serilog

Public Class LocalisationTable
    Private allLocalisations As BindingList(Of Localisation)

    Private Sub Localisation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using db As New IATDbContext
            db.Localisations.Load()
            allLocalisations = db.Localisations.Local.ToBindingList()
            dgvLocalisations.DataSource = allLocalisations
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterLocalisations()
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub

    Private Sub FilterLocalisations()
        If allLocalisations Is Nothing Then Return

        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        If String.IsNullOrWhiteSpace(searchText) Then
            ' Show all localisations
            dgvLocalisations.DataSource = allLocalisations
        Else
            ' Filter by key or value
            Dim filtered = allLocalisations.Where(Function(l) _
                (l.Key IsNot Nothing AndAlso l.Key.ToLower().Contains(searchText)) OrElse _
                (l.Value IsNot Nothing AndAlso l.Value.ToLower().Contains(searchText)) _
            ).ToList()

            dgvLocalisations.DataSource = New BindingList(Of Localisation)(filtered)
        End If
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

    Private Sub dgvLocalisations_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLocalisations.CellEndEdit
        Try
            ' Get the edited localisation object
            Dim localisation As Localisation = TryCast(dgvLocalisations.Rows(e.RowIndex).DataBoundItem, Localisation)
            If localisation Is Nothing Then Return

            ' Update in database
            Using db As New IATDbContext()
                Dim dbEntry = db.Localisations.FirstOrDefault(Function(l) l.Id = localisation.Id)
                If dbEntry IsNot Nothing Then
                    ' Update the properties
                    dbEntry.Key = localisation.Key
                    dbEntry.Value = localisation.Value
                    dbEntry.UploadedToCurseForge = localisation.UploadedToCurseForge

                    db.SaveChanges()
                    Log.Information("Updated localisation key '{Key}' in database", localisation.Key)
                End If
            End Using

        Catch ex As Exception
            Log.Error(ex, "Failed to update localisation in database")
            MessageBox.Show($"Error updating database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddCustomLocalisation_Click(sender As Object, e As EventArgs) Handles btnAddCustomLocalisation.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtKey.Text) Then
                MessageBox.Show("Error: Key cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtValue.Text) Then
                MessageBox.Show("Error: Value cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using db As New IATDbContext()
                ' Check if key already exists
                Dim existingLocalisation = db.Localisations.FirstOrDefault(Function(l) l.Key = txtKey.Text)

                If existingLocalisation IsNot Nothing Then
                    ' Update existing
                    existingLocalisation.Value = txtValue.Text
                    existingLocalisation.UploadedToCurseForge = False

                    db.SaveChanges()
                    Log.Information("Updated custom UI localisation: {Key}", txtKey.Text)
                    MessageBox.Show($"Updated existing localisation: {txtKey.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' Create new
                    Dim newLocalisation As New Localisation With {
                        .Key = txtKey.Text,
                        .Value = txtValue.Text,
                        .UploadedToCurseForge = False
                    }

                    db.Localisations.Add(newLocalisation)
                    db.SaveChanges()
                    Log.Information("Added custom UI localisation: {Key}", txtKey.Text)
                    MessageBox.Show($"Added new custom UI localisation: {txtKey.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' Reload the grid
                db.Localisations.Load()
                allLocalisations = db.Localisations.Local.ToBindingList()
                dgvLocalisations.DataSource = allLocalisations

                ' Clear input fields
                txtKey.Text = ""
                txtValue.Text = ""
                txtKey.Focus()

                ' Reapply filter if there was one
                FilterLocalisations()
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Log.Error(ex, "Failed to add custom UI localisation")
        End Try
    End Sub
End Class