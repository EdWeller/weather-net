#region

using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;

#endregion

namespace WeatherNet.Util.Api
{
    /// <summary>
    /// Raw Api client
    /// </summary>
    internal static class ApiClient
    {
        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public static JObject GetResponse(string queryString)
        {
            using (var client = new WebClient())
            {
                var apiKey = ClientSettings.ApiKey;
                var apiUrl = ClientSettings.ApiUrl;
                Trace.WriteLine("<HTTP - GET - " + queryString + " >");

                string url;
                if (!string.IsNullOrEmpty(apiKey))
                    url = apiUrl + queryString + "&APPID=" + apiKey;
                else
                    url = apiUrl + queryString;

                var response = client.DownloadString(url);
                var parsedResponse = JObject.Parse(response);
                return parsedResponse;
            }
        }
    }
}