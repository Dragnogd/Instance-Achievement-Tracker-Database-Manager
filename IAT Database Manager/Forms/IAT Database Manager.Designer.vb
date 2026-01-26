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
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        LocalisationsToolStripMenuItem = New ToolStripMenuItem()
        BrowserToolStripMenuItem = New ToolStripMenuItem()
        btnGenerateLocalisation = New Button()
        btnUploadLocale = New Button()
        btnEditBoss = New Button()
        ExpansionBindingSource = New BindingSource(components)
        tlpContainer = New TableLayoutPanel()
        tlpContentRight = New TableLayoutPanel()
        rtbLog = New RichTextBox()
        tlpContentLeft = New TableLayoutPanel()
        Panel2 = New Panel()
        btnPullLocalisation = New Button()
        btnInsertItem = New Button()
        btnInsertSpell = New Button()
        btnInsertNPC = New Button()
        chkEditTactics = New CheckBox()
        btnAddNewTactic = New Button()
        tcTactics = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        InstanceTypesBindingSource = New BindingSource(components)
        BossesBindingSource = New BindingSource(components)
        InstancesBindingSource = New BindingSource(components)
        TacticsBindingSource = New BindingSource(components)
        TacticParameterBindingSource = New BindingSource(components)
        MenuStrip1.SuspendLayout()
        CType(ExpansionBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        tlpContainer.SuspendLayout()
        tlpContentRight.SuspendLayout()
        tlpContentLeft.SuspendLayout()
        Panel2.SuspendLayout()
        tcTactics.SuspendLayout()
        CType(InstanceTypesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(BossesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(InstancesBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(TacticsBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(TacticParameterBindingSource, ComponentModel.ISupportInitialize).BeginInit()
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
        btnInsertTactic.Location = New Point(391, 3)
        btnInsertTactic.Margin = New Padding(4, 3, 4, 3)
        btnInsertTactic.Name = "btnInsertTactic"
        btnInsertTactic.Size = New Size(130, 26)
        btnInsertTactic.TabIndex = 4
        btnInsertTactic.Text = "Save Changes"
        btnInsertTactic.UseVisualStyleBackColor = True
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {InsertToolStripMenuItem, LocalisationManagerToolStripMenuItem, SettingsToolStripMenuItem, LocalisationsToolStripMenuItem, BrowserToolStripMenuItem})
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
        ' LocalisationManagerToolStripMenuItem
        ' 
        LocalisationManagerToolStripMenuItem.Name = "LocalisationManagerToolStripMenuItem"
        LocalisationManagerToolStripMenuItem.Size = New Size(123, 20)
        LocalisationManagerToolStripMenuItem.Text = "Update Localisation"
        ' 
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(61, 20)
        SettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' LocalisationsToolStripMenuItem
        ' 
        LocalisationsToolStripMenuItem.Name = "LocalisationsToolStripMenuItem"
        LocalisationsToolStripMenuItem.Size = New Size(87, 20)
        LocalisationsToolStripMenuItem.Text = "Localisations"
        ' 
        ' BrowserToolStripMenuItem
        ' 
        BrowserToolStripMenuItem.Name = "BrowserToolStripMenuItem"
        BrowserToolStripMenuItem.Size = New Size(61, 20)
        BrowserToolStripMenuItem.Text = "Browser"
        ' 
        ' btnGenerateLocalisation
        ' 
        btnGenerateLocalisation.Location = New Point(148, 30)
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
        btnUploadLocale.Location = New Point(10, 32)
        btnUploadLocale.Margin = New Padding(4, 3, 4, 3)
        btnUploadLocale.Name = "btnUploadLocale"
        btnUploadLocale.Size = New Size(130, 20)
        btnUploadLocale.TabIndex = 56
        btnUploadLocale.Text = "Upload Locale"
        btnUploadLocale.UseVisualStyleBackColor = True
        ' 
        ' btnEditBoss
        ' 
        btnEditBoss.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnEditBoss.Location = New Point(391, 32)
        btnEditBoss.Margin = New Padding(4, 3, 4, 3)
        btnEditBoss.Name = "btnEditBoss"
        btnEditBoss.Size = New Size(130, 26)
        btnEditBoss.TabIndex = 63
        btnEditBoss.Text = "Edit Boss"
        btnEditBoss.UseVisualStyleBackColor = True
        ' 
        ' ExpansionBindingSource
        ' 
        ExpansionBindingSource.DataSource = GetType(Expansion)
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
        tlpContainer.Size = New Size(1489, 503)
        tlpContainer.TabIndex = 76
        ' 
        ' tlpContentRight
        ' 
        tlpContentRight.ColumnCount = 1
        tlpContentRight.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpContentRight.Controls.Add(rtbLog, 0, 0)
        tlpContentRight.Dock = DockStyle.Fill
        tlpContentRight.Location = New Point(747, 3)
        tlpContentRight.Name = "tlpContentRight"
        tlpContentRight.RowCount = 1
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpContentRight.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpContentRight.Size = New Size(739, 497)
        tlpContentRight.TabIndex = 0
        ' 
        ' rtbLog
        ' 
        rtbLog.Dock = DockStyle.Fill
        rtbLog.Location = New Point(3, 3)
        rtbLog.Name = "rtbLog"
        rtbLog.Size = New Size(733, 491)
        rtbLog.TabIndex = 0
        rtbLog.Text = ""
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
        tlpContentLeft.Size = New Size(738, 497)
        tlpContentLeft.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(btnPullLocalisation)
        Panel2.Controls.Add(btnInsertItem)
        Panel2.Controls.Add(btnInsertSpell)
        Panel2.Controls.Add(btnInsertNPC)
        Panel2.Controls.Add(chkEditTactics)
        Panel2.Controls.Add(btnAddNewTactic)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(cboBosses)
        Panel2.Controls.Add(btnUploadLocale)
        Panel2.Controls.Add(btnGenerateLocalisation)
        Panel2.Controls.Add(btnEditBoss)
        Panel2.Controls.Add(btnInsertTactic)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(732, 118)
        Panel2.TabIndex = 0
        ' 
        ' btnPullLocalisation
        ' 
        btnPullLocalisation.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnPullLocalisation.Location = New Point(529, 3)
        btnPullLocalisation.Margin = New Padding(4, 3, 4, 3)
        btnPullLocalisation.Name = "btnPullLocalisation"
        btnPullLocalisation.Size = New Size(130, 26)
        btnPullLocalisation.TabIndex = 62
        btnPullLocalisation.Text = "Pull Localisation"
        btnPullLocalisation.UseVisualStyleBackColor = True
        ' 
        ' btnInsertItem
        ' 
        btnInsertItem.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertItem.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnInsertItem.Location = New Point(509, 89)
        btnInsertItem.Margin = New Padding(4, 3, 4, 3)
        btnInsertItem.Name = "btnInsertItem"
        btnInsertItem.Size = New Size(130, 26)
        btnInsertItem.TabIndex = 61
        btnInsertItem.Text = "Insert Item"
        btnInsertItem.UseVisualStyleBackColor = True
        ' 
        ' btnInsertSpell
        ' 
        btnInsertSpell.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertSpell.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnInsertSpell.Location = New Point(371, 89)
        btnInsertSpell.Margin = New Padding(4, 3, 4, 3)
        btnInsertSpell.Name = "btnInsertSpell"
        btnInsertSpell.Size = New Size(130, 26)
        btnInsertSpell.TabIndex = 60
        btnInsertSpell.Text = "Insert Spell"
        btnInsertSpell.UseVisualStyleBackColor = True
        ' 
        ' btnInsertNPC
        ' 
        btnInsertNPC.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertNPC.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnInsertNPC.Location = New Point(233, 89)
        btnInsertNPC.Margin = New Padding(4, 3, 4, 3)
        btnInsertNPC.Name = "btnInsertNPC"
        btnInsertNPC.Size = New Size(130, 26)
        btnInsertNPC.TabIndex = 59
        btnInsertNPC.Text = "Insert NPC"
        btnInsertNPC.UseVisualStyleBackColor = True
        ' 
        ' chkEditTactics
        ' 
        chkEditTactics.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        chkEditTactics.AutoSize = True
        chkEditTactics.Checked = True
        chkEditTactics.CheckState = CheckState.Checked
        chkEditTactics.Location = New Point(141, 94)
        chkEditTactics.Name = "chkEditTactics"
        chkEditTactics.Size = New Size(85, 19)
        chkEditTactics.TabIndex = 58
        chkEditTactics.Text = "Edit Tactics"
        chkEditTactics.UseVisualStyleBackColor = True
        ' 
        ' btnAddNewTactic
        ' 
        btnAddNewTactic.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnAddNewTactic.Font = New Font("Microsoft Sans Serif", 8.25F)
        btnAddNewTactic.Location = New Point(4, 89)
        btnAddNewTactic.Margin = New Padding(4, 3, 4, 3)
        btnAddNewTactic.Name = "btnAddNewTactic"
        btnAddNewTactic.Size = New Size(130, 26)
        btnAddNewTactic.TabIndex = 57
        btnAddNewTactic.Text = "Add New Tactic"
        btnAddNewTactic.UseVisualStyleBackColor = True
        ' 
        ' tcTactics
        ' 
        tcTactics.Controls.Add(TabPage1)
        tcTactics.Controls.Add(TabPage2)
        tcTactics.Dock = DockStyle.Fill
        tcTactics.Location = New Point(3, 127)
        tcTactics.Name = "tcTactics"
        tcTactics.SelectedIndex = 0
        tcTactics.Size = New Size(732, 367)
        tcTactics.TabIndex = 1
        ' 
        ' TabPage1
        ' 
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(724, 339)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(724, 339)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' InstanceTypesBindingSource
        ' 
        InstanceTypesBindingSource.DataMember = "InstanceTypes"
        InstanceTypesBindingSource.DataSource = ExpansionBindingSource
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
        ' TacticsBindingSource
        ' 
        TacticsBindingSource.DataMember = "Tactics"
        TacticsBindingSource.DataSource = BossesBindingSource
        ' 
        ' TacticParameterBindingSource
        ' 
        TacticParameterBindingSource.DataMember = "TacticParameter"
        TacticParameterBindingSource.DataSource = TacticsBindingSource
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
        CType(ExpansionBindingSource, ComponentModel.ISupportInitialize).EndInit()
        tlpContainer.ResumeLayout(False)
        tlpContentRight.ResumeLayout(False)
        tlpContentLeft.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        tcTactics.ResumeLayout(False)
        CType(InstanceTypesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(BossesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(InstancesBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(TacticsBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(TacticParameterBindingSource, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LocalisationManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tlpContainer As TableLayoutPanel
    Friend WithEvents tlpContentRight As TableLayoutPanel
    Friend WithEvents tlpContentLeft As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents InstanceTypeIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents InstanceTypesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExpansionBindingSource As BindingSource
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
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents BossesBindingSource As BindingSource
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents PatchDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TacticParameterIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TacticsBindingSource As BindingSource
    Friend WithEvents TacticParameterBindingSource As BindingSource
    Friend WithEvents tcTactics As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnAddNewTactic As Button
    Friend WithEvents rtbLog As RichTextBox
    Friend WithEvents chkEditTactics As CheckBox
    Friend WithEvents btnInsertNPC As Button
    Friend WithEvents btnInsertItem As Button
    Friend WithEvents btnInsertSpell As Button
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LocalisationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnPullLocalisation As Button
    Friend WithEvents BrowserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnEditBoss As Button
End Class
