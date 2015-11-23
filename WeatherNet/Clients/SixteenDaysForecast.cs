#region

using System;
using WeatherNet.Model;
using WeatherNet.Util.Api;
using WeatherNet.Util.Data;

#endregion

namespace WeatherNet.Clients
{
    /// <summary>
    /// Forecast for 16 days client.
    /// </summary>
    public static class SixteenDaysForecast
    {
        /// <summary>
        ///     Get the daily forecast for a specific city by indicating its 'OpenwWeatherMap' identifier.
        /// </summary>
        /// <param name="id">City 'OpenwWeatherMap' identifier.</param>
        /// <param name="days">Number of days we want the forecast for (from 1 to 15).</param>
        /// <returns>The forecast information.</returns>
        public static Result<SixteenDaysForecastResult> GetByCityId(int id, int days)
        {
            try
            {
                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 15.");
                if (0 > id)
                    return new Result<SixteenDaysForecastResult>(null, false, "City Id must be a positive number.");
                var response = ApiClient.GetResponse("/forecast/daily?id=" + id + "&cnt=" + days);
                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the daily forecast for a specific city by indicating its 'OpenwWeatherMap' identifier, language and units
        ///     (metric or imperial)..
        /// </summary>
        /// <param name="id">City 'OpenwWeatherMap' identifier.</param>
        /// <param name="days">Number of days we want the forecast for (from 1 to 15).</param>
        /// <param name="language">
        ///     The language of the information returned (example: English - en, Russian - ru, Italian - it,
        ///     Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl,
        ///     French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr ,
        ///     Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).
        /// </param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The forecast information.</returns>
        [Obsolete("Use the type safe method GetByCityId(int id, int days, Language language, Units units) instead.")]
        public static Result<SixteenDaysForecastResult> GetByCityId(int id, int days, String language, String units)
        {
            try
            {
                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 16.");
                if (0 > id)
                    return new Result<SixteenDaysForecastResult>(null, false, "City Id must be a positive number.");

                var response =
                    ApiClient.GetResponse("/forecast/daily?id=" + id + "&cnt=" + days + "&lang=" + language + "&units=" +
                                          units);
                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the daily forecast for a specific city by indicating its 'OpenwWeatherMap' identifier, language and units
        ///     (metric or imperial)..
        /// </summary>
        /// <param name="id">City 'OpenwWeatherMap' identifier.</param>
        /// <param name="days">Number of days we want the forecast for (from 1 to 15).</param>
        /// <param name="language">The language of the information returned.</param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The forecast information.</returns>
        public static Result<SixteenDaysForecastResult> GetByCityId(int id, int days, Language language, Units units)
        {
            try
            {
                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 16.");
                if (0 > id)
                    return new Result<SixteenDaysForecastResult>(null, false, "City Id must be a positive number.");

                string queryString = String.Format("/forecast/daily?id={0}&cnt={1}&lang={2}&units={3}", id, days,
                                                    Enumerations.GetEnumDescription(language), Enumerations.GetEnumDescription(units));

                var response = ApiClient.GetResponse(queryString);
                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        /// <summary>
        ///     Get the daily forecast for a specific city by indicating the city and country names.
        /// </summary>
        /// <param name="city">Name of the city.</param>
        /// <param name="country">Country of the city.</param>
        /// <param name="days">Number of days we want the forecast for (from 1 to 15).</param>
        /// <returns>The forecast information.</returns>
        public static Result<SixteenDaysForecastResult> GetByCityName(String city, String country, int days)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city) || String.IsNullOrEmpty(country))
                    return new Result<SixteenDaysForecastResult>(null, false, "City and/or Country cannot be empty.");
                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 16.");

                var response =
                    ApiClient.GetResponse("/forecast/daily?q=" + city + "," + country + "&cnt=" + days);
                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the daily forecast for a specific city by indicating the city, country, language and units (metric or
        ///     imperial).
        /// </summary>
        /// <param name="city">Name of the city.</param>
        /// <param name="country">Country of the city.</param>
        /// <param name="days">Number of days we want the forecast for (from 0 to 14).</param>
        /// <param name="language">
        ///     The language of the information returned (example: English - en, Russian - ru, Italian - it,
        ///     Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl,
        ///     French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr ,
        ///     Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).
        /// </param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The forecast information.</returns>
        [Obsolete("Use the type safe method GetByCityName(String city, String country, int days, Language language, Units units) instead.")]
        public static Result<SixteenDaysForecastResult> GetByCityName(String city, String country, int days, String language,
            String units)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city) || String.IsNullOrEmpty(country))
                    return new Result<SixteenDaysForecastResult>(null, false, "City and/or Country cannot be empty.");
                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 16.");

                var response =
                    ApiClient.GetResponse("/forecast/daily?q=" + city + "," + country + "&cnt=" + days + "&lang=" +
                                          language + "&units=" + units);
                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the daily forecast for a specific city by indicating the city, country, language and units (metric or
        ///     imperial).
        /// </summary>
        /// <param name="city">Name of the city.</param>
        /// <param name="country">Country of the city.</param>
        /// <param name="days">Number of days we want the forecast for (from 0 to 14).</param>
        /// <param name="language">The language of the information returned.</param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The forecast information.</returns>
        public static Result<SixteenDaysForecastResult> GetByCityName(String city, String country, int days, 
                                                                        Language language, Units units)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city) || String.IsNullOrEmpty(country))
                    return new Result<SixteenDaysForecastResult>(null, false, "City and/or Country cannot be empty.");

                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 16.");

                string queryString = String.Format("/forecast/daily?q={0},{1}&cnt={2}&lang={3}&units={4}", city, country, days,
                                                    Enumerations.GetEnumDescription(language), Enumerations.GetEnumDescription(units));

                var response = ApiClient.GetResponse(queryString);

                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> { Items = null, Success = false, Message = ex.Message };
            }
        }


        /// <summary>
        ///     Get the daily forecast for a specific city by indicating its coordinates.
        /// </summary>
        /// <param name="lat">Latitud of the city.</param>
        /// <param name="lon">Longitude of the city.</param>
        /// <param name="days">Number of days we want the forecast for (from 1 to 15).</param>
        /// <returns>The forecast information.</returns>
        public static Result<SixteenDaysForecastResult> GetByCoordinates(double lat, double lon, int days)
        {
            try
            {
                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 15.");
                var response =
                    ApiClient.GetResponse("/forecast/daily?lat=" + lat + "&lon=" + lon + "&cnt=" + days);
                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the daily forecast for a specific city by indicating its coordinates, language and units (metric or imperial).
        /// </summary>
        /// <param name="lat">Latitud of the city.</param>
        /// <param name="lon">Longitude of the city.</param>
        /// <param name="days">Number of days we want the forecast for (from 0 to 14).</param>
        /// <param name="language">
        ///     The language of the information returned (example: English - en, Russian - ru, Italian - it,
        ///     Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl,
        ///     French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr ,
        ///     Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).
        /// </param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The forecast information.</returns>
        [Obsolete("Use the type safe method GetByCoordinates(double lat, double lon, int days, Language language, Units units) instead.")]
        public static Result<SixteenDaysForecastResult> GetByCoordinates(double lat, double lon, int days, String language, String units)
        {
            try
            {
                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 16.");

                var response =
                    ApiClient.GetResponse("/forecast/daily?lat=" + lat + "&lon=" + lon + "&cnt=" + days + "&lang=" +
                                          language + "&units=" + units);
                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> {Items = null, Success = false, Message = ex.Message};
            }
        }

        /// <summary>
        ///     Get the daily forecast for a specific city by indicating its coordinates, language and units (metric or imperial).
        /// </summary>
        /// <param name="lat">Latitud of the city.</param>
        /// <param name="lon">Longitude of the city.</param>
        /// <param name="days">Number of days we want the forecast for (from 1 to 15).</param>
        /// <param name="language">The language of the information returned.</param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The forecast information.</returns>
        public static Result<SixteenDaysForecastResult> GetByCoordinates(double lat, double lon, int days, Language language, Units units)
        {
            try
            {
                if (0 > days || days > 16)
                    return new Result<SixteenDaysForecastResult>(null, false, "Days must be a value between 1 and 16.");

                string queryString = String.Format("/forecast/daily?lat={0}&lon={1}&cnt={2}&lang={3}&units={4}", lat, lon, days,
                                                   Enumerations.GetEnumDescription(language), Enumerations.GetEnumDescription(units));

                var response = ApiClient.GetResponse(queryString);
                return Deserializer.GetWeatherDaily(response);
            }
            catch (Exception ex)
            {
                return new Result<SixteenDaysForecastResult> { Items = null, Success = false, Message = ex.Message };
            }
        }
    }
}