Module Utility
    ''' <summary>
    ''' Sleep with pauses to refresh the application UI
    ''' </summary>
    ''' <param name="iMilliSeconds">Number of milliseconds to sleep for</param>
    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer)
        Dim i As Integer, iHalfSeconds As Integer = iMilliSeconds / 500
        For i = 1 To iHalfSeconds
            Threading.Thread.Sleep(500) : Application.DoEvents()
        Next i
    End Sub

    ''' <summary>
    ''' TODO: Update
    ''' </summary>
    ''' <param name="website"></param>
    Public Sub LoadWebsite(website)
        'Console.WriteLine("Adding site:" & website)
        'PreviousSites.Add(website)
        'CurrentSite = website
        'Dim Address = New Uri(website)
        'WebView2.Source = Address
    End Sub
End Module
