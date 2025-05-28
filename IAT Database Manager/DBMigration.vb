Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.EntityFrameworkCore.ChangeTracking

Module DBMigration
    ''' <summary>
    ''' Port Expansions from expansionDB.csv
    ''' </summary>
    Public Sub ImportExpansions()
        Using db As New IATDbContext()
            Using reader As New StreamReader("expansionsDB.csv")
                Dim line As String = reader.ReadLine()

                While line IsNot Nothing
                    Dim strArr() As String = line.Split(","c)

                    Dim newExpansion As New Expansion With {
                        .ExpansionGameId = Integer.Parse(strArr(0)),
                        .Name = strArr(1)
                    }

                    db.Expansions.Add(newExpansion)

                    line = reader.ReadLine()
                End While

            End Using

            db.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Port InstanceType code
    ''' </summary>
    Public Sub ImportInstanceTypes()
        Using db As New IATDbContext()

            ' Get all expansions
            Dim allExpansions = db.Expansions.ToList()

            For Each expansion In allExpansions
                ' Always add Raids and Dungeons
                Dim instanceTypes As New List(Of InstanceType) From {
                New InstanceType With {.Name = "Raids", .Expansion = expansion},
                New InstanceType With {.Name = "Dungeons", .Expansion = expansion}
            }

                ' Special case for Expansion 5: add Scenarios
                If expansion.ExpansionGameId = 5 Then
                    instanceTypes.Add(New InstanceType With {.Name = "Scenarios", .Expansion = expansion})
                End If

                ' Special case for Expansion 11: add Delves
                If expansion.ExpansionGameId = 11 Then
                    instanceTypes.Add(New InstanceType With {.Name = "Delves", .Expansion = expansion})
                End If

                db.InstanceTypes.AddRange(instanceTypes)
            Next

            db.SaveChanges()

        End Using
    End Sub

    ''' <summary>
    ''' Port Instances from instanceDB.csv
    ''' </summary>
    Public Sub ImportInstances()
        Using db As New IATDbContext()
            Using reader As New StreamReader("instancesDB.csv")
                Dim line = reader.ReadLine()

                While line IsNot Nothing
                    Dim strArr() As String = line.Split(","c)
                    Dim newInstance As New Instance

                    ' Split InstanceId by the decimal point
                    Dim instanceIdParts As String() = strArr(0).Split("."c)

                    ' Store the first part (before the decimal) as InstanceId
                    newInstance.InstanceId = Integer.Parse(instanceIdParts(0))

                    ' Store the second part (after the decimal) as LegacySize (if it exists)
                    If instanceIdParts.Length > 1 Then
                        newInstance.LegacySize = instanceIdParts(1)
                    End If

                    ' Set the other properties
                    newInstance.Name = strArr(1)
                    newInstance.InstanceNameID = Integer.Parse(strArr(2))

                    ' Optional fields (safe parsing)
                    If strArr.Length > 5 AndAlso Not String.IsNullOrWhiteSpace(strArr(5)) Then
                        newInstance.NameWrath = strArr(5)
                        newInstance.NameWrath = Regex.Replace(newInstance.NameWrath, "^L\[""(.+?)""\]$", "$1")
                    End If
                    If strArr.Length > 6 AndAlso Not String.IsNullOrWhiteSpace(strArr(6)) Then
                        newInstance.ClassicPhase = strArr(6)
                    End If
                    If strArr.Length > 7 AndAlso Not String.IsNullOrWhiteSpace(strArr(7)) Then
                        newInstance.RetailOnly = strArr(7)
                    End If
                    If strArr.Length > 8 AndAlso Not String.IsNullOrWhiteSpace(strArr(8)) Then
                        newInstance.ClassicOnly = strArr(8)
                    End If

                    ' Now link by foreign key:
                    Dim expansionName As String = strArr(3)
                    Dim instanceTypeName As String = strArr(4)

                    ' Find InstanceType
                    Dim instanceType = db.InstanceTypes.FirstOrDefault(Function(it) it.Name = instanceTypeName And it.Expansion.Name = expansionName)
                    If instanceType IsNot Nothing Then
                        newInstance.InstanceType = instanceType
                    Else
                        ' Handle missing instance type (optional)
                        Throw New Exception($"InstanceType '{instanceTypeName}' not found for Instance '{newInstance.Name}'")
                    End If

                    ' Finally add to database
                    db.Instances.Add(newInstance)

                    ' Read next line
                    line = reader.ReadLine()
                End While

                ' Save all to database
                db.SaveChanges()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Port bosses from bossesDB.csv
    ''' </summary>
    Public Sub ImportBosses()
        Using db As New IATDbContext
            Using reader As New StreamReader("bossesDB.csv")
                Dim line = reader.ReadLine()
                Dim bossCounter As Integer = 1

                While line IsNot Nothing
                    If line.Contains(";"c) Then
                        Dim strArr() As String = line.Split(";"c)

                        ' Handle Image
                        Dim Image As New List(Of String)
                        If strArr(14).Length > 0 Then
                            Dim trimmed = strArr(14).Trim("{"c, "}"c)
                            Image = trimmed.Split(","c).Select(Function(s) s.Trim(""""c)).ToList()
                        End If

                        ' Handle Tactics (Retail)
                        Dim tactic As String = strArr(6)

                        ' List of  tactics
                        Dim tacticsList As New ObservableCollectionListSource(Of Tactic)

                        ' If we have paramters for the tactic
                        If tactic.Contains("format(") Then

                            ' Regex to match each "format(...)" call in the string
                            Dim formatMatches = Regex.Matches(tactic, "format\s*\(((?:[^()]+|\((?:[^()]+|\([^()]*\))*\))*)\)")

                            ' Process each format call
                            For Each formatMatch As Match In formatMatches

                                ' Extract localisation key for this tactic
                                Dim keyMatch = Regex.Match(formatMatch.Value, "L\[""(?<key>[^""]+)""\]")
                                Dim localisationKey As String = If(keyMatch.Success, keyMatch.Groups("key").Value, Nothing)
                                Dim localisation As Localisation = db.Localisations.FirstOrDefault(Function(e) e.Key = localisationKey)

                                Dim parameters As New ObservableCollectionListSource(Of TacticParameter)
                                Dim paramsRaw = formatMatch.Groups(1).Value
                                Dim parametersList = paramsRaw.Split(","c).Select(Function(p) p.Trim()).ToList()
                                Dim order As Integer = 1

                                ' Loop through each paramter in the list
                                For Each param As String In parametersList
                                    ' Skip locale string parameters (L["..."])
                                    If param.StartsWith("L[") AndAlso param.EndsWith("]") Then
                                        Continue For
                                    End If

                                    If param.StartsWith("""IAT_") Then
                                        ' NPC parameter
                                        Dim npcId = Regex.Match(param, "\d+").Value
                                        Dim linkedNpc As NPC = db.NPCs.FirstOrDefault(Function(e) e.NPCID = npcId)

                                        parameters.Add(New TacticParameter With {
                                                           .Order = order,
                                                           .ParameterID = npcId,
                                                           .ParameterType = "NPC",
                                                           .NPC = linkedNpc
                                                       })
                                    ElseIf param.Contains("C_Spell.GetSpellLink") Then
                                        ' Spell parameter
                                        Dim spellId = Regex.Match(param, "\d+").Value

                                        parameters.Add(New TacticParameter With {
                                                           .Order = order,
                                                           .ParameterID = spellId,
                                                           .ParameterType = "Spell"
                                                       })
                                    End If

                                    order += 1
                                Next

                                ' Create new tactic
                                tacticsList.Add(New Tactic With {
                                    .ExpansionId = 11,
                                    .ImageName = If(Image.Count > 0, Image(0), Nothing),
                                    .ImageHeight = If(Image.Count > 0, Image(1), Nothing),
                                    .ImageWidth = If(Image.Count > 0, Image(2), Nothing),
                                    .ImgurLink = strArr(13),
                                    .TacticParameter = parameters,
                                    .Localisation = localisation
                                })
                            Next
                        Else
                            ' Tactics has no paramters just a locale string

                            ' Extract localisation key for this tactic
                            Dim keyMatch = Regex.Match(tactic, "L\[""(?<key>[^""]+)""\]")
                            Dim localisationKey As String = If(keyMatch.Success, keyMatch.Groups("key").Value, Nothing)
                            Dim localisation As Localisation = db.Localisations.FirstOrDefault(Function(e) e.Key = localisationKey)

                            tacticsList.Add(New Tactic With {
                                .ExpansionId = 11,
                                .ImageName = If(Image.Count > 0, Image(0), Nothing),
                                .ImageHeight = If(Image.Count > 0, Image(1), Nothing),
                                .ImageWidth = If(Image.Count > 0, Image(2), Nothing),
                                .ImgurLink = strArr(13),
                                .Localisation = localisation
                            })
                        End If

                        ' Handle Tactics (Wrath)
                        Dim tacticWrath As String = strArr(16)

                        ' Extract localisation key
                        Dim keyMatchWrath As Match = Regex.Match(tacticWrath, "L\[""(?<key>[^""]+)""\]")
                        Dim localisationKeyWrath As String = If(keyMatchWrath.Success, keyMatchWrath.Groups("key").Value, Nothing)
                        Dim localisationIdWrath As Integer = Nothing

                        ' Final result list
                        Dim parametersWrath As New ObservableCollectionListSource(Of TacticParameter)

                        If tactic.Contains("format(") Then
                            ' Extract parameters only
                            Dim paramsRaw = Regex.Match(tacticWrath, "format\s*\(.*?,\s*(?<params>.*)\)").Groups("params").Value
                            Dim order As Integer = 1

                            ' Match all IAT_XXXX IDs (NPCs)
                            Dim npcMatches = Regex.Matches(paramsRaw, """IAT_(\d+)""")
                            For Each m As Match In npcMatches
                                parametersWrath.Add(New TacticParameter With {
                                               .Order = order,
                                               .ParameterID = m.Groups(1).Value,
                                               .ParameterType = "NPC"
                                               })
                                order += 1
                            Next

                            ' Match all spell links
                            Dim spellMatches = Regex.Matches(paramsRaw, "C_Spell\.GetSpellLink\((\d+)\)")
                            For Each m As Match In spellMatches
                                parametersWrath.Add(New TacticParameter With {
                                                .Order = order,
                                                .ParameterID = m.Groups(1).Value,
                                                .ParameterType = "Spell"
                                               })
                            Next
                        End If

                        ' Find the localisation id based on the key
                        Dim localisationWrath As Localisation = db.Localisations.FirstOrDefault(Function(e) e.Key = localisationKeyWrath)

                        If strArr.Length > 16 AndAlso Not String.IsNullOrWhiteSpace(strArr(16)) Then
                            tacticsList.Add(New Tactic With {
                                .ExpansionId = 3,
                                .ImageName = If(Image.Count > 0, Image(0), Nothing),
                                .ImageHeight = If(Image.Count > 0, Image(1), Nothing),
                                .ImageWidth = If(Image.Count > 0, Image(2), Nothing),
                                .ImgurLink = strArr(17),
                                .TacticParameter = parametersWrath,
                                .Localisation = localisationWrath})
                        End If

                        Dim encounterIds As String() = strArr(10).Trim("{"c, "}"c).Split(","c).Select(Function(id) id.Trim()).ToArray()

                        ' Handle Boss Name ID
                        ' 1. If a single integer ID then save into BossNameID
                        ' 2. If a array of ints then save into BossNameID and BossNameID2
                        ' 3. If a string then save into BossNameLocale

                        Dim bossNameIDArray As String() = strArr(2).Trim("{"c, "}"c).Split(","c).Select(Function(id) id.Trim()).ToArray()
                        Dim newBossID As Integer = Nothing
                        Dim newBossID2 As Integer = Nothing
                        Dim newBossLocale As String = Nothing

                        If bossNameIDArray.Count = 1 Then
                            ' Either a single int or a localised string
                            If Integer.TryParse(bossNameIDArray(0), New Integer) Then
                                ' It's an int so saved into BossNameID
                                newBossID = bossNameIDArray(0)
                            Else
                                ' It's a string so saved into BossNameLocale
                                newBossLocale = bossNameIDArray(0)
                            End If
                        ElseIf bossNameIDArray.Count = 2 Then
                            ' Two ints so saved into BossNameID and BossNameID2
                            If Integer.TryParse(bossNameIDArray(0), newBossID) AndAlso Integer.TryParse(bossNameIDArray(1), newBossID2) Then
                                ' Both are ints
                                newBossID = bossNameIDArray(0)
                                newBossID2 = bossNameIDArray(1)
                            Else
                                ' Handle error
                                Throw New Exception($"Invalid Boss Name ID format: {strArr(2)}")
                            End If
                        ElseIf bossNameIDArray.Count > 2 Then
                            ' Handle error
                            Throw New Exception($"Invalid Boss Name ID format: {strArr(2)}")
                        End If

                        ' If boss name locale is not populated yet then save to index 15
                        If String.IsNullOrEmpty(newBossLocale) Then
                            newBossLocale = strArr(15)
                        End If

                        ' Clean NewBossLocale
                        newBossLocale = Regex.Replace(newBossLocale, "^L\[""(.+?)""\]$", "$1")

                        Dim newBoss As New Boss With {
                            .BossName = If(strArr(1).Length > 1, strArr(1), $"MISSINGNAME{bossCounter}"),
                            .BossNameLocale = newBossLocale,
                            .Order = Integer.Parse(Regex.Match(strArr(0), "\d+").Value),
                            .Track = strArr(8),
                            .Enabled = If(strArr(7) = "nil", False, Boolean.Parse(strArr(7))),
                            .DisplayInfoFrame = strArr(11),
                            .BossNameID = newBossID,
                            .BossNameID2 = newBossID2,
                            .AchievementID = strArr(4),
                            .EncounterID = If(encounterIds.Length > 0 AndAlso encounterIds(0).Length > 0, encounterIds(0), Nothing),
                            .EncounterID2 = If(encounterIds.Length > 1 AndAlso encounterIds(1).Length > 0, encounterIds(1), Nothing),
                            .BossIDs = strArr(3),
                            .PartialTrack = If(strArr(9).Length = 0 Or strArr(9).ToLower() = "false", False, True),
                            .Tactics = tacticsList
                            }

                        bossCounter += 1

                        ' Find Instance by Name (col 12 is the Instance Name)
                        Dim instanceName As String = strArr(12)
                        Dim instance = db.Instances.FirstOrDefault(Function(inst) inst.Name = instanceName)

                        If instance IsNot Nothing Then
                            ' Link via FK
                            newBoss.InstanceId = instance.Id

                            ' Add boss
                            db.Bosses.Add(newBoss)
                        Else
                            ' Optional: Throw error or skip
                            Throw New Exception($"Instance '{instanceName}' not found for Boss '{newBoss.BossName}'")
                        End If
                    End If

                    ' Next line
                    line = reader.ReadLine()
                End While

                ' Batch Save
                db.SaveChanges()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Port localisation from Localization.enUs.lua
    ''' </summary>
    Public Sub ImportLocalisation()
        Dim lines = File.ReadAllLines("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\Localization.enUS.lua")

        Using db As New IATDbContext()
            For Each line As String In lines
                Dim match As Match = Regex.Match(line, "\[\""(.*?)\""\]\s*=\s*\""(.*?)\""\s*")
                If match.Success Then
                    Dim key As String = match.Groups(1).Value
                    Dim value As String = match.Groups(2).Value

                    db.Localisations.Add(New Localisation With {.Key = key, .Value = value})
                End If
            Next

            db.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Port translations for localisation
    ''' </summary>
    ''' <param name="filePath">eg Localization.frFR.lua"</param>
    ''' <param name="languageCode">e.g frFR</param>
    Public Sub ImportTranslations(filePath As String, languageCode As String)
        ' Read the lines from the given language file (e.g., "Localization.frFR.lua")
        Dim lines = File.ReadAllLines(filePath)

        Using db As New IATDbContext()
            ' Iterate through each line in the localisation file
            For Each line As String In lines
                ' Match lines in the format ["Key"] = "Value"
                Dim match As Match = Regex.Match(line, "\[\""(.*?)\""\]\s*=\s*\""(.*?)\""\s*")
                If match.Success Then
                    Dim key As String = match.Groups(1).Value
                    Dim value As String = match.Groups(2).Value

                    ' Check if the localisation key exists in the Localisations table (English version)
                    Dim masterLocalisation = db.Localisations.FirstOrDefault(Function(l) l.Key = key)

                    ' If the English localisation does not exist, skip this translation
                    If masterLocalisation IsNot Nothing Then
                        ' Add the translation for the other language
                        db.Translations.Add(New Translation With {
                            .Localisation = masterLocalisation,
                            .LanguageCode = languageCode,
                            .Value = value
                        })
                    End If
                End If
            Next

            ' Save changes to the database
            db.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Import npcs from NPCCache.lua
    ''' </summary>
    Public Sub ImportNPCCache()
        Dim lines = File.ReadAllLines("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\NPCCache.lua")

        Using db As New IATDbContext()
            For Each line As String In lines
                ' Match pattern like: [123456] =123456, --Name
                Dim match As Match = Regex.Match(line, "\[(\d+)\]\s*=\s*\d+,\s*--(.+)$")

                If match.Success Then
                    Dim npcId As Integer = Integer.Parse(match.Groups(1).Value)
                    Dim name As String = match.Groups(2).Value.Trim()

                    Dim npc As New NPC With {
                        .NPCID = npcId,
                        .Name = name,
                        .Cache = True
                    }

                    db.NPCs.Add(npc)
                End If
            Next

            db.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Import Item Cache from ItemCache.lua
    ''' </summary>
    Public Sub ImportItemCache()
        Dim lines = File.ReadAllLines("C:\Users\ryanc\Dropbox\InstanceAchievementTracker\ItemCache.lua")

        Using db As New IATDbContext()
            For Each line As String In lines
                ' Match pattern like: [123456] =123456, --Name
                Dim match As Match = Regex.Match(line, "\[(\d+)\]\s*=\s*\d+,\s*--(.+)$")

                If match.Success Then
                    Dim itemId As Integer = Integer.Parse(match.Groups(1).Value)
                    Dim name As String = match.Groups(2).Value.Trim()

                    Dim item As New Item With {
                        .ItemId = itemId,
                        .Name = name
                    }

                    db.Items.Add(item)
                End If
            Next

            db.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Import Spell ID's from SpellIDs.lua
    ''' </summary>
    Public Sub ImportSpellIds()
        Dim lines = File.ReadAllLines("SpellIDs.csv")

        Using db As New IATDbContext()
            For Each line As String In lines
                Dim strArr As String() = line.Split(",")

                Dim spell As New Spell With {
                    .SpellId = strArr(0),
                    .Name = strArr(1)
                }

                db.Spells.Add(spell)
            Next

            db.SaveChanges()
        End Using
    End Sub
End Module
