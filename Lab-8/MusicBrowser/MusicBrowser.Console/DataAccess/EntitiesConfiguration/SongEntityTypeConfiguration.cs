namespace MusicBrowser.Console.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicBrowser.Console.Domain;

public class SongEntityTypeConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("songs");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnName("song_id");

        builder
            .Property(x => x.Title)
            .HasColumnName("title");

        builder
            .Property(x => x.Duration)
            .HasColumnName("duration");

        builder 
            .Property(x => x.AlbumId)
            .HasColumnName("album_id");
    }
}