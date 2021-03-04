using System;

// ��������, ����������� ��������� ��������� ������: 
// -foo -bar -GODMODE
// � MS 2008 ��� ����� ������� ���:
// Project -> /��� ������/ Properties -> Debug -> Comand line arguments
//                                    -> ������� -> ��������� ��������� ������


namespace HelloWorld
{
    public partial class SampleProgram
    {
        // ����� ����� � ���������.
        static void ComandLine(string[] args)
        {
            // ������������� ������� ���������� ��������� ������.

            // -- ����� ���� for
            Console.WriteLine("***** ��������� ��������� ������. *****");
            for (int x = 0; x < args.Length; x++)
            {
                Console.WriteLine("Arg: {0}", args[x]);
            }

            // -- ������ ����� foreach
            Console.WriteLine("\n***** �� ��, �� � ���������� foreach *****");
            foreach (string s in args)
                Console.WriteLine("Arg: {0}", s);

            // -- ������ ���������� System.Environment
            // ���� ������ ����� ������, ���� ��������� ������ �����������
            // ���-�� � ������� ������ �������
            Console.WriteLine("\n***** �� ��, �� � �����������  Environment.GetCommandLineArgs()*****");
            string[] theArgs = Environment.GetCommandLineArgs();
            Console.WriteLine("���� � ����������: {0}", theArgs[0]);

            for (int i = 1; i < theArgs.Length; i++)
                Console.WriteLine("��������� ���. ������: {0}", theArgs[i]);
            Console.WriteLine();
            //--------------------------------------------------------------
            // ����� ��� ����� ������������ ���������� �� ����������
            // ��� �����. ��� ���� ���� ����� ������������ �����
            // System.Environment. ��� ���-���, ��� ��� ����� ������.

            // OS?
            Console.WriteLine("������� OS: {0} ", Environment.OSVersion);

            // ����������?
            Console.WriteLine("������� ����������: {0} ",
                Environment.CurrentDirectory);

            // ���������� � ������.
            string[] drives = Environment.GetLogicalDrives();
            for (int i = 0; i < drives.Length; i++)
                Console.WriteLine("���� {0} : {1} ", i, drives[i]);

            // ������ .NET?
            Console.WriteLine("����������� ������ .NET: {0} ",
                Environment.Version);

            // ���������� �����������? ����� ������������ ���
            // ���������� �������������� ����������
            Console.WriteLine("���������� �����������: " + Environment.ProcessorCount);

            // ����������� � ������� ������� �������?
            Console.WriteLine("����������� � ������� ������� �������: " + 
                Environment.TickCount);

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}