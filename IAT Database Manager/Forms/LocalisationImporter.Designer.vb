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
        SuspendLayout()
        ' 
        ' txtStatus
        ' 
        txtStatus.BackColor = Color.Black
        txtStatus.BorderStyle = BorderStyle.None
        txtStatus.ForeColor = Color.White
        txtStatus.Location = New Point(-2, -4)
        txtStatus.Margin = New Padding(6)
        txtStatus.Multiline = True
        txtStatus.Name = "txtStatus"
        txtStatus.ScrollBars = ScrollBars.Vertical
        txtStatus.Size = New Size(1604, 875)
        txtStatus.TabIndex = 0
        ' 
        ' LocalisationImporter
        ' 
        AutoScaleDimensions = New SizeF(12F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(1600, 865)
        Controls.Add(txtStatus)
        Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(6)
        Name = "LocalisationImporter"
        Text = "Localisation Importer"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents txtStatus As TextBox
End Class
