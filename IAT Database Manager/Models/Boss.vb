Imports IAT_Database_Manager
Imports Microsoft.EntityFrameworkCore.ChangeTracking

Public Class Boss
    ' Primary Key
    Public Property Id As Integer
    ' The order of the boss in the instance.
    Public Property Order As Integer
    ' The user friendly name of the boss
    Public Property BossName As String
    ' The localised boss name id
    Public Property BossNameID As Integer
    ' The localised boss name id 2
    Public Property BossNameID2 As Integer
    ' Boss name localised when no ID present or tracking for non boss
    Public Property BossNameLocale As String
    ' The NPC ID of the boss
    Public Property BossIDs As String
    ' The ID of the achievement associated with the boss
    Public Property AchievementID As Integer
    ' Whether tracking is enabled
    Public Property Enabled As Boolean
    ' The tracking function
    Public Property Track As String
    ' Whether the tracking is only partial
    Public Property PartialTrack As Boolean
    ' The ID that triggers the start of the boss encounter
    Public Property EncounterID As Integer
    ' The ID that triggers the start of the boss encounter where seperate alliance/horde versions of boss
    Public Property EncounterID2 As Integer
    ' Whether to display the InfoFrame
    Public Property DisplayInfoFrame As Boolean

    ' Foreign Keys
    Public Property InstanceId As Integer

    ' Navigation Properties
    Public Overridable Property Instance As Instance
    ' Tactics for the boss for all game versions as well as revised tactics for newer patches
    Public Overridable Property Tactics As New ObservableCollectionListSource(Of Tactic)()
End Class