using System;
using System.IO;
using System.Text;
using System.Linq;

namespace FileStreamSample
{
    class FileSimple
    {
        // упрощенные (сокращенный) медоты работы с файлами
        //Следующие статические методы читают целый файл в память за один шаг: 
        //• File.ReadAllText(возвращает строку); 
        //• File.ReadAllLines(возвращает массив строк); 
        //• File.ReadAllBytes(возвращает байтовый массив). 
        //Приведенные ниже статические методы записывают целый файл за один шаг:
        //• File.WriteAllText;
        //• File.WriteAllLines;
        //• File.WriteAllBytes; 
        //• File.AppendAllText(удобен для добавления данных в журнальный файл).
        public static void Demo()
        {
            System.IO.DirectoryInfo df2 = new System.IO.DirectoryInfo("..\\..\\Stream");
            // путь к фйлу
            string filePath = Path.Combine(df2.FullName, "MyFile.txt");

            // Если файл не сущществует, создадим его
            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(filePath, createText, Encoding.UTF8);
            }

            string appendText = "This is extra text" + Environment.NewLine;
            File.AppendAllText(filePath, appendText, Encoding.UTF8);

            string readText = File.ReadAllText(filePath);
            Console.WriteLine(readText);

            // Есть также статический метод по имени File.ReadLines: 
            //он похож на ReadAllLines за исключением того, что возвращает лениво 
            //оцениваемое перечисление IEnumerable<string>.
            //Он более эффективен, т.к.не производит загрузку всего файла в память 
            //за один раз. 
            //Для потребления результатов идеально подходит LINQ; 
            //скажем, следующий код подсчитывает количество строк с длиной, 
            //превышающей 10 символов

            int longLines = File.ReadLines(filePath).Count(l => l.Length > 10);

            Console.WriteLine(longLines);

        }
    }
}
