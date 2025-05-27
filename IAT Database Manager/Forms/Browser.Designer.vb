<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Browser
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
        wvBrowser = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(wvBrowser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' wvBrowser
        ' 
        wvBrowser.AllowExternalDrop = True
        wvBrowser.CreationProperties = Nothing
        wvBrowser.DefaultBackgroundColor = Color.White
        wvBrowser.Dock = DockStyle.Fill
        wvBrowser.Location = New Point(0, 0)
        wvBrowser.Name = "wvBrowser"
        wvBrowser.Size = New Size(800, 450)
        wvBrowser.Source = New Uri("https://www.google.com", UriKind.Absolute)
        wvBrowser.TabIndex = 0
        wvBrowser.ZoomFactor = 1R
        ' 
        ' Browser
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(wvBrowser)
        Name = "Browser"
        Text = "Browser"
        CType(wvBrowser, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents wvBrowser As Microsoft.Web.WebView2.WinForms.WebView2
End Class
