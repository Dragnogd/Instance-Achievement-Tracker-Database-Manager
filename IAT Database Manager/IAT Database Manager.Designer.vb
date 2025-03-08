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
        Me.cboBosses = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTacticsLocale = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnInsertTactic = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboNPC = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpansionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BossToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NPCsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpellsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSpellsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocalisationManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CoordinateBuilderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtInstanceID = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtInstanceNameID = New System.Windows.Forms.TextBox()
        Me.txtInstanceName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtInstanceType = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtClassicPhase = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtInstanceNameWrath = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtExpansion = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtExpansionID = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtContext = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtImgurLink = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboExpansions = New System.Windows.Forms.ComboBox()
        Me.cboInstances = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtEncounterIDWrath = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtTactics = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtClassicTactics = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtBossNameWrath = New System.Windows.Forms.TextBox()
        Me.txtImage = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNameID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIndex = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBossName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBossIDs = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAchievement = New System.Windows.Forms.TextBox()
        Me.txtPlayers = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtEnabled = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTrack = New System.Windows.Forms.TextBox()
        Me.txtPartial = New System.Windows.Forms.TextBox()
        Me.txtInfoFrame = New System.Windows.Forms.TextBox()
        Me.txtEncounterID = New System.Windows.Forms.TextBox()
        Me.txtNewTactics = New System.Windows.Forms.TextBox()
        Me.btnGenerateLocalisation = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLocaleString = New System.Windows.Forms.TextBox()
        Me.txtInGame = New System.Windows.Forms.TextBox()
        Me.btnUploadLocale = New System.Windows.Forms.Button()
        Me.txtLoadingStatus = New System.Windows.Forms.Label()
        Me.txtSpellName = New System.Windows.Forms.TextBox()
        Me.btnAddSpell = New System.Windows.Forms.Button()
        Me.btnGenerateLocaleNoUpload = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.WebView2 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Tactics = New System.Windows.Forms.TabControl()
        Me.Retail = New System.Windows.Forms.TabPage()
        Me.Classic = New System.Windows.Forms.TabPage()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtNewTacticsClassic = New System.Windows.Forms.TextBox()
        Me.txtTacticsLocaleClassic = New System.Windows.Forms.TextBox()
        Me.txtInGameClassic = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtLocaleStringClassic = New System.Windows.Forms.TextBox()
        Me.btnTestTranslationClassic = New System.Windows.Forms.Button()
        Me.btnUploadLocaleClassic = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtImgurLinkClassic = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtContextClassic = New System.Windows.Forms.TextBox()
        Me.btnGenerateLocalisationClassic = New System.Windows.Forms.Button()
        Me.txtRetailOnly = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtClassicOnly = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.WebView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tactics.SuspendLayout()
        Me.Retail.SuspendLayout()
        Me.Classic.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboBosses
        '
        Me.cboBosses.FormattingEnabled = True
        Me.cboBosses.Location = New System.Drawing.Point(9, 33)
        Me.cboBosses.Name = "cboBosses"
        Me.cboBosses.Size = New System.Drawing.Size(269, 21)
        Me.cboBosses.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Boss"
        '
        'txtTacticsLocale
        '
        Me.txtTacticsLocale.Location = New System.Drawing.Point(6, 156)
        Me.txtTacticsLocale.Multiline = True
        Me.txtTacticsLocale.Name = "txtTacticsLocale"
        Me.txtTacticsLocale.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTacticsLocale.Size = New System.Drawing.Size(578, 119)
        Me.txtTacticsLocale.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tactics (Localisation)"
        '
        'btnInsertTactic
        '
        Me.btnInsertTactic.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsertTactic.Location = New System.Drawing.Point(935, 946)
        Me.btnInsertTactic.Name = "btnInsertTactic"
        Me.btnInsertTactic.Size = New System.Drawing.Size(293, 32)
        Me.btnInsertTactic.TabIndex = 4
        Me.btnInsertTactic.Text = "Save Changes"
        Me.btnInsertTactic.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(428, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Insert NPC"
        '
        'cboNPC
        '
        Me.cboNPC.FormattingEnabled = True
        Me.cboNPC.Location = New System.Drawing.Point(492, 63)
        Me.cboNPC.Name = "cboNPC"
        Me.cboNPC.Size = New System.Drawing.Size(121, 21)
        Me.cboNPC.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(100, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Item/Spell Name"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ViewSpellsToolStripMenuItem, Me.LocalisationManagerToolStripMenuItem, Me.CoordinateBuilderToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1701, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExpansionToolStripMenuItem, Me.InstanceToolStripMenuItem, Me.BossToolStripMenuItem})
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.InsertToolStripMenuItem.Text = "Insert"
        '
        'ExpansionToolStripMenuItem
        '
        Me.ExpansionToolStripMenuItem.Name = "ExpansionToolStripMenuItem"
        Me.ExpansionToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ExpansionToolStripMenuItem.Text = "Expansion"
        '
        'InstanceToolStripMenuItem
        '
        Me.InstanceToolStripMenuItem.Name = "InstanceToolStripMenuItem"
        Me.InstanceToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.InstanceToolStripMenuItem.Text = "Instance"
        '
        'BossToolStripMenuItem
        '
        Me.BossToolStripMenuItem.Name = "BossToolStripMenuItem"
        Me.BossToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.BossToolStripMenuItem.Text = "Boss"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NPCsToolStripMenuItem, Me.SpellsToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'NPCsToolStripMenuItem
        '
        Me.NPCsToolStripMenuItem.Name = "NPCsToolStripMenuItem"
        Me.NPCsToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.NPCsToolStripMenuItem.Text = "NPC's"
        '
        'SpellsToolStripMenuItem
        '
        Me.SpellsToolStripMenuItem.Name = "SpellsToolStripMenuItem"
        Me.SpellsToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.SpellsToolStripMenuItem.Text = "Spells"
        '
        'ViewSpellsToolStripMenuItem
        '
        Me.ViewSpellsToolStripMenuItem.Name = "ViewSpellsToolStripMenuItem"
        Me.ViewSpellsToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ViewSpellsToolStripMenuItem.Text = "View Spells"
        '
        'LocalisationManagerToolStripMenuItem
        '
        Me.LocalisationManagerToolStripMenuItem.Name = "LocalisationManagerToolStripMenuItem"
        Me.LocalisationManagerToolStripMenuItem.Size = New System.Drawing.Size(123, 20)
        Me.LocalisationManagerToolStripMenuItem.Text = "Update Localisation"
        '
        'CoordinateBuilderToolStripMenuItem
        '
        Me.CoordinateBuilderToolStripMenuItem.Name = "CoordinateBuilderToolStripMenuItem"
        Me.CoordinateBuilderToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.CoordinateBuilderToolStripMenuItem.Text = "Coordinate Builder"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Instance ID"
        '
        'txtInstanceID
        '
        Me.txtInstanceID.Location = New System.Drawing.Point(105, 24)
        Me.txtInstanceID.Name = "txtInstanceID"
        Me.txtInstanceID.Size = New System.Drawing.Size(195, 20)
        Me.txtInstanceID.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Instance Name ID"
        '
        'txtInstanceNameID
        '
        Me.txtInstanceNameID.Location = New System.Drawing.Point(105, 50)
        Me.txtInstanceNameID.Name = "txtInstanceNameID"
        Me.txtInstanceNameID.Size = New System.Drawing.Size(195, 20)
        Me.txtInstanceNameID.TabIndex = 33
        '
        'txtInstanceName
        '
        Me.txtInstanceName.Location = New System.Drawing.Point(105, 76)
        Me.txtInstanceName.Name = "txtInstanceName"
        Me.txtInstanceName.Size = New System.Drawing.Size(195, 20)
        Me.txtInstanceName.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(5, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Instance Name"
        '
        'txtInstanceType
        '
        Me.txtInstanceType.Location = New System.Drawing.Point(106, 127)
        Me.txtInstanceType.Name = "txtInstanceType"
        Me.txtInstanceType.Size = New System.Drawing.Size(195, 20)
        Me.txtInstanceType.TabIndex = 37
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 130)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Instance Type"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtClassicOnly)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.txtRetailOnly)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.txtClassicPhase)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.txtInstanceNameWrath)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtInstanceType)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtInstanceName)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtInstanceNameID)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtInstanceID)
        Me.GroupBox2.Location = New System.Drawing.Point(619, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 184)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Instance Specific"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(95, 159)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(58, 13)
        Me.Label36.TabIndex = 43
        Me.Label36.Text = "Retail Only"
        '
        'txtClassicPhase
        '
        Me.txtClassicPhase.Location = New System.Drawing.Point(55, 156)
        Me.txtClassicPhase.Name = "txtClassicPhase"
        Me.txtClassicPhase.Size = New System.Drawing.Size(34, 20)
        Me.txtClassicPhase.TabIndex = 42
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(8, 158)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(47, 13)
        Me.Label32.TabIndex = 41
        Me.Label32.Text = "C Phase"
        '
        'txtInstanceNameWrath
        '
        Me.txtInstanceNameWrath.Location = New System.Drawing.Point(126, 100)
        Me.txtInstanceNameWrath.Multiline = True
        Me.txtInstanceNameWrath.Name = "txtInstanceNameWrath"
        Me.txtInstanceNameWrath.Size = New System.Drawing.Size(173, 21)
        Me.txtInstanceNameWrath.TabIndex = 39
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(5, 103)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(117, 13)
        Me.Label29.TabIndex = 40
        Me.Label29.Text = "Wrath - Instance Name"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Expansion"
        '
        'txtExpansion
        '
        Me.txtExpansion.Location = New System.Drawing.Point(84, 13)
        Me.txtExpansion.Name = "txtExpansion"
        Me.txtExpansion.Size = New System.Drawing.Size(217, 20)
        Me.txtExpansion.TabIndex = 39
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Expansion ID"
        '
        'txtExpansionID
        '
        Me.txtExpansionID.Location = New System.Drawing.Point(84, 39)
        Me.txtExpansionID.Name = "txtExpansionID"
        Me.txtExpansionID.Size = New System.Drawing.Size(217, 20)
        Me.txtExpansionID.TabIndex = 41
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtExpansionID)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txtExpansion)
        Me.GroupBox3.Location = New System.Drawing.Point(625, 33)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(307, 69)
        Me.GroupBox3.TabIndex = 42
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Expansion Specific"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(940, 33)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 13)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "Localisation Importer"
        '
        'txtContext
        '
        Me.txtContext.Location = New System.Drawing.Point(4, 6)
        Me.txtContext.Multiline = True
        Me.txtContext.Name = "txtContext"
        Me.txtContext.Size = New System.Drawing.Size(305, 62)
        Me.txtContext.TabIndex = 47
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(18, 77)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "Imgur Link"
        '
        'txtImgurLink
        '
        Me.txtImgurLink.Location = New System.Drawing.Point(80, 74)
        Me.txtImgurLink.Name = "txtImgurLink"
        Me.txtImgurLink.Size = New System.Drawing.Size(223, 20)
        Me.txtImgurLink.TabIndex = 32
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(284, 36)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 13)
        Me.Label26.TabIndex = 48
        Me.Label26.Text = "Select Expansion"
        '
        'cboExpansions
        '
        Me.cboExpansions.FormattingEnabled = True
        Me.cboExpansions.Location = New System.Drawing.Point(379, 33)
        Me.cboExpansions.Name = "cboExpansions"
        Me.cboExpansions.Size = New System.Drawing.Size(101, 21)
        Me.cboExpansions.TabIndex = 49
        '
        'cboInstances
        '
        Me.cboInstances.FormattingEnabled = True
        Me.cboInstances.Location = New System.Drawing.Point(486, 33)
        Me.cboInstances.Name = "cboInstances"
        Me.cboInstances.Size = New System.Drawing.Size(133, 21)
        Me.cboInstances.TabIndex = 51
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(516, 17)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(81, 13)
        Me.Label27.TabIndex = 50
        Me.Label27.Text = "Select Instance"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.txtEncounterIDWrath)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.txtBossNameWrath)
        Me.GroupBox1.Controls.Add(Me.txtImage)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNameID)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtIndex)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtBossName)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtBossIDs)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtAchievement)
        Me.GroupBox1.Controls.Add(Me.txtPlayers)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.txtEnabled)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtTrack)
        Me.GroupBox1.Controls.Add(Me.txtPartial)
        Me.GroupBox1.Controls.Add(Me.txtInfoFrame)
        Me.GroupBox1.Controls.Add(Me.txtEncounterID)
        Me.GroupBox1.Location = New System.Drawing.Point(619, 348)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 535)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Boss Specific"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(190, 447)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(18, 13)
        Me.Label35.TabIndex = 43
        Me.Label35.Text = "W"
        '
        'txtEncounterIDWrath
        '
        Me.txtEncounterIDWrath.Location = New System.Drawing.Point(208, 444)
        Me.txtEncounterIDWrath.Name = "txtEncounterIDWrath"
        Me.txtEncounterIDWrath.Size = New System.Drawing.Size(91, 20)
        Me.txtEncounterIDWrath.TabIndex = 42
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(55, 213)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(246, 147)
        Me.TabControl1.TabIndex = 41
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtTactics)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(238, 121)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Retail"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtTactics
        '
        Me.txtTactics.Location = New System.Drawing.Point(6, 10)
        Me.txtTactics.Multiline = True
        Me.txtTactics.Name = "txtTactics"
        Me.txtTactics.Size = New System.Drawing.Size(223, 106)
        Me.txtTactics.TabIndex = 30
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtClassicTactics)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(238, 121)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Classic"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtClassicTactics
        '
        Me.txtClassicTactics.Location = New System.Drawing.Point(8, 7)
        Me.txtClassicTactics.Multiline = True
        Me.txtClassicTactics.Name = "txtClassicTactics"
        Me.txtClassicTactics.Size = New System.Drawing.Size(223, 106)
        Me.txtClassicTactics.TabIndex = 31
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 74)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 13)
        Me.Label30.TabIndex = 39
        Me.Label30.Text = "Wrath - Name"
        '
        'txtBossNameWrath
        '
        Me.txtBossNameWrath.Location = New System.Drawing.Point(85, 71)
        Me.txtBossNameWrath.Name = "txtBossNameWrath"
        Me.txtBossNameWrath.Size = New System.Drawing.Size(214, 20)
        Me.txtBossNameWrath.TabIndex = 40
        '
        'txtImage
        '
        Me.txtImage.Location = New System.Drawing.Point(75, 500)
        Me.txtImage.Name = "txtImage"
        Me.txtImage.Size = New System.Drawing.Size(223, 20)
        Me.txtImage.TabIndex = 38
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(5, 503)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(36, 13)
        Me.Label28.TabIndex = 37
        Me.Label28.Text = "Image"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(8, 369)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 13)
        Me.Label22.TabIndex = 36
        Me.Label22.Text = "Enabled"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Name ID"
        '
        'txtNameID
        '
        Me.txtNameID.Location = New System.Drawing.Point(77, 97)
        Me.txtNameID.Name = "txtNameID"
        Me.txtNameID.Size = New System.Drawing.Size(223, 20)
        Me.txtNameID.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Index"
        '
        'txtIndex
        '
        Me.txtIndex.Location = New System.Drawing.Point(77, 19)
        Me.txtIndex.Name = "txtIndex"
        Me.txtIndex.Size = New System.Drawing.Size(223, 20)
        Me.txtIndex.TabIndex = 33
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 213)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 13)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "Tactics"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Name"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 476)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "InfoFrame"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Boss ID's"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 447)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Encounter ID"
        '
        'txtBossName
        '
        Me.txtBossName.Location = New System.Drawing.Point(77, 45)
        Me.txtBossName.Name = "txtBossName"
        Me.txtBossName.Size = New System.Drawing.Size(223, 20)
        Me.txtBossName.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 424)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Partial"
        '
        'txtBossIDs
        '
        Me.txtBossIDs.Location = New System.Drawing.Point(78, 125)
        Me.txtBossIDs.Name = "txtBossIDs"
        Me.txtBossIDs.Size = New System.Drawing.Size(223, 20)
        Me.txtBossIDs.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 398)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Track"
        '
        'txtAchievement
        '
        Me.txtAchievement.Location = New System.Drawing.Point(78, 151)
        Me.txtAchievement.Name = "txtAchievement"
        Me.txtAchievement.Size = New System.Drawing.Size(223, 20)
        Me.txtAchievement.TabIndex = 15
        '
        'txtPlayers
        '
        Me.txtPlayers.Location = New System.Drawing.Point(78, 177)
        Me.txtPlayers.Name = "txtPlayers"
        Me.txtPlayers.Size = New System.Drawing.Size(223, 20)
        Me.txtPlayers.TabIndex = 16
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 187)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(41, 13)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Players"
        '
        'txtEnabled
        '
        Me.txtEnabled.Location = New System.Drawing.Point(76, 366)
        Me.txtEnabled.Name = "txtEnabled"
        Me.txtEnabled.Size = New System.Drawing.Size(223, 20)
        Me.txtEnabled.TabIndex = 17
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 161)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(69, 13)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "Achievement"
        '
        'txtTrack
        '
        Me.txtTrack.Location = New System.Drawing.Point(76, 392)
        Me.txtTrack.Name = "txtTrack"
        Me.txtTrack.Size = New System.Drawing.Size(223, 20)
        Me.txtTrack.TabIndex = 18
        '
        'txtPartial
        '
        Me.txtPartial.Location = New System.Drawing.Point(76, 418)
        Me.txtPartial.Name = "txtPartial"
        Me.txtPartial.Size = New System.Drawing.Size(223, 20)
        Me.txtPartial.TabIndex = 19
        '
        'txtInfoFrame
        '
        Me.txtInfoFrame.Location = New System.Drawing.Point(76, 470)
        Me.txtInfoFrame.Name = "txtInfoFrame"
        Me.txtInfoFrame.Size = New System.Drawing.Size(223, 20)
        Me.txtInfoFrame.TabIndex = 21
        Me.txtInfoFrame.Text = "false"
        '
        'txtEncounterID
        '
        Me.txtEncounterID.Location = New System.Drawing.Point(76, 444)
        Me.txtEncounterID.Name = "txtEncounterID"
        Me.txtEncounterID.Size = New System.Drawing.Size(108, 20)
        Me.txtEncounterID.TabIndex = 20
        '
        'txtNewTactics
        '
        Me.txtNewTactics.Location = New System.Drawing.Point(6, 26)
        Me.txtNewTactics.Multiline = True
        Me.txtNewTactics.Name = "txtNewTactics"
        Me.txtNewTactics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNewTactics.Size = New System.Drawing.Size(578, 124)
        Me.txtNewTactics.TabIndex = 53
        '
        'btnGenerateLocalisation
        '
        Me.btnGenerateLocalisation.Location = New System.Drawing.Point(936, 922)
        Me.btnGenerateLocalisation.Name = "btnGenerateLocalisation"
        Me.btnGenerateLocalisation.Size = New System.Drawing.Size(108, 19)
        Me.btnGenerateLocalisation.TabIndex = 54
        Me.btnGenerateLocalisation.Text = "Create Imgur Link"
        Me.btnGenerateLocalisation.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(633, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Locale String"
        '
        'txtLocaleString
        '
        Me.txtLocaleString.Location = New System.Drawing.Point(708, 108)
        Me.txtLocaleString.Name = "txtLocaleString"
        Me.txtLocaleString.Size = New System.Drawing.Size(217, 20)
        Me.txtLocaleString.TabIndex = 43
        '
        'txtInGame
        '
        Me.txtInGame.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInGame.Location = New System.Drawing.Point(6, 279)
        Me.txtInGame.Multiline = True
        Me.txtInGame.Name = "txtInGame"
        Me.txtInGame.Size = New System.Drawing.Size(578, 583)
        Me.txtInGame.TabIndex = 55
        '
        'btnUploadLocale
        '
        Me.btnUploadLocale.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadLocale.Location = New System.Drawing.Point(1234, 946)
        Me.btnUploadLocale.Name = "btnUploadLocale"
        Me.btnUploadLocale.Size = New System.Drawing.Size(169, 31)
        Me.btnUploadLocale.TabIndex = 56
        Me.btnUploadLocale.Text = "Upload Locale"
        Me.btnUploadLocale.UseVisualStyleBackColor = True
        '
        'txtLoadingStatus
        '
        Me.txtLoadingStatus.AutoSize = True
        Me.txtLoadingStatus.Location = New System.Drawing.Point(1419, 33)
        Me.txtLoadingStatus.Name = "txtLoadingStatus"
        Me.txtLoadingStatus.Size = New System.Drawing.Size(87, 13)
        Me.txtLoadingStatus.TabIndex = 59
        Me.txtLoadingStatus.Text = "Finished Loading"
        '
        'txtSpellName
        '
        Me.txtSpellName.Location = New System.Drawing.Point(192, 64)
        Me.txtSpellName.Name = "txtSpellName"
        Me.txtSpellName.Size = New System.Drawing.Size(127, 20)
        Me.txtSpellName.TabIndex = 61
        '
        'btnAddSpell
        '
        Me.btnAddSpell.Location = New System.Drawing.Point(325, 61)
        Me.btnAddSpell.Name = "btnAddSpell"
        Me.btnAddSpell.Size = New System.Drawing.Size(50, 24)
        Me.btnAddSpell.TabIndex = 62
        Me.btnAddSpell.Text = "Insert"
        Me.btnAddSpell.UseVisualStyleBackColor = True
        '
        'btnGenerateLocaleNoUpload
        '
        Me.btnGenerateLocaleNoUpload.Location = New System.Drawing.Point(1287, 920)
        Me.btnGenerateLocaleNoUpload.Name = "btnGenerateLocaleNoUpload"
        Me.btnGenerateLocaleNoUpload.Size = New System.Drawing.Size(116, 19)
        Me.btnGenerateLocaleNoUpload.TabIndex = 64
        Me.btnGenerateLocaleNoUpload.Text = "Test Translation"
        Me.btnGenerateLocaleNoUpload.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(1050, 27)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(96, 22)
        Me.btnBack.TabIndex = 66
        Me.btnBack.Text = "Refresh"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'WebView2
        '
        Me.WebView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebView2.CreationProperties = Nothing
        Me.WebView2.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView2.Location = New System.Drawing.Point(938, 57)
        Me.WebView2.Name = "WebView2"
        Me.WebView2.Size = New System.Drawing.Size(751, 857)
        Me.WebView2.TabIndex = 67
        Me.WebView2.ZoomFactor = 1.0R
        '
        'Tactics
        '
        Me.Tactics.Controls.Add(Me.Retail)
        Me.Tactics.Controls.Add(Me.Classic)
        Me.Tactics.Location = New System.Drawing.Point(9, 91)
        Me.Tactics.Name = "Tactics"
        Me.Tactics.SelectedIndex = 0
        Me.Tactics.Size = New System.Drawing.Size(598, 894)
        Me.Tactics.TabIndex = 68
        '
        'Retail
        '
        Me.Retail.Controls.Add(Me.Label2)
        Me.Retail.Controls.Add(Me.txtNewTactics)
        Me.Retail.Controls.Add(Me.txtTacticsLocale)
        Me.Retail.Controls.Add(Me.txtInGame)
        Me.Retail.Location = New System.Drawing.Point(4, 22)
        Me.Retail.Name = "Retail"
        Me.Retail.Padding = New System.Windows.Forms.Padding(3)
        Me.Retail.Size = New System.Drawing.Size(590, 868)
        Me.Retail.TabIndex = 0
        Me.Retail.Text = "Retail"
        Me.Retail.UseVisualStyleBackColor = True
        '
        'Classic
        '
        Me.Classic.Controls.Add(Me.Label31)
        Me.Classic.Controls.Add(Me.txtNewTacticsClassic)
        Me.Classic.Controls.Add(Me.txtTacticsLocaleClassic)
        Me.Classic.Controls.Add(Me.txtInGameClassic)
        Me.Classic.Location = New System.Drawing.Point(4, 22)
        Me.Classic.Name = "Classic"
        Me.Classic.Padding = New System.Windows.Forms.Padding(3)
        Me.Classic.Size = New System.Drawing.Size(590, 868)
        Me.Classic.TabIndex = 1
        Me.Classic.Text = "Classic"
        Me.Classic.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(6, 7)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(107, 13)
        Me.Label31.TabIndex = 57
        Me.Label31.Text = "Tactics (Localisation)"
        '
        'txtNewTacticsClassic
        '
        Me.txtNewTacticsClassic.Location = New System.Drawing.Point(6, 25)
        Me.txtNewTacticsClassic.Multiline = True
        Me.txtNewTacticsClassic.Name = "txtNewTacticsClassic"
        Me.txtNewTacticsClassic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNewTacticsClassic.Size = New System.Drawing.Size(578, 124)
        Me.txtNewTacticsClassic.TabIndex = 58
        '
        'txtTacticsLocaleClassic
        '
        Me.txtTacticsLocaleClassic.Location = New System.Drawing.Point(6, 155)
        Me.txtTacticsLocaleClassic.Multiline = True
        Me.txtTacticsLocaleClassic.Name = "txtTacticsLocaleClassic"
        Me.txtTacticsLocaleClassic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTacticsLocaleClassic.Size = New System.Drawing.Size(578, 119)
        Me.txtTacticsLocaleClassic.TabIndex = 56
        '
        'txtInGameClassic
        '
        Me.txtInGameClassic.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInGameClassic.Location = New System.Drawing.Point(6, 278)
        Me.txtInGameClassic.Multiline = True
        Me.txtInGameClassic.Name = "txtInGameClassic"
        Me.txtInGameClassic.Size = New System.Drawing.Size(578, 583)
        Me.txtInGameClassic.TabIndex = 59
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(613, 139)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(105, 13)
        Me.Label33.TabIndex = 69
        Me.Label33.Text = "Locale String Classic"
        '
        'txtLocaleStringClassic
        '
        Me.txtLocaleStringClassic.Location = New System.Drawing.Point(721, 136)
        Me.txtLocaleStringClassic.Name = "txtLocaleStringClassic"
        Me.txtLocaleStringClassic.Size = New System.Drawing.Size(204, 20)
        Me.txtLocaleStringClassic.TabIndex = 70
        '
        'btnTestTranslationClassic
        '
        Me.btnTestTranslationClassic.Location = New System.Drawing.Point(1409, 920)
        Me.btnTestTranslationClassic.Name = "btnTestTranslationClassic"
        Me.btnTestTranslationClassic.Size = New System.Drawing.Size(137, 19)
        Me.btnTestTranslationClassic.TabIndex = 71
        Me.btnTestTranslationClassic.Text = "Test Translation Classic"
        Me.btnTestTranslationClassic.UseVisualStyleBackColor = True
        '
        'btnUploadLocaleClassic
        '
        Me.btnUploadLocaleClassic.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadLocaleClassic.Location = New System.Drawing.Point(1409, 947)
        Me.btnUploadLocaleClassic.Name = "btnUploadLocaleClassic"
        Me.btnUploadLocaleClassic.Size = New System.Drawing.Size(280, 31)
        Me.btnUploadLocaleClassic.TabIndex = 72
        Me.btnUploadLocaleClassic.Text = "Upload Locale Classic"
        Me.btnUploadLocaleClassic.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Location = New System.Drawing.Point(609, 874)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(323, 126)
        Me.TabControl2.TabIndex = 73
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtContext)
        Me.TabPage3.Controls.Add(Me.txtImgurLink)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(315, 100)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Retail"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtImgurLinkClassic)
        Me.TabPage4.Controls.Add(Me.Label34)
        Me.TabPage4.Controls.Add(Me.txtContextClassic)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(315, 100)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Classic"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtImgurLinkClassic
        '
        Me.txtImgurLinkClassic.Location = New System.Drawing.Point(80, 76)
        Me.txtImgurLinkClassic.Name = "txtImgurLinkClassic"
        Me.txtImgurLinkClassic.Size = New System.Drawing.Size(223, 20)
        Me.txtImgurLinkClassic.TabIndex = 49
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(18, 79)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 13)
        Me.Label34.TabIndex = 50
        Me.Label34.Text = "Imgur Link"
        '
        'txtContextClassic
        '
        Me.txtContextClassic.Location = New System.Drawing.Point(5, 5)
        Me.txtContextClassic.Multiline = True
        Me.txtContextClassic.Name = "txtContextClassic"
        Me.txtContextClassic.Size = New System.Drawing.Size(305, 65)
        Me.txtContextClassic.TabIndex = 48
        '
        'btnGenerateLocalisationClassic
        '
        Me.btnGenerateLocalisationClassic.Location = New System.Drawing.Point(1050, 922)
        Me.btnGenerateLocalisationClassic.Name = "btnGenerateLocalisationClassic"
        Me.btnGenerateLocalisationClassic.Size = New System.Drawing.Size(159, 19)
        Me.btnGenerateLocalisationClassic.TabIndex = 74
        Me.btnGenerateLocalisationClassic.Text = "Create Imgur Link Classic"
        Me.btnGenerateLocalisationClassic.UseVisualStyleBackColor = True
        '
        'txtRetailOnly
        '
        Me.txtRetailOnly.Location = New System.Drawing.Point(150, 156)
        Me.txtRetailOnly.Name = "txtRetailOnly"
        Me.txtRetailOnly.Size = New System.Drawing.Size(34, 20)
        Me.txtRetailOnly.TabIndex = 44
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(190, 159)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(64, 13)
        Me.Label37.TabIndex = 45
        Me.Label37.Text = "Classic Only"
        '
        'txtClassicOnly
        '
        Me.txtClassicOnly.Location = New System.Drawing.Point(260, 156)
        Me.txtClassicOnly.Name = "txtClassicOnly"
        Me.txtClassicOnly.Size = New System.Drawing.Size(34, 20)
        Me.txtClassicOnly.TabIndex = 46
        '
        'frmIATDatabaseManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1701, 1004)
        Me.Controls.Add(Me.btnGenerateLocalisationClassic)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.btnUploadLocaleClassic)
        Me.Controls.Add(Me.btnTestTranslationClassic)
        Me.Controls.Add(Me.txtLocaleStringClassic)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Tactics)
        Me.Controls.Add(Me.WebView2)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnGenerateLocaleNoUpload)
        Me.Controls.Add(Me.btnAddSpell)
        Me.Controls.Add(Me.txtSpellName)
        Me.Controls.Add(Me.txtLoadingStatus)
        Me.Controls.Add(Me.btnUploadLocale)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnGenerateLocalisation)
        Me.Controls.Add(Me.txtLocaleString)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboInstances)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cboExpansions)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboNPC)
        Me.Controls.Add(Me.btnInsertTactic)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboBosses)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmIATDatabaseManager"
        Me.Text = "IAT Database Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.WebView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tactics.ResumeLayout(False)
        Me.Retail.ResumeLayout(False)
        Me.Retail.PerformLayout()
        Me.Classic.ResumeLayout(False)
        Me.Classic.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
