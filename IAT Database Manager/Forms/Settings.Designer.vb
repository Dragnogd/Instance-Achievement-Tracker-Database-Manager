<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        GroupBox1 = New GroupBox()
        txtCurseforgeProjectID = New TextBox()
        Label4 = New Label()
        txtImgurSecret = New TextBox()
        Label3 = New Label()
        txtCurseForgeAPIKey = New TextBox()
        Label2 = New Label()
        txtImgurClient = New TextBox()
        Label1 = New Label()
        btnSaveChanges = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnSaveChanges)
        GroupBox1.Controls.Add(txtCurseforgeProjectID)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(txtImgurSecret)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(txtCurseForgeAPIKey)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(txtImgurClient)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(662, 432)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "API Keys"
        ' 
        ' txtCurseforgeProjectID
        ' 
        txtCurseforgeProjectID.Location = New Point(131, 106)
        txtCurseforgeProjectID.Name = "txtCurseforgeProjectID"
        txtCurseforgeProjectID.Size = New Size(169, 23)
        txtCurseforgeProjectID.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(6, 109)
        Label4.Name = "Label4"
        Label4.Size = New Size(119, 15)
        Label4.TabIndex = 6
        Label4.Text = "Curseforge Project ID"
        ' 
        ' txtImgurSecret
        ' 
        txtImgurSecret.Location = New Point(133, 48)
        txtImgurSecret.Name = "txtImgurSecret"
        txtImgurSecret.Size = New Size(169, 23)
        txtImgurSecret.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 51)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 15)
        Label3.TabIndex = 4
        Label3.Text = "Imgur Secret"
        ' 
        ' txtCurseForgeAPIKey
        ' 
        txtCurseForgeAPIKey.Location = New Point(133, 77)
        txtCurseForgeAPIKey.Name = "txtCurseForgeAPIKey"
        txtCurseForgeAPIKey.Size = New Size(169, 23)
        txtCurseForgeAPIKey.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 80)
        Label2.Name = "Label2"
        Label2.Size = New Size(108, 15)
        Label2.TabIndex = 2
        Label2.Text = "Curseforge API Key"
        ' 
        ' txtImgurClient
        ' 
        txtImgurClient.Location = New Point(133, 22)
        txtImgurClient.Name = "txtImgurClient"
        txtImgurClient.Size = New Size(169, 23)
        txtImgurClient.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(73, 15)
        Label1.TabIndex = 0
        Label1.Text = "Imgur Client"
        ' 
        ' btnSaveChanges
        ' 
        btnSaveChanges.Location = New Point(6, 392)
        btnSaveChanges.Name = "btnSaveChanges"
        btnSaveChanges.Size = New Size(296, 34)
        btnSaveChanges.TabIndex = 8
        btnSaveChanges.Text = "Save Changes"
        btnSaveChanges.UseVisualStyleBackColor = True
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(686, 456)
        Controls.Add(GroupBox1)
        Name = "Settings"
        Text = "Settings"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCurseForgeAPIKey As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtImgurClient As TextBox
    Friend WithEvents txtImgurSecret As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCurseforgeProjectID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSaveChanges As Button
End Class
