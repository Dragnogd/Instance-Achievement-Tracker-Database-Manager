Imports Microsoft.EntityFrameworkCore.ChangeTracking

Public Class Instance
    Public Property Id As Integer ' Primary Key
    Public Property InstanceId As Integer
    Public Property Name As String
    Public Property NameWrath As String
    Public Property InstanceNameID As Integer
    Public Property ClassicPhase As String
    Public Property RetailOnly As Boolean
    Public Property ClassicOnly As Boolean
    Public Property LegacySize As Integer

    ' Foreign key
    Public Property InstanceTypeId As Integer
    Public Overridable Property InstanceType As InstanceType

    ' Navigation properties
    Public Overridable Property Bosses As New ObservableCollectionListSource(Of Boss)()
End Class