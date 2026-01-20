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
        components = New ComponentModel.Container()
        txtStatus = New TextBox()
        btnAddInstance = New Button()
        Label17 = New Label()
        txtInstanceName = New TextBox()
        lblInstanceName = New Label()
        txtInstanceNameID = New TextBox()
        lblInstanceNameID = New Label()
        Label14 = New Label()
        txtInstanceID = New TextBox()
        cboExpansions = New ComboBox()
        Label1 = New Label()
        cboInstanceTypes = New ComboBox()
        txtLuaImport = New TextBox()
        Label2 = New Label()
        Timer1 = New Timer(components)
        cboWagoInstances = New ComboBox()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' txtStatus
        ' 
        txtStatus.Location = New Point(14, 211)
        txtStatus.Margin = New Padding(4, 3, 4, 3)
        txtStatus.Name = "txtStatus"
        txtStatus.Size = New Size(375, 23)
        txtStatus.TabIndex = 11
        ' 
        ' btnAddInstance
        ' 
        btnAddInstance.Location = New Point(14, 162)
        btnAddInstance.Margin = New Padding(4, 3, 4, 3)
        btnAddInstance.Name = "btnAddInstance"
        btnAddInstance.Size = New Size(376, 43)
        btnAddInstance.TabIndex = 10
        btnAddInstance.Text = "Add Instance"
        btnAddInstance.UseVisualStyleBackColor = True
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(13, 104)
        Label17.Margin = New Padding(4, 0, 4, 0)
        Label17.Name = "Label17"
        Label17.Size = New Size(79, 15)
        Label17.TabIndex = 44
        Label17.Text = "Instance Type"
        ' 
        ' txtInstanceName
        ' 
        txtInstanceName.Location = New Point(130, 70)
        txtInstanceName.Margin = New Padding(4, 3, 4, 3)
        txtInstanceName.Name = "txtInstanceName"
        txtInstanceName.Size = New Size(259, 23)
        txtInstanceName.TabIndex = 43
        ' 
        ' lblInstanceName
        ' 
        lblInstanceName.AutoSize = True
        lblInstanceName.Location = New Point(13, 74)
        lblInstanceName.Margin = New Padding(4, 0, 4, 0)
        lblInstanceName.Name = "lblInstanceName"
        lblInstanceName.Size = New Size(86, 15)
        lblInstanceName.TabIndex = 42
        lblInstanceName.Text = "Instance Name"
        ' 
        ' txtInstanceNameID
        ' 
        txtInstanceNameID.Location = New Point(130, 40)
        txtInstanceNameID.Margin = New Padding(4, 3, 4, 3)
        txtInstanceNameID.Name = "txtInstanceNameID"
        txtInstanceNameID.Size = New Size(259, 23)
        txtInstanceNameID.TabIndex = 41
        ' 
        ' lblInstanceNameID
        ' 
        lblInstanceNameID.AutoSize = True
        lblInstanceNameID.Location = New Point(13, 44)
        lblInstanceNameID.Margin = New Padding(4, 0, 4, 0)
        lblInstanceNameID.Name = "lblInstanceNameID"
        lblInstanceNameID.Size = New Size(100, 15)
        lblInstanceNameID.TabIndex = 40
        lblInstanceNameID.Text = "Instance Name ID"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(14, 10)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(65, 15)
        Label14.TabIndex = 38
        Label14.Text = "Instance ID"
        ' 
        ' txtInstanceID
        ' 
        txtInstanceID.Location = New Point(130, 10)
        txtInstanceID.Margin = New Padding(4, 3, 4, 3)
        txtInstanceID.Name = "txtInstanceID"
        txtInstanceID.Size = New Size(259, 23)
        txtInstanceID.TabIndex = 39
        ' 
        ' cboExpansions
        ' 
        cboExpansions.FormattingEnabled = True
        cboExpansions.Location = New Point(130, 130)
        cboExpansions.Margin = New Padding(4, 3, 4, 3)
        cboExpansions.Name = "cboExpansions"
        cboExpansions.Size = New Size(259, 23)
        cboExpansions.TabIndex = 46
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(14, 130)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 15)
        Label1.TabIndex = 47
        Label1.Text = "Expansion"
        ' 
        ' cboInstanceTypes
        ' 
        cboInstanceTypes.FormattingEnabled = True
        cboInstanceTypes.Items.AddRange(New Object() {"Raids", "Dungeons", "Scenarios", "Delves"})
        cboInstanceTypes.Location = New Point(130, 100)
        cboInstanceTypes.Margin = New Padding(4, 3, 4, 3)
        cboInstanceTypes.Name = "cboInstanceTypes"
        cboInstanceTypes.Size = New Size(259, 23)
        cboInstanceTypes.TabIndex = 48
        ' 
        ' txtLuaImport
        ' 
        txtLuaImport.Location = New Point(397, 78)
        txtLuaImport.Margin = New Padding(4, 3, 4, 3)
        txtLuaImport.Multiline = True
        txtLuaImport.Name = "txtLuaImport"
        txtLuaImport.Size = New Size(280, 155)
        txtLuaImport.TabIndex = 49
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(397, 60)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 15)
        Label2.TabIndex = 50
        Label2.Text = "Lua Table Import"
        ' 
        ' Timer1
        ' 
        ' 
        ' cboWagoInstances
        ' 
        cboWagoInstances.FormattingEnabled = True
        cboWagoInstances.Location = New Point(397, 29)
        cboWagoInstances.Margin = New Padding(4, 3, 4, 3)
        cboWagoInstances.Name = "cboWagoInstances"
        cboWagoInstances.Size = New Size(280, 23)
        cboWagoInstances.TabIndex = 51
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(397, 10)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(131, 15)
        Label3.TabIndex = 52
        Label3.Text = "Select Instance (Wago)"
        ' 
        ' InsertInstance
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(693, 238)
        Controls.Add(Label3)
        Controls.Add(cboWagoInstances)
        Controls.Add(Label2)
        Controls.Add(txtLuaImport)
        Controls.Add(cboInstanceTypes)
        Controls.Add(Label1)
        Controls.Add(cboExpansions)
        Controls.Add(Label17)
        Controls.Add(txtInstanceName)
        Controls.Add(lblInstanceName)
        Controls.Add(txtInstanceNameID)
        Controls.Add(lblInstanceNameID)
        Controls.Add(Label14)
        Controls.Add(txtInstanceID)
        Controls.Add(txtStatus)
        Controls.Add(btnAddInstance)
        Margin = New Padding(4, 3, 4, 3)
        Name = "InsertInstance"
        Text = "InsertInstance"
        ResumeLayout(False)
        PerformLayout()

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
    Friend WithEvents cboWagoInstances As ComboBox
    Friend WithEvents Label3 As Label
End Class
