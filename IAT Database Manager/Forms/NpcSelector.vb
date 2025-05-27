Public Class NpcSelector
    Private npcBindingSource As New BindingSource()
    Private allNpcs As List(Of NPC)

    ' Add this at class level to remember the clicked link ID or text
    Public SelectedNPC As NPC

    Private Async Sub NpcSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using db As New IATDbContext()
            allNpcs = db.NPCs.OrderBy(Function(n) n.Name).ToList()
            npcBindingSource.DataSource = allNpcs
            dgvNPCs.DataSource = npcBindingSource
        End Using

        dgvNPCs.Columns("Id").Visible = False
        dgvNPCs.Columns("Cache").Visible = False
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim filterText = txtSearch.Text.ToLower()
        npcBindingSource.DataSource = allNpcs _
        .Where(Function(n) n.Name IsNot Nothing AndAlso n.Name.ToLower().Contains(filterText)) _
        .ToList()
        dgvNPCs.DataSource = npcBindingSource

        ' Open search in wowhead too
        Dim searchUrl As Uri = New Uri("https://www.wowhead.com/npcs/name:" & filterText)
        Browser.wvBrowser.Source = searchUrl
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvNPCs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvNPCs.SelectionChanged
        If dgvNPCs.SelectedRows.Count > 0 Then
            Dim npc As NPC = TryCast(dgvNPCs.SelectedRows(0).DataBoundItem, NPC)
            If npc IsNot Nothing Then
                SelectedNPC = npc
            End If
        End If
    End Sub

    Private Sub btnAddNPC_Click(sender As Object, e As EventArgs) Handles btnAddNPC.Click
        Browser.Show()
        Browser.wvBrowser.Source = New Uri("https://www.wowhead.com/npcs/name" & txtSearch.Text)
    End Sub
End Class