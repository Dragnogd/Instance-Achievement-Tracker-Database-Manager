Imports Microsoft.EntityFrameworkCore.ChangeTracking

Public Class Expansion
    Public Property ExpansionId As Integer ' Primary Key

    Public Property Name As String

    ' Navigation property
    Public Overridable ReadOnly Property InstanceTypes As New ObservableCollectionListSource(Of InstanceType)()
End Class