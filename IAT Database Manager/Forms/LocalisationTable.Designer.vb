<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocalisationTable
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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        dgvLocalisations = New DataGridView()
        IdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        KeyDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ValueDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        UploadedToCurseForgeDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        Upload = New DataGridViewButtonColumn()
        LocalisationBindingSource = New BindingSource(components)
        GroupBox1 = New GroupBox()
        btnAddCustomLocalisation = New Button()
        txtValue = New TextBox()
        txtKey = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        txtSearch = New TextBox()
        Label3 = New Label()
        btnClearSearch = New Button()
        CType(dgvLocalisations, ComponentModel.ISupportInitialize).BeginInit()
        CType(LocalisationBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvLocalisations
        ' 
        dgvLocalisations.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvLocalisations.AutoGenerateColumns = False
        dgvLocalisations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLocalisations.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn, KeyDataGridViewTextBoxColumn, ValueDataGridViewTextBoxColumn, UploadedToCurseForgeDataGridViewCheckBoxColumn, Upload})
        dgvLocalisations.DataSource = LocalisationBindingSource
        dgvLocalisations.Location = New Point(0, 40)
        dgvLocalisations.Name = "dgvLocalisations"
        dgvLocalisations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLocalisations.Size = New Size(1139, 350)
        dgvLocalisations.TabIndex = 0
        ' 
        ' IdDataGridViewTextBoxColumn
        ' 
        IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn.HeaderText = "Id"
        IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        IdDataGridViewTextBoxColumn.Visible = False
        ' 
        ' KeyDataGridViewTextBoxColumn
        ' 
        KeyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        KeyDataGridViewTextBoxColumn.DataPropertyName = "Key"
        KeyDataGridViewTextBoxColumn.HeaderText = "Key"
        KeyDataGridViewTextBoxColumn.Name = "KeyDataGridViewTextBoxColumn"
        KeyDataGridViewTextBoxColumn.Width = 51
        ' 
        ' ValueDataGridViewTextBoxColumn
        ' 
        ValueDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ValueDataGridViewTextBoxColumn.DataPropertyName = "Value"
        ValueDataGridViewTextBoxColumn.HeaderText = "Value"
        ValueDataGridViewTextBoxColumn.Name = "ValueDataGridViewTextBoxColumn"
        ' 
        ' UploadedToCurseForgeDataGridViewCheckBoxColumn
        ' 
        UploadedToCurseForgeDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        UploadedToCurseForgeDataGridViewCheckBoxColumn.DataPropertyName = "UploadedToCurseForge"
        UploadedToCurseForgeDataGridViewCheckBoxColumn.HeaderText = "UploadedToCurseForge"
        UploadedToCurseForgeDataGridViewCheckBoxColumn.Name = "UploadedToCurseForgeDataGridViewCheckBoxColumn"
        UploadedToCurseForgeDataGridViewCheckBoxColumn.Width = 137
        ' 
        ' Upload
        ' 
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.SelectionForeColor = Color.Black
        Upload.DefaultCellStyle = DataGridViewCellStyle1
        Upload.HeaderText = "Upload"
        Upload.Name = "Upload"
        Upload.Text = "Upload to Curseforge"
        Upload.ToolTipText = "Upload to Curseforge"
        ' 
        ' LocalisationBindingSource
        ' 
        LocalisationBindingSource.DataSource = GetType(Localisation)
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox1.Controls.Add(btnAddCustomLocalisation)
        GroupBox1.Controls.Add(txtValue)
        GroupBox1.Controls.Add(txtKey)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 396)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1115, 107)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Add Custom UI Localisation"
        ' 
        ' btnAddCustomLocalisation
        ' 
        btnAddCustomLocalisation.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddCustomLocalisation.Location = New Point(940, 22)
        btnAddCustomLocalisation.Name = "btnAddCustomLocalisation"
        btnAddCustomLocalisation.Size = New Size(160, 70)
        btnAddCustomLocalisation.TabIndex = 4
        btnAddCustomLocalisation.Text = "Add Localisation"
        btnAddCustomLocalisation.UseVisualStyleBackColor = True
        ' 
        ' txtValue
        ' 
        txtValue.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtValue.Location = New Point(60, 58)
        txtValue.Multiline = True
        txtValue.Name = "txtValue"
        txtValue.Size = New Size(860, 40)
        txtValue.TabIndex = 3
        ' 
        ' txtKey
        ' 
        txtKey.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtKey.Location = New Point(60, 25)
        txtKey.Name = "txtKey"
        txtKey.Size = New Size(860, 23)
        txtKey.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 61)
        Label2.Name = "Label2"
        Label2.Size = New Size(38, 15)
        Label2.TabIndex = 1
        Label2.Text = "Value:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(15, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(29, 15)
        Label1.TabIndex = 0
        Label1.Text = "Key:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearch.Location = New Point(60, 10)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Search by key or value..."
        txtSearch.Size = New Size(990, 23)
        txtSearch.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 13)
        Label3.Name = "Label3"
        Label3.Size = New Size(45, 15)
        Label3.TabIndex = 3
        Label3.Text = "Search:"
        ' 
        ' btnClearSearch
        ' 
        btnClearSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClearSearch.Location = New Point(1056, 9)
        btnClearSearch.Name = "btnClearSearch"
        btnClearSearch.Size = New Size(75, 25)
        btnClearSearch.TabIndex = 4
        btnClearSearch.Text = "Clear"
        btnClearSearch.UseVisualStyleBackColor = True
        ' 
        ' LocalisationTable
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1139, 515)
        Controls.Add(btnClearSearch)
        Controls.Add(Label3)
        Controls.Add(txtSearch)
        Controls.Add(GroupBox1)
        Controls.Add(dgvLocalisations)
        Name = "LocalisationTable"
        Text = "Localisation"
        WindowState = FormWindowState.Maximized
        CType(dgvLocalisations, ComponentModel.ISupportInitialize).EndInit()
        CType(LocalisationBindingSource, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvLocalisations As DataGridView
    Friend WithEvents LocalisationBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents KeyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ValueDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UploadedToCurseForgeDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents Upload As DataGridViewButtonColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddCustomLocalisation As Button
    Friend WithEvents txtValue As TextBox
    Friend WithEvents txtKey As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnClearSearch As Button
End Class
