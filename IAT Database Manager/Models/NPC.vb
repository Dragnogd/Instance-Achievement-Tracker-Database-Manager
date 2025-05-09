Public Class NPC
    ' Primary Key
    Public Property Id As Integer
    ' NPC ID
    Public Property NPCID As Integer
    ' The user friendly name of the NPC
    Public Property Name As String
    ' Whether we are caching the NPC in client
    Public Property Cache As Boolean = False
End Class