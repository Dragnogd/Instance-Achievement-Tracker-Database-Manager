Public Class NPC
    ' Primary Key
    Public Property Id As Integer
    ' NPC ID
    Public Property NPCId As Integer
    ' The user friendly name of the NPC
    Public Property Name As String
    ' Which expansion the npc was added in
    Public Property ExpansionId As Integer = 0
    ' Whether we are caching the NPC in client
    Public Property Cache As Boolean = False
End Class