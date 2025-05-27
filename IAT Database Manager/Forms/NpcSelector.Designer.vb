<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NpcSelector
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
        btnSave = New Button()
        btnAddNPC = New Button()
        txtSearch = New TextBox()
        lblSearch = New Label()
        dgvNPCs = New DataGridView()
        btnCancel = New Button()
        CType(dgvNPCs, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSave
        ' 
        btnSave.DialogResult = DialogResult.OK
        btnSave.Font = New Font("Segoe UI", 14.25F)
        btnSave.Location = New Point(9, 445)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(184, 34)
        btnSave.TabIndex = 4
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnAddNPC
        ' 
        btnAddNPC.Location = New Point(219, 6)
        btnAddNPC.Name = "btnAddNPC"
        btnAddNPC.Size = New Size(166, 23)
        btnAddNPC.TabIndex = 5
        btnAddNPC.Text = "Add NPC"
        btnAddNPC.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(66, 7)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(147, 23)
        txtSearch.TabIndex = 7
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(9, 10)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(42, 15)
        lblSearch.TabIndex = 8
        lblSearch.Text = "Search"
        ' 
        ' dgvNPCs
        ' 
        dgvNPCs.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvNPCs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvNPCs.Location = New Point(9, 36)
        dgvNPCs.Name = "dgvNPCs"
        dgvNPCs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvNPCs.Size = New Size(376, 403)
        dgvNPCs.TabIndex = 9
        ' 
        ' btnCancel
        ' 
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.Font = New Font("Segoe UI", 14.25F)
        btnCancel.Location = New Point(199, 445)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(184, 34)
        btnCancel.TabIndex = 10
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' NpcSelector
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(392, 490)
        Controls.Add(btnCancel)
        Controls.Add(dgvNPCs)
        Controls.Add(lblSearch)
        Controls.Add(txtSearch)
        Controls.Add(btnAddNPC)
        Controls.Add(btnSave)
        Name = "NpcSelector"
        Text = "NpcSelector"
        CType(dgvNPCs, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddNPC As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents dgvNPCs As DataGridView
    Friend WithEvents btnCancel As Button
End Class
