<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpellSelector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnCancel = New Button()
        dgvSpells = New DataGridView()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnAddSpell = New Button()
        btnSave = New Button()
        CType(dgvSpells, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.Font = New Font("Segoe UI", 14.25F)
        btnCancel.Location = New Point(202, 445)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(184, 34)
        btnCancel.TabIndex = 16
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' dgvSpells
        ' 
        dgvSpells.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvSpells.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSpells.Location = New Point(12, 36)
        dgvSpells.Name = "dgvSpells"
        dgvSpells.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSpells.Size = New Size(369, 403)
        dgvSpells.TabIndex = 15
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(12, 10)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(42, 15)
        lblSearch.TabIndex = 14
        lblSearch.Text = "Search"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(69, 7)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(147, 23)
        txtSearch.TabIndex = 13
        ' 
        ' btnAddSpell
        ' 
        btnAddSpell.Location = New Point(222, 6)
        btnAddSpell.Name = "btnAddSpell"
        btnAddSpell.Size = New Size(166, 23)
        btnAddSpell.TabIndex = 12
        btnAddSpell.Text = "Add Spell"
        btnAddSpell.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.DialogResult = DialogResult.OK
        btnSave.Font = New Font("Segoe UI", 14.25F)
        btnSave.Location = New Point(12, 445)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(184, 34)
        btnSave.TabIndex = 11
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' SpellSelector
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(393, 483)
        Controls.Add(btnCancel)
        Controls.Add(dgvSpells)
        Controls.Add(lblSearch)
        Controls.Add(txtSearch)
        Controls.Add(btnAddSpell)
        Controls.Add(btnSave)
        Name = "SpellSelector"
        Text = "SpellSelector"
        CType(dgvSpells, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents dgvSpells As DataGridView
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnAddSpell As Button
    Friend WithEvents btnSave As Button
End Class
