Public Class SpellSelector
    Private npcBindingSource As New BindingSource()
    Private allSpells As List(Of Spell)

    Public SelectedSpell As Spell

    Private Async Sub NpcSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using db As New IATDbContext()
            allSpells = db.Spells.OrderBy(Function(n) n.Name).ToList()
            npcBindingSource.DataSource = allSpells
            dgvSpells.DataSource = npcBindingSource
        End Using

        dgvSpells.Columns("Id").Visible = False
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim filterText = txtSearch.Text.ToLower()
        npcBindingSource.DataSource = allSpells _
        .Where(Function(n) n.Name IsNot Nothing AndAlso n.Name.ToLower().Contains(filterText)) _
        .ToList()
        dgvSpells.DataSource = npcBindingSource

        ' Open search in wowhead too
        Dim searchUrl As Uri = New Uri("https://www.wowhead.com/npcs/name:" & filterText)
        Browser.wvBrowser.Source = searchUrl
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvSpells_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSpells.SelectionChanged
        If dgvSpells.SelectedRows.Count > 0 Then
            Dim spell As Spell = TryCast(dgvSpells.SelectedRows(0).DataBoundItem, Spell)
            If spell IsNot Nothing Then
                SelectedSpell = spell
            End If
        End If
    End Sub

    Private Sub btnAddNPC_Click(sender As Object, e As EventArgs) Handles btnAddSpell.Click
        Browser.Show()
        Browser.wvBrowser.Source = New Uri("https://www.wowhead.com/npcs/name" & txtSearch.Text)
    End Sub
End Class