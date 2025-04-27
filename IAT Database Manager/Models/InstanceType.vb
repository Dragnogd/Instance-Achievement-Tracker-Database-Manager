Imports Microsoft.EntityFrameworkCore.ChangeTracking

Public Class InstanceType
    Public Property InstanceTypeId As Integer ' Primary Key

    Public Property Name As String

    ' Foreign Key
    Public Property ExpansionId As Integer

    ' Navigation property
    Public Property Expansion As Expansion

    ' Navigation property
    Public Overridable Property Instances As New ObservableCollectionListSource(Of Instance)
End Class
