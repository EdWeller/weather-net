using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WeatherNet
{
    /// <summary>
    /// Settings for all clients.
    /// </summary>
    public static class ClientSettings
    {

        /// <summary>
        /// The API key
        /// </summary>
        public static string ApiKey = null;
        /// <summary>
        /// The API URL
        /// </summary>
        public static string ApiUrl = "http://api.openweathermap.org/data/2.5";

        /// <summary>
        /// Sets the API key.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public static void SetApiKey(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Sets the API URL.
        /// </summary>
        /// <param name="apiUrl">The API URL.</param>
        public static void SetApiUrl(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

    }
}
