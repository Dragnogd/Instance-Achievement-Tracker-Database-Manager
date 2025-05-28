<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIATDatabaseManager
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIATDatabaseManager))
        cboBosses = New ComboBox()
        Label1 = New Label()
        btnInsertTactic = New Button()
        MenuStrip1 = New MenuStrip()
        InsertToolStripMenuItem = New ToolStripMenuItem()
        ExpansionToolStripMenuItem = New ToolStripMenuItem()
        InstanceToolStripMenuItem = New ToolStripMenuItem()
        BossToolStripMenuItem = New ToolStripMenuItem()
        LocalisationManagerToolStripMenuItem = New ToolStripMenuItem()
        btnGenerateLocalisation = New Button()
        btnUploadLocale = New Button()
        btnGenerateLocaleNoUpload = New Button()
        btnTestTranslationClassic = New Button()
        btnUploadLocaleClassic = New Button()
        btnGenerateLocalisationClassic = New Button()
        dgvExpansions = New DataGridView()
        IdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ExpansionGameIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        NameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ExpansionBindingSource = New BindingSource(components)
        tlpContainer = New TableLayoutPanel()
        tlpContentRight = New TableLayoutPanel()
        TableLayoutPanel1 = New TableLayoutPanel()
        dgvInstanceTypes = New DataGridView()
        IdDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        NameDataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
        InstanceTypesBindingSource = New BindingSource(components)
        TableLayoutPanel2 = New TableLayoutPanel()
        dgvBosses = New DataGridView()
        IdDataGridViewTextBoxColumn4 = New DataGridViewTextBoxColumn()
        OrderDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossNameIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossNameID2DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossNameLocaleDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossIDsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        AchievementIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        EnabledDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        TrackDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PartialTrackDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        EncounterIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        EncounterID2DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DisplayInfoFrameDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        InstanceIdDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        InstanceDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossesBindingSource = New BindingSource(components)
        InstancesBindingSource = New BindingSource(components)
        dgvInstances = New DataGridView()
        IdDataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
        InstanceIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        NameDataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
        NameWrathDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        InstanceNameIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ClassicPhaseDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        RetailOnlyDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        ClassicOnlyDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        LegacySizeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        InstanceTypeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        TableLayoutPanel3 = New TableLayoutPanel()
        dgvTactics = New DataGridView()
        IdDataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
        ImgurLinkDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ImageNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ImageWidthDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ImageHeightDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        LocalisationIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        LocalisationDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        TacticsBindingSource = New BindingSource(components)
        dgvTacticsParameters = New DataGridView()
        IdDataGridViewTextBoxColumn5 = New DataGridViewTextBoxColumn()
        OrderDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        ParameterIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ParameterTypeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        TacticParameterBindingSource = New BindingSource(components)
        tlpContentLeft = New TableLayoutPanel()
        Panel2 = New Panel()
        tcTactics = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        MenuStrip1.SuspendLayout()
        CType(dgvExpansions, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExpansionBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        tlpContainer.SuspendLayout()
        tlpContentRight.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(dgvInstanceTypes, ComponentModel.ISupportInitialize).BeginInit()
        CType(InstanceTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel2.SuspendLayout()
        CType(dgvBosses, ComponentModel.ISupportInitialize).BeginInit()
        CType(BossesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(InstancesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvInstances, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel3.SuspendLayout()
        CType(dgvTactics, ComponentModel.ISupportInitialize).BeginInit()
        CType(TacticsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvTacticsParameters, ComponentModel.ISupportInitialize).BeginInit()
        CType(TacticParameterBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        tlpContentLeft.SuspendLayout()
        Panel2.SuspendLayout()
        tcTactics.SuspendLayout()
        SuspendLayout()
        ' 
        ' cboBosses
        ' 
        cboBosses.FormattingEnabled = True
        cboBosses.Location = New Point(70, 3)
        cboBosses.Margin = New Padding(4, 3, 4, 3)
        cboBosses.Name = "cboBosses"
        cboBosses.Size = New Size(313, 23)
        cboBosses.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(4, 4)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(65, 15)
        Label1.TabIndex = 1
        Label1.Text = "Select Boss"
        ' 
        ' btnInsertTactic
        ' 
        btnInsertTactic.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnInsertTactic.Location = New Point(447, 4)
        btnInsertTactic.Margin = New Padding(4, 3, 4, 3)
        btnInsertTactic.Name = "btnInsertTactic"
        btnInsertTactic.Size = New Size(130, 26)
        btnInsertTactic.TabIndex = 4
        btnInsertTactic.Text = "Save Changes"
        btnInsertTactic.UseVisualStyleBackColor = True
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {InsertToolStripMenuItem, LocalisationManagerToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(7, 2, 0, 2)
        MenuStrip1.Size = New Size(1489, 24)
        MenuStrip1.TabIndex = 10
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' InsertToolStripMenuItem
        ' 
        InsertToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ExpansionToolStripMenuItem, InstanceToolStripMenuItem, BossToolStripMenuItem})
        InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        InsertToolStripMenuItem.Size = New Size(48, 20)
        InsertToolStripMenuItem.Text = "Insert"
        ' 
        ' ExpansionToolStripMenuItem
        ' 
        ExpansionToolStripMenuItem.Name = "ExpansionToolStripMenuItem"
        ExpansionToolStripMenuItem.Size = New Size(180, 22)
        ExpansionToolStripMenuItem.Text = "Expansion"
        ' 
        ' InstanceToolStripMenuItem
        ' 
        InstanceToolStripMenuItem.Name = "InstanceToolStripMenuItem"
        InstanceToolStripMenuItem.Size = New Size(180, 22)
        InstanceToolStripMenuItem.Text = "Instance"
        ' 
        ' BossToolStripMenuItem
        ' 
        BossToolStripMenuItem.Name = "BossToolStripMenuItem"
        BossToolStripMenuItem.Size = New Size(180, 22)
        BossToolStripMenuItem.Text = "Boss"
        ' 
        ' LocalisationManagerToolStripMenuItem
        ' 
        LocalisationManagerToolStripMenuItem.Name = "LocalisationManagerToolStripMenuItem"
        LocalisationManagerToolStripMenuItem.Size = New Size(123, 20)
        LocalisationManagerToolStripMenuItem.Text = "Update Localisation"
        ' 
        ' btnGenerateLocalisation
        ' 
        btnGenerateLocalisation.Location = New Point(285, 62)
        btnGenerateLocalisation.Margin = New Padding(4, 3, 4, 3)
        btnGenerateLocalisation.Name = "btnGenerateLocalisation"
        btnGenerateLocalisation.Size = New Size(126, 22)
        btnGenerateLocalisation.TabIndex = 54
        btnGenerateLocalisation.Text = "Create Imgur Link"
        btnGenerateLocalisation.UseVisualStyleBackColor = True
        ' 
        ' btnUploadLocale
        ' 
        btnUploadLocale.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnUploadLocale.Location = New Point(148, 64)
        btnUploadLocale.Margin = New Padding(4, 3, 4, 3)
        btnUploadLocale.Name = "btnUploadLocale"
        btnUploadLocale.Size = New Size(130, 20)
        btnUploadLocale.TabIndex = 56
        btnUploadLocale.Text = "Upload Locale"
        btnUploadLocale.UseVisualStyleBackColor = True
        ' 
        ' btnGenerateLocaleNoUpload
        ' 
        btnGenerateLocaleNoUpload.Location = New Point(82, 37)
        btnGenerateLocaleNoUpload.Margin = New Padding(4, 3, 4, 3)
        btnGenerateLocaleNoUpload.Name = "btnGenerateLocaleNoUpload"
        btnGenerateLocaleNoUpload.Size = New Size(135, 22)
        btnGenerateLocaleNoUpload.TabIndex = 64
        btnGenerateLocaleNoUpload.Text = "Test Translation"
        btnGenerateLocaleNoUpload.UseVisualStyleBackColor = True
        ' 
        ' btnTestTranslationClassic
        ' 
        btnTestTranslationClassic.Location = New Point(417, 62)
        btnTestTranslationClassic.Margin = New Padding(4, 3, 4, 3)
        btnTestTranslationClassic.Name = "btnTestTranslationClassic"
        btnTestTranslationClassic.Size = New Size(160, 22)
        btnTestTranslationClassic.TabIndex = 71
        btnTestTranslationClassic.Text = "Test Translation Classic"
        btnTestTranslationClassic.UseVisualStyleBackColor = True
        ' 
        ' btnUploadLocaleClassic
        ' 
        btnUploadLocaleClassic.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnUploadLocaleClassic.Location = New Point(10, 65)
        btnUploadLocaleClassic.Margin = New Padding(4, 3, 4, 3)
        btnUploadLocaleClassic.Name = "btnUploadLocaleClassic"
        btnUploadLocaleClassic.Size = New Size(130, 19)
        btnUploadLocaleClassic.TabIndex = 72
        btnUploadLocaleClassic.Text = "Upload Locale Classic"
        btnUploadLocaleClassic.UseVisualStyleBackColor = True
        ' 
        ' btnGenerateLocalisationClassic
        ' 
        btnGenerateLocalisationClassic.Location = New Point(255, 37)
        btnGenerateLocalisationClassic.Margin = New Padding(4, 3, 4, 3)
        btnGenerateLocalisationClassic.Name = "btnGenerateLocalisationClassic"
        btnGenerateLocalisationClassic.Size = New Size(186, 22)
        btnGenerateLocalisationClassic.TabIndex = 74
        btnGenerateLocalisationClassic.Text = "Create Imgur Link Classic"
        btnGenerateLocalisationClassic.UseVisualStyleBackColor = True
        ' 
        ' dgvExpansions
        ' 
        dgvExpansions.AutoGenerateColumns = False
        dgvExpansions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvExpansions.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn, ExpansionGameIdDataGridViewTextBoxColumn, NameDataGridViewTextBoxColumn})
        dgvExpansions.DataSource = ExpansionBindingSource
        dgvExpansions.Dock = DockStyle.Fill
        dgvExpansions.Location = New Point(3, 3)
        dgvExpansions.Name = "dgvExpansions"
        dgvExpansions.Size = New Size(436, 153)
        dgvExpansions.TabIndex = 75
        ' 
        ' IdDataGridViewTextBoxColumn
        ' 
        IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn.HeaderText = "Id"
        IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        ' 
        ' ExpansionGameIdDataGridViewTextBoxColumn
        ' 
        ExpansionGameIdDataGridViewTextBoxColumn.DataPropertyName = "ExpansionGameId"
        ExpansionGameIdDataGridViewTextBoxColumn.HeaderText = "ExpansionGameId"
        ExpansionGameIdDataGridViewTextBoxColumn.Name = "ExpansionGameIdDataGridViewTextBoxColumn"
        ' 
        ' NameDataGridViewTextBoxColumn
        ' 
        NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        NameDataGridViewTextBoxColumn.HeaderText = "Name"
        NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        ' 
        ' ExpansionBindingSource
        ' 
        ExpansionBindingSource.DataSource = GetType(Expansion)
        ' 
        ' tlpContainer
        ' 
        tlpContainer.ColumnCount = 2
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 39.87976F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.12024F))
        tlpContainer.Controls.Add(tlpContentRight, 1, 0)
        tlpContainer.Controls.Add(tlpContentLeft, 0, 0)
        tlpContainer.Dock = DockStyle.Fill
        tlpContainer.Location = New Point(0, 24)
        tlpContainer.Name = "tlpContainer"
        tlpContainer.RowCount = 1
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpContainer.Size = New Size(1489, 503)
        tlpContainer.TabIndex = 76
        ' 
        ' tlpContentRight
        ' 
        tlpContentRight.ColumnCount = 1
        tlpContentRight.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpContentRight.Controls.Add(TableLayoutPanel1, 0, 0)
        tlpContentRight.Controls.Add(TableLayoutPanel2, 0, 1)
        tlpContentRight.Controls.Add(TableLayoutPanel3, 0, 2)
        tlpContentRight.Dock = DockStyle.Fill
        tlpContentRight.Location = New Point(596, 3)
        tlpContentRight.Name = "tlpContentRight"
        tlpContentRight.RowCount = 3
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentRight.Size = New Size(890, 497)
        tlpContentRight.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(dgvExpansions, 0, 0)
        TableLayoutPanel1.Controls.Add(dgvInstanceTypes, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(3, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(884, 159)
        TableLayoutPanel1.TabIndex = 79
        ' 
        ' dgvInstanceTypes
        ' 
        dgvInstanceTypes.AutoGenerateColumns = False
        dgvInstanceTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInstanceTypes.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn1, NameDataGridViewTextBoxColumn2})
        dgvInstanceTypes.DataSource = InstanceTypesBindingSource
        dgvInstanceTypes.Dock = DockStyle.Fill
        dgvInstanceTypes.Location = New Point(445, 3)
        dgvInstanceTypes.Name = "dgvInstanceTypes"
        dgvInstanceTypes.Size = New Size(436, 153)
        dgvInstanceTypes.TabIndex = 76
        ' 
        ' IdDataGridViewTextBoxColumn1
        ' 
        IdDataGridViewTextBoxColumn1.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn1.HeaderText = "Id"
        IdDataGridViewTextBoxColumn1.Name = "IdDataGridViewTextBoxColumn1"
        ' 
        ' NameDataGridViewTextBoxColumn2
        ' 
        NameDataGridViewTextBoxColumn2.DataPropertyName = "Name"
        NameDataGridViewTextBoxColumn2.HeaderText = "Name"
        NameDataGridViewTextBoxColumn2.Name = "NameDataGridViewTextBoxColumn2"
        ' 
        ' InstanceTypesBindingSource
        ' 
        InstanceTypesBindingSource.DataMember = "InstanceTypes"
        InstanceTypesBindingSource.DataSource = ExpansionBindingSource
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(dgvBosses, 1, 0)
        TableLayoutPanel2.Controls.Add(dgvInstances, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 168)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(884, 159)
        TableLayoutPanel2.TabIndex = 80
        ' 
        ' dgvBosses
        ' 
        dgvBosses.AllowUserToAddRows = False
        dgvBosses.AutoGenerateColumns = False
        dgvBosses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBosses.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn4, OrderDataGridViewTextBoxColumn, BossNameDataGridViewTextBoxColumn, BossNameIDDataGridViewTextBoxColumn, BossNameID2DataGridViewTextBoxColumn, BossNameLocaleDataGridViewTextBoxColumn, BossIDsDataGridViewTextBoxColumn, AchievementIDDataGridViewTextBoxColumn, EnabledDataGridViewCheckBoxColumn, TrackDataGridViewTextBoxColumn, PartialTrackDataGridViewCheckBoxColumn, EncounterIDDataGridViewTextBoxColumn, EncounterID2DataGridViewTextBoxColumn, DisplayInfoFrameDataGridViewCheckBoxColumn, InstanceIdDataGridViewTextBoxColumn1, InstanceDataGridViewTextBoxColumn})
        dgvBosses.DataSource = BossesBindingSource
        dgvBosses.Dock = DockStyle.Fill
        dgvBosses.Location = New Point(445, 3)
        dgvBosses.Name = "dgvBosses"
        dgvBosses.Size = New Size(436, 153)
        dgvBosses.TabIndex = 0
        ' 
        ' IdDataGridViewTextBoxColumn4
        ' 
        IdDataGridViewTextBoxColumn4.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn4.HeaderText = "Id"
        IdDataGridViewTextBoxColumn4.Name = "IdDataGridViewTextBoxColumn4"
        ' 
        ' OrderDataGridViewTextBoxColumn
        ' 
        OrderDataGridViewTextBoxColumn.DataPropertyName = "Order"
        OrderDataGridViewTextBoxColumn.HeaderText = "Order"
        OrderDataGridViewTextBoxColumn.Name = "OrderDataGridViewTextBoxColumn"
        ' 
        ' BossNameDataGridViewTextBoxColumn
        ' 
        BossNameDataGridViewTextBoxColumn.DataPropertyName = "BossName"
        BossNameDataGridViewTextBoxColumn.HeaderText = "BossName"
        BossNameDataGridViewTextBoxColumn.Name = "BossNameDataGridViewTextBoxColumn"
        ' 
        ' BossNameIDDataGridViewTextBoxColumn
        ' 
        BossNameIDDataGridViewTextBoxColumn.DataPropertyName = "BossNameID"
        BossNameIDDataGridViewTextBoxColumn.HeaderText = "BossNameID"
        BossNameIDDataGridViewTextBoxColumn.Name = "BossNameIDDataGridViewTextBoxColumn"
        ' 
        ' BossNameID2DataGridViewTextBoxColumn
        ' 
        BossNameID2DataGridViewTextBoxColumn.DataPropertyName = "BossNameID2"
        BossNameID2DataGridViewTextBoxColumn.HeaderText = "BossNameID2"
        BossNameID2DataGridViewTextBoxColumn.Name = "BossNameID2DataGridViewTextBoxColumn"
        ' 
        ' BossNameLocaleDataGridViewTextBoxColumn
        ' 
        BossNameLocaleDataGridViewTextBoxColumn.DataPropertyName = "BossNameLocale"
        BossNameLocaleDataGridViewTextBoxColumn.HeaderText = "BossNameLocale"
        BossNameLocaleDataGridViewTextBoxColumn.Name = "BossNameLocaleDataGridViewTextBoxColumn"
        ' 
        ' BossIDsDataGridViewTextBoxColumn
        ' 
        BossIDsDataGridViewTextBoxColumn.DataPropertyName = "BossIDs"
        BossIDsDataGridViewTextBoxColumn.HeaderText = "BossIDs"
        BossIDsDataGridViewTextBoxColumn.Name = "BossIDsDataGridViewTextBoxColumn"
        ' 
        ' AchievementIDDataGridViewTextBoxColumn
        ' 
        AchievementIDDataGridViewTextBoxColumn.DataPropertyName = "AchievementID"
        AchievementIDDataGridViewTextBoxColumn.HeaderText = "AchievementID"
        AchievementIDDataGridViewTextBoxColumn.Name = "AchievementIDDataGridViewTextBoxColumn"
        ' 
        ' EnabledDataGridViewCheckBoxColumn
        ' 
        EnabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled"
        EnabledDataGridViewCheckBoxColumn.HeaderText = "Enabled"
        EnabledDataGridViewCheckBoxColumn.Name = "EnabledDataGridViewCheckBoxColumn"
        ' 
        ' TrackDataGridViewTextBoxColumn
        ' 
        TrackDataGridViewTextBoxColumn.DataPropertyName = "Track"
        TrackDataGridViewTextBoxColumn.HeaderText = "Track"
        TrackDataGridViewTextBoxColumn.Name = "TrackDataGridViewTextBoxColumn"
        ' 
        ' PartialTrackDataGridViewCheckBoxColumn
        ' 
        PartialTrackDataGridViewCheckBoxColumn.DataPropertyName = "PartialTrack"
        PartialTrackDataGridViewCheckBoxColumn.HeaderText = "PartialTrack"
        PartialTrackDataGridViewCheckBoxColumn.Name = "PartialTrackDataGridViewCheckBoxColumn"
        ' 
        ' EncounterIDDataGridViewTextBoxColumn
        ' 
        EncounterIDDataGridViewTextBoxColumn.DataPropertyName = "EncounterID"
        EncounterIDDataGridViewTextBoxColumn.HeaderText = "EncounterID"
        EncounterIDDataGridViewTextBoxColumn.Name = "EncounterIDDataGridViewTextBoxColumn"
        ' 
        ' EncounterID2DataGridViewTextBoxColumn
        ' 
        EncounterID2DataGridViewTextBoxColumn.DataPropertyName = "EncounterID2"
        EncounterID2DataGridViewTextBoxColumn.HeaderText = "EncounterID2"
        EncounterID2DataGridViewTextBoxColumn.Name = "EncounterID2DataGridViewTextBoxColumn"
        ' 
        ' DisplayInfoFrameDataGridViewCheckBoxColumn
        ' 
        DisplayInfoFrameDataGridViewCheckBoxColumn.DataPropertyName = "DisplayInfoFrame"
        DisplayInfoFrameDataGridViewCheckBoxColumn.HeaderText = "DisplayInfoFrame"
        DisplayInfoFrameDataGridViewCheckBoxColumn.Name = "DisplayInfoFrameDataGridViewCheckBoxColumn"
        ' 
        ' InstanceIdDataGridViewTextBoxColumn1
        ' 
        InstanceIdDataGridViewTextBoxColumn1.DataPropertyName = "InstanceId"
        InstanceIdDataGridViewTextBoxColumn1.HeaderText = "InstanceId"
        InstanceIdDataGridViewTextBoxColumn1.Name = "InstanceIdDataGridViewTextBoxColumn1"
        ' 
        ' InstanceDataGridViewTextBoxColumn
        ' 
        InstanceDataGridViewTextBoxColumn.DataPropertyName = "Instance"
        InstanceDataGridViewTextBoxColumn.HeaderText = "Instance"
        InstanceDataGridViewTextBoxColumn.Name = "InstanceDataGridViewTextBoxColumn"
        ' 
        ' BossesBindingSource
        ' 
        BossesBindingSource.DataMember = "Bosses"
        BossesBindingSource.DataSource = InstancesBindingSource
        ' 
        ' InstancesBindingSource
        ' 
        InstancesBindingSource.DataMember = "Instances"
        InstancesBindingSource.DataSource = InstanceTypesBindingSource
        ' 
        ' dgvInstances
        ' 
        dgvInstances.AutoGenerateColumns = False
        dgvInstances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInstances.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn2, InstanceIdDataGridViewTextBoxColumn, NameDataGridViewTextBoxColumn3, NameWrathDataGridViewTextBoxColumn, InstanceNameIDDataGridViewTextBoxColumn, ClassicPhaseDataGridViewTextBoxColumn, RetailOnlyDataGridViewCheckBoxColumn, ClassicOnlyDataGridViewCheckBoxColumn, LegacySizeDataGridViewTextBoxColumn, DataGridViewTextBoxColumn1, InstanceTypeDataGridViewTextBoxColumn})
        dgvInstances.DataSource = InstancesBindingSource
        dgvInstances.Dock = DockStyle.Fill
        dgvInstances.Location = New Point(3, 3)
        dgvInstances.Name = "dgvInstances"
        dgvInstances.Size = New Size(436, 153)
        dgvInstances.TabIndex = 77
        ' 
        ' IdDataGridViewTextBoxColumn2
        ' 
        IdDataGridViewTextBoxColumn2.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn2.HeaderText = "Id"
        IdDataGridViewTextBoxColumn2.Name = "IdDataGridViewTextBoxColumn2"
        ' 
        ' InstanceIdDataGridViewTextBoxColumn
        ' 
        InstanceIdDataGridViewTextBoxColumn.DataPropertyName = "InstanceId"
        InstanceIdDataGridViewTextBoxColumn.HeaderText = "InstanceId"
        InstanceIdDataGridViewTextBoxColumn.Name = "InstanceIdDataGridViewTextBoxColumn"
        ' 
        ' NameDataGridViewTextBoxColumn3
        ' 
        NameDataGridViewTextBoxColumn3.DataPropertyName = "Name"
        NameDataGridViewTextBoxColumn3.HeaderText = "Name"
        NameDataGridViewTextBoxColumn3.Name = "NameDataGridViewTextBoxColumn3"
        ' 
        ' NameWrathDataGridViewTextBoxColumn
        ' 
        NameWrathDataGridViewTextBoxColumn.DataPropertyName = "NameWrath"
        NameWrathDataGridViewTextBoxColumn.HeaderText = "NameWrath"
        NameWrathDataGridViewTextBoxColumn.Name = "NameWrathDataGridViewTextBoxColumn"
        ' 
        ' InstanceNameIDDataGridViewTextBoxColumn
        ' 
        InstanceNameIDDataGridViewTextBoxColumn.DataPropertyName = "InstanceNameID"
        InstanceNameIDDataGridViewTextBoxColumn.HeaderText = "InstanceNameID"
        InstanceNameIDDataGridViewTextBoxColumn.Name = "InstanceNameIDDataGridViewTextBoxColumn"
        ' 
        ' ClassicPhaseDataGridViewTextBoxColumn
        ' 
        ClassicPhaseDataGridViewTextBoxColumn.DataPropertyName = "ClassicPhase"
        ClassicPhaseDataGridViewTextBoxColumn.HeaderText = "ClassicPhase"
        ClassicPhaseDataGridViewTextBoxColumn.Name = "ClassicPhaseDataGridViewTextBoxColumn"
        ' 
        ' RetailOnlyDataGridViewCheckBoxColumn
        ' 
        RetailOnlyDataGridViewCheckBoxColumn.DataPropertyName = "RetailOnly"
        RetailOnlyDataGridViewCheckBoxColumn.HeaderText = "RetailOnly"
        RetailOnlyDataGridViewCheckBoxColumn.Name = "RetailOnlyDataGridViewCheckBoxColumn"
        ' 
        ' ClassicOnlyDataGridViewCheckBoxColumn
        ' 
        ClassicOnlyDataGridViewCheckBoxColumn.DataPropertyName = "ClassicOnly"
        ClassicOnlyDataGridViewCheckBoxColumn.HeaderText = "ClassicOnly"
        ClassicOnlyDataGridViewCheckBoxColumn.Name = "ClassicOnlyDataGridViewCheckBoxColumn"
        ' 
        ' LegacySizeDataGridViewTextBoxColumn
        ' 
        LegacySizeDataGridViewTextBoxColumn.DataPropertyName = "LegacySize"
        LegacySizeDataGridViewTextBoxColumn.HeaderText = "LegacySize"
        LegacySizeDataGridViewTextBoxColumn.Name = "LegacySizeDataGridViewTextBoxColumn"
        ' 
        ' DataGridViewTextBoxColumn1
        ' 
        DataGridViewTextBoxColumn1.DataPropertyName = "InstanceTypeId"
        DataGridViewTextBoxColumn1.HeaderText = "InstanceTypeId"
        DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        ' 
        ' InstanceTypeDataGridViewTextBoxColumn
        ' 
        InstanceTypeDataGridViewTextBoxColumn.DataPropertyName = "InstanceType"
        InstanceTypeDataGridViewTextBoxColumn.HeaderText = "InstanceType"
        InstanceTypeDataGridViewTextBoxColumn.Name = "InstanceTypeDataGridViewTextBoxColumn"
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel3.Controls.Add(dgvTactics, 0, 0)
        TableLayoutPanel3.Controls.Add(dgvTacticsParameters, 1, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 333)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(884, 161)
        TableLayoutPanel3.TabIndex = 81
        ' 
        ' dgvTactics
        ' 
        dgvTactics.AutoGenerateColumns = False
        dgvTactics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTactics.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn3, ImgurLinkDataGridViewTextBoxColumn, ImageNameDataGridViewTextBoxColumn, ImageWidthDataGridViewTextBoxColumn, ImageHeightDataGridViewTextBoxColumn, LocalisationIdDataGridViewTextBoxColumn, LocalisationDataGridViewTextBoxColumn})
        dgvTactics.DataSource = TacticsBindingSource
        dgvTactics.Dock = DockStyle.Fill
        dgvTactics.Location = New Point(3, 3)
        dgvTactics.Name = "dgvTactics"
        dgvTactics.Size = New Size(436, 155)
        dgvTactics.TabIndex = 0
        ' 
        ' IdDataGridViewTextBoxColumn3
        ' 
        IdDataGridViewTextBoxColumn3.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn3.HeaderText = "Id"
        IdDataGridViewTextBoxColumn3.Name = "IdDataGridViewTextBoxColumn3"
        ' 
        ' ImgurLinkDataGridViewTextBoxColumn
        ' 
        ImgurLinkDataGridViewTextBoxColumn.DataPropertyName = "ImgurLink"
        ImgurLinkDataGridViewTextBoxColumn.HeaderText = "ImgurLink"
        ImgurLinkDataGridViewTextBoxColumn.Name = "ImgurLinkDataGridViewTextBoxColumn"
        ' 
        ' ImageNameDataGridViewTextBoxColumn
        ' 
        ImageNameDataGridViewTextBoxColumn.DataPropertyName = "ImageName"
        ImageNameDataGridViewTextBoxColumn.HeaderText = "ImageName"
        ImageNameDataGridViewTextBoxColumn.Name = "ImageNameDataGridViewTextBoxColumn"
        ' 
        ' ImageWidthDataGridViewTextBoxColumn
        ' 
        ImageWidthDataGridViewTextBoxColumn.DataPropertyName = "ImageWidth"
        ImageWidthDataGridViewTextBoxColumn.HeaderText = "ImageWidth"
        ImageWidthDataGridViewTextBoxColumn.Name = "ImageWidthDataGridViewTextBoxColumn"
        ' 
        ' ImageHeightDataGridViewTextBoxColumn
        ' 
        ImageHeightDataGridViewTextBoxColumn.DataPropertyName = "ImageHeight"
        ImageHeightDataGridViewTextBoxColumn.HeaderText = "ImageHeight"
        ImageHeightDataGridViewTextBoxColumn.Name = "ImageHeightDataGridViewTextBoxColumn"
        ' 
        ' LocalisationIdDataGridViewTextBoxColumn
        ' 
        LocalisationIdDataGridViewTextBoxColumn.DataPropertyName = "LocalisationId"
        LocalisationIdDataGridViewTextBoxColumn.HeaderText = "LocalisationId"
        LocalisationIdDataGridViewTextBoxColumn.Name = "LocalisationIdDataGridViewTextBoxColumn"
        ' 
        ' LocalisationDataGridViewTextBoxColumn
        ' 
        LocalisationDataGridViewTextBoxColumn.DataPropertyName = "Localisation"
        LocalisationDataGridViewTextBoxColumn.HeaderText = "Localisation"
        LocalisationDataGridViewTextBoxColumn.Name = "LocalisationDataGridViewTextBoxColumn"
        ' 
        ' TacticsBindingSource
        ' 
        TacticsBindingSource.DataMember = "Tactics"
        TacticsBindingSource.DataSource = BossesBindingSource
        ' 
        ' dgvTacticsParameters
        ' 
        dgvTacticsParameters.AutoGenerateColumns = False
        dgvTacticsParameters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTacticsParameters.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn5, OrderDataGridViewTextBoxColumn1, ParameterIDDataGridViewTextBoxColumn, ParameterTypeDataGridViewTextBoxColumn})
        dgvTacticsParameters.DataSource = TacticParameterBindingSource
        dgvTacticsParameters.Dock = DockStyle.Fill
        dgvTacticsParameters.Location = New Point(445, 3)
        dgvTacticsParameters.Name = "dgvTacticsParameters"
        dgvTacticsParameters.Size = New Size(436, 155)
        dgvTacticsParameters.TabIndex = 1
        ' 
        ' IdDataGridViewTextBoxColumn5
        ' 
        IdDataGridViewTextBoxColumn5.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn5.HeaderText = "Id"
        IdDataGridViewTextBoxColumn5.Name = "IdDataGridViewTextBoxColumn5"
        ' 
        ' OrderDataGridViewTextBoxColumn1
        ' 
        OrderDataGridViewTextBoxColumn1.DataPropertyName = "Order"
        OrderDataGridViewTextBoxColumn1.HeaderText = "Order"
        OrderDataGridViewTextBoxColumn1.Name = "OrderDataGridViewTextBoxColumn1"
        ' 
        ' ParameterIDDataGridViewTextBoxColumn
        ' 
        ParameterIDDataGridViewTextBoxColumn.DataPropertyName = "ParameterID"
        ParameterIDDataGridViewTextBoxColumn.HeaderText = "ParameterID"
        ParameterIDDataGridViewTextBoxColumn.Name = "ParameterIDDataGridViewTextBoxColumn"
        ' 
        ' ParameterTypeDataGridViewTextBoxColumn
        ' 
        ParameterTypeDataGridViewTextBoxColumn.DataPropertyName = "ParameterType"
        ParameterTypeDataGridViewTextBoxColumn.HeaderText = "ParameterType"
        ParameterTypeDataGridViewTextBoxColumn.Name = "ParameterTypeDataGridViewTextBoxColumn"
        ' 
        ' TacticParameterBindingSource
        ' 
        TacticParameterBindingSource.DataMember = "TacticParameter"
        TacticParameterBindingSource.DataSource = TacticsBindingSource
        ' 
        ' tlpContentLeft
        ' 
        tlpContentLeft.ColumnCount = 1
        tlpContentLeft.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpContentLeft.Controls.Add(Panel2, 0, 0)
        tlpContentLeft.Controls.Add(tcTactics, 0, 1)
        tlpContentLeft.Dock = DockStyle.Fill
        tlpContentLeft.Location = New Point(3, 3)
        tlpContentLeft.Name = "tlpContentLeft"
        tlpContentLeft.RowCount = 2
        tlpContentLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 75F))
        tlpContentLeft.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpContentLeft.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpContentLeft.Size = New Size(587, 497)
        tlpContentLeft.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(btnTestTranslationClassic)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(btnUploadLocaleClassic)
        Panel2.Controls.Add(btnGenerateLocalisationClassic)
        Panel2.Controls.Add(cboBosses)
        Panel2.Controls.Add(btnGenerateLocaleNoUpload)
        Panel2.Controls.Add(btnUploadLocale)
        Panel2.Controls.Add(btnGenerateLocalisation)
        Panel2.Controls.Add(btnInsertTactic)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(581, 118)
        Panel2.TabIndex = 0
        ' 
        ' tcTactics
        ' 
        tcTactics.Controls.Add(TabPage1)
        tcTactics.Controls.Add(TabPage2)
        tcTactics.Dock = DockStyle.Fill
        tcTactics.Location = New Point(3, 127)
        tcTactics.Name = "tcTactics"
        tcTactics.SelectedIndex = 0
        tcTactics.Size = New Size(581, 367)
        tcTactics.TabIndex = 1
        ' 
        ' TabPage1
        ' 
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(573, 339)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(573, 339)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' frmIATDatabaseManager
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1489, 527)
        Controls.Add(tlpContainer)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(4, 3, 4, 3)
        Name = "frmIATDatabaseManager"
        Text = "IAT Database Manager"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(dgvExpansions, ComponentModel.ISupportInitialize).EndInit()
        CType(ExpansionBindingSource, ComponentModel.ISupportInitialize).EndInit()
        tlpContainer.ResumeLayout(False)
        tlpContentRight.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        CType(dgvInstanceTypes, ComponentModel.ISupportInitialize).EndInit()
        CType(InstanceTypesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel2.ResumeLayout(False)
        CType(dgvBosses, ComponentModel.ISupportInitialize).EndInit()
        CType(BossesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(InstancesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvInstances, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel3.ResumeLayout(False)
        CType(dgvTactics, ComponentModel.ISupportInitialize).EndInit()
        CType(TacticsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvTacticsParameters, ComponentModel.ISupportInitialize).EndInit()
        CType(TacticParameterBindingSource, ComponentModel.ISupportInitialize).EndInit()
        tlpContentLeft.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        tcTactics.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents cboBosses As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnInsertTactic As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents InsertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpansionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BossToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnGenerateLocalisation As Button
    Friend WithEvents btnUploadLocale As Button
    Friend WithEvents btnGenerateLocaleNoUpload As Button
    Friend WithEvents LocalisationManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnTestTranslationClassic As Button
    Friend WithEvents btnUploadLocaleClassic As Button
    Friend WithEvents btnGenerateLocalisationClassic As Button
    Friend WithEvents dgvExpansions As DataGridView
    Friend WithEvents tlpContainer As TableLayoutPanel
    Friend WithEvents tlpContentRight As TableLayoutPanel
    Friend WithEvents dgvInstances As DataGridView
    Friend WithEvents dgvInstanceTypes As DataGridView
    Friend WithEvents tlpContentLeft As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvBosses As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents InstanceTypeIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExpansionGameIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InstanceTypesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExpansionBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents InstanceTypesDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents BossIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PlayersDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TacticsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocaleTextDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocaleNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HTMLTacticsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossNameWrathDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClassicTacticsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocaleTextClassicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocaleNameClassicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImgurLinkClassicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImageClassicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EncounterIDWrathDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InstancesBindingSource As BindingSource
    Friend WithEvents InstanceTypesBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents InstanceIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents NameWrathDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InstanceNameIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClassicPhaseDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RetailOnlyDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents ClassicOnlyDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents LegacySizeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents InstanceTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents dgvTactics As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents dgvTacticsParameters As DataGridView
    Friend WithEvents IdDataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents OrderDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossNameIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossNameID2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossNameLocaleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossIDsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AchievementIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EnabledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents TrackDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PartialTrackDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents EncounterIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EncounterID2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DisplayInfoFrameDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents InstanceIdDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents InstanceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossesBindingSource As BindingSource
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents PatchDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImgurLinkDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImageNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImageWidthDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImageHeightDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocalisationIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TacticParameterIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocalisationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TacticsBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents OrderDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents ParameterIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ParameterTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TacticParameterBindingSource As BindingSource
    Friend WithEvents tcTactics As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
End Class
