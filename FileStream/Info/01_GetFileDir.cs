using System;
using System.IO;

// ������ ����, ��� �������� ������ ������ � �����  
// � ��������� ����������. 

namespace FileStreamSample
{
    class A
    {
        private int t;

        private int T { get => t; set => t = value; }
    }
    // ����� � ����� � ������� ��������
    public class Sample1
    {
        public Sample1():base()
        { }


        public static void Demo()
        {

            string dir = "C:\\";
            DirectoryInfo di = new DirectoryInfo(dir);
            ShowDirectory(di);
        }

        // ����������� �������� ����� � ������
        static void ShowDirectory(DirectoryInfo dir)
        {
            // ������ ����������
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                Console.WriteLine(subDir.FullName);
            }
            // ������ ������
            foreach (FileInfo fi in dir.GetFiles())
            {
                Console.WriteLine(fi.FullName);
            }
        }
    }
}