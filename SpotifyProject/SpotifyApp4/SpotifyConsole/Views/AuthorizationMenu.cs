using MenuFramework;
using SpotifyConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyConsole.Views
{
    public class AuthorizationMenu : ConsoleMenu
    {

        private readonly Authorization authorization;

        public AuthorizationMenu(Authorization authorization)
        {
            this.authorization = authorization;

            AddOption("Enter Spotify Username", Login)
                .AddOption("Exit", Exit);
        }

        protected override void OnBeforeShow()
        {
            Console.WriteLine("Welcome! Please enter your Spotify username to get started.");
        }

        // When the user logs in, generate token.
        private MenuOptionResult Login()
        {
            User user = new User();
            CurrentUserToken.SetUser(user);
            user.UserId = GetString("Spotify username: ");

            Token token = authorization.GetAuthorization();
            user.Token = token;

            return new MainMenu().Show();
        }
    }
}
