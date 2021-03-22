using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyConsole.Models
{
    public class User
    {
        public string UserId { get; set; }
        public Token Token { get; set; }
        public List<Playlist> UserPlaylists { get; set; }
    }
}
