<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InsertInstance
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
        Me.components = New System.ComponentModel.Container()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnAddInstance = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtInstanceName = New System.Windows.Forms.TextBox()
        Me.lblInstanceName = New System.Windows.Forms.Label()
        Me.txtInstanceNameID = New System.Windows.Forms.TextBox()
        Me.lblInstanceNameID = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtInstanceID = New System.Windows.Forms.TextBox()
        Me.cboExpansions = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboInstanceTypes = New System.Windows.Forms.ComboBox()
        Me.txtLuaImport = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(12, 183)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(322, 20)
        Me.txtStatus.TabIndex = 11
        '
        'btnAddInstance
        '
        Me.btnAddInstance.Location = New System.Drawing.Point(12, 140)
        Me.btnAddInstance.Name = "btnAddInstance"
        Me.btnAddInstance.Size = New System.Drawing.Size(322, 37)
        Me.btnAddInstance.TabIndex = 10
        Me.btnAddInstance.Text = "Add Instance"
        Me.btnAddInstance.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 90)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Instance Type"
        '
        'txtInstanceName
        '
        Me.txtInstanceName.Location = New System.Drawing.Point(111, 61)
        Me.txtInstanceName.Name = "txtInstanceName"
        Me.txtInstanceName.Size = New System.Drawing.Size(223, 20)
        Me.txtInstanceName.TabIndex = 43
        '
        'lblInstanceName
        '
        Me.lblInstanceName.AutoSize = True
        Me.lblInstanceName.Location = New System.Drawing.Point(11, 64)
        Me.lblInstanceName.Name = "lblInstanceName"
        Me.lblInstanceName.Size = New System.Drawing.Size(79, 13)
        Me.lblInstanceName.TabIndex = 42
        Me.lblInstanceName.Text = "Instance Name"
        '
        'txtInstanceNameID
        '
        Me.txtInstanceNameID.Location = New System.Drawing.Point(111, 35)
        Me.txtInstanceNameID.Name = "txtInstanceNameID"
        Me.txtInstanceNameID.Size = New System.Drawing.Size(223, 20)
        Me.txtInstanceNameID.TabIndex = 41
        '
        'lblInstanceNameID
        '
        Me.lblInstanceNameID.AutoSize = True
        Me.lblInstanceNameID.Location = New System.Drawing.Point(11, 38)
        Me.lblInstanceNameID.Name = "lblInstanceNameID"
        Me.lblInstanceNameID.Size = New System.Drawing.Size(93, 13)
        Me.lblInstanceNameID.TabIndex = 40
        Me.lblInstanceNameID.Text = "Instance Name ID"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Instance ID"
        '
        'txtInstanceID
        '
        Me.txtInstanceID.Location = New System.Drawing.Point(111, 9)
        Me.txtInstanceID.Name = "txtInstanceID"
        Me.txtInstanceID.Size = New System.Drawing.Size(223, 20)
        Me.txtInstanceID.TabIndex = 39
        '
        'cboExpansions
        '
        Me.cboExpansions.FormattingEnabled = True
        Me.cboExpansions.Location = New System.Drawing.Point(111, 113)
        Me.cboExpansions.Name = "cboExpansions"
        Me.cboExpansions.Size = New System.Drawing.Size(223, 21)
        Me.cboExpansions.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Expansion"
        '
        'cboInstanceTypes
        '
        Me.cboInstanceTypes.FormattingEnabled = True
        Me.cboInstanceTypes.Items.AddRange(New Object() {"Raids", "Dungeons", "Scenarios", "Delves"})
        Me.cboInstanceTypes.Location = New System.Drawing.Point(111, 87)
        Me.cboInstanceTypes.Name = "cboInstanceTypes"
        Me.cboInstanceTypes.Size = New System.Drawing.Size(223, 21)
        Me.cboInstanceTypes.TabIndex = 48
        '
        'txtLuaImport
        '
        Me.txtLuaImport.Location = New System.Drawing.Point(340, 38)
        Me.txtLuaImport.Multiline = True
        Me.txtLuaImport.Name = "txtLuaImport"
        Me.txtLuaImport.Size = New System.Drawing.Size(241, 165)
        Me.txtLuaImport.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(340, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Lua Table Import"
        '
        'Timer1
        '
        '
        'InsertInstance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 214)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLuaImport)
        Me.Controls.Add(Me.cboInstanceTypes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboExpansions)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtInstanceName)
        Me.Controls.Add(Me.lblInstanceName)
        Me.Controls.Add(Me.txtInstanceNameID)
        Me.Controls.Add(Me.lblInstanceNameID)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtInstanceID)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.btnAddInstance)
        Me.Name = "InsertInstance"
        Me.Text = "InsertInstance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtStatus As TextBox
    Friend WithEvents btnAddInstance As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents txtInstanceName As TextBox
    Friend WithEvents lblInstanceName As Label
    Friend WithEvents txtInstanceNameID As TextBox
    Friend WithEvents lblInstanceNameID As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtInstanceID As TextBox
    Friend WithEvents cboExpansions As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboInstanceTypes As ComboBox
    Friend WithEvents txtLuaImport As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
End Class
