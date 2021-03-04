using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;


namespace FileStreamSample
{
 /*Библиотека встроена в состав общей платформы .NET Core 3,0 .
Для других целевых платформ установите System.Text.Json пакет NuGet.   Ссылки -> управление пакетами NuGet
Пакет поддерживает:
.NET Standard 2,0 и более поздних версий
.NET Framework 4.7.2 и более поздних версий
.NET Core 2,0, 2,1 и 2,2  */

    class JSON01
    {
        public static void Demo()
        {
            Student student = new Student();
            student.Age = 20;
            student.firstName = "Иван";
            student.lastName = "Иванов";

            SaveAsJSON(student, "json.json");
        }

        public static void SaveAsJSON(Student student, string fileName)
        {
            string json1 = JsonConvert.SerializeObject(student);
            File.WriteAllText(fileName, json1);

            // В Net Core 3.0 это работает иначе   https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/system-text-json-how-to
        }

        public static Student LoadAsJSON(string filename)
        {
            Student res = JsonConvert.DeserializeObject<Student>(File.ReadAllText(filename));

            return res;
        }
    }
}
