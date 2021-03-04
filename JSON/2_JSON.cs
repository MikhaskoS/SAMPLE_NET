using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace JSON
{
    // https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/system-text-json-how-to
    class JSONOptions
    {
        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
            [JsonPropertyName("Wind")]
            public int WindSpeed { get; set; }
        }
        // Использование политики именования свойств JSON
        public class UpperCaseNamingPolicy : JsonNamingPolicy
        {
            public override string ConvertName(string name) =>
                name.ToUpper();
        }

        public static void Demo1()
        {
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.Date = DateTimeOffset.Now;
            weatherForecast.TemperatureCelsius = 15;
            weatherForecast.Summary = "Hot";
            weatherForecast.WindSpeed = 25;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,  // форматированный вывод
            };

            string jsonString =  JsonSerializer.Serialize(weatherForecast, options);

            Console.WriteLine(jsonString);
            //{
            //  "Date": "2020-02-07T22:03:49.2534387+03:00",
            //  "TemperatureCelsius": 15,
            //  "Summary": "Hot",
            //  "Wind": 25                    <------- [JsonPropertyName("Wind")] Применяется при сериализации и десирализации
            //}
        }

        public static void Demo2()
        {
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.Date = DateTimeOffset.Now;
            weatherForecast.TemperatureCelsius = 15;
            weatherForecast.Summary = "Hot";
            weatherForecast.WindSpeed = 25;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  //<--  Использование прописных букв
                WriteIndented = true,  // форматированный вывод
            };

            string jsonString = JsonSerializer.Serialize(weatherForecast, options);

            Console.WriteLine(jsonString);
            //{
            //    "date": "2020-02-07T22:07:45.067907+03:00",
            //    "temperatureCelsius": 15,
            //    "summary": "Hot",
            //    "Wind": 25             < -- обрати внимание
            //}
        }

        public static void Demo3()
        {
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.Date = DateTimeOffset.Now;
            weatherForecast.TemperatureCelsius = 15;
            weatherForecast.Summary = "Hot";
            weatherForecast.WindSpeed = 25;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new UpperCaseNamingPolicy(),  //<--  
                WriteIndented = true,  // форматированный вывод
            };

            string jsonString = JsonSerializer.Serialize(weatherForecast, options);

            Console.WriteLine(jsonString);
            //{
            //  "DATE": "2020-02-07T22:12:22.8316234+03:00",
            //  "TEMPERATURECELSIUS": 15,
            //  "SUMMARY": "Hot", 
            //  "Wind": 25             < -- обрати внимание               
            //}
        }

        public static void Demo4()
        {
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.Date = DateTimeOffset.Now;
            weatherForecast.TemperatureCelsius = 15;
            weatherForecast.Summary = "Hot";
            weatherForecast.WindSpeed = 25;

            var options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,  //<--  верблюжья нотация
                WriteIndented = true,  // форматированный вывод
            };

            string jsonString = JsonSerializer.Serialize(weatherForecast, options);

            Console.WriteLine(jsonString);
            //{
            //     "Date": "2020-02-07T22:16:13.583228+03:00",
            //     "TemperatureCelsius": 15,
            //     "Summary": "Hot",
            //     "Wind": 25
            //}
        }
    }
}
