namespace MusicBrowser.Console.DataAccess.AdoNet
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MusicBrowser.Console.Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class AdoNetMusicRepository : IMusicRepository
    {
        private readonly string _connectionString;

        private readonly ApplicationContext _context;

        public AdoNetMusicRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> ListAlbums()
        {
            /*List<Album> result = new List<Album>();

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

            return result;*/

            return _context.Albums;
        }

        public async Task<Album> Add(Album album)
        {
            /*int albumId;

            NpgsqlDataSource sqlDataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

            NpgsqlConnection connection = await sqlDataSource.OpenConnectionAsync();

            await using (NpgsqlCommand command = new NpgsqlCommand("insert into albums (title, date) values (@Title, @Date);" + 
                                                    "select album_id from albums order by album_id desc limit 1;", connection))
            {
                command.Parameters.AddWithValue("Title", album.Title);
                command.Parameters.AddWithValue("Date", album.Date);
                albumId = Convert.ToInt32(await command.ExecuteScalarAsync());
            }

            return new Album {
                Id = albumId,
                Title = album.Title,
                Date = album.Date
            };*/

            await _context.AddAsync(album);
            await _context.SaveChangesAsync();

            return await _context.Albums.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }


        public async void Delete(Album album)
        {
            /*NpgsqlDataSource sqlDataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

            NpgsqlConnection connection = await sqlDataSource.OpenConnectionAsync();

            await using (NpgsqlCommand command = new NpgsqlCommand("delete from albums where album_id = @album_id", connection))
            {
                command.Parameters.AddWithValue("album_id", album.Id);
                command.ExecuteNonQuery();
            }*/

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Song>> ListSongs(Album album)
        {
            /*List<Song> result = new List<Song>();

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

            return result;*/

            return _context.Songs;
        }

        public async void Delete(Song song)
        {
            /*NpgsqlDataSource sqlDataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

            NpgsqlConnection connection = await sqlDataSource.OpenConnectionAsync();

            await using (NpgsqlCommand command = new NpgsqlCommand("delete from songs where song_id = @song_id", connection))
            {
                command.Parameters.AddWithValue("song_id", song.Id);
                command.ExecuteNonQuery();
            }*/

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }

        public async Task<Song> Add(Song song)
        {
            /*int songId;

            NpgsqlDataSource sqlDataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

            NpgsqlConnection connection = await sqlDataSource.OpenConnectionAsync();

            await using (NpgsqlCommand command = new NpgsqlCommand("insert into songs (title, duration, album_id) values (@Title, @Duration, @Album_id);" + 
                                                    "select song_id from songs order by song_id desc limit 1;", connection))
            {
                command.Parameters.AddWithValue("Title", song.Title);
                command.Parameters.AddWithValue("Duration", song.Duration);
                command.Parameters.AddWithValue("Album_id", song.Album.Id);
                songId = Convert.ToInt32(await command.ExecuteScalarAsync());
            }

            return new Song {
                Id = songId,
                Title = song.Title,
                Duration = song.Duration,
                Album = song.Album
            };*/

            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return await _context.Songs.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}