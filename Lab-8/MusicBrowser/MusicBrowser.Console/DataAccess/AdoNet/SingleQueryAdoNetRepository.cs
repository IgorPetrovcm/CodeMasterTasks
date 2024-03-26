namespace MusicBrowser.Console.DataAccess.AdoNet;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MusicBrowser.Console.Domain;
using Npgsql;

public class SingleQueryAdoNetRepository : IMusicRepository
{
    private readonly string _connectionString;

    public SingleQueryAdoNetRepository(string connectionString)
    {
        _connectionString = connectionString;   
    }

    public async Task<Album> Add(Album album)
    {
        int albumId;

        NpgsqlDataSource sqlDataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        NpgsqlConnection connection = await sqlDataSource.OpenConnectionAsync();

        await using (NpgsqlCommand command = new NpgsqlCommand("insert into albums (title, date) values (@Title, @Date);" + 
                                                    "select album_id from albums order by album_id desc limit 1;", connection))
        {
            command.Parameters.AddWithValue("Title", album.Title);
            command.Parameters.AddWithValue("Date", album.Date);
            albumId = Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        return new Album(){
            Id = albumId,
            Title = album.Title,
            Date = album.Date
        };
    }

    public Song Add(Song song)
    {
        throw new System.NotImplementedException();
    }


    public void Delete(Song song)
    {
        throw new System.NotImplementedException();
    }

    public void Delete(Album album)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<Album>> ListAlbums()
    {
        List<Album> result = new List<Album>();

        NpgsqlDataSource sqlDataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        NpgsqlConnection connection = await sqlDataSource.OpenConnectionAsync();

        await using (NpgsqlCommand command = new NpgsqlCommand("select title, date, album_id from albums", connection))
        {
            await using (NpgsqlDataReader dataReader = await command.ExecuteReaderAsync())
            {
                while (dataReader.Read())
                {
                    result.Add( new Album {
                        Title = dataReader.GetString(0),
                        Date = dataReader.GetDateTime(1),
                        Id = dataReader.GetInt32(2)
                    });
                }
            }
        }

        return result;
    }

    public async Task<IEnumerable<Song>> ListSongs(Album album)
    {
        List<Song> result = new List<Song>();

        NpgsqlDataSource sqlDataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        NpgsqlConnection connection = await sqlDataSource.OpenConnectionAsync();

        await using (NpgsqlCommand command = new NpgsqlCommand("select songs.title, duration, songs.album_id, song_id from songs " +
                                                                "join albums on albums.album_id = songs.album_id " + 
                                                                "where albums.album_id = @album_id", connection))
        {
            command.Parameters.AddWithValue("album_id", album.Id);

            await using (NpgsqlDataReader dataReader = await command.ExecuteReaderAsync())
            {
                while (dataReader.Read())
                {
                    result.Add( new Song {
                        Id = dataReader.GetInt32(3),
                        Album = album,
                        Title = dataReader.GetString(0),
                        Duration = dataReader.GetTimeSpan(1)
                    });
                }
            }
        }

        return result;
    }
}