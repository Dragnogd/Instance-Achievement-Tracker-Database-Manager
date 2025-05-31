Public Class Translation
    ' Primary Key
    Public Property Id As Integer
    ' Language code
    Public Property LanguageCode As String
    ' The translated value
    Public Property Value As String
    ' If the translation is broken
    Public Property IsBroken As Boolean = False
    ' Which localisation this links back to
    Public Property LocalisationId As Integer
    ' Navigation Property
    Public Overridable Property Localisation As Localisation
End Class
