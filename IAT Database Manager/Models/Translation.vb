Public Class Translation
    ' Primary Key
    Public Property Id As Integer
    ' Language code
    Public Property LanguageCode As String
    Public Property Value As String
    ' Which localisation this links back to
    Public Property LocalisationId As Integer
    ' Navigation Property
    Public Overridable Property Localisation As Localisation
End Class
