Imports Microsoft.Extensions.Configuration
Imports System.IO
Imports System.Text.Json

Public Class Settings
    Private configPath As String = "appsettings.json"
    Private config As IConfigurationRoot
    Public configData As Dictionary(Of String, String)

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtImgurClient.Text = GetValue("ImgurClient")
        txtImgurSecret.Text = GetValue("ImgurSecret")
        txtCurseForgeAPIKey.Text = GetValue("CurseForgeAPIKey")
        txtCurseforgeProjectID.Text = GetValue("CurseForgeProjectID")
    End Sub

    Public Sub LoadConfig()
        Dim builder = New ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory()).
            AddJsonFile(configPath, optional:=True, reloadOnChange:=True)
        config = builder.Build()

        ' Load as Dictionary for editing/saving
        If File.Exists(configPath) Then
            configData = JsonSerializer.Deserialize(Of Dictionary(Of String, String))(File.ReadAllText(configPath))
        Else
            configData = New Dictionary(Of String, String)()
        End If
    End Sub

    Private Function GetValue(key As String) As String
        Return If(config(key), "")
    End Function

    Private Sub SetValue(key As String, value As String)
        If configData.ContainsKey(key) Then
            configData(key) = value
        Else
            configData.Add(key, value)
        End If

        File.WriteAllText(configPath, JsonSerializer.Serialize(configData, New JsonSerializerOptions With {.WriteIndented = True}))
        LoadConfig() ' Reload to refresh IConfiguration
    End Sub

    Private Sub txtCurseForgeAPIKey_TextChanged(sender As Object, e As EventArgs) Handles txtCurseForgeAPIKey.TextChanged
        SetValue("CurseForgeAPIKey", txtCurseForgeAPIKey.Text)
    End Sub

    Private Sub txtImgurSecret_TextChanged(sender As Object, e As EventArgs) Handles txtImgurSecret.TextChanged
        SetValue("ImgurSecret", txtImgurSecret.Text)
    End Sub

    Private Sub txtImgurClient_TextChanged(sender As Object, e As EventArgs) Handles txtImgurClient.TextChanged
        SetValue("ImgurClient", txtImgurClient.Text)
    End Sub

    Private Sub txtCurseforgeProjectID_TextChanged(sender As Object, e As EventArgs) Handles txtCurseforgeProjectID.TextChanged
        SetValue("CurseForgeProjectID", txtCurseforgeProjectID.Text)
    End Sub
End Class
