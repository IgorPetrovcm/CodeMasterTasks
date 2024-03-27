namespace MusicBrowser.Console.Domain
{
    using System;

    public sealed class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public int AlbumId { get; set;}

        public Album Album { get; set; }
    }
}
