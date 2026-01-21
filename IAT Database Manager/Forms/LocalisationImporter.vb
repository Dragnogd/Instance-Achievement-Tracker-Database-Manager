Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports Serilog

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

    Private Sub btnAddCustomLocalisation_Click(sender As Object, e As EventArgs) Handles btnAddCustomLocalisation.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtKey.Text) Then
                txtStatus.AppendText(vbNewLine & "Error: Key cannot be empty" & vbNewLine)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtValue.Text) Then
                txtStatus.AppendText(vbNewLine & "Error: Value cannot be empty" & vbNewLine)
                Return
            End If

            Using db As New IATDbContext()
                ' Check if key already exists
                Dim existingLocalisation = db.Localisations.FirstOrDefault(Function(l) l.Key = txtKey.Text)

                If existingLocalisation IsNot Nothing Then
                    ' Update existing
                    existingLocalisation.Value = txtValue.Text
                    existingLocalisation.UploadedToCurseForge = False
                    
                    txtStatus.AppendText(vbNewLine & $"Updated existing localisation: {txtKey.Text}" & vbNewLine)
                    Log.Information("Updated custom UI localisation: {Key}", txtKey.Text)
                Else
                    ' Create new
                    Dim newLocalisation As New Localisation With {
                        .Key = txtKey.Text,
                        .Value = txtValue.Text,
                        .UploadedToCurseForge = False
                    }

                    db.Localisations.Add(newLocalisation)
                    txtStatus.AppendText(vbNewLine & $"Added new custom UI localisation: {txtKey.Text}" & vbNewLine)
                    Log.Information("Added custom UI localisation: {Key}", txtKey.Text)
                End If

                db.SaveChanges()

                ' Clear input fields
                txtKey.Text = ""
                txtValue.Text = ""
                txtKey.Focus()

                txtStatus.AppendText($"Successfully saved. Total localisations: {db.Localisations.Count()}" & vbNewLine)
            End Using

        Catch ex As Exception
            txtStatus.AppendText(vbNewLine & $"Error: {ex.Message}" & vbNewLine)
            Log.Error(ex, "Failed to add custom UI localisation")
        End Try
    End Sub
End Class