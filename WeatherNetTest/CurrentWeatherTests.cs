using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherNet;
using WeatherNet.Clients;
using WeatherNet.Model;

namespace WeatherNetTest
{
    /// <summary>
    /// Summary description for CurrentWeatherTests
    /// </summary>
    [TestClass]
    public class CurrentWeatherTests
    {
        public CurrentWeatherTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            ClientSettings.ApiUrl = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];
            ClientSettings.ApiKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetByCityName_Dublin_ShouldReturnTrue()
        {
            var result = CurrentWeather.GetByCityName("Dublin", "Ireland", Language.Romanian, Units.Metric );
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
            Assert.IsTrue(result.Item.WeatherConditionId > 0, "Weather condition is an integer between 1 and 1000");

        }
    }
}
