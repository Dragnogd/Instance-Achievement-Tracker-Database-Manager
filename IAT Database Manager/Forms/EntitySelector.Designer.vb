<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EntitySelector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnSave = New Button()
        btnAddEntity = New Button()
        txtSearch = New TextBox()
        lblSearch = New Label()
        dgvEntities = New DataGridView()
        btnCancel = New Button()
        SplitContainer1 = New SplitContainer()
        wvBrowser = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(dgvEntities, ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(wvBrowser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSave.DialogResult = DialogResult.OK
        btnSave.Font = New Font("Segoe UI", 14.25F)
        btnSave.Location = New Point(12, 444)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(184, 34)
        btnSave.TabIndex = 4
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnAddEntity
        ' 
        btnAddEntity.Location = New Point(220, 8)
        btnAddEntity.Name = "btnAddEntity"
        btnAddEntity.Size = New Size(166, 23)
        btnAddEntity.TabIndex = 5
        btnAddEntity.Text = "Add New"
        btnAddEntity.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(60, 8)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(147, 23)
        txtSearch.TabIndex = 7
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(12, 11)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(42, 15)
        lblSearch.TabIndex = 8
        lblSearch.Text = "Search"
        ' 
        ' dgvEntities
        ' 
        dgvEntities.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvEntities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEntities.Location = New Point(12, 37)
        dgvEntities.Name = "dgvEntities"
        dgvEntities.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEntities.Size = New Size(374, 401)
        dgvEntities.TabIndex = 9
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.Font = New Font("Segoe UI", 14.25F)
        btnCancel.Location = New Point(202, 444)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(184, 34)
        btnCancel.TabIndex = 10
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(lblSearch)
        SplitContainer1.Panel1.Controls.Add(btnCancel)
        SplitContainer1.Panel1.Controls.Add(btnSave)
        SplitContainer1.Panel1.Controls.Add(dgvEntities)
        SplitContainer1.Panel1.Controls.Add(btnAddEntity)
        SplitContainer1.Panel1.Controls.Add(txtSearch)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(wvBrowser)
        SplitContainer1.Size = New Size(1400, 490)
        SplitContainer1.SplitterDistance = 402
        SplitContainer1.TabIndex = 11
        ' 
        ' wvBrowser
        ' 
        wvBrowser.AllowExternalDrop = True
        wvBrowser.CreationProperties = Nothing
        wvBrowser.DefaultBackgroundColor = Color.White
        wvBrowser.Dock = DockStyle.Fill
        wvBrowser.Location = New Point(0, 0)
        wvBrowser.Name = "wvBrowser"
        wvBrowser.Size = New Size(994, 490)
        wvBrowser.Source = New Uri("https://www.wowhead.com/npcs", UriKind.Absolute)
        wvBrowser.TabIndex = 0
        wvBrowser.ZoomFactor = 1R
        ' 
        ' EntitySelector
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1400, 490)
        Controls.Add(SplitContainer1)
        Name = "EntitySelector"
        Text = "Selector"
        WindowState = FormWindowState.Maximized
        CType(dgvEntities, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(wvBrowser, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddEntity As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents dgvEntities As DataGridView
    Friend WithEvents btnCancel As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents wvBrowser As Microsoft.Web.WebView2.WinForms.WebView2
End Class
