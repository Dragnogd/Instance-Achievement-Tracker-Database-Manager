Imports Microsoft.EntityFrameworkCore.ChangeTracking

Public Class InstanceType
    Public Property Id As Integer ' Primary Key
    Public Property Name As String

    ' Foreign Key
    Public Property ExpansionId As Integer
    Public Overridable Property Expansion As Expansion

    ' Navigation Properties
    Public Overridable Property Instances As New ObservableCollectionListSource(Of Instance)()
End Class
