Imports System.Globalization
Imports System.Text.RegularExpressions

Public Enum EntityType
    NPC
    Item
    Spell
End Enum

Public Class EntitySelector

    Private entityBindingSource As New BindingSource()
    Private allEntities As IList
    Public SelectedEntity As Object
    Public SelectedItemIndex As Integer
    Public TypeToLoad As EntityType

    Private Async Sub EntitySelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEntities()

        ' Dont show the primary key id
        dgvEntities.Columns("Id").Visible = False

        ' Fill remaining width of the DataGridView with the name column
        With dgvEntities.Columns("Name")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
    End Sub

    Private Sub LoadEntities()
        Using db As New IATDbContext()
            Select Case TypeToLoad
                Case EntityType.NPC
                    allEntities = db.NPCs.OrderBy(Function(n) n.Name).ToList()
                Case EntityType.Spell
                    allEntities = db.Spells.OrderBy(Function(s) s.Name).ToList()
                Case EntityType.Item
                    allEntities = db.Items.OrderBy(Function(i) i.Name).ToList()
            End Select

            entityBindingSource.DataSource = allEntities
            dgvEntities.DataSource = entityBindingSource
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim text = txtSearch.Text.ToLower()

        entityBindingSource.DataSource = allEntities.Cast(Of Object)().
            Where(Function(f)
                      Dim nameProp = f.GetType().GetProperty("Name")
                      Return nameProp IsNot Nothing AndAlso
                             nameProp.GetValue(f).ToString().ToLower().Contains(text)
                  End Function).ToList()

        wvBrowser.Source = New Uri("https://www.wowhead.com/npcs/name:" & text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If SelectedEntity IsNot Nothing Then
            Dim nameProp = SelectedEntity.GetType().GetProperty("Name")
            Dim idProp = SelectedEntity.GetType().GetProperties().First(Function(p) p.Name.EndsWith("Id"))

            Dim entityName As String = nameProp.GetValue(SelectedEntity).ToString().Replace("'", "\'")
            Dim entityId As String = Nothing

            Select Case TypeToLoad.ToString().ToLower()
                Case "npc"
                    entityId = SelectedEntity.GetType().GetProperty("NPCId").GetValue(SelectedEntity).ToString()
                Case "spell"
                    entityId = SelectedEntity.GetType().GetProperty("SpellId").GetValue(SelectedEntity).ToString()
                Case "item"
                    entityId = SelectedEntity.GetType().GetProperty("ItemId").GetValue(SelectedEntity).ToString()
                Case Else
                    Throw New Exception("Unsupported entity type: " & TypeToLoad.ToString())
            End Select

            Dim hrefPrefix As String = TypeToLoad.ToString().ToLower()

            Dim script As String =
                $"var elem = document.getElementById('{SelectedItemIndex}');" &
                $"if (elem) {{" &
                    $"elem.innerText = '{entityName}';" &
                    $"elem.setAttribute('href', '{hrefPrefix}:{entityId}:pos:{SelectedItemIndex}');" &
                $"}}"

            ' Accessing WebView2 on main form/tab
            Dim tabControl = frmIATDatabaseManager.tcTactics
            If tabControl IsNot Nothing Then
                Dim currentTab = tabControl.SelectedTab
                Dim wv = currentTab.Controls.OfType(Of Microsoft.Web.WebView2.WinForms.WebView2).FirstOrDefault()
                If wv IsNot Nothing AndAlso wv.CoreWebView2 IsNot Nothing Then
                    wv.CoreWebView2.ExecuteScriptAsync(script)
                End If
            End If
        End If

        Me.Close()
    End Sub

    Private Sub dgvNPCs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEntities.SelectionChanged
        If dgvEntities.SelectedRows.Count > 0 Then
            SelectedEntity = dgvEntities.SelectedRows(0).DataBoundItem
        End If
    End Sub

    Private Sub btnAddEntity_Click(sender As Object, e As EventArgs) Handles btnAddEntity.Click
        Dim entityId As Integer = 0
        Dim entityName As String = ""
        Dim entityTypeString As String = TypeToLoad.ToString().ToLower()

        ' Parse Wowhead-style URL
        Dim match = Regex.Match(wvBrowser.Source.ToString(), $"{entityTypeString}=(\d+)(?:/([^/?#]+))?")
        If Not match.Success Then
            MessageBox.Show($"URL is not a valid Wowhead {TypeToLoad} link.")
            Return
        End If

        entityId = Integer.Parse(match.Groups(1).Value)

        If match.Groups.Count > 2 AndAlso Not String.IsNullOrEmpty(match.Groups(2).Value) Then
            Dim slug = match.Groups(2).Value
            entityName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(slug.Replace("-", " "))
        End If

        Using db As New IATDbContext()
            Dim alreadyExists As Boolean = False

            Select Case TypeToLoad
                Case EntityType.NPC
                    alreadyExists = db.NPCs.Any(Function(n) n.NPCID = entityId)
                    If Not alreadyExists Then
                        db.NPCs.Add(New NPC With {.NPCID = entityId, .Name = entityName})
                    End If

                Case EntityType.Spell
                    alreadyExists = db.Spells.Any(Function(s) s.SpellId = entityId)
                    If Not alreadyExists Then
                        db.Spells.Add(New Spell With {.SpellId = entityId, .Name = entityName})
                    End If

                Case EntityType.Item
                    alreadyExists = db.Items.Any(Function(i) i.ItemId = entityId)
                    If Not alreadyExists Then
                        db.Items.Add(New Item With {.ItemId = entityId, .Name = entityName})
                    End If
            End Select

            If alreadyExists Then
                MessageBox.Show($"{TypeToLoad} '{entityName}' (ID: {entityId}) already exists.")
            Else
                db.SaveChanges()
                LoadEntities()
            End If
        End Using
    End Sub
End Class