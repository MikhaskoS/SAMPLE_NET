using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace JSON
{
    /*       https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/system-text-json-how-to
            1. По умолчанию все открытые свойства сериализуются. Можно указать свойства для исключения.
            2  Кодировщик по умолчанию выводит символы, не входящие в набор ASCII, символы, 
               УЧИТЫВАЮЩИЕ формат ASCII, и символы, которые должны быть экранированы в соответствии со спецификацией RFC 8259 JSON.
            3  По умолчанию JSON — минифицированные. JSON можно довольно просто распечатать.
            4. По умолчанию регистр имен JSON соответствует именам .NET. Можно настроить регистр имен JSON.
            5. Обнаружены циклические ссылки и создаются исключения.
            6. В настоящее время поля исключаются (!!!).
     */
    class JSONSample
    {
        public static void Demo1()
        {
            Student student = new Student
            {
                Age = 20,
                firstName = "Иван",
                lastName = "Иванов"
            };

            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;  // путь к исполню файлу

            string jsonString;
            jsonString = JsonSerializer.Serialize(student);
            File.WriteAllText(baseFolder + "\\Demo.json", jsonString);

            // Видим, что поля исключены. Сериализовалось только свойство
            //{ "Age":20}
        }

        public static void Demo2()
        {
            Weather weatherForecast = new Weather
            {
                Date = DateTimeOffset.Now,
                TemperatureCelsius = 15,
                Summary = "Hot",
                SummaryField = "Hello!"
            };

            List<DateTimeOffset> _l = new List<DateTimeOffset>();
            _l.Add(DateTimeOffset.Now);
            _l.Add(DateTimeOffset.UtcNow);

            weatherForecast.DatesAvailable = _l;
            weatherForecast.TemperatureRanges = new Dictionary<string, HighLowTemps>
            {
                { "Cold", new HighLowTemps { High = 10, Low = -10 } },
                { "Hot", new HighLowTemps { High = 60, Low = 20 } }
            };

            weatherForecast.SummaryWords = new string[] { "Cool", "Windy", "Humid" };

            string jsonString;
            jsonString = JsonSerializer.Serialize(weatherForecast);

            Console.WriteLine(jsonString);

            /*{"Date":"2020-02-07T21:38:14.9656713+03:00","TemperatureCelsius":15,"Summary":"Hot","DatesAvailable":["2020-02-07T21:38:15.0045669+03:00","2020-02-07T18:38:15.0046507+00:00"],"TemperatureRanges":{"Cold":{"High":10,"Low":-10},"Hot":{"High":60,"Low":20}},"SummaryWords":["Cool","Windy","Humid"]}*/
        }

        public static void Demo3()
        {
            Weather forecast = new Weather
            {
                Date = DateTimeOffset.Now,
                TemperatureCelsius = 15,
                Summary = "Hot",
                SummaryField = "Hello!"
            };

            List<DateTimeOffset> _l = new List<DateTimeOffset>();
            _l.Add(DateTimeOffset.Now);
            _l.Add(DateTimeOffset.UtcNow);

            forecast.DatesAvailable = _l;
            forecast.TemperatureRanges = new Dictionary<string, HighLowTemps>();
            forecast.TemperatureRanges.Add("Cold", new HighLowTemps { High = 10, Low = -10 });
            forecast.TemperatureRanges.Add("Hot", new HighLowTemps { High = 60, Low = 20 });

            forecast.SummaryWords = new string[] { "Cool", "Windy", "Humid" };

            // Форматированный вывод
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(forecast, options);

            Console.WriteLine(jsonString);
            /*
                        {
                            "Date": "2020-02-07T21:44:12.9377194+03:00",
                            "TemperatureCelsius": 15,
                            "Summary": "Hot",
                            "DatesAvailable": [
                            "2020-02-07T21:44:12.9437107+03:00",
                            "2020-02-07T18:44:12.9437544+00:00"
                            ],
                            "TemperatureRanges": {
                            "Cold": {
                                "High": 10,
                                "Low": -10
                            },
                            "Hot": {
                                "High": 60,
                                "Low": 20
                            }
                            },
                            "SummaryWords": [
                            "Cool",
                            "Windy",
                            "Humid"
                            ]
                        }
            */
        }
    }

    public class Student
    {
        public string firstName;
        public string lastName;

        int age;

        public int Age
        {
            get { return age; }
            set { if (value > 0) age = value; }
        }

    }

    public class Weather
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public string SummaryField;
        public IList<DateTimeOffset> DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
        public string[] SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }
}
