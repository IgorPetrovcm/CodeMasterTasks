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
            return _context.Albums;
        }

        public async Task<Album> Add(Album album)
        {
            await _context.AddAsync(album);
            await _context.SaveChangesAsync();

            return await _context.Albums.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }


        public async void Delete(Album album)
        {
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Song>> ListSongs(Album album)
        {
            return _context.Songs.Where(x => x.AlbumId == album.Id);
        }

        public async void Delete(Song song)
        {
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }

        public async Task<Song> Add(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return await _context.Songs.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}