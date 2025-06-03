<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen1
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen1))
        ProgressBar1 = New ProgressBar()
        Label1 = New Label()
        lblCounter = New Label()
        SuspendLayout()
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(-2, 383)
        ProgressBar1.Margin = New Padding(4, 3, 4, 3)
        ProgressBar1.Maximum = 13
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(583, 39)
        ProgressBar1.Step = 9
        ProgressBar1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Black
        Label1.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(0, 352)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(93, 24)
        Label1.TabIndex = 1
        Label1.Text = "Loading..."
        ' 
        ' lblCounter
        ' 
        lblCounter.AutoSize = True
        lblCounter.BackColor = Color.Black
        lblCounter.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCounter.ForeColor = Color.White
        lblCounter.Location = New Point(472, 352)
        lblCounter.Margin = New Padding(4, 0, 4, 0)
        lblCounter.Name = "lblCounter"
        lblCounter.Size = New Size(93, 24)
        lblCounter.TabIndex = 2
        lblCounter.Text = "Loading..."
        ' 
        ' SplashScreen1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(579, 422)
        ControlBox = False
        Controls.Add(lblCounter)
        Controls.Add(Label1)
        Controls.Add(ProgressBar1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "SplashScreen1"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCounter As Label
End Class
