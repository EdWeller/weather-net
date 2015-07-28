#region

using System;
using WeatherNet.Model;
using WeatherNet.Util.Api;
using WeatherNet.Util.Data;

#endregion

namespace WeatherNet.Clients
{
    public static class FiveDaysForecast
    {

        /// <summary>
        ///     Get the forecast for a specificcity by indicating its 'OpenwWeatherMap' identifier.
        /// </summary>
        /// <param name="id">City 'OpenwWeatherMap' identifier.</param>
        /// <returns> The forecast information.</returns>
        public static Result<FiveDaysForecastResult> GetByCityId(int id)
        {
            try
            {
                if (0 > id) return new Result<FiveDaysForecastResult>(null, false, "City Id must be a positive number.");
                var response = ApiClient.GetResponse("/forecast?id=" + id);
                return Deserializer.GetWeatherForecast(response);
            }
            catch (Exception ex)
            {
                return new Result<FiveDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the forecast for a specificcity by indicating its 'OpenwWeatherMap' identifier, language and units (metric or imperial).
        /// </summary>
        /// <param name="id">City 'OpenwWeatherMap' identifier.</param>
        /// <param name="language">The language of the information returned (example: English - en, Russian - ru, Italian - it, Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl, French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr , Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).</param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns> The forecast information.</returns>
        public static Result<FiveDaysForecastResult> GetByCityId(int id, String language, String units)
        {
            try
            {
                if (0 > id) return new Result<FiveDaysForecastResult>(null, false, "City Id must be a positive number.");
                var response = ApiClient.GetResponse("/forecast?id=" + id + "&lang=" + language + "&units=" + units);
                return Deserializer.GetWeatherForecast(response);
            }
            catch (Exception ex)
            {
                return new Result<FiveDaysForecastResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        /// <summary>
        ///     Get the forecast for a specific city by indicating the city and country names.
        /// </summary>
        /// <param name="city">Name of the city.</param>
        /// <param name="country">Country of the city.</param>
        /// <returns> The forecast information.</returns>
        public static Result<FiveDaysForecastResult> GetByCityName(String city, String country)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city) || String.IsNullOrEmpty(country))
                    return new Result<FiveDaysForecastResult>(null, false, "City and/or Country cannot be empty.");
                var response = ApiClient.GetResponse("/forecast?q=" + city + "," + country);

                return Deserializer.GetWeatherForecast(response);
            }
            catch (Exception ex)
            {
                return new Result<FiveDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the forecast for a specific city by indicating the city, country, language and units (metric or imperial).
        /// </summary>
        /// <param name="city">Name of the city.</param>
        /// <param name="country">Country of the city.</param>
        /// <param name="language">The language of the information returned (example: English - en, Russian - ru, Italian - it, Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl, French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr , Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).</param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns> The forecast information.</returns>
        public static Result<FiveDaysForecastResult> GetByCityName(String city, String country, String language, String units)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city) || String.IsNullOrEmpty(country))
                    return new Result<FiveDaysForecastResult>(null, false, "City and/or Country cannot be empty.");
                var response = ApiClient.GetResponse("/forecast?q=" + city + "," + country + "&lang=" + language + "&units=" + units);

                return Deserializer.GetWeatherForecast(response);
            }
            catch (Exception ex)
            {
                return new Result<FiveDaysForecastResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        /// <summary>
        ///     Get the forecast for a specificcity by indicating its coordinates.
        /// </summary>
        /// <param name="lat">Latitud of the city.</param>
        /// <param name="lon">Longitude of the city.</param>
        /// <returns> The forecast information.</returns>
        public static Result<FiveDaysForecastResult> GetByCoordinates(double lat, double lon)
        {
            try
            {
                var latString = lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
                var lonString = lon.ToString(System.Globalization.CultureInfo.InvariantCulture);
                var response = ApiClient.GetResponse("/forecast?lat=" + latString + "&lon=" + lonString);
                return Deserializer.GetWeatherForecast(response);
            }
            catch (Exception ex)
            {
                return new Result<FiveDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the forecast for a specificcity by indicating its coordinates, language and units (metric or imperial).
        /// </summary>
        /// <param name="lat">Latitud of the city.</param>
        /// <param name="lon">Longitude of the city.</param>
        /// <param name="language">The language of the information returned (example: English - en, Russian - ru, Italian - it, Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl, French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr , Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).</param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns> The forecast information.</returns>
        public static Result<FiveDaysForecastResult> GetByCoordinates(double lat, double lon, String language, String units)
        {
            try
            {
                var latString = lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
                var lonString = lon.ToString(System.Globalization.CultureInfo.InvariantCulture);
                var response = ApiClient.GetResponse("/forecast?lat=" + latString + "&lon=" + lonString + "&lang=" + language + "&units=" + units);
                return Deserializer.GetWeatherForecast(response);
            }
            catch (Exception ex)
            {
                return new Result<FiveDaysForecastResult> { Items = null, Success = false, Message = ex.Message };
            }
        }
    }
}
