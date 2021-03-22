using RestSharp;
using RestSharp.Authenticators;
using SpotifyConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyConsole
{
    public class Authorization
    {
        // Use Authorization Code Flow 
        // Used for applications in which the user grants permission only once
        // Provides an access token that can be refreshed


        //********************************//
        // 1. Have your application request authorization; the user logs in and authorizes access

        private readonly static string API_AUTHORIZE = "https://accounts.spotify.com/api/token";
        private readonly static string CLIENT_ID = "99f1e1f990ab4852b3ec040d3e99c621";
        private readonly static string CLIENT_PRIVATE_ID = "fabd0379798c4a85956362a934c63dd1";
        private readonly static string GRANT_TYPE = "client_credentials";
        private readonly static string ADD_PARAMETER = $"grant_type={GRANT_TYPE}&client_id={CLIENT_ID}&client_secret={CLIENT_PRIVATE_ID}";
        private readonly IRestClient client = new RestClient();

        public Token GetAuthorization()
        {
            // Return a token containing access_token, token_type, and expiration
            Token token = new Token();

            // The endpoint for the post request
            RestRequest request = new RestRequest(API_AUTHORIZE);

            // In the request body, include a parameter of grant_type which is set to client_credentials
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", ADD_PARAMETER, ParameterType.RequestBody);


            // Return a token
            IRestResponse<Token> response = client.Post<Token>(request);

            token = response.Data;
            return token;
        }




    }
}
