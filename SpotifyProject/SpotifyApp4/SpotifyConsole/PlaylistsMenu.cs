using MenuFramework;
using SpotifyConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyConsole
{
    public class PlaylistsMenu: ConsoleMenu
    {
        MainMenuMethods methods = new MainMenuMethods();
        Authorization authorization = new Authorization();

        List<Playlist> listOfPlaylists = CurrentUserToken.GetPlaylists();

        protected override void OnBeforeShow()
        {
            Console.WriteLine();
            foreach (Playlist p in listOfPlaylists)
            {
                Console.WriteLine($"  {p.PlaylistTitle}");
            }
            Console.WriteLine();
            Console.WriteLine("********************************************");
            Console.WriteLine();
        }


        public PlaylistsMenu()
        {
            AddOption("Select Playlist", DisplayTracks)
                .AddOption("Exit", Exit);
        }

        private MenuOptionResult DisplayTracks()
        {
            foreach (Playlist p in listOfPlaylists)
            {
                Console.WriteLine($"  {p.PlaylistTitle}");
            }
            Console.WriteLine();
            Console.Write("Which playlist do you want to view? ");
            Playlist playlist = new Playlist();
            playlist.PlaylistTitle = Console.ReadLine();

            foreach (Playlist pl in listOfPlaylists)
            {
                if (playlist.PlaylistTitle == pl.PlaylistTitle)
                {
                    playlist.PlaylistId = pl.PlaylistId;
                }
            }

            List<Song> listOfSongs = methods.GetSongs(playlist.PlaylistId);

            //Now I have the playlist title, which I have to use to get the playlist

            int counter = 1;

            Console.WriteLine();
            Console.WriteLine("Song");

            foreach(Song s in listOfSongs)
            {
                Console.WriteLine($"{counter}. {s.Title} by {s.Artist}");
                counter++;
            }

            return MenuOptionResult.WaitAfterMenuSelection;
        }

    }
}
