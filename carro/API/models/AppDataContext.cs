using System;
using Microsoft.EntityFrameworkCore;

using API.Models; // Make sure the namespace is correct

public class AppDataContext : DbContext
{
    // Define DbSet for Carro model
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Modelo> Modelos {get; set; }
    // Configure SQLite connection string
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}
