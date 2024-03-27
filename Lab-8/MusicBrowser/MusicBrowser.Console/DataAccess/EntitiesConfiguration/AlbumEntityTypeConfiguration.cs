namespace MusicBrowser.Console.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicBrowser.Console.Domain;

public class AlbumEntityTypeConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable("albums");

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Songs)
            .WithOne(x => x.Album)
            .HasForeignKey(x => x.AlbumId);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnName("album_id");

        builder 
            .Property(x => x.Title)
            .HasColumnName("title");

        builder
            .Property(x => x.Date)
            .HasColumnName("date");
    }
}