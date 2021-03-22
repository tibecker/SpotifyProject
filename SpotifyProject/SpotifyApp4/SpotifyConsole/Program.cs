using SpotifyConsole.Views;
using System;

namespace SpotifyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Authorization authorization = new Authorization();
            new AuthorizationMenu(authorization).Show();
        }
    }
}
