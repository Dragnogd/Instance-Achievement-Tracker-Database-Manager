Imports Microsoft.EntityFrameworkCore.ChangeTracking

Public Class Expansion
    Public Property Id As Integer ' Primary Key
    Public Property ExpansionGameId As Integer
    Public Property Name As String

    Public Overridable Property InstanceTypes As New ObservableCollectionListSource(Of InstanceType)()
End Class