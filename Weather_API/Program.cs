using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Principal;

namespace Weather_API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var key = File.ReadAllText("appsettings.json");
            var defaultKey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            Console.WriteLine("Please enter a city to see current weather information.");
            Console.WriteLine("Example: London, Atlanta, Miami, ect...");
            var userRequest = Console.ReadLine().ToLower();
            var weatherURL = "https://api.openweathermap.org/data/2.5/weather?q=" + userRequest + "&appid=" + defaultKey + "&units=imperial";
            var userResults = client.GetStringAsync(weatherURL).Result;
      
            var userCoordsInfo = JObject.Parse(userResults).GetValue("coord").ToString();
            Coords userCoords = JsonConvert.DeserializeObject<Coords>(userCoordsInfo);

            var userMainWeatherInfo = JObject.Parse(userResults).GetValue("main").ToString();
            MainWeatherInfo userWeather = JsonConvert.DeserializeObject<MainWeatherInfo>(userMainWeatherInfo);

            var userCloudsInfo = JObject.Parse(userResults).GetValue("clouds").ToString();
            CloudsInfo userClouds = JsonConvert.DeserializeObject<CloudsInfo>(userCloudsInfo);

            //var userWindInfo = JObject.Parse(userRequest).GetValue("wind").ToString();
            //WindInfo userWind = JsonConvert.DeserializeObject<WindInfo>(userWindInfo);

            Console.WriteLine($"The main weather info for: {userRequest.ToUpper()}");
            Console.WriteLine($"Coordinates: {userCoords.lat}, {userCoords.lon}");
            Console.WriteLine($"Current temperature is {userWeather.temp} F.");
            Console.WriteLine($"Current humidity is {userWeather.humidity}%.");
            Console.WriteLine($"The high for today is {userWeather.temp_max} F.");
            Console.WriteLine($"The low for today is {userWeather.temp_min} F.");
        
            if (userClouds.all >= 90)
            {
                Console.WriteLine("It is overcast today.");
            }
            else if (userClouds.all < 90 && userClouds.all >= 70)
            {
                Console.WriteLine("It is mostly cloudy today.");
            }
            else if (userClouds.all < 70 && userClouds.all >= 60)
            {
                Console.WriteLine("It is partly sunny today.");
            }
            else if (userClouds.all < 60 && userClouds.all >= 30)
            {
                Console.WriteLine("It is partly cloudy today.");
            }
            else
            {
                Console.WriteLine("It is sunny today.");
            }
        }
    }
}