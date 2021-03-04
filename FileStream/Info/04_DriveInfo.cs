using System;
using System.IO;

 // ����� DriveInfo
namespace FileStreamSample
{
    class Sample4
    {
        public static void Demo()
        {
            // ���������� ����� � �������
            // ��������� ������ � �������:
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("����: {0} ",
                    drive.Name);
                try
                {
                    // ���� ������:
                    // CDRom - ���������� ����, CDRom, DVD...
                    // Fixed - ������������ ������� ����
                    // Network - ������� ����
                    // NotRootDirectory - ��� ��������� ��������
                    // Ram - ����������� ����
                    // Removable - ������� ����
                    // Unknown - �����������
                    Console.WriteLine("--> ���: {0}", drive.DriveType);
                    Console.WriteLine("--> ����� ����: {0}", drive.VolumeLabel);
                    Console.WriteLine("--> ������ �����: {0}", drive.DriveFormat);
                    Console.WriteLine("--> �����? : {0}", drive.IsReady);
                    Console.WriteLine("--> ����� ���������� ����� : {0}", drive.TotalFreeSpace);
                    Console.WriteLine("--> ������ ����� : {0}", drive.TotalSize);
                    Console.WriteLine("--> ��������� �����, � ������ ����� : {0}",
                        drive.AvailableFreeSpace);
                    // ������������ DirectoryInfo ��� �������� ������� �����
                    Console.WriteLine("--> �������� ������� : {0}", drive.RootDirectory.Name);
                    Console.WriteLine("--> �����? : {0}", drive.IsReady);
                }
                catch (IOException)
                {
                    Console.WriteLine("--> ���� ����������!");
                }
            }

        }
    }
}
