using System;
using System.IO;

 //� NET Framework ���� � �� �� ���������� ����� ��������
 //������� ���������. ���������� ����� System.Environment,
 //������� ��������� ��������� �������� � ������� �����.
 //(��������� ����� ����� ���������� � ������ �������)
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
            // ������, �� ������� ����������� ������� ���
            // ���� � ������������ ����� .exe, ������� ��� �����
            string assemblyFile = System.Reflection.Assembly.GetExecutingAssembly().Location;


            // ������� ����������
            Console.WriteLine("--> ���� � ������������ �����: " + System.Environment.CurrentDirectory);
            // ���������� system32
            Console.WriteLine("--> ��������� ����������: " + System.Environment.SystemDirectory);
            //--------------
            #region Environment.SpecialFolder
            /*
        ����������� �����:
        [ApplicationData] - �������, ����������� ������� ������ �������������� 
        ��� ������ ���������� �������� ���������� ������������. ��������� 
        ������������ �������� �� ���������� ����������� ����. ������� ���������� 
        ������������ �������� �� ������� ���� � ����������� � ������� 
        ��� ����������� ������������.

        [CommonApplicationData] - �������, ����������� ������� ������ ���������
        ��� ������ ����������, ������������� ����� ��������������. 

        [CommonProgramFiles] ������� ��� �����������, ����� ��� ����������.

        [Cookies] - �������, �������� ����� ���������� ������ �cookies�. 

        [Desktop] - ���������� ������� ����, � �� ���������� �������������� 
        ������ �������. 

        [DesktopDirectory] - �������, ������������ ��� ����������� �������� 
        �������� ����� �������� �����. ������� ��������� ���� ������� � ����� 
        �������� �����, ������� �������� ����������� ������.

        [Favorites] - �������, �������� � �������� ������ ��������� ��� ���������
        ��������� ������������. 

        [History] - �������, �������� ����� ���������� ��������� ������� ���������. 

        [InternetCache] - �������, �������� ����� ���������� ��������� ������ ��������. 

        [LocalApplicationData] - �������, ����������� ������� ������ ��������� ��� ������ 
        ����������, ������������ ������� ����������� �������������.

        [MyComputer] - ����� ���� ���������. 

        MyMusic - ����� ���� ������. 

        [MyPictures] - ����� ���� ����������. 

        [Personal] - �������, �������� � �������� ������ ��������� ��� ����������.

        [ProgramFiles] - ������� ������ ��������. 

        [Programs] - �������, ���������� ������ �������� ������������. 

        [Recent] - �������, ���������� ��������� ������������ ���������. 

        [SendTo] - �������, ���������� ����� ���� �����������. 

        [StartMenu] - �������, ���������� ������ ���� �����. 

        [Startup] - �������, ��������������� ������ �������� ������������ ������������.
        ������� ��������� ��� ��������� ��� ����� ������������ ��� ����� 
        ������������ ������ Windows 98, Windows NT ��� ����� ������� ������.

        [System] ��������� �������.

        [Templates] �������, �������� � �������� ������ ��������� ��� �������� ������ 
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
