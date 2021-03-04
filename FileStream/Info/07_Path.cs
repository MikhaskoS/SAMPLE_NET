using System;
using System.IO;

// ������������ ������������ ������ Path
namespace FileStreamSample
{
    class Sample7
    {
        public static void Demo()
        {
            string def = "\n" + new string('-', 50) + "\n";
            // �������� ���� �������
            Console.WindowHeight = 60;
            Console.WindowWidth = 110;
            Console.Clear();

            // ������, �� ������� ����������� ������� ���
            string assemblyFile = System.Reflection.Assembly.GetExecutingAssembly().Location;

            Console.WriteLine("--> ���� � ������������ �����, ������� ��� �����" +
            "\n� ��� ����������: " + assemblyFile);

            string fileName = System.IO.Path.GetFileName(assemblyFile);
            Console.WriteLine("--> ��� �����: " + fileName);

            string assemblyPath = System.IO.Path.GetDirectoryName(assemblyFile);
            Console.WriteLine("--> ���� � ������������ �����: " + assemblyPath);

            string exeName = System.IO.Path.GetFileNameWithoutExtension(assemblyFile);
            Console.WriteLine("--> ��� ������������ ����� ��� ����������: " + exeName);

            // ���������� ����� (��� ����� ��������: System.IO.Path.ChangeExtension())
            Console.WriteLine("--> ���������� �����: " +
                System.IO.Path.GetExtension(assemblyFile));

            // ��� ������ �������� ������ ���� �� ��������������
            Console.WriteLine("--> ������ ����: " +
                System.IO.Path.GetFullPath(fileName));

            // ��� ������ �������� ������ ���� �� ��������������
            Console.WriteLine("--> �������� �������: " +
                System.IO.Path.GetPathRoot(assemblyPath));


            // ���������� ��� ������ ����. 
            string subDir = Path.Combine(assemblyPath, "Data");
            Console.WriteLine("--> ����������� �����: " + subDir);

            Console.WriteLine("--> ��������� ��� �����: " +
                System.IO.Path.GetRandomFileName());

            // ���������� ���������� ��� ���������� ����� � ������� �� ����� �� ����� 
            // ����� ���� ������ 0 ����.
            string tempFile = Path.GetTempFileName();
            Console.WriteLine("--> ��������� ����: " + tempFile);
            System.IO.File.Delete(tempFile); // ����� ��� ������ :)
            // ���� � ��������� �����
            Console.WriteLine("--> ���� � ����� � ���������� �������: " +
                Path.GetTempPath());
            //-------------------------------------------------------------------  
            Console.WriteLine(def);

            // ����� ����� �������� ��������� ������������ ��� ��������
            Console.WriteLine("--> ���� ���������� � �����? - " +
                System.IO.Path.HasExtension(fileName));
            Console.WriteLine("--> �������� ������� ������ � ����? - " +
               System.IO.Path.IsPathRooted(fileName));

            //-------------------------------------------------------------------  
            Console.WriteLine(def);
            //��������� �������, ����������� ��� ���������� �����
            Console.WriteLine("Path.AltDirectorySeparatorChar = {0}",
            Path.AltDirectorySeparatorChar);
            Console.WriteLine("Path.DirectorySeparatorChar = {0}",
            Path.DirectorySeparatorChar);
            Console.WriteLine("Path.PathSeparator = {0}",
            Path.PathSeparator);
            Console.WriteLine("Path.VolumeSeparatorChar = {0}",
            Path.VolumeSeparatorChar);
            //--------------

        }

    }
}
