namespace MusicBrowser.Console.DataAccess
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MusicBrowser.Console.Domain;

    public interface IMusicRepository
    {
        Task<IEnumerable<Album>> ListAlbums();

        Task<IEnumerable<Song>> ListSongs(Album album);

        void Delete(Song song);

        void Delete(Album album);

        Task<Song> Add(Song song);

        Task<Album> Add(Album album);
    }
}