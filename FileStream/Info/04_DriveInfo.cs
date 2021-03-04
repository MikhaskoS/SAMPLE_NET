using System;
using System.IO;

 // Класс DriveInfo
namespace FileStreamSample
{
    class Sample4
    {
        public static void Demo()
        {
            // Перечислим диски в системе
            // коллекция дисков в системе:
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Диск: {0} ",
                    drive.Name);
                try
                {
                    // типы бывают:
                    // CDRom - оптический диск, CDRom, DVD...
                    // Fixed - фиксированый жесткий диск
                    // Network - сетевой диск
                    // NotRootDirectory - без корневого каталога
                    // Ram - виртуальный диск
                    // Removable - съемный диск
                    // Unknown - неизвестный
                    Console.WriteLine("--> Тип: {0}", drive.DriveType);
                    Console.WriteLine("--> Метка тома: {0}", drive.VolumeLabel);
                    Console.WriteLine("--> Формат диска: {0}", drive.DriveFormat);
                    Console.WriteLine("--> Готов? : {0}", drive.IsReady);
                    Console.WriteLine("--> Объем свободного места : {0}", drive.TotalFreeSpace);
                    Console.WriteLine("--> Размер диска : {0}", drive.TotalSize);
                    Console.WriteLine("--> Свободное место, с учетом квоты : {0}",
                        drive.AvailableFreeSpace);
                    // возвращается DirectoryInfo как корневой каталог диска
                    Console.WriteLine("--> Корневой каталог : {0}", drive.RootDirectory.Name);
                    Console.WriteLine("--> Готов? : {0}", drive.IsReady);
                }
                catch (IOException)
                {
                    Console.WriteLine("--> Диск недоступен!");
                }
            }

        }
    }
}
