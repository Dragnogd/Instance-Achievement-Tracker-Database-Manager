Public Class TacticParameter
    ' Primary Key
    Public Property Id As Integer
    ' The order of the parameter in the tactic
    Public Property Order As Integer
    ' The id of the parameter
    Public Property ParameterID As Integer
    ' The type of the parameter
    Public Property ParameterType As String

    Public Property NPCId As Integer?
    Public Property TacticId As Integer
    Public Overridable Property NPC As NPC
End Class
