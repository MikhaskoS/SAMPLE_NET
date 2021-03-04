using System;
using System.IO;

// ������ ���������� ��� ����� ������������ � ���� �����
// ������ File � Directory
namespace FileStreamSample
{
    class Sample5
    {
        public static void Demo()
        {
            string file = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Console.WriteLine("������ ���� � ������������ �����: " + file);

            // ������� ��� �� �������, ������� �������� ���������� ��� �������� (Set...)
            Console.WriteLine("��������: " + File.GetAttributes(file));
            Console.WriteLine("F02--> " + File.GetAccessControl(file));
            Console.WriteLine("������: " + File.GetCreationTime(file));
            Console.WriteLine("��������� ��������� � �����: " + File.GetLastAccessTime(file));
            Console.WriteLine("��������� ������ � ����: " + File.GetLastWriteTime(file));
            Console.WriteLine(new string('-', 45));

            //
            string filePath = Path.GetDirectoryName(file);
            Console.WriteLine("���������� �������: " + Directory.GetCreationTime(filePath));
            Console.WriteLine("������� ������� ����������: " + Directory.GetCurrentDirectory());
            Console.WriteLine("��������� � ����������: " + Directory.GetLastAccessTime(filePath));
            Console.WriteLine("��������� � ����������: " + Directory.GetLastWriteTime(filePath));
            Console.WriteLine("������������ �����: " + Directory.GetParent(filePath));
            Console.WriteLine("�������� �����: " + Directory.GetDirectoryRoot(filePath));
            Console.WriteLine(new string('-', 45));

            // �� �, ����������, ������ ����������
            string[] ds = Directory.GetDirectories("C:\\");
            foreach (string NameDir in ds)
            {
                Console.WriteLine(NameDir);
            }

        }
    }
}