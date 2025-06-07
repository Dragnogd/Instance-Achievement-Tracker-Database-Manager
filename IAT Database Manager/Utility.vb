Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Xml

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

    Public Function ReplaceFirst(input As String, search As String, replace As String) As String
        Dim pos = input.IndexOf(search)
        If pos < 0 Then Return input
        Return input.Substring(0, pos) & replace & input.Substring(pos + search.Length)
    End Function

    Public Function GetWowheadPatchForNPC(npcID As Integer) As String
        Try
            Dim url As String = $"https://www.wowhead.com/npc={npcID}"
            Using client As New WebClient()
                client.Headers(HttpRequestHeader.UserAgent) = "Mozilla/5.0"
                Dim html As String = client.DownloadString(url)

                ' 1) Find the start of the acronym tag
                Dim openTag As String = "[acronym"
                Dim startIdx As Integer = html.IndexOf(openTag, StringComparison.OrdinalIgnoreCase)
                If startIdx < 0 Then Return "Unknown"

                ' 2) Find the closing ']' of that tag
                Dim bracketCloseIdx As Integer = html.IndexOf("]", startIdx)
                If bracketCloseIdx < 0 Then Return "Unknown"

                ' 3) Look for both possible closing tags: "[/acronym]" or "[\/acronym]"
                Dim closeTag1 As String = "[/acronym]"
                Dim closeTag2 As String = "[\/acronym]"

                Dim endIdx As Integer = html.IndexOf(closeTag1, bracketCloseIdx + 1, StringComparison.OrdinalIgnoreCase)
                If endIdx < 0 Then
                    endIdx = html.IndexOf(closeTag2, bracketCloseIdx + 1, StringComparison.OrdinalIgnoreCase)
                    If endIdx < 0 Then Return "Unknown"
                End If

                ' 4) Extract everything between the ']' and the start of the closing tag
                Dim contentStart As Integer = bracketCloseIdx + 1
                Dim length As Integer = endIdx - contentStart
                If length <= 0 Then Return "Unknown"

                Dim patch As String = html.Substring(contentStart, length).Trim()
                Return patch

                Return "Unknown"
            End Using
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
End Module
