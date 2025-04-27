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
        txtTacticsLocale = New TextBox()
        btnInsertTactic = New Button()
        Label3 = New Label()
        cboNPC = New ComboBox()
        Label4 = New Label()
        MenuStrip1 = New MenuStrip()
        InsertToolStripMenuItem = New ToolStripMenuItem()
        ExpansionToolStripMenuItem = New ToolStripMenuItem()
        InstanceToolStripMenuItem = New ToolStripMenuItem()
        BossToolStripMenuItem = New ToolStripMenuItem()
        ImportToolStripMenuItem = New ToolStripMenuItem()
        NPCsToolStripMenuItem = New ToolStripMenuItem()
        SpellsToolStripMenuItem = New ToolStripMenuItem()
        ViewSpellsToolStripMenuItem = New ToolStripMenuItem()
        LocalisationManagerToolStripMenuItem = New ToolStripMenuItem()
        CoordinateBuilderToolStripMenuItem = New ToolStripMenuItem()
        txtNewTactics = New TextBox()
        btnGenerateLocalisation = New Button()
        txtInGame = New TextBox()
        btnUploadLocale = New Button()
        txtSpellName = New TextBox()
        btnAddSpell = New Button()
        btnGenerateLocaleNoUpload = New Button()
        btnTestTranslationClassic = New Button()
        btnUploadLocaleClassic = New Button()
        btnGenerateLocalisationClassic = New Button()
        dgvExpansions = New DataGridView()
        tlpContainer = New TableLayoutPanel()
        tlpContentRight = New TableLayoutPanel()
        dgvBosses = New DataGridView()
        TableLayoutPanel1 = New TableLayoutPanel()
        dgvInstanceTypes = New DataGridView()
        dgvInstances = New DataGridView()
        tlpContentLeft = New TableLayoutPanel()
        Panel2 = New Panel()
        ExpansionBindingSource = New BindingSource(components)
        ExpansionIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        NameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        InstanceTypesBindingSource = New BindingSource(components)
        InstanceTypeIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        NameDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        InstancesBindingSource = New BindingSource(components)
        IdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        InstanceIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        NameDataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
        NameWrathDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        InstanceNameIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ClassicPhaseDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        RetailOnlyDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        ClassicOnlyDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        LegacySizeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ExpansionIdDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        InstanceTypeIdDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        ExpansionDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        InstanceTypeDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossesBindingSource = New BindingSource(components)
        BossIdDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        OrderDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossNameIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossIDsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        AchievementIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PlayersDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        TacticsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        EnabledDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        TrackDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        PartialTrackDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        EncounterIDDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        DisplayInfoFrameDataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        LocaleTextDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        LocaleNameDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ImgurLinkDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        HTMLTacticsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ImageDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        BossNameWrathDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ClassicTacticsDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        LocaleTextClassicDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        LocaleNameClassicDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ImgurLinkClassicDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        ImageClassicDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        EncounterIDWrathDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        InstanceIdDataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        InstanceDataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        MenuStrip1.SuspendLayout()
        CType(dgvExpansions, ComponentModel.ISupportInitialize).BeginInit()
        tlpContainer.SuspendLayout()
        tlpContentRight.SuspendLayout()
        CType(dgvBosses, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        CType(dgvInstanceTypes, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvInstances, ComponentModel.ISupportInitialize).BeginInit()
        tlpContentLeft.SuspendLayout()
        Panel2.SuspendLayout()
        CType(ExpansionBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(InstanceTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(InstancesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(BossesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
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
        ' txtTacticsLocale
        ' 
        txtTacticsLocale.Dock = DockStyle.Fill
        txtTacticsLocale.Location = New Point(4, 253)
        txtTacticsLocale.Margin = New Padding(4, 3, 4, 3)
        txtTacticsLocale.Multiline = True
        txtTacticsLocale.Name = "txtTacticsLocale"
        txtTacticsLocale.ScrollBars = ScrollBars.Vertical
        txtTacticsLocale.Size = New Size(734, 119)
        txtTacticsLocale.TabIndex = 2
        ' 
        ' btnInsertTactic
        ' 
        btnInsertTactic.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnInsertTactic.Location = New Point(554, 77)
        btnInsertTactic.Margin = New Padding(4, 3, 4, 3)
        btnInsertTactic.Name = "btnInsertTactic"
        btnInsertTactic.Size = New Size(130, 26)
        btnInsertTactic.TabIndex = 4
        btnInsertTactic.Text = "Save Changes"
        btnInsertTactic.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(9, 68)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 15)
        Label3.TabIndex = 6
        Label3.Text = "Insert NPC"
        ' 
        ' cboNPC
        ' 
        cboNPC.FormattingEnabled = True
        cboNPC.Location = New Point(80, 65)
        cboNPC.Margin = New Padding(4, 3, 4, 3)
        cboNPC.Name = "cboNPC"
        cboNPC.Size = New Size(140, 23)
        cboNPC.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(10, 43)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(96, 15)
        Label4.TabIndex = 8
        Label4.Text = "Item/Spell Name"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {InsertToolStripMenuItem, ImportToolStripMenuItem, ViewSpellsToolStripMenuItem, LocalisationManagerToolStripMenuItem, CoordinateBuilderToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(7, 2, 0, 2)
        MenuStrip1.Size = New Size(1497, 24)
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
        ExpansionToolStripMenuItem.Size = New Size(127, 22)
        ExpansionToolStripMenuItem.Text = "Expansion"
        ' 
        ' InstanceToolStripMenuItem
        ' 
        InstanceToolStripMenuItem.Name = "InstanceToolStripMenuItem"
        InstanceToolStripMenuItem.Size = New Size(127, 22)
        InstanceToolStripMenuItem.Text = "Instance"
        ' 
        ' BossToolStripMenuItem
        ' 
        BossToolStripMenuItem.Name = "BossToolStripMenuItem"
        BossToolStripMenuItem.Size = New Size(127, 22)
        BossToolStripMenuItem.Text = "Boss"
        ' 
        ' ImportToolStripMenuItem
        ' 
        ImportToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NPCsToolStripMenuItem, SpellsToolStripMenuItem})
        ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        ImportToolStripMenuItem.Size = New Size(55, 20)
        ImportToolStripMenuItem.Text = "Import"
        ' 
        ' NPCsToolStripMenuItem
        ' 
        NPCsToolStripMenuItem.Name = "NPCsToolStripMenuItem"
        NPCsToolStripMenuItem.Size = New Size(106, 22)
        NPCsToolStripMenuItem.Text = "NPC's"
        ' 
        ' SpellsToolStripMenuItem
        ' 
        SpellsToolStripMenuItem.Name = "SpellsToolStripMenuItem"
        SpellsToolStripMenuItem.Size = New Size(106, 22)
        SpellsToolStripMenuItem.Text = "Spells"
        ' 
        ' ViewSpellsToolStripMenuItem
        ' 
        ViewSpellsToolStripMenuItem.Name = "ViewSpellsToolStripMenuItem"
        ViewSpellsToolStripMenuItem.Size = New Size(77, 20)
        ViewSpellsToolStripMenuItem.Text = "View Spells"
        ' 
        ' LocalisationManagerToolStripMenuItem
        ' 
        LocalisationManagerToolStripMenuItem.Name = "LocalisationManagerToolStripMenuItem"
        LocalisationManagerToolStripMenuItem.Size = New Size(123, 20)
        LocalisationManagerToolStripMenuItem.Text = "Update Localisation"
        ' 
        ' CoordinateBuilderToolStripMenuItem
        ' 
        CoordinateBuilderToolStripMenuItem.Name = "CoordinateBuilderToolStripMenuItem"
        CoordinateBuilderToolStripMenuItem.Size = New Size(118, 20)
        CoordinateBuilderToolStripMenuItem.Text = "Coordinate Builder"
        ' 
        ' txtNewTactics
        ' 
        txtNewTactics.Dock = DockStyle.Fill
        txtNewTactics.Location = New Point(4, 128)
        txtNewTactics.Margin = New Padding(4, 3, 4, 3)
        txtNewTactics.Multiline = True
        txtNewTactics.Name = "txtNewTactics"
        txtNewTactics.ScrollBars = ScrollBars.Vertical
        txtNewTactics.Size = New Size(734, 119)
        txtNewTactics.TabIndex = 53
        ' 
        ' btnGenerateLocalisation
        ' 
        btnGenerateLocalisation.Location = New Point(411, 7)
        btnGenerateLocalisation.Margin = New Padding(4, 3, 4, 3)
        btnGenerateLocalisation.Name = "btnGenerateLocalisation"
        btnGenerateLocalisation.Size = New Size(126, 22)
        btnGenerateLocalisation.TabIndex = 54
        btnGenerateLocalisation.Text = "Create Imgur Link"
        btnGenerateLocalisation.UseVisualStyleBackColor = True
        ' 
        ' txtInGame
        ' 
        txtInGame.Dock = DockStyle.Fill
        txtInGame.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtInGame.Location = New Point(4, 378)
        txtInGame.Margin = New Padding(4, 3, 4, 3)
        txtInGame.Multiline = True
        txtInGame.Name = "txtInGame"
        txtInGame.Size = New Size(734, 120)
        txtInGame.TabIndex = 55
        ' 
        ' btnUploadLocale
        ' 
        btnUploadLocale.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnUploadLocale.Location = New Point(411, 83)
        btnUploadLocale.Margin = New Padding(4, 3, 4, 3)
        btnUploadLocale.Name = "btnUploadLocale"
        btnUploadLocale.Size = New Size(130, 20)
        btnUploadLocale.TabIndex = 56
        btnUploadLocale.Text = "Upload Locale"
        btnUploadLocale.UseVisualStyleBackColor = True
        ' 
        ' txtSpellName
        ' 
        txtSpellName.Location = New Point(114, 36)
        txtSpellName.Margin = New Padding(4, 3, 4, 3)
        txtSpellName.Name = "txtSpellName"
        txtSpellName.Size = New Size(148, 23)
        txtSpellName.TabIndex = 61
        ' 
        ' btnAddSpell
        ' 
        btnAddSpell.Location = New Point(269, 32)
        btnAddSpell.Margin = New Padding(4, 3, 4, 3)
        btnAddSpell.Name = "btnAddSpell"
        btnAddSpell.Size = New Size(58, 28)
        btnAddSpell.TabIndex = 62
        btnAddSpell.Text = "Insert"
        btnAddSpell.UseVisualStyleBackColor = True
        ' 
        ' btnGenerateLocaleNoUpload
        ' 
        btnGenerateLocaleNoUpload.Location = New Point(411, 31)
        btnGenerateLocaleNoUpload.Margin = New Padding(4, 3, 4, 3)
        btnGenerateLocaleNoUpload.Name = "btnGenerateLocaleNoUpload"
        btnGenerateLocaleNoUpload.Size = New Size(135, 22)
        btnGenerateLocaleNoUpload.TabIndex = 64
        btnGenerateLocaleNoUpload.Text = "Test Translation"
        btnGenerateLocaleNoUpload.UseVisualStyleBackColor = True
        ' 
        ' btnTestTranslationClassic
        ' 
        btnTestTranslationClassic.Location = New Point(554, 31)
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
        btnUploadLocaleClassic.Location = New Point(253, 81)
        btnUploadLocaleClassic.Margin = New Padding(4, 3, 4, 3)
        btnUploadLocaleClassic.Name = "btnUploadLocaleClassic"
        btnUploadLocaleClassic.Size = New Size(130, 19)
        btnUploadLocaleClassic.TabIndex = 72
        btnUploadLocaleClassic.Text = "Upload Locale Classic"
        btnUploadLocaleClassic.UseVisualStyleBackColor = True
        ' 
        ' btnGenerateLocalisationClassic
        ' 
        btnGenerateLocalisationClassic.Location = New Point(545, 7)
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
        dgvExpansions.Columns.AddRange(New DataGridViewColumn() {ExpansionIdDataGridViewTextBoxColumn, NameDataGridViewTextBoxColumn})
        dgvExpansions.DataSource = ExpansionBindingSource
        dgvExpansions.Dock = DockStyle.Fill
        dgvExpansions.Location = New Point(3, 3)
        dgvExpansions.Name = "dgvExpansions"
        dgvExpansions.Size = New Size(362, 155)
        dgvExpansions.TabIndex = 75
        ' 
        ' tlpContainer
        ' 
        tlpContainer.ColumnCount = 2
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContainer.Controls.Add(tlpContentRight, 1, 0)
        tlpContainer.Controls.Add(tlpContentLeft, 0, 0)
        tlpContainer.Dock = DockStyle.Fill
        tlpContainer.Location = New Point(0, 24)
        tlpContainer.Name = "tlpContainer"
        tlpContainer.RowCount = 1
        tlpContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpContainer.Size = New Size(1497, 507)
        tlpContainer.TabIndex = 76
        ' 
        ' tlpContentRight
        ' 
        tlpContentRight.ColumnCount = 1
        tlpContentRight.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpContentRight.Controls.Add(dgvBosses, 0, 2)
        tlpContentRight.Controls.Add(TableLayoutPanel1, 0, 0)
        tlpContentRight.Controls.Add(dgvInstances, 0, 1)
        tlpContentRight.Dock = DockStyle.Fill
        tlpContentRight.Location = New Point(751, 3)
        tlpContentRight.Name = "tlpContentRight"
        tlpContentRight.RowCount = 3
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentRight.Size = New Size(743, 501)
        tlpContentRight.TabIndex = 0
        ' 
        ' dgvBosses
        ' 
        dgvBosses.AllowUserToAddRows = False
        dgvBosses.AutoGenerateColumns = False
        dgvBosses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBosses.Columns.AddRange(New DataGridViewColumn() {BossIdDataGridViewTextBoxColumn, OrderDataGridViewTextBoxColumn, BossNameDataGridViewTextBoxColumn, BossNameIDDataGridViewTextBoxColumn, BossIDsDataGridViewTextBoxColumn, AchievementIDDataGridViewTextBoxColumn, PlayersDataGridViewTextBoxColumn, TacticsDataGridViewTextBoxColumn, EnabledDataGridViewCheckBoxColumn, TrackDataGridViewTextBoxColumn, PartialTrackDataGridViewTextBoxColumn, EncounterIDDataGridViewTextBoxColumn, DisplayInfoFrameDataGridViewCheckBoxColumn, LocaleTextDataGridViewTextBoxColumn, LocaleNameDataGridViewTextBoxColumn, ImgurLinkDataGridViewTextBoxColumn, HTMLTacticsDataGridViewTextBoxColumn, ImageDataGridViewTextBoxColumn, BossNameWrathDataGridViewTextBoxColumn, ClassicTacticsDataGridViewTextBoxColumn, LocaleTextClassicDataGridViewTextBoxColumn, LocaleNameClassicDataGridViewTextBoxColumn, ImgurLinkClassicDataGridViewTextBoxColumn, ImageClassicDataGridViewTextBoxColumn, EncounterIDWrathDataGridViewTextBoxColumn, InstanceIdDataGridViewTextBoxColumn1, InstanceDataGridViewTextBoxColumn})
        dgvBosses.DataSource = BossesBindingSource
        dgvBosses.Dock = DockStyle.Fill
        dgvBosses.Location = New Point(3, 337)
        dgvBosses.Name = "dgvBosses"
        dgvBosses.Size = New Size(737, 161)
        dgvBosses.TabIndex = 0
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
        TableLayoutPanel1.Size = New Size(737, 161)
        TableLayoutPanel1.TabIndex = 79
        ' 
        ' dgvInstanceTypes
        ' 
        dgvInstanceTypes.AutoGenerateColumns = False
        dgvInstanceTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInstanceTypes.Columns.AddRange(New DataGridViewColumn() {InstanceTypeIdDataGridViewTextBoxColumn, NameDataGridViewTextBoxColumn1})
        dgvInstanceTypes.DataSource = InstanceTypesBindingSource
        dgvInstanceTypes.Dock = DockStyle.Fill
        dgvInstanceTypes.Location = New Point(371, 3)
        dgvInstanceTypes.Name = "dgvInstanceTypes"
        dgvInstanceTypes.Size = New Size(363, 155)
        dgvInstanceTypes.TabIndex = 76
        ' 
        ' dgvInstances
        ' 
        dgvInstances.AutoGenerateColumns = False
        dgvInstances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInstances.Columns.AddRange(New DataGridViewColumn() {IdDataGridViewTextBoxColumn, InstanceIdDataGridViewTextBoxColumn, NameDataGridViewTextBoxColumn2, NameWrathDataGridViewTextBoxColumn, InstanceNameIDDataGridViewTextBoxColumn, ClassicPhaseDataGridViewTextBoxColumn, RetailOnlyDataGridViewCheckBoxColumn, ClassicOnlyDataGridViewCheckBoxColumn, LegacySizeDataGridViewTextBoxColumn, ExpansionIdDataGridViewTextBoxColumn1, InstanceTypeIdDataGridViewTextBoxColumn1, ExpansionDataGridViewTextBoxColumn, InstanceTypeDataGridViewTextBoxColumn})
        dgvInstances.DataSource = InstancesBindingSource
        dgvInstances.Dock = DockStyle.Fill
        dgvInstances.Location = New Point(3, 170)
        dgvInstances.Name = "dgvInstances"
        dgvInstances.Size = New Size(737, 161)
        dgvInstances.TabIndex = 77
        ' 
        ' tlpContentLeft
        ' 
        tlpContentLeft.ColumnCount = 1
        tlpContentLeft.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpContentLeft.Controls.Add(Panel2, 0, 0)
        tlpContentLeft.Controls.Add(txtInGame, 0, 3)
        tlpContentLeft.Controls.Add(txtTacticsLocale, 0, 2)
        tlpContentLeft.Controls.Add(txtNewTactics, 0, 1)
        tlpContentLeft.Dock = DockStyle.Fill
        tlpContentLeft.Location = New Point(3, 3)
        tlpContentLeft.Name = "tlpContentLeft"
        tlpContentLeft.RowCount = 4
        tlpContentLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpContentLeft.Size = New Size(742, 501)
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
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(btnUploadLocale)
        Panel2.Controls.Add(btnAddSpell)
        Panel2.Controls.Add(btnGenerateLocalisation)
        Panel2.Controls.Add(cboNPC)
        Panel2.Controls.Add(btnInsertTactic)
        Panel2.Controls.Add(txtSpellName)
        Panel2.Controls.Add(Label4)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(736, 119)
        Panel2.TabIndex = 0
        ' 
        ' ExpansionBindingSource
        ' 
        ExpansionBindingSource.DataSource = GetType(Expansion)
        ' 
        ' ExpansionIdDataGridViewTextBoxColumn
        ' 
        ExpansionIdDataGridViewTextBoxColumn.DataPropertyName = "ExpansionId"
        ExpansionIdDataGridViewTextBoxColumn.HeaderText = "ExpansionId"
        ExpansionIdDataGridViewTextBoxColumn.Name = "ExpansionIdDataGridViewTextBoxColumn"
        ' 
        ' NameDataGridViewTextBoxColumn
        ' 
        NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        NameDataGridViewTextBoxColumn.HeaderText = "Name"
        NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        ' 
        ' InstanceTypesBindingSource
        ' 
        InstanceTypesBindingSource.DataMember = "InstanceTypes"
        InstanceTypesBindingSource.DataSource = ExpansionBindingSource
        ' 
        ' InstanceTypeIdDataGridViewTextBoxColumn
        ' 
        InstanceTypeIdDataGridViewTextBoxColumn.DataPropertyName = "InstanceTypeId"
        InstanceTypeIdDataGridViewTextBoxColumn.HeaderText = "InstanceTypeId"
        InstanceTypeIdDataGridViewTextBoxColumn.Name = "InstanceTypeIdDataGridViewTextBoxColumn"
        ' 
        ' NameDataGridViewTextBoxColumn1
        ' 
        NameDataGridViewTextBoxColumn1.DataPropertyName = "Name"
        NameDataGridViewTextBoxColumn1.HeaderText = "Name"
        NameDataGridViewTextBoxColumn1.Name = "NameDataGridViewTextBoxColumn1"
        ' 
        ' InstancesBindingSource
        ' 
        InstancesBindingSource.DataMember = "Instances"
        InstancesBindingSource.DataSource = InstanceTypesBindingSource
        ' 
        ' IdDataGridViewTextBoxColumn
        ' 
        IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        IdDataGridViewTextBoxColumn.HeaderText = "Id"
        IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        ' 
        ' InstanceIdDataGridViewTextBoxColumn
        ' 
        InstanceIdDataGridViewTextBoxColumn.DataPropertyName = "InstanceId"
        InstanceIdDataGridViewTextBoxColumn.HeaderText = "InstanceId"
        InstanceIdDataGridViewTextBoxColumn.Name = "InstanceIdDataGridViewTextBoxColumn"
        ' 
        ' NameDataGridViewTextBoxColumn2
        ' 
        NameDataGridViewTextBoxColumn2.DataPropertyName = "Name"
        NameDataGridViewTextBoxColumn2.HeaderText = "Name"
        NameDataGridViewTextBoxColumn2.Name = "NameDataGridViewTextBoxColumn2"
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
        ' ExpansionIdDataGridViewTextBoxColumn1
        ' 
        ExpansionIdDataGridViewTextBoxColumn1.DataPropertyName = "ExpansionId"
        ExpansionIdDataGridViewTextBoxColumn1.HeaderText = "ExpansionId"
        ExpansionIdDataGridViewTextBoxColumn1.Name = "ExpansionIdDataGridViewTextBoxColumn1"
        ' 
        ' InstanceTypeIdDataGridViewTextBoxColumn1
        ' 
        InstanceTypeIdDataGridViewTextBoxColumn1.DataPropertyName = "InstanceTypeId"
        InstanceTypeIdDataGridViewTextBoxColumn1.HeaderText = "InstanceTypeId"
        InstanceTypeIdDataGridViewTextBoxColumn1.Name = "InstanceTypeIdDataGridViewTextBoxColumn1"
        ' 
        ' ExpansionDataGridViewTextBoxColumn
        ' 
        ExpansionDataGridViewTextBoxColumn.DataPropertyName = "Expansion"
        ExpansionDataGridViewTextBoxColumn.HeaderText = "Expansion"
        ExpansionDataGridViewTextBoxColumn.Name = "ExpansionDataGridViewTextBoxColumn"
        ' 
        ' InstanceTypeDataGridViewTextBoxColumn
        ' 
        InstanceTypeDataGridViewTextBoxColumn.DataPropertyName = "InstanceType"
        InstanceTypeDataGridViewTextBoxColumn.HeaderText = "InstanceType"
        InstanceTypeDataGridViewTextBoxColumn.Name = "InstanceTypeDataGridViewTextBoxColumn"
        ' 
        ' BossesBindingSource
        ' 
        BossesBindingSource.DataMember = "Bosses"
        BossesBindingSource.DataSource = InstancesBindingSource
        ' 
        ' BossIdDataGridViewTextBoxColumn
        ' 
        BossIdDataGridViewTextBoxColumn.DataPropertyName = "BossId"
        BossIdDataGridViewTextBoxColumn.HeaderText = "BossId"
        BossIdDataGridViewTextBoxColumn.Name = "BossIdDataGridViewTextBoxColumn"
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
        ' PlayersDataGridViewTextBoxColumn
        ' 
        PlayersDataGridViewTextBoxColumn.DataPropertyName = "Players"
        PlayersDataGridViewTextBoxColumn.HeaderText = "Players"
        PlayersDataGridViewTextBoxColumn.Name = "PlayersDataGridViewTextBoxColumn"
        ' 
        ' TacticsDataGridViewTextBoxColumn
        ' 
        TacticsDataGridViewTextBoxColumn.DataPropertyName = "Tactics"
        TacticsDataGridViewTextBoxColumn.HeaderText = "Tactics"
        TacticsDataGridViewTextBoxColumn.Name = "TacticsDataGridViewTextBoxColumn"
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
        ' PartialTrackDataGridViewTextBoxColumn
        ' 
        PartialTrackDataGridViewTextBoxColumn.DataPropertyName = "PartialTrack"
        PartialTrackDataGridViewTextBoxColumn.HeaderText = "PartialTrack"
        PartialTrackDataGridViewTextBoxColumn.Name = "PartialTrackDataGridViewTextBoxColumn"
        ' 
        ' EncounterIDDataGridViewTextBoxColumn
        ' 
        EncounterIDDataGridViewTextBoxColumn.DataPropertyName = "EncounterID"
        EncounterIDDataGridViewTextBoxColumn.HeaderText = "EncounterID"
        EncounterIDDataGridViewTextBoxColumn.Name = "EncounterIDDataGridViewTextBoxColumn"
        ' 
        ' DisplayInfoFrameDataGridViewCheckBoxColumn
        ' 
        DisplayInfoFrameDataGridViewCheckBoxColumn.DataPropertyName = "DisplayInfoFrame"
        DisplayInfoFrameDataGridViewCheckBoxColumn.HeaderText = "DisplayInfoFrame"
        DisplayInfoFrameDataGridViewCheckBoxColumn.Name = "DisplayInfoFrameDataGridViewCheckBoxColumn"
        ' 
        ' LocaleTextDataGridViewTextBoxColumn
        ' 
        LocaleTextDataGridViewTextBoxColumn.DataPropertyName = "LocaleText"
        LocaleTextDataGridViewTextBoxColumn.HeaderText = "LocaleText"
        LocaleTextDataGridViewTextBoxColumn.Name = "LocaleTextDataGridViewTextBoxColumn"
        ' 
        ' LocaleNameDataGridViewTextBoxColumn
        ' 
        LocaleNameDataGridViewTextBoxColumn.DataPropertyName = "LocaleName"
        LocaleNameDataGridViewTextBoxColumn.HeaderText = "LocaleName"
        LocaleNameDataGridViewTextBoxColumn.Name = "LocaleNameDataGridViewTextBoxColumn"
        ' 
        ' ImgurLinkDataGridViewTextBoxColumn
        ' 
        ImgurLinkDataGridViewTextBoxColumn.DataPropertyName = "ImgurLink"
        ImgurLinkDataGridViewTextBoxColumn.HeaderText = "ImgurLink"
        ImgurLinkDataGridViewTextBoxColumn.Name = "ImgurLinkDataGridViewTextBoxColumn"
        ' 
        ' HTMLTacticsDataGridViewTextBoxColumn
        ' 
        HTMLTacticsDataGridViewTextBoxColumn.DataPropertyName = "HTMLTactics"
        HTMLTacticsDataGridViewTextBoxColumn.HeaderText = "HTMLTactics"
        HTMLTacticsDataGridViewTextBoxColumn.Name = "HTMLTacticsDataGridViewTextBoxColumn"
        ' 
        ' ImageDataGridViewTextBoxColumn
        ' 
        ImageDataGridViewTextBoxColumn.DataPropertyName = "Image"
        ImageDataGridViewTextBoxColumn.HeaderText = "Image"
        ImageDataGridViewTextBoxColumn.Name = "ImageDataGridViewTextBoxColumn"
        ' 
        ' BossNameWrathDataGridViewTextBoxColumn
        ' 
        BossNameWrathDataGridViewTextBoxColumn.DataPropertyName = "BossNameWrath"
        BossNameWrathDataGridViewTextBoxColumn.HeaderText = "BossNameWrath"
        BossNameWrathDataGridViewTextBoxColumn.Name = "BossNameWrathDataGridViewTextBoxColumn"
        ' 
        ' ClassicTacticsDataGridViewTextBoxColumn
        ' 
        ClassicTacticsDataGridViewTextBoxColumn.DataPropertyName = "ClassicTactics"
        ClassicTacticsDataGridViewTextBoxColumn.HeaderText = "ClassicTactics"
        ClassicTacticsDataGridViewTextBoxColumn.Name = "ClassicTacticsDataGridViewTextBoxColumn"
        ' 
        ' LocaleTextClassicDataGridViewTextBoxColumn
        ' 
        LocaleTextClassicDataGridViewTextBoxColumn.DataPropertyName = "LocaleTextClassic"
        LocaleTextClassicDataGridViewTextBoxColumn.HeaderText = "LocaleTextClassic"
        LocaleTextClassicDataGridViewTextBoxColumn.Name = "LocaleTextClassicDataGridViewTextBoxColumn"
        ' 
        ' LocaleNameClassicDataGridViewTextBoxColumn
        ' 
        LocaleNameClassicDataGridViewTextBoxColumn.DataPropertyName = "LocaleNameClassic"
        LocaleNameClassicDataGridViewTextBoxColumn.HeaderText = "LocaleNameClassic"
        LocaleNameClassicDataGridViewTextBoxColumn.Name = "LocaleNameClassicDataGridViewTextBoxColumn"
        ' 
        ' ImgurLinkClassicDataGridViewTextBoxColumn
        ' 
        ImgurLinkClassicDataGridViewTextBoxColumn.DataPropertyName = "ImgurLinkClassic"
        ImgurLinkClassicDataGridViewTextBoxColumn.HeaderText = "ImgurLinkClassic"
        ImgurLinkClassicDataGridViewTextBoxColumn.Name = "ImgurLinkClassicDataGridViewTextBoxColumn"
        ' 
        ' ImageClassicDataGridViewTextBoxColumn
        ' 
        ImageClassicDataGridViewTextBoxColumn.DataPropertyName = "ImageClassic"
        ImageClassicDataGridViewTextBoxColumn.HeaderText = "ImageClassic"
        ImageClassicDataGridViewTextBoxColumn.Name = "ImageClassicDataGridViewTextBoxColumn"
        ' 
        ' EncounterIDWrathDataGridViewTextBoxColumn
        ' 
        EncounterIDWrathDataGridViewTextBoxColumn.DataPropertyName = "EncounterIDWrath"
        EncounterIDWrathDataGridViewTextBoxColumn.HeaderText = "EncounterIDWrath"
        EncounterIDWrathDataGridViewTextBoxColumn.Name = "EncounterIDWrathDataGridViewTextBoxColumn"
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
        ' frmIATDatabaseManager
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1497, 531)
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
        tlpContainer.ResumeLayout(False)
        tlpContentRight.ResumeLayout(False)
        CType(dgvBosses, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        CType(dgvInstanceTypes, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvInstances, ComponentModel.ISupportInitialize).EndInit()
        tlpContentLeft.ResumeLayout(False)
        tlpContentLeft.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(ExpansionBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(InstanceTypesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(InstancesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(BossesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents cboBosses As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTacticsLocale As TextBox
    Friend WithEvents btnInsertTactic As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cboNPC As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents InsertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpansionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BossToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtNewTactics As TextBox
    Friend WithEvents btnGenerateLocalisation As Button
    Friend WithEvents txtInGame As TextBox
    Friend WithEvents btnUploadLocale As Button
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NPCsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpellsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewSpellsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtSpellName As TextBox
    Friend WithEvents btnAddSpell As Button
    Friend WithEvents btnGenerateLocaleNoUpload As Button
    Friend WithEvents LocalisationManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CoordinateBuilderToolStripMenuItem As ToolStripMenuItem
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
    Friend WithEvents ExpansionIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExpansionBindingSource As BindingSource
    Friend WithEvents BossIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OrderDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossNameIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossIDsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AchievementIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PlayersDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TacticsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EnabledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents TrackDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PartialTrackDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EncounterIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DisplayInfoFrameDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents LocaleTextDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocaleNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImgurLinkDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HTMLTacticsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossNameWrathDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClassicTacticsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocaleTextClassicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocaleNameClassicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImgurLinkClassicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImageClassicDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EncounterIDWrathDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InstanceIdDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents InstanceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BossesBindingSource As BindingSource
    Friend WithEvents InstancesBindingSource As BindingSource
    Friend WithEvents InstanceTypesBindingSource As BindingSource
    Friend WithEvents InstanceTypeIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InstanceIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents NameWrathDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InstanceNameIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClassicPhaseDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RetailOnlyDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents ClassicOnlyDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents LegacySizeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExpansionIdDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents InstanceTypeIdDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents ExpansionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InstanceTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
