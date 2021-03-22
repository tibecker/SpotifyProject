using Microsoft.AspNetCore.Mvc;
using SpotifyApp4.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyApp4.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        [HttpPost]
        public Token Authenticate()
        {
            Token token = new Token();
            return token;
        }


    }
}
