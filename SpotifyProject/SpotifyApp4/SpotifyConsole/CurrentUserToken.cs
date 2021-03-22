using SpotifyConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyConsole
{
    public static class CurrentUserToken
    {
        private static User user = new User();

        public static void SetUser(User u)
        {
            user = u;
        }

        public static Token GetToken()
        {
            return user.Token;
        }

        public static User GetUser()
        {
            return user;
        }

        public static List<Playlist> GetPlaylists()
        {
            return user.UserPlaylists;
        }

    }
}
