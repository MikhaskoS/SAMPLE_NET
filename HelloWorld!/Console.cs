using System;


namespace HelloWorld
{
    public partial class SampleProgram
    {
        static void SampleConsole()
        {
            try
            {
                Console.WriteLine("������. ������ �� �������������� � ���������� " +
                    " ���������� ������ System.Console ��� Visual Studio!");
                Console.WriteLine();

                #region Title

                Console.WriteLine("��-����������, ��������� ���� ������� ��� ���� � ��������� ������.");
                Console.Write("������� ����� ��������� ���� (Title) ��� ���� �������:");
                Console.Title = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine();

                #endregion Title

                #region Size

                Console.WriteLine("�� ������ ������ �������� ������ ����.");
                Console.WriteLine();

                int newHeight;
                int newWidth;

                Console.Write("������� ������ ���� � �������� (40 - ������� ��������):");
                try
                {
                    newHeight = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. � ��� ��������� Height = 40.");
                    newHeight = 40;
                }
                Console.WriteLine();

                Console.Write("������� ������ ���� � �������� (100 - ������� ��������):");
                try
                {
                    newWidth = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. � ��� ��������� Width = 100.");
                    newWidth = 100;
                }

                // Make sure the window is not set larger than possible
                if (newHeight > Console.LargestWindowHeight)
                {
                    newHeight = Console.LargestWindowHeight;
                    Console.WriteLine("������ ����������� ������ ��������� ���������� ��������.");
                }

                if (newWidth > Console.LargestWindowWidth)
                {
                    newWidth = Console.LargestWindowWidth;
                    Console.WriteLine("������ ����������� ������ ��������� ����������� ��������.");
                }

                Console.WindowHeight = newHeight;
                Console.WindowWidth = newWidth;

                Console.Write("����� ������� ����: " +
                    Console.WindowHeight + " x " + Console.WindowWidth);
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();

                Console.Clear();

                #endregion Size

                #region Color

                Console.WriteLine("�� ������ ����� �������� ���� ������� " +
                    "���� � ������ �����, ��������� ���� �� ��������� ������:");
                Console.WriteLine();

                foreach (string colorName in Enum.GetNames(typeof(ConsoleColor)))
                {
                    Console.Write(colorName + ", ");
                }

                Console.WriteLine();

                Console.Write("������� ���� ����:");
                try
                {
                    string newBackgroundColor = Console.ReadLine();
                    Console.BackgroundColor =
                        (ConsoleColor)Enum.Parse(typeof(ConsoleColor), newBackgroundColor, true);
                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. ��������� ��� � Green.");
                    Console.BackgroundColor = ConsoleColor.Green;
                }

                Console.Write("������� ���� ������ �����:");

                try
                {
                    string newForegroundColor = Console.ReadLine();
                    Console.ForegroundColor =
                        (ConsoleColor)Enum.Parse(typeof(ConsoleColor), newForegroundColor, true);
                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. ��������� ��� � Yellow.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // allow the user to see this before we clear the screen
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("�� ������ ������� ������������� �����.");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                #endregion Color

                #region Buffer

                Console.WriteLine("� ���������� � ������� ����, �� ������ �������� � ������ �������.");
                Console.WriteLine("������ ������� �� ����� ���� ������, ��� ������ ����.");

                int newBufferWidth;
                int newBufferHeight;

                Console.Write("������� �������� ������ �������: ");
                try
                {
                    newBufferHeight = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. ��������� ��� ������ 50. ");
                    newBufferHeight = 50;
                }


                Console.Write("������� �������� ������ �������: ");
                try
                {
                    newBufferWidth = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. ��������� ��� ������ 120. ");
                    newBufferWidth = 120;
                }

                if (newBufferWidth < Console.WindowWidth)
                    newBufferWidth = Console.WindowWidth;

                if (newBufferHeight < Console.WindowHeight)
                    newBufferHeight = Console.WindowHeight;

                Console.SetBufferSize(newBufferWidth, newBufferHeight);

                Console.Write("����� ������ �������: " + Console.BufferWidth + " x " + Console.BufferHeight);

                Console.WriteLine();
                Console.WriteLine("������� Enter ��� �����������...");
                Console.ReadLine();

                Console.Clear();

                Console.WindowWidth = 120;
                Console.WindowHeight = 40;
                Console.BufferWidth = 120;
                Console.BufferHeight = 40;


                Console.WriteLine("@@@@@@@@@@");
                Console.WriteLine("@@@@@@@@@@");
                Console.WriteLine("@@@@@@@@@@");
                Console.WriteLine("@@@@@@@@@@");
                Console.WriteLine("@@@@@@@@@@");

                Console.WriteLine("�� ������ ����������� ������.");
                Console.WriteLine("����� ������� 10 x 5.");
                Console.WriteLine("���������� �� � ������ �������� ���� � ������ ������.");

                Console.WriteLine();
                Console.WriteLine("������� Enter ��� �����������...");
                Console.ReadLine();


                Console.MoveBufferArea(0, 0, 10, 5, Console.BufferWidth - 10, Console.BufferHeight - 5);

                Console.WriteLine();
                Console.WriteLine("������� Enter ��� �����������...");
                Console.ReadLine();

                Console.Clear();


                #endregion Buffer

                #region Cursor

                Console.SetWindowSize(120, 40);

                Console.WriteLine("�� ������ �������� ������� �������, ����������� ���," +
                    " � ����� ������� ��� ���������.");
                Console.WriteLine();
                Console.WriteLine("������� ������� �������: Left = " + Console.CursorLeft +
                    " Top = " + Console.CursorTop);
                Console.WriteLine();
                Console.WriteLine("������� Enter ��� ����������� ������� � ��������� Left = 20, top = 20");
                Console.ReadLine();
                Console.CursorLeft = 20;
                Console.CursorTop = 20;
                Console.Write("������� ������� �������: Left = " + Console.CursorLeft +
                    " Top = " + Console.CursorTop);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("������� Enter ��� �����������...");
                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("������ ������� ������ ������� � ��������� ����� ���������.");
                Console.WriteLine();
                Console.WriteLine("������ ������ ������� = " + Console.CursorSize);
                Console.WriteLine();

                int newCursorSize;

                Console.Write("������� ����� ������: ");
                try
                {
                    newCursorSize = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. ����� ��� ����� 50.");
                    newCursorSize = 50;
                }

                if (newCursorSize <= 0 || newCursorSize > 100)
                {
                    Console.WriteLine("������ ������� ����� ���� �� 1 �� 100. ����� ��� ����� 50.");
                    newCursorSize = 50;
                }

                Console.CursorSize = newCursorSize;
                Console.WriteLine();
                Console.WriteLine("������ ������� = " + Console.CursorSize);
                Console.WriteLine();
                Console.WriteLine("������� Enter ��� �����������...");
                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("������ ������ ���������.");
                Console.CursorVisible = false;
                Console.WriteLine();
                Console.WriteLine("������� Enter ��� �����������...");
                Console.ReadLine();

                Console.WriteLine("����� ������ �����.");
                Console.CursorVisible = true;

                Console.WriteLine();
                Console.WriteLine("������� Enter ��� �����������...");
                Console.ReadLine();
                Console.Clear();

                Console.Clear();

                #endregion Cursor

                #region Beep

                Console.WriteLine("�������� ������� � ����������������� ��������� �������.");
                Console.WriteLine();

                int frequency;
                int duration;

                Console.Write("������� ������� [37 , 32767]: ");
                try
                {
                    frequency = Int32.Parse(Console.ReadLine());

                    if (frequency < 37 | frequency > 32767)
                    {
                        Console.WriteLine("�� ����� ������������ ��������. ����� ��� ����� 1000.");
                        frequency = 1000;
                    }

                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. ����� ��� ����� 1000.");
                    frequency = 1000;
                }
                Console.WriteLine();

                Console.Write("������� ������������ � ������������ (1000 = 1 second): ");
                try
                {
                    duration = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("�� ����� ������������ ��������. ����� ��� ����� 500.");
                    duration = 500;
                }

                Console.Beep(frequency, duration);

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();

                Console.Clear();


                #endregion Beep

                Console.WriteLine();
                Console.WriteLine("������� Enter ��� ������ �� ����������.");
                Console.ReadLine();
            }
            catch (ApplicationException ex)
            {
                String msg = "������ ����������:" + ex.Message;
                Console.WriteLine(msg);
            }
        }

        public static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Now CTRL+C is used as the cancel key");
            Console.ReadLine();
            e.Cancel = true;
        }
    }
}
