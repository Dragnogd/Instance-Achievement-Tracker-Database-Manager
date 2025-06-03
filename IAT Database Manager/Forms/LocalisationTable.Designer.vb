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
        CType(dgvLocalisations, ComponentModel.ISupportInitialize).BeginInit()
        CType(LocalisationBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvLocalisations
        ' 
        dgvLocalisations.AutoGenerateColumns = False
        dgvLocalisations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLocalisations.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn, KeyDataGridViewTextBoxColumn, ValueDataGridViewTextBoxColumn, UploadedToCurseForgeDataGridViewCheckBoxColumn, Upload})
        dgvLocalisations.DataSource = LocalisationBindingSource
        dgvLocalisations.Dock = DockStyle.Fill
        dgvLocalisations.Location = New Point(0, 0)
        dgvLocalisations.Name = "dgvLocalisations"
        dgvLocalisations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLocalisations.Size = New Size(1139, 515)
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
        ' LocalisationTable
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1139, 515)
        Controls.Add(dgvLocalisations)
        Name = "LocalisationTable"
        Text = "Localisation"
        WindowState = FormWindowState.Maximized
        CType(dgvLocalisations, ComponentModel.ISupportInitialize).EndInit()
        CType(LocalisationBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvLocalisations As DataGridView
    Friend WithEvents LocalisationBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents KeyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ValueDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UploadedToCurseForgeDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents Upload As DataGridViewButtonColumn
End Class
