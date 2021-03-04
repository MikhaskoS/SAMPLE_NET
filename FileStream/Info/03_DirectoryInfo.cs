using System;
using System.IO;

// ����� DirectoryInfo
// ���������� � ����������
/*
 * Create () CreateSubdirectory()     ������� ������� (��� ����� ������������) �� ��������� �������� �����
 * Delete ()                          ������� ������� � ��� ��� ����������
 * GetDirectories()                   ���������� ������ �������� Directorylnfo, 
 *                                    ������� ������������ ��� ����������� � ������� ��������
 * GetFiles()                         ��������� ������ �������� Filelnfo, �������������� ����� ������ � 
 *                                    �������� ��������
 * MoveTo()                           ���������� ������� �� ���� ���������� � ����� ����
 * Parent                             ��������� ������������ ������� ������� ��������
 * Root                               �������� �������� ����� ����

 */

namespace FileStreamSample
{
    class Sample3
    {
        public static void Demo1()
        {

            // �������� ������ ���� DirectoryInfo
            System.IO.DirectoryInfo df1 = new System.IO.DirectoryInfo("C:\\Program Files");

            // ������� ������� �������
            System.IO.DirectoryInfo df2 = new System.IO.DirectoryInfo(".");
            Console.WriteLine("������� �������: \t" + df2.FullName);

            // ����� ������� �������, ����� ��� �������
            System.IO.DirectoryInfo df3 = new System.IO.DirectoryInfo("C:\\MY_TEST");
            // ������� ����� �� ����� ����
            df3.Create();

            Console.WriteLine("�������� ���������� � ����������:");

            // ����� �������� ������� ����������
            Console.WriteLine("CreationTime: \t" + df1.CreationTime);
            // ����� ��������� ������ � �����
            Console.WriteLine("LastWriteTime: \t" + df1.LastWriteTime);
            // ����� ���������� ������� � ����� (�����)
            Console.WriteLine("LastAccessTime: \t" + df1.LastAccessTime);
            // ������������ �������
            Console.WriteLine("Parent: \t" + df1.Parent);
            // ������������ ������� c ������ �����
            Console.WriteLine("Parent.FullName: \t" + df1.Parent.FullName);
            Console.WriteLine("Name: \t" + df1.Name);
            // ������ ���� ����������
            Console.WriteLine("FullName: \t" + df1.FullName);
            // �������� �������
            Console.WriteLine("Root: \t" + df1.Root);
            // �������� ����������
            #region ������ ����������
            /*     
         * Archive -   ���� ��������� � ��������� �������������. 
         *             ���������� ���������� ���� �������, ����� �������� ����� 
         *             ��� ���������� ����������� ��� ��������.  
         * Compressed -���� ����. 
         * Device  -   ��������������� ��� ����������� �������������. 
         * Directory - ���� ������������ ����� �����. 
         * Encrypted - ���� ��� ����� �����������. ��� ����� ��� ��������, ��� ��� ������ 
         *             � ����� �����������. ��� ����� ��� ��������, ��� ���������� 
         *             ������������ �� ��������� ��� ����� ����������� ������ � �����. 
         * Hidden -    ���� ������� �, ����� �������, �� ���������� � ������� 
         *             ������ �����.  
         * Normal -    ���� �������, � ������ �������� �� �����������.
         *             ���� ������� ������������ ������, ���� ������������ ����,
         *             ��� ������ ���������. 
         * NotContentIndexed - ���� �� ����� ��������������� ������� ��������������
         *             ���������� ������������ �������.  
         * Offline -   ���� � ���������� ������. ������ ����� ����� ���������� 
         *             ���������������. 
         * ReadOnly -  ���� �������� ������ ��� ������.  
         * ReparsePoint -���� �������� ����� ��������� ���������, ����������� 
         *             ������������ ������������� ������, ��������� � ������ ��� ������.
         * SparseFile -���� ������������ ����� ����������� ����. ������������ ������� 
         *             ������ �������� ������� �����, � ������� � �������� ������� 
         *             ������. 
         * System -    ���� �������� ��������� ������. ���� ���� �������� ������
         *             ������������ ������� ��� ������������ ������������� 
         *             ������������ ��������.  
         * Temporary - ��������� ����. �������� ������� ��� ��������� ������� �������� 
         *             ������� ��� ������ � ������, � �� ���������� �� �����, � �������� ������. 
         *             ���������� ������ ������� ��������� ���� ����� ����, ��� �� ������ �������.
        */
            #endregion
            Console.WriteLine("Attributes: \t" + df1.Attributes);
        }

        public static void Demo2()
        {
            // ���������� ���������� 
            // ���� � ������������ �����
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("������� ���������� : " + baseFolder);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("���������� .exe ���� � ����������, �� ������� \n" +
                "����� ������� ����� (������� �������������!).");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("������� ����� � ����������� [.sample]: ");
            string ext = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(baseFolder);
            DeleteFile(di, ext);
        }

        //-----------------------------------------------------------------------
        // �������� ������ � ��������� ����������� �� ���������� � ��� ����������
        //-----------------------------------------------------------------------
        public static void DeleteFile(DirectoryInfo di, string ext)
        {
            FileInfo[] fi = di.GetFiles();
            for (int i = fi.Length - 1; i >= 0; i--)
            {
                if (fi[i].Extension == ext) fi[i].Delete();
            }

            DirectoryInfo[] _d = di.GetDirectories();
            foreach (DirectoryInfo d in _d)
            {
                Console.WriteLine(d.Name);
                DeleteFile(d, ext);
            }
        }
    }
}