namespace MusicBrowser.Console.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicBrowser.Console.Domain;

public class ApplicationContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Album> Albums => Set<Album>();

    public DbSet<Song> Songs => Set<Song>();

    public ApplicationContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SongEntityTypeConfiguration());
    }
}