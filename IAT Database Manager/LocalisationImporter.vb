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
        Dim localeString As String = ""
        txtStatus.AppendText(vbNewLine & "------------------------------------------------------" & vbNewLine)
        txtStatus.AppendText("Starting Importer for " & language & vbNewLine)
        Dim webClient As New System.Net.WebClient
        webClient.Headers.Add("X-Api-Token", "11a38840-3f8b-4714-bd02-f908bc107611")
        txtStatus.AppendText("Downloading " & language & vbNewLine)
        webClient.Encoding = Encoding.UTF8
        Dim result As String
        result = webClient.DownloadString("https://wow.curseforge.com/api/projects/286675/localization/export?lang=" & language & "&export-type=Table&unlocalized=Ignore")
        txtStatus.AppendText("Download Successful" & vbNewLine)
        txtStatus.AppendText("Creating file" & vbNewLine)
        If File.Exists("Localization." & language & ".lua") Then
            File.Delete("Localization." & language & ".lua")
        End If
        If File.Exists("tmpLocalization." & language & ".lua") Then
            File.Delete("tmpLocalization." & language & ".lua")
        End If
        Using writer As StreamWriter = New StreamWriter("tmpLocalization." & language & ".lua", True, Encoding.UTF8)
            writer.WriteLine(result)
        End Using
        txtStatus.AppendText("File created successfully" & vbNewLine)
        txtStatus.AppendText("Checking for formatting issues" & vbNewLine)
        Dim count = 1
        Dim ErrorFound = False
        Using reader As StreamReader = New StreamReader("tmpLocalization." & language & ".lua")
            Dim line = reader.ReadLine

            While Not line Is Nothing
                If line.Contains("] =") And line.Contains("[""") Then
                    Dim regex As Regex = New Regex("\[(.*?)\]")
                    Dim match As Match = regex.Match(line)
                    Dim Locale = match.Value.Trim("[".ToCharArray()).Trim("]".ToCharArray())

                    Dim LocaleText = line.Split("=")(1).Trim().Trim("""".ToCharArray()).Trim(",").Trim("""")
                    Dim LocaleNameNoReplace = line.Split("=")(0).Trim()
                    Dim LocaleName = line.Split("=")(0).Trim().Replace("[", "").Replace("]", "").Replace("""", "")

                    For Each expansion In frmIATDatabaseManager.CentralDB
                        For Each instancetype In expansion.InstanceTypes
                            For Each instance In instancetype.Instances
                                For Each boss In instance.Bosses
                                    If boss.LocaleName = LocaleName Then
                                        'Run formatting on text to check for errors
                                        Dim PercentFound = False
                                        Dim FormatStringsFound = 0
                                        Dim FormatStringsEnglish = 0
                                        Dim LineError = False

                                        'Count format string in imported localisation
                                        For Each c As Char In LocaleText
                                                If PercentFound Then
                                                    If c = "s" Then
                                                        FormatStringsFound += 1
                                                    ElseIf c <> "%" Then
                                                        txtStatus.AppendText("Parsing error found on line " & count & " (" & LocaleName & ")" & vbNewLine)
                                                        ErrorFound = True
                                                        LineError = True
                                                        Exit For
                                                    End If
                                                    PercentFound = False
                                                ElseIf c = "%" And PercentFound = False Then
                                                    PercentFound = True
                                                End If
                                            Next

                                            'Count lines in english localisation
                                            For Each c As Char In boss.LocaleText
                                                If PercentFound Then
                                                    If c = "s" Then
                                                        FormatStringsEnglish += 1
                                                    End If
                                                    PercentFound = False
                                                ElseIf c = "%" And PercentFound = False Then
                                                    PercentFound = True
                                                End If
                                            Next

                                            If FormatStringsEnglish <> FormatStringsFound Then
                                                txtStatus.AppendText("Formatting Mismatch detected on line " & count & " (" & LocaleName & ")" & vbNewLine)
                                                ErrorFound = True
                                                LineError = True
                                            End If

                                            If LineError = True Then
                                                'Comment out bad line
                                                txtStatus.AppendText("Commenting out line " & count & vbNewLine)
                                                result = result.Replace(LocaleNameNoReplace, "--" & LocaleNameNoReplace)
                                            End If
                                        End If
                                Next
                            Next
                        Next
                    Next
                End If

                If Not line.Contains(vbTab) And count > 5 Then
                    MsgBox("Multi Line Detected. Fix on curseforge: " & line)
                End If

                count += 1
                line = reader.ReadLine
            End While
        End Using

        txtStatus.AppendText("Finished reading file" & vbNewLine)
        txtStatus.AppendText("Preparing file for merge" & vbNewLine)
        Select Case language
            Case "esES"
                result = "if(GetLocale() ~= 'esES') then return end" & vbNewLine & vbNewLine & "local _, core = ..." & vbNewLine & result
                result = result.Replace("L = {", "local baseLocale = {").Replace("\\n", "\n").Replace("[=[", """").Replace("]=]", """")
                result = result & vbNewLine & vbNewLine & "core:RegisterLocale('esES', baseLocale)" & vbNewLine & vbNewLine & "-- core:RegisterLocale('enUS', baseLocale)"
            Case "ruRU"
                result = "if(GetLocale() ~= 'ruRU') then return end" & vbNewLine & vbNewLine & "local _, core = ..." & vbNewLine & result
                result = result.Replace("L = {", "local baseLocale = {").Replace("\\n", "\n").Replace("[=[", """").Replace("]=]", """")
                result = result & vbNewLine & vbNewLine & "core:RegisterLocale('ruRU', baseLocale)" & vbNewLine & vbNewLine & "-- core:RegisterLocale('enUS', baseLocale)"
            Case "deDE"
                result = "if(GetLocale() ~= 'deDE') then return end" & vbNewLine & vbNewLine & "local _, core = ..." & vbNewLine & result
                result = result.Replace("L = {", "local baseLocale = {").Replace("\\n", "\n").Replace("[=[", """").Replace("]=]", """")
                result = result & vbNewLine & vbNewLine & "core:RegisterLocale('deDE', baseLocale)" & vbNewLine & vbNewLine & "-- core:RegisterLocale('enUS', baseLocale)"
            Case "zhCN"
                result = "if(GetLocale() ~= 'zhCN') then return end" & vbNewLine & vbNewLine & "local _, core = ..." & vbNewLine & result
                result = result.Replace("L = {", "local baseLocale = {").Replace("\\n", "\n").Replace("[=[", """").Replace("]=]", """")
                result = result & vbNewLine & vbNewLine & "core:RegisterLocale('zhCN', baseLocale)" & vbNewLine & vbNewLine & "-- core:RegisterLocale('enUS', baseLocale)"
            Case "zhTW"
                result = "if(GetLocale() ~= 'zhTW') then return end" & vbNewLine & vbNewLine & "local _, core = ..." & vbNewLine & result
                result = result.Replace("L = {", "local baseLocale = {").Replace("\\n", "\n").Replace("[=[", """").Replace("]=]", """")
                result = result & vbNewLine & vbNewLine & "core:RegisterLocale('zhTW', baseLocale)" & vbNewLine & vbNewLine & "-- core:RegisterLocale('enUS', baseLocale)"
            Case "frFR"
                result = "if(GetLocale() ~= 'frFR') then return end" & vbNewLine & vbNewLine & "local _, core = ..." & vbNewLine & result
                result = result.Replace("L = {", "local baseLocale = {").Replace("\\n", "\n").Replace("[=[", """").Replace("]=]", """")
                result = result & vbNewLine & vbNewLine & "core:RegisterLocale('frFR', baseLocale)" & vbNewLine & vbNewLine & "-- core:RegisterLocale('enUS', baseLocale)"
            Case "esMX"
                result = "if(GetLocale() ~= 'esMX') then return end" & vbNewLine & vbNewLine & "local _, core = ..." & vbNewLine & result
                result = result.Replace("L = {", "local baseLocale = {").Replace("\\n", "\n").Replace("[=[", """").Replace("]=]", """")
                result = result & vbNewLine & vbNewLine & "core:RegisterLocale('exMX', baseLocale)" & vbNewLine & vbNewLine & "-- core:RegisterLocale('enUS', baseLocale)"
        End Select
        txtStatus.AppendText("File prepared" & vbNewLine)

        'Write to master
        If File.Exists("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization." & language & ".lua") Then
            File.Delete("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization." & language & ".lua")
        End If
        Using writer As StreamWriter = New StreamWriter("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization." & language & ".lua", True, Encoding.UTF8)
            writer.WriteLine(result)
        End Using
        txtStatus.AppendText("Merged into master successfully" & vbNewLine)
        Return localeString
    End Function
End Class