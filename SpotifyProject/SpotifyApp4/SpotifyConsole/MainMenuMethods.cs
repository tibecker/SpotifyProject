using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SpotifyConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotifyConsole
{
    public class MainMenuMethods
    {


        private readonly static string API_PLAYLISTS_URL = "https://api.spotify.com/v1/users/";
        private readonly IRestClient client = new RestClient();
        private Token token = CurrentUserToken.GetToken();

        //To get songs 
        //https://api.spotify.com/v1/playlists/{playlist_id}/tracks
        private readonly static string API_SONGS_URL = "https://api.spotify.com/v1/playlists/";


        public List<Playlist> GetPlaylists(string userid)
        {
            client.Authenticator = new JwtAuthenticator(token.AccessToken);

            RestRequest request = new RestRequest(API_PLAYLISTS_URL + userid + "/playlists");
            IRestResponse<List<Playlist>> response = client.Get<List<Playlist>>(request);
            List<Playlist> listOfPlaylists = new List<Playlist>();

            // Split based on "name" in string
            string myString = response.Content;

            string[] myArray = myString.Split("\"name\" :");
            List<string> myList = myArray.ToList();

            for (int i = 1; i < myList.Count; i ++)
            {
                Playlist playlist = new Playlist();
                string[] tempArray = myArray[i].Split(',');
                playlist.PlaylistTitle = tempArray[0].Substring(2, tempArray[0].Length-3);
                listOfPlaylists.Add(playlist);
            }

            // Add playlistId to each playlist
            myArray = myString.Split("/tracks");

            for (int i = 0; i < listOfPlaylists.Count; i++){
                listOfPlaylists[i].PlaylistId = myArray[i].Substring(myArray[i].Length - 22);
            }

            return listOfPlaylists;

        }


        public List<Song> GetSongs(string playlistId)
        {
            client.Authenticator = new JwtAuthenticator(token.AccessToken);

            RestRequest request = new RestRequest(API_SONGS_URL + playlistId + "/tracks");
            IRestResponse<List<Song>> response = client.Get<List<Song>>(request);
            List<Song> listOfSongs = new List<Song>();

            string myString = response.Content;

            string[] myArray = myString.Split("\"name\" :");
            List<string> myList = myArray.ToList();

            for (int i = 1; i < myList.Count-3; i+=4)
            {
                Song song = new Song();
                string[] tempArray = myArray[i].Split(',');
                song.Artist = tempArray[0].Substring(2, tempArray[0].Length - 3);
                tempArray = myArray[i + 1].Split(',');
                song.Album = tempArray[0].Substring(2, tempArray[0].Length - 3);
                tempArray = myArray[i + 3].Split(',');
                song.Title = tempArray[0].Substring(2, tempArray[0].Length - 3);
                listOfSongs.Add(song);
            }
            return listOfSongs;
        }

        public Playlist CreatePlaylist(string userId)
        {
            Console.Write("Playlist name: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            bool isPublic = false;

            RequestBodyw rb = new RequestBodyw();
            rb.Description = description;
            rb.Name = name;
            rb.Public = isPublic;

            client.Authenticator = new JwtAuthenticator(token.AccessToken);
            RestRequest request = new RestRequest(API_PLAYLISTS_URL + userId + "/playlists");
            request.AddJsonBody(rb);
            IRestResponse<Playlist> response = client.Post<Playlist>(request);

            Playlist playlist = new Playlist();

            string data = response.Content;
            playlist = response.Data;

            return playlist;
        }

    }
}
