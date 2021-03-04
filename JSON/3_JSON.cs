using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace JSON
{
    //По умолчанию перечисления сериализуются как числа. 
    //Чтобы сериализовать имена перечислений как строки, используйте JsonStringEnumConverter.
    class JSONEnum
    {
        public class WeatherForecastWithEnum
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public Summary Summary { get; set; }
        }

        public enum Summary
        {
            Cold, Cool, Warm, Hot
        }

        public static void Demo1()
        {
            WeatherForecastWithEnum weatherForecast = new WeatherForecastWithEnum();
            weatherForecast.Date = DateTimeOffset.Now;
            weatherForecast.TemperatureCelsius = 15;
            weatherForecast.Summary = Summary.Hot;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,  // форматированный вывод
                
            };

            string jsonString = JsonSerializer.Serialize(weatherForecast, options);

            Console.WriteLine(jsonString);

            //{
            //  "Date": "2020-02-07T23:49:15.2302079+03:00",
            //  "TemperatureCelsius": 15,
            //  "Summary": 3                  < --
            //}
        }

        public static void Demo2()
        {
            WeatherForecastWithEnum weatherForecast = new WeatherForecastWithEnum();
            weatherForecast.Date = DateTimeOffset.Now;
            weatherForecast.TemperatureCelsius = 15;
            weatherForecast.Summary = Summary.Hot;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,  // форматированный вывод
            };
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));    //   < --


            string jsonString = JsonSerializer.Serialize(weatherForecast, options);

            Console.WriteLine(jsonString);

            //{
            //  "Date": "2020-02-07T23:54:08.2349892+03:00",
            //  "TemperatureCelsius": 15,
            //  "Summary": "hot"              < --
            //}
        }
    }
}
