using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyConsole.Models
{
    public class Playlist
    {
        public string PlaylistId { get; set; }
        public string PlaylistTitle { get; set; }
        public List<Song> ListOfSongs { get; set; }
    }
}
