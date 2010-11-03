using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// A utility class to initiate a Tropo session for outbound call, SMS, IM, etc.
    /// </summary>
    public static class TropoCreateSessionExtensions
    {
        // The endpoint for initiating Tropo outbound sessions.
        private const string CREATE_SESSION_URL = "http://api.tropo.com/1.0/sessions?action={0}&token={1}&";

        // The default action command to send the Tropo outbound session API.
        private const string CREATE_SESSION_ACTION = "create";

        public static Stream CreateSession(this Tropo tropo, String token, IDictionary<string, string> parameters)
        {
            // Format the session initiation URL.
            string enpoint = String.Format(CREATE_SESSION_URL, CREATE_SESSION_ACTION, token);

            // Interate over parameters and append to endpoint URL.
            foreach (KeyValuePair<string, string> param in parameters)
            {
                enpoint += param.Key + "=" + param.Value + "&";
            }

            // Set up HTTP request.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(enpoint);
            request.Method = "GET";
            
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.GetResponseStream();
        }

        public static Stream CreateSession(this Tropo tropo, String token)
        {
            // Format the session initiation URL.
            string enpoint = String.Format(CREATE_SESSION_URL, CREATE_SESSION_ACTION, token);

            // Set up HTTP request.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(enpoint);
            request.Method = "GET";

            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.GetResponseStream();
        }
    }
}