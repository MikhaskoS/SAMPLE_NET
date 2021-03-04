using System;
using System.IO;

 //В NET Framework одну и ту же информацию можно получить
 //разными способами. Рассмотрим класс System.Environment,
 //который позволяет различные сведения о рабочей среде.
 //(Подробнее класс будет рассмотрен в другом разделе)
namespace FileStreamSample
{
    class Sample6
    {
        public static void Demo()
        {
            string def = "\n" + new string('-', 50) + "\n";
            Console.WindowHeight = 60;
            Console.WindowWidth = 110;
            Console.Clear();
            // Сборка, из которой выполняется текущий код
            // Путь к исполняемому файлу .exe, включая имя файла
            string assemblyFile = System.Reflection.Assembly.GetExecutingAssembly().Location;


            // Текущая директория
            Console.WriteLine("--> Путь к исполняемому файлу: " + System.Environment.CurrentDirectory);
            // Директория system32
            Console.WriteLine("--> Системная директория: " + System.Environment.SystemDirectory);
            //--------------
            #region Environment.SpecialFolder
            /*
        Специальные папки:
        [ApplicationData] - каталог, выполняющий функции общего резервирования 
        для данных приложения текущего подвижного пользователя. Подвижный 
        пользователь работает на нескольких компьютерах сети. Профиль подвижного 
        пользователя хранится на сервере сети и загружается в систему 
        при подключении пользователя.

        [CommonApplicationData] - каталог, выполняющий функции общего хранилища
        для данных приложения, используемого всеми пользователями. 

        [CommonProgramFiles] Каталог для компонентов, общих для приложений.

        [Cookies] - Каталог, служащий обшим хранилищем файлов «cookies». 

        [Desktop] - Логический рабочий стол, а не физическое местоположение 
        файлов системы. 

        [DesktopDirectory] - Каталог, используемый для физического хранения 
        объектов файла рабочего стола. Следует различать этот каталог и папку 
        рабочего стола, которая является виртуальной папкой.

        [Favorites] - Каталог, служащий в качестве общего хранилища для избранных
        элементов пользователя. 

        [History] - Каталог, служащий общим хранилищем элементов журнала Интернета. 

        [InternetCache] - Каталог, служащий общим хранилищем временных файлов Интернет. 

        [LocalApplicationData] - Каталог, выполняющий функции общего хранилища для данных 
        приложения, используемых текущим неподвижным пользователем.

        [MyComputer] - Папка «Мой компьютер». 

        MyMusic - Папка «Моя музыка». 

        [MyPictures] - Папка «Мои фотографии». 

        [Personal] - Каталог, служащий в качестве обшего хранилища для документов.

        [ProgramFiles] - Каталог файлов программ. 

        [Programs] - Каталог, содержащий группы программ пользователя. 

        [Recent] - Каталог, содержащий последние используемые документы. 

        [SendTo] - Каталог, содержащий пункт меню «Отправить». 

        [StartMenu] - Каталог, содержащий пункты меню «Пуск». 

        [Startup] - Каталог, соответствующий группе программ автозагрузки пользователя.
        Система запускает эти программы при входе пользователя или пуске 
        операционных систем Windows 98, Windows NT или более поздних версий.

        [System] Системный каталог.

        [Templates] Каталог, служащий в качестве обшего хранилища для шаблонов докуме 
        */
            #endregion


            Console.WriteLine("E03-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Console.WriteLine("E04-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            Console.WriteLine("E05-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles));
            Console.WriteLine("E06-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            Console.WriteLine("E07-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Console.WriteLine("E08-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            Console.WriteLine("E09-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.Favorites));
            Console.WriteLine("E10-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.History));
            Console.WriteLine("E11-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.InternetCache));
            Console.WriteLine("E12-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            Console.WriteLine("E13-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
            Console.WriteLine("E14-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Console.WriteLine("E15-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            Console.WriteLine("E16-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            Console.WriteLine("E17-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            Console.WriteLine("E18-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            Console.WriteLine("E19-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.Programs));
            Console.WriteLine("E20-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.Recent));
            Console.WriteLine("E21-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.SendTo));
            Console.WriteLine("E22-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            Console.WriteLine("E23-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            Console.WriteLine("E24-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.System));
            Console.WriteLine("E25-->" +
                Environment.GetFolderPath(Environment.SpecialFolder.Templates));
            Console.WriteLine(def);
            //--------------

        }
    }
}
