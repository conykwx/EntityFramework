using GamesApp;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-9K56BQI\\SQLEXPRESS;Database=GamesDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
