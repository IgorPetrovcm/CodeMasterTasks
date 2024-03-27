namespace MusicBrowser.Console.Domain
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<Song> Songs { get; set; }
    }
}
