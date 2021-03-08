/* -------------------------------------------------------------
 * ������������ ������ ������������� ��������
 * -------------------------------------------------------------*/
using System;
using System.Collections;
using System.IO;

// ��������: � ��������� �������� ���������� �����, ��������� 
// � 2007 ����. �� ��� ����������� ��������� ������ � ��� 
// ���������� ��������� �� �����.
namespace Delegate
{
    class Sample4
    {
        // ��������� �������
        public delegate bool GetFilesFilter(string files);

        public static void Demo()
        {
            string Path = @"M:\BOOK";
            // �������� �����
            string[] Files = GetFiles(Path, new GetFilesFilter(FilterFiles));
            // ���������� ��
            foreach (string file in Files)
                Console.WriteLine(file);
        }


        static bool FilterFiles(string file)
        {
            // � ������ ������ ����� ������, ���������
            // ������ � 2007 ����. �.�. ������� ������
            // true, ���� ����� ������� � ���� ����
            return (File.GetCreationTime(file).Year == 2007);
        }

        // ��������� ���������� ������� �� ���� ������, ���������������
        // ���������.
        public static string[] GetFiles(string path, GetFilesFilter filter)
        {
            ArrayList res = new ArrayList();
            foreach (string file in Directory.GetFiles(path))
            {
                // ���� ���������� ������ � ���������� ������ filter
                // �� � ��� FilterFiles
                if (filter == null || filter(file))
                    res.Add(file);
            }

            // ����������� ������ ����������
            foreach (string dir in Directory.GetDirectories(path))
                // AddRange ���������� �������� ��������� (string[]) 
                // � ����� ������ ���������
                res.AddRange(GetFiles(dir, filter)); // ��������!

            return (string[])res.ToArray(typeof(string));
        }
    }
}