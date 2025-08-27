using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Domain;


namespace PruebaTecnica.Api.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<Cliente> Clientes => Set<Cliente>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Índices útiles
        modelBuilder.Entity<Cliente>()
        .HasIndex(c => c.Email)
        .HasFilter("[Email] IS NOT NULL")
        .HasDatabaseName("IX_Cliente_Email");
    }
}