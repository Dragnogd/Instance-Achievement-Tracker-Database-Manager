Imports Microsoft.EntityFrameworkCore.ChangeTracking

Public Class Tactic
    ' Primary Key
    Public Property Id As Integer
    ' Expansion the tactic is associated with
    Public Property ExpansionId As Integer
    ' Localse Name for the tactic
    Public Property ImgurLink As String
    ' Image Name
    Public Property ImageName As String
    ' Image Width
    Public Property ImageWidth As Integer
    ' Image Height
    Public Property ImageHeight As Integer

    ' Foreign Key
    Public Property LocalisationId As Integer
    ' Navigation Property
    Public Overridable Property Localisation As Localisation
    Public Overridable Property Boss As Boss
    Public Overridable Property TacticParameter As New ObservableCollectionListSource(Of TacticParameter)()
End Class
