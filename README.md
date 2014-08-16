A simple client for [Open Weather Map API] (http://openweathermap.org/) written in .NET C# 4.0

####Features

- OpenWeatherMap Api 2.5

- Search by city name, geographic coordinates or city ID

- Multiple language and units of measure

Types of weather data supported:

- Current weather
- 5 days forecsat (every 3 hours)
- 16 days forecast (daily)



####Usage
```c#
var result =  CurrentWeather.GetByCityName("Stockholm", "Sweden", "en", "metric");
```
Additional usage examples included in the test project.

####Dependencies
* JSON.net

####Nuget package
Available at [https://www.nuget.org/packages/WeatherNet](https://www.nuget.org/packages/WeatherNet)

####License
This bundle is under the MIT license. For the full copyright and license information, please view the LICENSE file that was distributed with this source code.



