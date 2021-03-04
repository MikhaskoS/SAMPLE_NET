using System;
using System.IO;

// ��������� �������� � �����
namespace FileStreamSample
{
    /*
     * AppendText()          ������� ������ StreamWriter � ��������� ����� � ����
     * CopyTo()              �������� ������������ ���� � ����� ����
     * Create()              ������� ����� ���� � ���������� ������ FileStream 
     *                       ��� �������������� � ����� ��������� ������
     * CreateText()          ������� ������ StreamWriter, ������� ���������� ������ � ����� ��������� ����
     * Delete()              ������� ����, � �������� �������� ��������� Filelnfo
     * Directory             �������� ��������� ������������� ��������
     * DirectoryName         �������� ������ ���� � ������������� ��������
     * Length                �������� ������ �������� �����
     * MoveTo()              ���������� ��������� ���� � ����� ��������������, 
     *                       ������������ ����������� �������� ������ ����� ��� �����
     * Name                  �������� ��� �����
     * Open()                ��������� ���� � �������������� ������������ ������/������ � ����������� �������
     * OpenRead()            ������� ������ FileStream, ��������� ������ ��� ������
     * OpenText()            ������� ������ StreamReader , ������� ���������� ������ �� ������������� 
     *                       ���������� �����
     * OpenWrite()           ������� ������ FileStream, ��������� ������ ��� ������
     */
    class Sample2
    {
        public static void Demo()
        {
            string dir = "C:\\";
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] files = di.GetFiles();

            // ���������� � ������ (� ��� ����� �������)
            // �� ����� C
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i].FullName);
                FileProp(files[i]);
                Console.WriteLine(new string('*', 40));
            }

        }

        // ���������� � �����
        static void FileProp(FileInfo file)
        {
            Console.WriteLine("����� �������� �����: {0}", file.CreationTime);
            Console.WriteLine("���������� �� ����: {0}", file.Exists);
            Console.WriteLine("���������� �����: {0}", file.Extension);
            Console.WriteLine("��� �����: {0}", file.Name);
            Console.WriteLine("���� � �����: {0}", file.FullName);
            Console.WriteLine("����� ���������� ��������� � �����: {0}", file.LastAccessTime);
            Console.WriteLine("����� ��������� ������ � ����: {0}", file.LastWriteTime);
            Console.WriteLine("��� �����: {0}", file.Name);

            Console.WriteLine("����� � ������� ���������� ����: {0}", file.Directory);
            Console.WriteLine("��� �����, � ������� ���������� ����: {0}", file.DirectoryName);
            Console.WriteLine("����� ������� ����?: {0}", file.IsReadOnly);
            Console.WriteLine("������ �����: {0}", file.Length);
            Console.WriteLine("����� �������� �����: {0}", file.CreationTime);
        }
    }
}