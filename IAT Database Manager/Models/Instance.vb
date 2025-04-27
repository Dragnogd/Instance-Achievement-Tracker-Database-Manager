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

    ' Foreign Keys
    Public Property ExpansionId As Integer
    Public Property InstanceTypeId As Integer

    ' Navigation Properties
    Public Overridable Property Expansion As Expansion
    Public Overridable Property InstanceType As InstanceType

    ' List of bosses inside this instance
    Public Overridable Property Bosses As ObservableCollectionListSource(Of Boss)
End Class