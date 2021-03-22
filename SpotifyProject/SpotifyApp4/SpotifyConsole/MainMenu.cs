using MenuFramework;
using SpotifyConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyConsole
{
    public class MainMenu: ConsoleMenu
    {
        MainMenuMethods methods = new MainMenuMethods();
        Authorization authorization = new Authorization();

        public MainMenu()
        {
            AddOption("View your playlists", ViewPlaylists)
                .AddOption("Create new playlist", CreatePlaylist)
                .AddOption("Exit", Exit);
        }

        private MenuOptionResult ViewPlaylists()
        {
            User user = CurrentUserToken.GetUser();

            List<Playlist> playlists = methods.GetPlaylists(user.UserId);

            user.UserPlaylists = playlists;

            //Console.WriteLine($"{user.UserId}'s Playlists");
            //Console.WriteLine();
            //Console.WriteLine();

            //foreach(Playlist p in playlists)
            //{
            //    Console.WriteLine(p.PlaylistTitle);
            //}

            return new PlaylistsMenu().Show();
        }

        private MenuOptionResult CreatePlaylist()
        {
            User user = CurrentUserToken.GetUser();

            Playlist playlist = methods.CreatePlaylist(user.UserId);

            return MenuOptionResult.WaitAfterMenuSelection;
            
        }


    }
}
