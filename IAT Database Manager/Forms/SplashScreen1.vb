Public NotInheritable Class SplashScreen1

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).
    Public Count As Integer = 0

    Private Delegate Sub UpdateProgressDelegate(ByVal msg As String, ByVal percentage As Integer)
    Private Delegate Sub IncrementCountDelegate()

    Public Sub UpdateProgress(ByVal msg As String, ByVal percentage As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateProgressDelegate(AddressOf UpdateProgress), New Object() {msg, percentage})
        Else
            Me.Label1.Text = msg
            If percentage >= Me.ProgressBar1.Minimum AndAlso percentage <= Me.ProgressBar1.Maximum Then
                Me.ProgressBar1.Value = percentage
            End If
        End If
    End Sub

    Public Sub IncrementCount()
        If Me.InvokeRequired Then
            Me.Invoke(New IncrementCountDelegate(AddressOf IncrementCount), New Object() {})
        Else
            Count += 1
            Me.lblCounter.Text = Count
        End If
    End Sub

    Public Sub ResetCount()
        Count = 0
    End Sub

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            'ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            'ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        'Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        'Copyright.Text = My.Application.Info.Copyright
    End Sub

End Class
