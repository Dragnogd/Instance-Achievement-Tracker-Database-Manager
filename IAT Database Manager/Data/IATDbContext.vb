Imports Microsoft.EntityFrameworkCore

Public Class IATDbContext
    Inherits DbContext

    Public Property TacticParameters As DbSet(Of TacticParameter)
    Public Property Tactics As DbSet(Of Tactic)
    Public Property Bosses As DbSet(Of Boss)
    Public Property Instances As DbSet(Of Instance)
    Public Property InstanceTypes As DbSet(Of InstanceType)
    Public Property Expansions As DbSet(Of Expansion)
    Public Property Localisations As DbSet(Of Localisation)
    Public Property Translations As DbSet(Of Translation)
    Public Property NPCs As DbSet(Of NPC)
    Public Property Spells As DbSet(Of Spell)
    Public Property Items As DbSet(Of Item)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseLazyLoadingProxies()
        optionsBuilder.UseSqlite("Data Source=IATDatabase.db")
    End Sub
End Class
