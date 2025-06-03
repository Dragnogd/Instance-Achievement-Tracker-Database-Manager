Imports System.Net.Http
Imports System.Text
Imports System.Text.Json
Imports Newtonsoft.Json
Imports Serilog

Public Class CurseForgeClient
    Private ReadOnly _httpClient As HttpClient

    Public Sub New()
        _httpClient = New HttpClient()
        _httpClient.DefaultRequestHeaders.Add("X-Api-Token", Settings.configData("CurseForgeAPIKey"))
    End Sub

    ''' <summary>
    ''' Downloads the localization for a specific project and language from CurseForge.
    ''' The localization is returned as a string in CSV format.
    ''' </summary>
    ''' <param name="projectId"></param>
    ''' <param name="language"></param>
    ''' <returns></returns>
    Public Async Function GetLocalizationAsync(Optional language As String = "enUS") As Task(Of String)
        Dim url As String = $"https://wow.curseforge.com/api/projects/{Settings.configData("CurseForgeProjectID")}/localization/export?lang={language}&export-type=Table&unlocalized=Ignore"
        Dim response As HttpResponseMessage = Await _httpClient.GetAsync(url)
        If response.IsSuccessStatusCode Then
            Return Await response.Content.ReadAsStringAsync()
        Else
            Log.Error($"Error fetching localization: {response.ReasonPhrase} {response.StatusCode}")
        End If
    End Function

    Public Async Function UploadLocalisationAsync(key As String, value As String, Optional language As String = "enUS") As Task(Of String)
        ' Validates the key and value before attempting to upload them
        If String.IsNullOrWhiteSpace(key) OrElse String.IsNullOrWhiteSpace(value) Then
            Log.Warning("Cannot upload localisation: key or value is empty.")
            Return Nothing
        End If

        ' Prepare the data to be uploaded
        Dim projectId = Settings.configData("CurseForgeProjectID")
        Dim url As String = $"https://wow.curseforge.com/api/projects/{projectId}/localization/import"

        ' Escape quotes for Lua string
        Dim keyEscaped = key.Replace("""", "\""")
        Dim valueEscaped = value.Replace("""", "\""")
        Dim luaLine As String = $"L[""{keyEscaped}""] = ""{valueEscaped}"""

        ' Create the payload for the request
        Dim metadataObj = New With {
            .language = language,
            .namespace = "Base Namespace",
            .formatType = "TableAdditions",
            .missing_phrase_handling = "DoNothing"
        }

        Dim options As New JsonSerializerOptions With {
            .PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            .WriteIndented = False
        }

        Dim metadataJson As String = JsonConvert.SerializeObject(metadataObj)

        Using formData As New MultipartFormDataContent()
            formData.Add(New StringContent(metadataJson, Encoding.UTF8, "application/json"), "metadata")
            formData.Add(New StringContent(luaLine, Encoding.UTF8, "text/plain"), "localizations")

            Dim response = Await _httpClient.PostAsync(url, formData)

            If response.IsSuccessStatusCode Then
                Log.Information("Successfully uploaded localisation line.")
                Return True
            Else
                Dim content = Await response.Content.ReadAsStringAsync()
                Log.Error($"Upload failed: {response.StatusCode} {response.ReasonPhrase} - {content}")
                Return False
            End If
        End Using
    End Function
End Class
