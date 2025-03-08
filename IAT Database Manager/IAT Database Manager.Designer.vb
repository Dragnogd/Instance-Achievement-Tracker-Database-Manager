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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIATDatabaseManager))
        cboBosses = New ComboBox()
        Label1 = New Label()
        txtTacticsLocale = New TextBox()
        Label2 = New Label()
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
        Label14 = New Label()
        txtInstanceID = New TextBox()
        Label15 = New Label()
        txtInstanceNameID = New TextBox()
        txtInstanceName = New TextBox()
        Label16 = New Label()
        txtInstanceType = New TextBox()
        Label17 = New Label()
        GroupBox2 = New GroupBox()
        txtClassicOnly = New TextBox()
        Label37 = New Label()
        txtRetailOnly = New TextBox()
        Label36 = New Label()
        txtClassicPhase = New TextBox()
        Label32 = New Label()
        txtInstanceNameWrath = New TextBox()
        Label29 = New Label()
        Label18 = New Label()
        txtExpansion = New TextBox()
        Label19 = New Label()
        txtExpansionID = New TextBox()
        GroupBox3 = New GroupBox()
        Label20 = New Label()
        txtContext = New TextBox()
        Label23 = New Label()
        txtImgurLink = New TextBox()
        Label26 = New Label()
        cboExpansions = New ComboBox()
        cboInstances = New ComboBox()
        Label27 = New Label()
        GroupBox1 = New GroupBox()
        Label35 = New Label()
        txtEncounterIDWrath = New TextBox()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        txtTactics = New TextBox()
        TabPage2 = New TabPage()
        txtClassicTactics = New TextBox()
        Label30 = New Label()
        txtBossNameWrath = New TextBox()
        txtImage = New TextBox()
        Label28 = New Label()
        Label22 = New Label()
        Label5 = New Label()
        txtNameID = New TextBox()
        Label6 = New Label()
        txtIndex = New TextBox()
        Label21 = New Label()
        Label7 = New Label()
        Label13 = New Label()
        Label8 = New Label()
        Label12 = New Label()
        txtBossName = New TextBox()
        Label11 = New Label()
        txtBossIDs = New TextBox()
        Label10 = New Label()
        txtAchievement = New TextBox()
        txtPlayers = New TextBox()
        Label24 = New Label()
        txtEnabled = New TextBox()
        Label25 = New Label()
        txtTrack = New TextBox()
        txtPartial = New TextBox()
        txtInfoFrame = New TextBox()
        txtEncounterID = New TextBox()
        txtNewTactics = New TextBox()
        btnGenerateLocalisation = New Button()
        Label9 = New Label()
        txtLocaleString = New TextBox()
        txtInGame = New TextBox()
        btnUploadLocale = New Button()
        txtLoadingStatus = New Label()
        txtSpellName = New TextBox()
        btnAddSpell = New Button()
        btnGenerateLocaleNoUpload = New Button()
        btnBack = New Button()
        WebView2 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Tactics = New TabControl()
        Retail = New TabPage()
        Classic = New TabPage()
        Label31 = New Label()
        txtNewTacticsClassic = New TextBox()
        txtTacticsLocaleClassic = New TextBox()
        txtInGameClassic = New TextBox()
        Label33 = New Label()
        txtLocaleStringClassic = New TextBox()
        btnTestTranslationClassic = New Button()
        btnUploadLocaleClassic = New Button()
        TabControl2 = New TabControl()
        TabPage3 = New TabPage()
        TabPage4 = New TabPage()
        txtImgurLinkClassic = New TextBox()
        Label34 = New Label()
        txtContextClassic = New TextBox()
        btnGenerateLocalisationClassic = New Button()
        MenuStrip1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox1.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        CType(WebView2, ComponentModel.ISupportInitialize).BeginInit()
        Tactics.SuspendLayout()
        Retail.SuspendLayout()
        Classic.SuspendLayout()
        TabControl2.SuspendLayout()
        TabPage3.SuspendLayout()
        TabPage4.SuspendLayout()
        SuspendLayout()
        ' 
        ' cboBosses
        ' 
        cboBosses.FormattingEnabled = True
        cboBosses.Location = New Point(13, 27)
        cboBosses.Margin = New Padding(4, 3, 4, 3)
        cboBosses.Name = "cboBosses"
        cboBosses.Size = New Size(313, 23)
        cboBosses.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(25, 55)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(65, 15)
        Label1.TabIndex = 1
        Label1.Text = "Select Boss"
        ' 
        ' txtTacticsLocale
        ' 
        txtTacticsLocale.Location = New Point(7, 180)
        txtTacticsLocale.Margin = New Padding(4, 3, 4, 3)
        txtTacticsLocale.Multiline = True
        txtTacticsLocale.Name = "txtTacticsLocale"
        txtTacticsLocale.ScrollBars = ScrollBars.Vertical
        txtTacticsLocale.Size = New Size(674, 137)
        txtTacticsLocale.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(7, 9)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(117, 15)
        Label2.TabIndex = 3
        Label2.Text = "Tactics (Localisation)"
        ' 
        ' btnInsertTactic
        ' 
        btnInsertTactic.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnInsertTactic.Location = New Point(955, 881)
        btnInsertTactic.Margin = New Padding(4, 3, 4, 3)
        btnInsertTactic.Name = "btnInsertTactic"
        btnInsertTactic.Size = New Size(342, 37)
        btnInsertTactic.TabIndex = 4
        btnInsertTactic.Text = "Save Changes"
        btnInsertTactic.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(502, 65)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 15)
        Label3.TabIndex = 6
        Label3.Text = "Insert NPC"
        ' 
        ' cboNPC
        ' 
        cboNPC.FormattingEnabled = True
        cboNPC.Location = New Point(577, 62)
        cboNPC.Margin = New Padding(4, 3, 4, 3)
        cboNPC.Name = "cboNPC"
        cboNPC.Size = New Size(140, 23)
        cboNPC.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(120, 59)
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
        MenuStrip1.Size = New Size(1904, 24)
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
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(7, 28)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(65, 15)
        Label14.TabIndex = 30
        Label14.Text = "Instance ID"
        ' 
        ' txtInstanceID
        ' 
        txtInstanceID.Location = New Point(122, 28)
        txtInstanceID.Margin = New Padding(4, 3, 4, 3)
        txtInstanceID.Name = "txtInstanceID"
        txtInstanceID.Size = New Size(227, 23)
        txtInstanceID.TabIndex = 31
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(6, 61)
        Label15.Margin = New Padding(4, 0, 4, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(100, 15)
        Label15.TabIndex = 32
        Label15.Text = "Instance Name ID"
        ' 
        ' txtInstanceNameID
        ' 
        txtInstanceNameID.Location = New Point(122, 58)
        txtInstanceNameID.Margin = New Padding(4, 3, 4, 3)
        txtInstanceNameID.Name = "txtInstanceNameID"
        txtInstanceNameID.Size = New Size(227, 23)
        txtInstanceNameID.TabIndex = 33
        ' 
        ' txtInstanceName
        ' 
        txtInstanceName.Location = New Point(122, 88)
        txtInstanceName.Margin = New Padding(4, 3, 4, 3)
        txtInstanceName.Name = "txtInstanceName"
        txtInstanceName.Size = New Size(227, 23)
        txtInstanceName.TabIndex = 35
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(6, 91)
        Label16.Margin = New Padding(4, 0, 4, 0)
        Label16.Name = "Label16"
        Label16.Size = New Size(86, 15)
        Label16.TabIndex = 34
        Label16.Text = "Instance Name"
        ' 
        ' txtInstanceType
        ' 
        txtInstanceType.Location = New Point(124, 147)
        txtInstanceType.Margin = New Padding(4, 3, 4, 3)
        txtInstanceType.Name = "txtInstanceType"
        txtInstanceType.Size = New Size(227, 23)
        txtInstanceType.TabIndex = 37
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(7, 150)
        Label17.Margin = New Padding(4, 0, 4, 0)
        Label17.Name = "Label17"
        Label17.Size = New Size(79, 15)
        Label17.TabIndex = 36
        Label17.Text = "Instance Type"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(txtClassicOnly)
        GroupBox2.Controls.Add(Label37)
        GroupBox2.Controls.Add(txtRetailOnly)
        GroupBox2.Controls.Add(Label36)
        GroupBox2.Controls.Add(txtClassicPhase)
        GroupBox2.Controls.Add(Label32)
        GroupBox2.Controls.Add(txtInstanceNameWrath)
        GroupBox2.Controls.Add(Label29)
        GroupBox2.Controls.Add(txtInstanceType)
        GroupBox2.Controls.Add(Label17)
        GroupBox2.Controls.Add(txtInstanceName)
        GroupBox2.Controls.Add(Label16)
        GroupBox2.Controls.Add(txtInstanceNameID)
        GroupBox2.Controls.Add(Label15)
        GroupBox2.Controls.Add(Label14)
        GroupBox2.Controls.Add(txtInstanceID)
        GroupBox2.Location = New Point(1100, 637)
        GroupBox2.Margin = New Padding(4, 3, 4, 3)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(4, 3, 4, 3)
        GroupBox2.Size = New Size(358, 212)
        GroupBox2.TabIndex = 38
        GroupBox2.TabStop = False
        GroupBox2.Text = "Instance Specific"
        ' 
        ' txtClassicOnly
        ' 
        txtClassicOnly.Location = New Point(303, 180)
        txtClassicOnly.Margin = New Padding(4, 3, 4, 3)
        txtClassicOnly.Name = "txtClassicOnly"
        txtClassicOnly.Size = New Size(39, 23)
        txtClassicOnly.TabIndex = 46
        ' 
        ' Label37
        ' 
        Label37.AutoSize = True
        Label37.Location = New Point(222, 183)
        Label37.Margin = New Padding(4, 0, 4, 0)
        Label37.Name = "Label37"
        Label37.Size = New Size(71, 15)
        Label37.TabIndex = 45
        Label37.Text = "Classic Only"
        ' 
        ' txtRetailOnly
        ' 
        txtRetailOnly.Location = New Point(175, 180)
        txtRetailOnly.Margin = New Padding(4, 3, 4, 3)
        txtRetailOnly.Name = "txtRetailOnly"
        txtRetailOnly.Size = New Size(39, 23)
        txtRetailOnly.TabIndex = 44
        ' 
        ' Label36
        ' 
        Label36.AutoSize = True
        Label36.Location = New Point(111, 183)
        Label36.Margin = New Padding(4, 0, 4, 0)
        Label36.Name = "Label36"
        Label36.Size = New Size(64, 15)
        Label36.TabIndex = 43
        Label36.Text = "Retail Only"
        ' 
        ' txtClassicPhase
        ' 
        txtClassicPhase.Location = New Point(64, 180)
        txtClassicPhase.Margin = New Padding(4, 3, 4, 3)
        txtClassicPhase.Name = "txtClassicPhase"
        txtClassicPhase.Size = New Size(39, 23)
        txtClassicPhase.TabIndex = 42
        ' 
        ' Label32
        ' 
        Label32.AutoSize = True
        Label32.Location = New Point(9, 182)
        Label32.Margin = New Padding(4, 0, 4, 0)
        Label32.Name = "Label32"
        Label32.Size = New Size(49, 15)
        Label32.TabIndex = 41
        Label32.Text = "C Phase"
        ' 
        ' txtInstanceNameWrath
        ' 
        txtInstanceNameWrath.Location = New Point(147, 115)
        txtInstanceNameWrath.Margin = New Padding(4, 3, 4, 3)
        txtInstanceNameWrath.Multiline = True
        txtInstanceNameWrath.Name = "txtInstanceNameWrath"
        txtInstanceNameWrath.Size = New Size(201, 24)
        txtInstanceNameWrath.TabIndex = 39
        ' 
        ' Label29
        ' 
        Label29.AutoSize = True
        Label29.Location = New Point(6, 119)
        Label29.Margin = New Padding(4, 0, 4, 0)
        Label29.Name = "Label29"
        Label29.Size = New Size(129, 15)
        Label29.TabIndex = 40
        Label29.Text = "Wrath - Instance Name"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(9, 15)
        Label18.Margin = New Padding(4, 0, 4, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(60, 15)
        Label18.TabIndex = 38
        Label18.Text = "Expansion"
        ' 
        ' txtExpansion
        ' 
        txtExpansion.Location = New Point(98, 15)
        txtExpansion.Margin = New Padding(4, 3, 4, 3)
        txtExpansion.Name = "txtExpansion"
        txtExpansion.Size = New Size(252, 23)
        txtExpansion.TabIndex = 39
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(9, 45)
        Label19.Margin = New Padding(4, 0, 4, 0)
        Label19.Name = "Label19"
        Label19.Size = New Size(74, 15)
        Label19.TabIndex = 40
        Label19.Text = "Expansion ID"
        ' 
        ' txtExpansionID
        ' 
        txtExpansionID.Location = New Point(98, 45)
        txtExpansionID.Margin = New Padding(4, 3, 4, 3)
        txtExpansionID.Name = "txtExpansionID"
        txtExpansionID.Size = New Size(252, 23)
        txtExpansionID.TabIndex = 41
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(Label19)
        GroupBox3.Controls.Add(txtExpansionID)
        GroupBox3.Controls.Add(Label18)
        GroupBox3.Controls.Add(txtExpansion)
        GroupBox3.Location = New Point(734, 20)
        GroupBox3.Margin = New Padding(4, 3, 4, 3)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Padding = New Padding(4, 3, 4, 3)
        GroupBox3.Size = New Size(358, 80)
        GroupBox3.TabIndex = 42
        GroupBox3.TabStop = False
        GroupBox3.Text = "Expansion Specific"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(1100, 27)
        Label20.Margin = New Padding(4, 0, 4, 0)
        Label20.Name = "Label20"
        Label20.Size = New Size(119, 15)
        Label20.TabIndex = 44
        Label20.Text = "Localisation Importer"
        ' 
        ' txtContext
        ' 
        txtContext.Location = New Point(5, 7)
        txtContext.Margin = New Padding(4, 3, 4, 3)
        txtContext.Multiline = True
        txtContext.Name = "txtContext"
        txtContext.Size = New Size(355, 71)
        txtContext.TabIndex = 47
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Location = New Point(21, 89)
        Label23.Margin = New Padding(4, 0, 4, 0)
        Label23.Name = "Label23"
        Label23.Size = New Size(64, 15)
        Label23.TabIndex = 33
        Label23.Text = "Imgur Link"
        ' 
        ' txtImgurLink
        ' 
        txtImgurLink.Location = New Point(93, 85)
        txtImgurLink.Margin = New Padding(4, 3, 4, 3)
        txtImgurLink.Name = "txtImgurLink"
        txtImgurLink.Size = New Size(259, 23)
        txtImgurLink.TabIndex = 32
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Location = New Point(334, 31)
        Label26.Margin = New Padding(4, 0, 4, 0)
        Label26.Name = "Label26"
        Label26.Size = New Size(94, 15)
        Label26.TabIndex = 48
        Label26.Text = "Select Expansion"
        ' 
        ' cboExpansions
        ' 
        cboExpansions.FormattingEnabled = True
        cboExpansions.Location = New Point(445, 27)
        cboExpansions.Margin = New Padding(4, 3, 4, 3)
        cboExpansions.Name = "cboExpansions"
        cboExpansions.Size = New Size(117, 23)
        cboExpansions.TabIndex = 49
        ' 
        ' cboInstances
        ' 
        cboInstances.FormattingEnabled = True
        cboInstances.Location = New Point(570, 27)
        cboInstances.Margin = New Padding(4, 3, 4, 3)
        cboInstances.Name = "cboInstances"
        cboInstances.Size = New Size(154, 23)
        cboInstances.TabIndex = 51
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Location = New Point(605, 9)
        Label27.Margin = New Padding(4, 0, 4, 0)
        Label27.Name = "Label27"
        Label27.Size = New Size(85, 15)
        Label27.TabIndex = 50
        Label27.Text = "Select Instance"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label35)
        GroupBox1.Controls.Add(txtEncounterIDWrath)
        GroupBox1.Controls.Add(TabControl1)
        GroupBox1.Controls.Add(Label30)
        GroupBox1.Controls.Add(txtBossNameWrath)
        GroupBox1.Controls.Add(txtImage)
        GroupBox1.Controls.Add(Label28)
        GroupBox1.Controls.Add(Label22)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(txtNameID)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(txtIndex)
        GroupBox1.Controls.Add(Label21)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(Label13)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label12)
        GroupBox1.Controls.Add(txtBossName)
        GroupBox1.Controls.Add(Label11)
        GroupBox1.Controls.Add(txtBossIDs)
        GroupBox1.Controls.Add(Label10)
        GroupBox1.Controls.Add(txtAchievement)
        GroupBox1.Controls.Add(txtPlayers)
        GroupBox1.Controls.Add(Label24)
        GroupBox1.Controls.Add(txtEnabled)
        GroupBox1.Controls.Add(Label25)
        GroupBox1.Controls.Add(txtTrack)
        GroupBox1.Controls.Add(txtPartial)
        GroupBox1.Controls.Add(txtInfoFrame)
        GroupBox1.Controls.Add(txtEncounterID)
        GroupBox1.Location = New Point(722, 175)
        GroupBox1.Margin = New Padding(4, 3, 4, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 3, 4, 3)
        GroupBox1.Size = New Size(358, 617)
        GroupBox1.TabIndex = 52
        GroupBox1.TabStop = False
        GroupBox1.Text = "Boss Specific"
        ' 
        ' Label35
        ' 
        Label35.AutoSize = True
        Label35.Location = New Point(222, 516)
        Label35.Margin = New Padding(4, 0, 4, 0)
        Label35.Name = "Label35"
        Label35.Size = New Size(18, 15)
        Label35.TabIndex = 43
        Label35.Text = "W"
        ' 
        ' txtEncounterIDWrath
        ' 
        txtEncounterIDWrath.Location = New Point(243, 512)
        txtEncounterIDWrath.Margin = New Padding(4, 3, 4, 3)
        txtEncounterIDWrath.Name = "txtEncounterIDWrath"
        txtEncounterIDWrath.Size = New Size(106, 23)
        txtEncounterIDWrath.TabIndex = 42
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Location = New Point(64, 246)
        TabControl1.Margin = New Padding(4, 3, 4, 3)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(287, 170)
        TabControl1.TabIndex = 41
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(txtTactics)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Margin = New Padding(4, 3, 4, 3)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(4, 3, 4, 3)
        TabPage1.Size = New Size(279, 142)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Retail"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' txtTactics
        ' 
        txtTactics.Location = New Point(7, 12)
        txtTactics.Margin = New Padding(4, 3, 4, 3)
        txtTactics.Multiline = True
        txtTactics.Name = "txtTactics"
        txtTactics.Size = New Size(259, 122)
        txtTactics.TabIndex = 30
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(txtClassicTactics)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Margin = New Padding(4, 3, 4, 3)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(4, 3, 4, 3)
        TabPage2.Size = New Size(279, 142)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Classic"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' txtClassicTactics
        ' 
        txtClassicTactics.Location = New Point(9, 8)
        txtClassicTactics.Margin = New Padding(4, 3, 4, 3)
        txtClassicTactics.Multiline = True
        txtClassicTactics.Name = "txtClassicTactics"
        txtClassicTactics.Size = New Size(259, 122)
        txtClassicTactics.TabIndex = 31
        ' 
        ' Label30
        ' 
        Label30.AutoSize = True
        Label30.Location = New Point(7, 85)
        Label30.Margin = New Padding(4, 0, 4, 0)
        Label30.Name = "Label30"
        Label30.Size = New Size(82, 15)
        Label30.TabIndex = 39
        Label30.Text = "Wrath - Name"
        ' 
        ' txtBossNameWrath
        ' 
        txtBossNameWrath.Location = New Point(99, 82)
        txtBossNameWrath.Margin = New Padding(4, 3, 4, 3)
        txtBossNameWrath.Name = "txtBossNameWrath"
        txtBossNameWrath.Size = New Size(249, 23)
        txtBossNameWrath.TabIndex = 40
        ' 
        ' txtImage
        ' 
        txtImage.Location = New Point(88, 577)
        txtImage.Margin = New Padding(4, 3, 4, 3)
        txtImage.Name = "txtImage"
        txtImage.Size = New Size(259, 23)
        txtImage.TabIndex = 38
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.Location = New Point(6, 580)
        Label28.Margin = New Padding(4, 0, 4, 0)
        Label28.Name = "Label28"
        Label28.Size = New Size(40, 15)
        Label28.TabIndex = 37
        Label28.Text = "Image"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(9, 426)
        Label22.Margin = New Padding(4, 0, 4, 0)
        Label22.Name = "Label22"
        Label22.Size = New Size(49, 15)
        Label22.TabIndex = 36
        Label22.Text = "Enabled"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(8, 115)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(53, 15)
        Label5.TabIndex = 34
        Label5.Text = "Name ID"
        ' 
        ' txtNameID
        ' 
        txtNameID.Location = New Point(90, 112)
        txtNameID.Margin = New Padding(4, 3, 4, 3)
        txtNameID.Name = "txtNameID"
        txtNameID.Size = New Size(259, 23)
        txtNameID.TabIndex = 35
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(7, 25)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(35, 15)
        Label6.TabIndex = 32
        Label6.Text = "Index"
        ' 
        ' txtIndex
        ' 
        txtIndex.Location = New Point(90, 22)
        txtIndex.Margin = New Padding(4, 3, 4, 3)
        txtIndex.Name = "txtIndex"
        txtIndex.Size = New Size(259, 23)
        txtIndex.TabIndex = 33
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(8, 246)
        Label21.Margin = New Padding(4, 0, 4, 0)
        Label21.Name = "Label21"
        Label21.Size = New Size(43, 15)
        Label21.TabIndex = 31
        Label21.Text = "Tactics"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(8, 55)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(39, 15)
        Label7.TabIndex = 11
        Label7.Text = "Name"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(6, 549)
        Label13.Margin = New Padding(4, 0, 4, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(61, 15)
        Label13.TabIndex = 29
        Label13.Text = "InfoFrame"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(8, 153)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(53, 15)
        Label8.TabIndex = 12
        Label8.Text = "Boss ID's"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(4, 516)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(75, 15)
        Label12.TabIndex = 28
        Label12.Text = "Encounter ID"
        ' 
        ' txtBossName
        ' 
        txtBossName.Location = New Point(90, 52)
        txtBossName.Margin = New Padding(4, 3, 4, 3)
        txtBossName.Name = "txtBossName"
        txtBossName.Size = New Size(259, 23)
        txtBossName.TabIndex = 13
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(6, 489)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(40, 15)
        Label11.TabIndex = 27
        Label11.Text = "Partial"
        ' 
        ' txtBossIDs
        ' 
        txtBossIDs.Location = New Point(91, 144)
        txtBossIDs.Margin = New Padding(4, 3, 4, 3)
        txtBossIDs.Name = "txtBossIDs"
        txtBossIDs.Size = New Size(259, 23)
        txtBossIDs.TabIndex = 14
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(6, 459)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(35, 15)
        Label10.TabIndex = 26
        Label10.Text = "Track"
        ' 
        ' txtAchievement
        ' 
        txtAchievement.Location = New Point(91, 174)
        txtAchievement.Margin = New Padding(4, 3, 4, 3)
        txtAchievement.Name = "txtAchievement"
        txtAchievement.Size = New Size(259, 23)
        txtAchievement.TabIndex = 15
        ' 
        ' txtPlayers
        ' 
        txtPlayers.Location = New Point(91, 204)
        txtPlayers.Margin = New Padding(4, 3, 4, 3)
        txtPlayers.Name = "txtPlayers"
        txtPlayers.Size = New Size(259, 23)
        txtPlayers.TabIndex = 16
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Location = New Point(8, 216)
        Label24.Margin = New Padding(4, 0, 4, 0)
        Label24.Name = "Label24"
        Label24.Size = New Size(44, 15)
        Label24.TabIndex = 24
        Label24.Text = "Players"
        ' 
        ' txtEnabled
        ' 
        txtEnabled.Location = New Point(89, 422)
        txtEnabled.Margin = New Padding(4, 3, 4, 3)
        txtEnabled.Name = "txtEnabled"
        txtEnabled.Size = New Size(259, 23)
        txtEnabled.TabIndex = 17
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Location = New Point(8, 186)
        Label25.Margin = New Padding(4, 0, 4, 0)
        Label25.Name = "Label25"
        Label25.Size = New Size(77, 15)
        Label25.TabIndex = 23
        Label25.Text = "Achievement"
        ' 
        ' txtTrack
        ' 
        txtTrack.Location = New Point(89, 452)
        txtTrack.Margin = New Padding(4, 3, 4, 3)
        txtTrack.Name = "txtTrack"
        txtTrack.Size = New Size(259, 23)
        txtTrack.TabIndex = 18
        ' 
        ' txtPartial
        ' 
        txtPartial.Location = New Point(89, 482)
        txtPartial.Margin = New Padding(4, 3, 4, 3)
        txtPartial.Name = "txtPartial"
        txtPartial.Size = New Size(259, 23)
        txtPartial.TabIndex = 19
        ' 
        ' txtInfoFrame
        ' 
        txtInfoFrame.Location = New Point(89, 542)
        txtInfoFrame.Margin = New Padding(4, 3, 4, 3)
        txtInfoFrame.Name = "txtInfoFrame"
        txtInfoFrame.Size = New Size(259, 23)
        txtInfoFrame.TabIndex = 21
        txtInfoFrame.Text = "false"
        ' 
        ' txtEncounterID
        ' 
        txtEncounterID.Location = New Point(89, 512)
        txtEncounterID.Margin = New Padding(4, 3, 4, 3)
        txtEncounterID.Name = "txtEncounterID"
        txtEncounterID.Size = New Size(125, 23)
        txtEncounterID.TabIndex = 20
        ' 
        ' txtNewTactics
        ' 
        txtNewTactics.Location = New Point(7, 30)
        txtNewTactics.Margin = New Padding(4, 3, 4, 3)
        txtNewTactics.Multiline = True
        txtNewTactics.Name = "txtNewTactics"
        txtNewTactics.ScrollBars = ScrollBars.Vertical
        txtNewTactics.Size = New Size(674, 142)
        txtNewTactics.TabIndex = 53
        ' 
        ' btnGenerateLocalisation
        ' 
        btnGenerateLocalisation.Location = New Point(956, 853)
        btnGenerateLocalisation.Margin = New Padding(4, 3, 4, 3)
        btnGenerateLocalisation.Name = "btnGenerateLocalisation"
        btnGenerateLocalisation.Size = New Size(126, 22)
        btnGenerateLocalisation.TabIndex = 54
        btnGenerateLocalisation.Text = "Create Imgur Link"
        btnGenerateLocalisation.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(741, 117)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(75, 15)
        Label9.TabIndex = 42
        Label9.Text = "Locale String"
        ' 
        ' txtLocaleString
        ' 
        txtLocaleString.Location = New Point(829, 114)
        txtLocaleString.Margin = New Padding(4, 3, 4, 3)
        txtLocaleString.Name = "txtLocaleString"
        txtLocaleString.Size = New Size(252, 23)
        txtLocaleString.TabIndex = 43
        ' 
        ' txtInGame
        ' 
        txtInGame.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtInGame.Location = New Point(7, 322)
        txtInGame.Margin = New Padding(4, 3, 4, 3)
        txtInGame.Multiline = True
        txtInGame.Name = "txtInGame"
        txtInGame.Size = New Size(674, 672)
        txtInGame.TabIndex = 55
        ' 
        ' btnUploadLocale
        ' 
        btnUploadLocale.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUploadLocale.Location = New Point(1304, 881)
        btnUploadLocale.Margin = New Padding(4, 3, 4, 3)
        btnUploadLocale.Name = "btnUploadLocale"
        btnUploadLocale.Size = New Size(197, 36)
        btnUploadLocale.TabIndex = 56
        btnUploadLocale.Text = "Upload Locale"
        btnUploadLocale.UseVisualStyleBackColor = True
        ' 
        ' txtLoadingStatus
        ' 
        txtLoadingStatus.AutoSize = True
        txtLoadingStatus.Location = New Point(1659, 27)
        txtLoadingStatus.Margin = New Padding(4, 0, 4, 0)
        txtLoadingStatus.Name = "txtLoadingStatus"
        txtLoadingStatus.Size = New Size(97, 15)
        txtLoadingStatus.TabIndex = 59
        txtLoadingStatus.Text = "Finished Loading"
        ' 
        ' txtSpellName
        ' 
        txtSpellName.Location = New Point(227, 63)
        txtSpellName.Margin = New Padding(4, 3, 4, 3)
        txtSpellName.Name = "txtSpellName"
        txtSpellName.Size = New Size(148, 23)
        txtSpellName.TabIndex = 61
        ' 
        ' btnAddSpell
        ' 
        btnAddSpell.Location = New Point(382, 59)
        btnAddSpell.Margin = New Padding(4, 3, 4, 3)
        btnAddSpell.Name = "btnAddSpell"
        btnAddSpell.Size = New Size(58, 28)
        btnAddSpell.TabIndex = 62
        btnAddSpell.Text = "Insert"
        btnAddSpell.UseVisualStyleBackColor = True
        ' 
        ' btnGenerateLocaleNoUpload
        ' 
        btnGenerateLocaleNoUpload.Location = New Point(1366, 851)
        btnGenerateLocaleNoUpload.Margin = New Padding(4, 3, 4, 3)
        btnGenerateLocaleNoUpload.Name = "btnGenerateLocaleNoUpload"
        btnGenerateLocaleNoUpload.Size = New Size(135, 22)
        btnGenerateLocaleNoUpload.TabIndex = 64
        btnGenerateLocaleNoUpload.Text = "Test Translation"
        btnGenerateLocaleNoUpload.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(1228, 20)
        btnBack.Margin = New Padding(4, 3, 4, 3)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(112, 25)
        btnBack.TabIndex = 66
        btnBack.Text = "Refresh"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' WebView2
        ' 
        WebView2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        WebView2.CreationProperties = Nothing
        WebView2.DefaultBackgroundColor = Color.White
        WebView2.Location = New Point(1097, 55)
        WebView2.Margin = New Padding(4, 3, 4, 3)
        WebView2.Name = "WebView2"
        WebView2.Size = New Size(796, 575)
        WebView2.TabIndex = 67
        WebView2.ZoomFactor = 1.0R
        ' 
        ' Tactics
        ' 
        Tactics.Controls.Add(Retail)
        Tactics.Controls.Add(Classic)
        Tactics.Location = New Point(16, 91)
        Tactics.Margin = New Padding(4, 3, 4, 3)
        Tactics.Name = "Tactics"
        Tactics.SelectedIndex = 0
        Tactics.Size = New Size(698, 938)
        Tactics.TabIndex = 68
        ' 
        ' Retail
        ' 
        Retail.Controls.Add(Label2)
        Retail.Controls.Add(txtNewTactics)
        Retail.Controls.Add(txtTacticsLocale)
        Retail.Controls.Add(txtInGame)
        Retail.Location = New Point(4, 24)
        Retail.Margin = New Padding(4, 3, 4, 3)
        Retail.Name = "Retail"
        Retail.Padding = New Padding(4, 3, 4, 3)
        Retail.Size = New Size(690, 910)
        Retail.TabIndex = 0
        Retail.Text = "Retail"
        Retail.UseVisualStyleBackColor = True
        ' 
        ' Classic
        ' 
        Classic.Controls.Add(Label31)
        Classic.Controls.Add(txtNewTacticsClassic)
        Classic.Controls.Add(txtTacticsLocaleClassic)
        Classic.Controls.Add(txtInGameClassic)
        Classic.Location = New Point(4, 24)
        Classic.Margin = New Padding(4, 3, 4, 3)
        Classic.Name = "Classic"
        Classic.Padding = New Padding(4, 3, 4, 3)
        Classic.Size = New Size(690, 1004)
        Classic.TabIndex = 1
        Classic.Text = "Classic"
        Classic.UseVisualStyleBackColor = True
        ' 
        ' Label31
        ' 
        Label31.AutoSize = True
        Label31.Location = New Point(7, 8)
        Label31.Margin = New Padding(4, 0, 4, 0)
        Label31.Name = "Label31"
        Label31.Size = New Size(117, 15)
        Label31.TabIndex = 57
        Label31.Text = "Tactics (Localisation)"
        ' 
        ' txtNewTacticsClassic
        ' 
        txtNewTacticsClassic.Location = New Point(7, 29)
        txtNewTacticsClassic.Margin = New Padding(4, 3, 4, 3)
        txtNewTacticsClassic.Multiline = True
        txtNewTacticsClassic.Name = "txtNewTacticsClassic"
        txtNewTacticsClassic.ScrollBars = ScrollBars.Vertical
        txtNewTacticsClassic.Size = New Size(674, 142)
        txtNewTacticsClassic.TabIndex = 58
        ' 
        ' txtTacticsLocaleClassic
        ' 
        txtTacticsLocaleClassic.Location = New Point(7, 179)
        txtTacticsLocaleClassic.Margin = New Padding(4, 3, 4, 3)
        txtTacticsLocaleClassic.Multiline = True
        txtTacticsLocaleClassic.Name = "txtTacticsLocaleClassic"
        txtTacticsLocaleClassic.ScrollBars = ScrollBars.Vertical
        txtTacticsLocaleClassic.Size = New Size(674, 137)
        txtTacticsLocaleClassic.TabIndex = 56
        ' 
        ' txtInGameClassic
        ' 
        txtInGameClassic.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtInGameClassic.Location = New Point(7, 321)
        txtInGameClassic.Margin = New Padding(4, 3, 4, 3)
        txtInGameClassic.Multiline = True
        txtInGameClassic.Name = "txtInGameClassic"
        txtInGameClassic.Size = New Size(674, 672)
        txtInGameClassic.TabIndex = 59
        ' 
        ' Label33
        ' 
        Label33.AutoSize = True
        Label33.Location = New Point(718, 149)
        Label33.Margin = New Padding(4, 0, 4, 0)
        Label33.Name = "Label33"
        Label33.Size = New Size(114, 15)
        Label33.TabIndex = 69
        Label33.Text = "Locale String Classic"
        ' 
        ' txtLocaleStringClassic
        ' 
        txtLocaleStringClassic.Location = New Point(844, 146)
        txtLocaleStringClassic.Margin = New Padding(4, 3, 4, 3)
        txtLocaleStringClassic.Name = "txtLocaleStringClassic"
        txtLocaleStringClassic.Size = New Size(237, 23)
        txtLocaleStringClassic.TabIndex = 70
        ' 
        ' btnTestTranslationClassic
        ' 
        btnTestTranslationClassic.Location = New Point(1508, 851)
        btnTestTranslationClassic.Margin = New Padding(4, 3, 4, 3)
        btnTestTranslationClassic.Name = "btnTestTranslationClassic"
        btnTestTranslationClassic.Size = New Size(160, 22)
        btnTestTranslationClassic.TabIndex = 71
        btnTestTranslationClassic.Text = "Test Translation Classic"
        btnTestTranslationClassic.UseVisualStyleBackColor = True
        ' 
        ' btnUploadLocaleClassic
        ' 
        btnUploadLocaleClassic.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUploadLocaleClassic.Location = New Point(1508, 882)
        btnUploadLocaleClassic.Margin = New Padding(4, 3, 4, 3)
        btnUploadLocaleClassic.Name = "btnUploadLocaleClassic"
        btnUploadLocaleClassic.Size = New Size(327, 36)
        btnUploadLocaleClassic.TabIndex = 72
        btnUploadLocaleClassic.Text = "Upload Locale Classic"
        btnUploadLocaleClassic.UseVisualStyleBackColor = True
        ' 
        ' TabControl2
        ' 
        TabControl2.Controls.Add(TabPage3)
        TabControl2.Controls.Add(TabPage4)
        TabControl2.Location = New Point(1483, 657)
        TabControl2.Margin = New Padding(4, 3, 4, 3)
        TabControl2.Name = "TabControl2"
        TabControl2.SelectedIndex = 0
        TabControl2.Size = New Size(377, 145)
        TabControl2.TabIndex = 73
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(txtContext)
        TabPage3.Controls.Add(txtImgurLink)
        TabPage3.Controls.Add(Label23)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Margin = New Padding(4, 3, 4, 3)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(4, 3, 4, 3)
        TabPage3.Size = New Size(369, 117)
        TabPage3.TabIndex = 0
        TabPage3.Text = "Retail"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' TabPage4
        ' 
        TabPage4.Controls.Add(txtImgurLinkClassic)
        TabPage4.Controls.Add(Label34)
        TabPage4.Controls.Add(txtContextClassic)
        TabPage4.Location = New Point(4, 24)
        TabPage4.Margin = New Padding(4, 3, 4, 3)
        TabPage4.Name = "TabPage4"
        TabPage4.Padding = New Padding(4, 3, 4, 3)
        TabPage4.Size = New Size(369, 117)
        TabPage4.TabIndex = 1
        TabPage4.Text = "Classic"
        TabPage4.UseVisualStyleBackColor = True
        ' 
        ' txtImgurLinkClassic
        ' 
        txtImgurLinkClassic.Location = New Point(93, 88)
        txtImgurLinkClassic.Margin = New Padding(4, 3, 4, 3)
        txtImgurLinkClassic.Name = "txtImgurLinkClassic"
        txtImgurLinkClassic.Size = New Size(259, 23)
        txtImgurLinkClassic.TabIndex = 49
        ' 
        ' Label34
        ' 
        Label34.AutoSize = True
        Label34.Location = New Point(21, 91)
        Label34.Margin = New Padding(4, 0, 4, 0)
        Label34.Name = "Label34"
        Label34.Size = New Size(64, 15)
        Label34.TabIndex = 50
        Label34.Text = "Imgur Link"
        ' 
        ' txtContextClassic
        ' 
        txtContextClassic.Location = New Point(6, 6)
        txtContextClassic.Margin = New Padding(4, 3, 4, 3)
        txtContextClassic.Multiline = True
        txtContextClassic.Name = "txtContextClassic"
        txtContextClassic.Size = New Size(355, 74)
        txtContextClassic.TabIndex = 48
        ' 
        ' btnGenerateLocalisationClassic
        ' 
        btnGenerateLocalisationClassic.Location = New Point(1089, 853)
        btnGenerateLocalisationClassic.Margin = New Padding(4, 3, 4, 3)
        btnGenerateLocalisationClassic.Name = "btnGenerateLocalisationClassic"
        btnGenerateLocalisationClassic.Size = New Size(186, 22)
        btnGenerateLocalisationClassic.TabIndex = 74
        btnGenerateLocalisationClassic.Text = "Create Imgur Link Classic"
        btnGenerateLocalisationClassic.UseVisualStyleBackColor = True
        ' 
        ' frmIATDatabaseManager
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1904, 1041)
        Controls.Add(btnGenerateLocalisationClassic)
        Controls.Add(TabControl2)
        Controls.Add(btnUploadLocaleClassic)
        Controls.Add(btnTestTranslationClassic)
        Controls.Add(txtLocaleStringClassic)
        Controls.Add(Label33)
        Controls.Add(Tactics)
        Controls.Add(WebView2)
        Controls.Add(btnBack)
        Controls.Add(btnGenerateLocaleNoUpload)
        Controls.Add(btnAddSpell)
        Controls.Add(txtSpellName)
        Controls.Add(txtLoadingStatus)
        Controls.Add(btnUploadLocale)
        Controls.Add(Label9)
        Controls.Add(btnGenerateLocalisation)
        Controls.Add(txtLocaleString)
        Controls.Add(GroupBox1)
        Controls.Add(cboInstances)
        Controls.Add(Label27)
        Controls.Add(cboExpansions)
        Controls.Add(Label26)
        Controls.Add(Label20)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(cboNPC)
        Controls.Add(btnInsertTactic)
        Controls.Add(Label1)
        Controls.Add(cboBosses)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(4, 3, 4, 3)
        Name = "frmIATDatabaseManager"
        Text = "IAT Database Manager"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        CType(WebView2, ComponentModel.ISupportInitialize).EndInit()
        Tactics.ResumeLayout(False)
        Retail.ResumeLayout(False)
        Retail.PerformLayout()
        Classic.ResumeLayout(False)
        Classic.PerformLayout()
        TabControl2.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        TabPage4.ResumeLayout(False)
        TabPage4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents cboBosses As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTacticsLocale As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnInsertTactic As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cboNPC As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents InsertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpansionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BossToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label14 As Label
    Friend WithEvents txtInstanceID As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtInstanceNameID As TextBox
    Friend WithEvents txtInstanceName As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtInstanceType As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtExpansion As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtExpansionID As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtContext As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtImgurLink As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents cboExpansions As ComboBox
    Friend WithEvents cboInstances As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNameID As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtIndex As TextBox
    Friend WithEvents txtTactics As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBossName As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtBossIDs As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtAchievement As TextBox
    Friend WithEvents txtPlayers As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtEnabled As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtTrack As TextBox
    Friend WithEvents txtPartial As TextBox
    Friend WithEvents txtInfoFrame As TextBox
    Friend WithEvents txtEncounterID As TextBox
    Friend WithEvents txtNewTactics As TextBox
    Friend WithEvents btnGenerateLocalisation As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txtLocaleString As TextBox
    Friend WithEvents txtInGame As TextBox
    Friend WithEvents btnUploadLocale As Button
    Friend WithEvents txtLoadingStatus As Label
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NPCsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpellsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewSpellsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtSpellName As TextBox
    Friend WithEvents btnAddSpell As Button
    Friend WithEvents btnGenerateLocaleNoUpload As Button
    Friend WithEvents LocalisationManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnBack As Button
    Friend WithEvents CoordinateBuilderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtImage As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents WebView2 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Label29 As Label
    Friend WithEvents txtInstanceNameWrath As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtBossNameWrath As TextBox
    Friend WithEvents Tactics As TabControl
    Friend WithEvents Retail As TabPage
    Friend WithEvents Classic As TabPage
    Friend WithEvents Label31 As Label
    Friend WithEvents txtNewTacticsClassic As TextBox
    Friend WithEvents txtTacticsLocaleClassic As TextBox
    Friend WithEvents txtInGameClassic As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtClassicTactics As TextBox
    Friend WithEvents txtClassicPhase As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents txtLocaleStringClassic As TextBox
    Friend WithEvents btnTestTranslationClassic As Button
    Friend WithEvents btnUploadLocaleClassic As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents txtContextClassic As TextBox
    Friend WithEvents txtImgurLinkClassic As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents btnGenerateLocalisationClassic As Button
    Friend WithEvents txtEncounterIDWrath As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents txtClassicOnly As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents txtRetailOnly As TextBox
End Class
