Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class LocalisationImporter
    Public Sub Import()
        CheckLanguage("esES")
        CheckLanguage("deDE")
        CheckLanguage("ruRU")
        CheckLanguage("zhCN")
        CheckLanguage("zhTW")
        CheckLanguage("frFR")
        CheckLanguage("esMX")
    End Sub

    Public Function CheckLanguage(language As String)
        'Dim localeString As String = ""
        'txtStatus.AppendText(vbNewLine & "------------------------------------------------------" & vbNewLine)
        'txtStatus.AppendText("Starting Importer for " & language & vbNewLine)
        'Dim webClient As New System.Net.WebClient
        'webClient.Headers.Add("X-Api-Token", "11a38840-3f8b-4714-bd02-f908bc107611")
        'txtStatus.AppendText("Downloading " & language & vbNewLine)
        'webClient.Encoding = Encoding.UTF8
        'Dim result As String
        'result = webClient.DownloadString("https://wow.curseforge.com/api/projects/286675/localization/export?lang=" & language & "&export-type=Table&unlocalized=Ignore")
    End Function

End Class