Imports Microsoft.EntityFrameworkCore

Public Class IATDbContext
    Inherits DbContext

    Public Property Bosses As DbSet(Of Boss)
    Public Property Instances As DbSet(Of Instance)
    Public Property InstanceTypes As DbSet(Of InstanceType)
    Public Property Expansions As DbSet(Of Expansion)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlite("Data Source=IATDatabase.db")
    End Sub
End Class
