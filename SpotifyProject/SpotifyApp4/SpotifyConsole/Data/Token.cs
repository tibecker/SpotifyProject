using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyConsole.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
}
