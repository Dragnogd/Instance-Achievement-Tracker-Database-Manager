<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocalisationImporter
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
        txtStatus = New TextBox()
        GroupBox1 = New GroupBox()
        btnAddCustomLocalisation = New Button()
        txtValue = New TextBox()
        txtKey = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtStatus
        ' 
        txtStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtStatus.BackColor = Color.Black
        txtStatus.BorderStyle = BorderStyle.None
        txtStatus.ForeColor = Color.White
        txtStatus.Location = New Point(0, 0)
        txtStatus.Margin = New Padding(6)
        txtStatus.Multiline = True
        txtStatus.Name = "txtStatus"
        txtStatus.ScrollBars = ScrollBars.Vertical
        txtStatus.Size = New Size(1600, 670)
        txtStatus.TabIndex = 0
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnAddCustomLocalisation)
        GroupBox1.Controls.Add(txtValue)
        GroupBox1.Controls.Add(txtKey)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.ForeColor = Color.White
        GroupBox1.Location = New Point(12, 677)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1576, 176)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Add Custom UI Localisation"
        ' 
        ' btnAddCustomLocalisation
        ' 
        btnAddCustomLocalisation.ForeColor = Color.Black
        btnAddCustomLocalisation.Location = New Point(1200, 40)
        btnAddCustomLocalisation.Name = "btnAddCustomLocalisation"
        btnAddCustomLocalisation.Size = New Size(350, 100)
        btnAddCustomLocalisation.TabIndex = 4
        btnAddCustomLocalisation.Text = "Add Localisation"
        btnAddCustomLocalisation.UseVisualStyleBackColor = True
        ' 
        ' txtValue
        ' 
        txtValue.Location = New Point(100, 100)
        txtValue.Multiline = True
        txtValue.Name = "txtValue"
        txtValue.Size = New Size(1080, 60)
        txtValue.TabIndex = 3
        ' 
        ' txtKey
        ' 
        txtKey.Location = New Point(100, 40)
        txtKey.Name = "txtKey"
        txtKey.Size = New Size(1080, 32)
        txtKey.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(20, 103)
        Label2.Name = "Label2"
        Label2.Size = New Size(77, 25)
        Label2.TabIndex = 1
        Label2.Text = "Value:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(20, 43)
        Label1.Name = "Label1"
        Label1.Size = New Size(58, 25)
        Label1.TabIndex = 0
        Label1.Text = "Key:"
        ' 
        ' LocalisationImporter
        ' 
        AutoScaleDimensions = New SizeF(12F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(1600, 865)
        Controls.Add(GroupBox1)
        Controls.Add(txtStatus)
        Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(6)
        Name = "LocalisationImporter"
        Text = "Localisation Importer"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents txtStatus As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddCustomLocalisation As Button
    Friend WithEvents txtValue As TextBox
    Friend WithEvents txtKey As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
