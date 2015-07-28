#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherNet;
using WeatherNet.Clients;

#endregion

namespace WeatherNetTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCurrentWeatherByCityNameTest()
        {
            //Specifying optional settings
            ClientSettings.ApiUrl = "http://api.openweathermap.org/data/2.5";
            ClientSettings.ApiKey = "1234567890";


            //Exist
            var result = CurrentWeather.GetByCityName("Dublin", "Ireland", "se", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);


            result = CurrentWeather.GetByCityName("Dublin", "Ireland", "nl", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }

        [TestMethod]
        public void GetCurrentCurrentWeatherByCityIdTest()
        {
            //Does not exist
            var result = CurrentWeather.GetByCityId(1111111);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Item);

            //Exist
            result = CurrentWeather.GetByCityId(2964574);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }

        [TestMethod]
        public void GetCurrentCurrentWeatherByCityCoordinatesTest()
        {
            //Does Not Exist
            var result = CurrentWeather.GetByCoordinates(-1984453.363665, -1984453.363665);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Item);

            //Exist
            result = CurrentWeather.GetByCoordinates(53.363665, -6.255541);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);

            result = CurrentWeather.GetByCoordinates(53.363665, -6.255541, "nl", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }


        [TestMethod]
        public void GetFiveDaysForecastByCityNameTest()
        {
            //Does not exist
            var result = FiveDaysForecast.GetByCityName("12345325231432", "32412342134231");
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = FiveDaysForecast.GetByCityName("Dublin", "Ireland");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);

            result = FiveDaysForecast.GetByCityName("Dublin", "Ireland", "de", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetFiveDaysForecastByCityIdTest()
        {
            //Does not exist
            var result = FiveDaysForecast.GetByCityId(-2964574);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = FiveDaysForecast.GetByCityId(2964574);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);

            result = FiveDaysForecast.GetByCityId(2964574, "de", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetFiveDaysForecastByCityCoordinatesTest()
        {
            //Does not exist
            var result = FiveDaysForecast.GetByCoordinates(-1984453.363665, -1984453.363665);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = FiveDaysForecast.GetByCoordinates(53.363665, -6.255541, "se", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }


        [TestMethod]
        public void GetSixteenDaysForecastByCityNameTest()
        {
            //Does not exist
            var result = SixteenDaysForecast.GetByCityName("3AC946DD - 3344 - 423A - AD9A - 8D67B8BF01C5", "3AC946DD - 3344 - 423A - AD9A - 8D67B8BF01C5", 14);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = SixteenDaysForecast.GetByCityName("Dublin", "Ireland", 14);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetSixteenDaysForecastByCityIdTest()
        {
            //Does not exist
            var result = SixteenDaysForecast.GetByCityId(1111111, 5);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = SixteenDaysForecast.GetByCityId(2964574, 14);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetSixteenDaysForecastByCityCoordinatesTest()
        {
            //Does not exist
            var result = SixteenDaysForecast.GetByCoordinates(-1984453.363665, -1984453.363665, 14);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = SixteenDaysForecast.GetByCoordinates(53.363665, -6.255541, 14, "se", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }
    }
}