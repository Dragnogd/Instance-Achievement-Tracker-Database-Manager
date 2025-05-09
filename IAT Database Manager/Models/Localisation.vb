Imports Microsoft.EntityFrameworkCore.ChangeTracking

Public Class Localisation
    ' Primary Key
    Public Property Id As Integer
    Public Property Key As String
    Public Property Value As String

    ' The translations for the localisation string in other languages
    Public Overridable Property Translations As New ObservableCollectionListSource(Of Translation)()
End Class
