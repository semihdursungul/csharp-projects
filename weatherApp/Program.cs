using System;
using System.Net;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string apiKey = "YOUR-API-KEY";

        bool searchAgain = true;

        while (searchAgain)
        {
            Console.WriteLine("Enter a city name:");
            string city = Console.ReadLine();

            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(apiUrl);

                    WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);

                    Console.WriteLine($"City: {weatherData.Name}");
                    Console.WriteLine($"Temperature: {weatherData.Main.Temp}°C");
                    Console.WriteLine($"Weather: {weatherData.Weather[0].Description}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Do you want to search for another city? (Y/N)");
            string userInput = Console.ReadLine();

            if (!string.Equals(userInput, "Y", StringComparison.OrdinalIgnoreCase))
            {
                searchAgain = false;
            }
        }
    }
}

class WeatherData
{
    public string Name { get; set; }
    public MainData Main { get; set; }
    public Weather[] Weather { get; set; }
}

class MainData
{
    public float Temp { get; set; }
}

class Weather
{
    public string Description { get; set; }
}
