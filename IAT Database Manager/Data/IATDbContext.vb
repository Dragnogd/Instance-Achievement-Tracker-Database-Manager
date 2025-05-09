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

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseLazyLoadingProxies()
        optionsBuilder.UseSqlite("Data Source=IATDatabase.db")
    End Sub

    'Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
    '    modelBuilder.Entity(Of Expansion)() _
    '        .WithMany(Function(e) e.InstanceTypes) _
    '        .HasForeignKey(Function(it) it.ExpansionGameId)

    '    modelBuilder.Entity(Of Instance)() _
    '        .HasOne(Function(i) i.InstanceType) _
    '        .WithMany(Function(it) it.Instances) _
    '        .HasForeignKey(Function(i) i.InstanceTypeID)

    '    modelBuilder.Entity(Of InstanceType)() _
    '        .HasOne(Function(it) it.Expansion) _
    '        .WithMany(Function(e) e.InstanceTypes) _
    '        .HasForeignKey(Function(it) it.ExpansionGameId)
    'End Sub
End Class
