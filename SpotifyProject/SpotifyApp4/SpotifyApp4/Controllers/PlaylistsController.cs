using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyApp4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyApp4.Controllers
{
    [Route("v1/users")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {

        // To get a list of user's playlists
        // https://api.spotify.com/v1/users/{user_id}/playlists

        [HttpGet("{user_Id}/playlists")]
        public List<Playlist> GetPlaylists(string userId)
        {
            List<Playlist> listOfPlaylists = new List<Playlist>();
            return listOfPlaylists;
        }



    }
}
