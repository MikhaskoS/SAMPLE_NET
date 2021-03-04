using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSample
{
    class ParallelSample
    {
        static string theBook;

        public static void Demo1()
        {
            GetBook();
        }

        static void GetBook()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                theBook = eArgs.Result;
                Console.WriteLine(" Download complete. ");
                //GetStats();
                GetStatsParallel();
            };
            // Загрузить электронную книгу Чарльза Диккенса "A Tale of Two Cities". 
            // Может понадобиться двукратное выполнение этого кода, если ранее вы 
            // не посещали данный сайт, поскольку при первом его посещении появляется 
            // окно с сообщением, предотвращающее нормальное выполнение кода. 
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }


        // Обычный вызов
        private static void GetStats()
        {
            // Получить слова из электронной книги. 
            string[] words = theBook.Split(new char[]
            {' ', '\u000A',',', '.' ,'?', ';',':','-','/' }, StringSplitOptions.RemoveEmptyEntries);
            // Найти 10 наиболее часто встречающихся слов. 
            string[] tenMostCommon = FindTenMostCommon(words);
            // Получить самое длинное слово. 
            string longestWord = FindLongestWord(words);
            // Когда все задачи завершены, построить строку, 
            // показывающую всю статистику в окне сообщений. 
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }
            bookStats.AppendFormat("Longest word is: {0} ", longestWord);  //Самое длинное слово
            bookStats.AppendLine();
            Console.WriteLine(bookStats.ToString(), "Book info");
        }


        // Паралельное программирование
        private static void GetStatsParallel()
        {
            // Получить слова из электронной книги. 
            string[] words = theBook.Split(new char[]
            {' ', '\u000A',',', '.' ,'?', ';',':','-','/' }, StringSplitOptions.RemoveEmptyEntries);

            string[] tenMostCommon = null;
            string longestWord = string.Empty;

            // библиотека TPL теперь будет использовать все доступные процессоры 
            // машины для вызова каждого метода параллельно, если подобное возможно.
            //------------------------------------------------
            Parallel.Invoke(() =>
            {
                // Найти 10 наиболее часто встречающихся слов. 
                tenMostCommon = FindTenMostCommon(words);
            },
            () =>
            {
                // Найти самое длинное слово. 
                longestWord = FindLongestWord(words);
            });
            //------------------------------------------------

            // Когда все задачи завершены, построить строку, 
            // показывающую всю статистику в окне сообщений. 
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }
            bookStats.AppendFormat("Longest word is: {0} ", longestWord);  //Самое длинное слово
            bookStats.AppendLine();
            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        // Найти 10 наиболее часто встречающихся слов.
        private static string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count()
                                 descending
                                 select g.Key;
            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;

        }

        // Получить самое длинное слово.
        private static string FindLongestWord(string[] words)
        {
            return (from w in words
                    orderby w.Length
                    descending
                    select w).FirstOrDefault();
        }
    }
}
