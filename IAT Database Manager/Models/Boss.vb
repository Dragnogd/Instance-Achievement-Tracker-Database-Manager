Imports IAT_Database_Manager

Public Class Boss
    Public Property BossId As Integer ' Primary Key
    Public Property Order As Integer
    Public Property BossName As String
    Public Property BossNameID As String
    Public Property BossIDs As String
    Public Property AchievementID As Integer
    Public Property Players As String
    Public Property Tactics As String
    Public Property Enabled As Boolean
    Public Property Track As String
    Public Property PartialTrack As String
    Public Property EncounterID As String
    Public Property DisplayInfoFrame As Boolean
    Public Property LocaleText As String
    Public Property LocaleName As String
    Public Property ImgurLink As String
    Public Property HTMLTactics As String
    Public Property Image As String
    Public Property BossNameWrath As String
    Public Property ClassicTactics As String
    Public Property LocaleTextClassic As String
    Public Property LocaleNameClassic As String
    Public Property ImgurLinkClassic As String
    Public Property ImageClassic As String
    Public Property EncounterIDWrath As String

    ' Foreign Keys
    Public Property InstanceId As Integer

    ' Navigation Properties
    Public Overridable Property Instance As Instance
End Class