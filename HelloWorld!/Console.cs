using System;


namespace HelloWorld
{
    public partial class SampleProgram
    {
        static void SampleConsole()
        {
            try
            {
                Console.WriteLine("Привет. Сейчас вы познакомитемсь с некоторыми " +
                    " свойствами класса System.Console для Visual Studio!");
                Console.WriteLine();

                #region Title

                Console.WriteLine("По-умолчаанию, заголовок окна консоли это путь к командной строке.");
                Console.Write("Введите новый заголовок окна (Title) для окна консоли:");
                Console.Title = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine();

                #endregion Title

                #region Size

                Console.WriteLine("Вы можете теперь изменить размер окна.");
                Console.WriteLine();

                int newHeight;
                int newWidth;

                Console.Write("Введите высоту окна в пикселях (40 - хорошее значение):");
                try
                {
                    newHeight = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Я сам установлю Height = 40.");
                    newHeight = 40;
                }
                Console.WriteLine();

                Console.Write("Введите ширину окна в пикселях (100 - хорошее значение):");
                try
                {
                    newWidth = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Я сам установлю Width = 100.");
                    newWidth = 100;
                }

                // Make sure the window is not set larger than possible
                if (newHeight > Console.LargestWindowHeight)
                {
                    newHeight = Console.LargestWindowHeight;
                    Console.WriteLine("Высота установлена больше предельно опустимого значения.");
                }

                if (newWidth > Console.LargestWindowWidth)
                {
                    newWidth = Console.LargestWindowWidth;
                    Console.WriteLine("Ширина установлена больше предельно допустимого значения.");
                }

                Console.WindowHeight = newHeight;
                Console.WindowWidth = newWidth;

                Console.Write("Новые размеры окна: " +
                    Console.WindowHeight + " x " + Console.WindowWidth);
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();

                Console.Clear();

                #endregion Size

                #region Color

                Console.WriteLine("Вы можете также изменить цвет заднего " +
                    "фона и строки ввода, используя один из следующих цветов:");
                Console.WriteLine();

                foreach (string colorName in Enum.GetNames(typeof(ConsoleColor)))
                {
                    Console.Write(colorName + ", ");
                }

                Console.WriteLine();

                Console.Write("Введите цвет фона:");
                try
                {
                    string newBackgroundColor = Console.ReadLine();
                    Console.BackgroundColor =
                        (ConsoleColor)Enum.Parse(typeof(ConsoleColor), newBackgroundColor, true);
                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Установим его в Green.");
                    Console.BackgroundColor = ConsoleColor.Green;
                }

                Console.Write("Введите цвет строки ввода:");

                try
                {
                    string newForegroundColor = Console.ReadLine();
                    Console.ForegroundColor =
                        (ConsoleColor)Enum.Parse(typeof(ConsoleColor), newForegroundColor, true);
                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Установим его в Yellow.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // allow the user to see this before we clear the screen
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("Вы можете увидеть установленные цвета.");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                #endregion Color

                #region Buffer

                Console.WriteLine("В дополнении к размеру окна, вы можете изменить и размер буффера.");
                Console.WriteLine("Размер буффера не может быть меньше, чем размер окна.");

                int newBufferWidth;
                int newBufferHeight;

                Console.Write("Введите значение высоты буффера: ");
                try
                {
                    newBufferHeight = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Установим его равным 50. ");
                    newBufferHeight = 50;
                }


                Console.Write("Введите значение ширины буффера: ");
                try
                {
                    newBufferWidth = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Установим его равным 120. ");
                    newBufferWidth = 120;
                }

                if (newBufferWidth < Console.WindowWidth)
                    newBufferWidth = Console.WindowWidth;

                if (newBufferHeight < Console.WindowHeight)
                    newBufferHeight = Console.WindowHeight;

                Console.SetBufferSize(newBufferWidth, newBufferHeight);

                Console.Write("Новый размер буффера: " + Console.BufferWidth + " x " + Console.BufferHeight);

                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для продолжения...");
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

                Console.WriteLine("Вы можете переместить буффер.");
                Console.WriteLine("Имеем матрицу 10 x 5.");
                Console.WriteLine("Переместим ее с левого верхнего угла в правый нижний.");

                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();


                Console.MoveBufferArea(0, 0, 10, 5, Console.BufferWidth - 10, Console.BufferHeight - 5);

                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();

                Console.Clear();


                #endregion Buffer

                #region Cursor

                Console.SetWindowSize(120, 40);

                Console.WriteLine("Вы можете изменить размеры курсора, переместить его," +
                    " а также сделать его невидимым.");
                Console.WriteLine();
                Console.WriteLine("Текущая позиция курсора: Left = " + Console.CursorLeft +
                    " Top = " + Console.CursorTop);
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для перемещения курсора в положение Left = 20, top = 20");
                Console.ReadLine();
                Console.CursorLeft = 20;
                Console.CursorTop = 20;
                Console.Write("Текущая позиция курсора: Left = " + Console.CursorLeft +
                    " Top = " + Console.CursorTop);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Теперь изменим размер курсора и установим режим видимости.");
                Console.WriteLine();
                Console.WriteLine("Сейчас размер курсора = " + Console.CursorSize);
                Console.WriteLine();

                int newCursorSize;

                Console.Write("Введите новый размер: ");
                try
                {
                    newCursorSize = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Пусть это будет 50.");
                    newCursorSize = 50;
                }

                if (newCursorSize <= 0 || newCursorSize > 100)
                {
                    Console.WriteLine("Размер курсора может быть от 1 до 100. Пусть это будет 50.");
                    newCursorSize = 50;
                }

                Console.CursorSize = newCursorSize;
                Console.WriteLine();
                Console.WriteLine("Размер курсора = " + Console.CursorSize);
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Делаем курсор невидимым.");
                Console.CursorVisible = false;
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();

                Console.WriteLine("Снова курсор виден.");
                Console.CursorVisible = true;

                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
                Console.Clear();

                Console.Clear();

                #endregion Cursor

                #region Beep

                Console.WriteLine("Назначим частоту и продолжительность звукового сигнала.");
                Console.WriteLine();

                int frequency;
                int duration;

                Console.Write("Введите частоту [37 , 32767]: ");
                try
                {
                    frequency = Int32.Parse(Console.ReadLine());

                    if (frequency < 37 | frequency > 32767)
                    {
                        Console.WriteLine("Вы ввели недопустимое значение. Пусть это будет 1000.");
                        frequency = 1000;
                    }

                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Пусть это будет 1000.");
                    frequency = 1000;
                }
                Console.WriteLine();

                Console.Write("Введите длительность в милисекундах (1000 = 1 second): ");
                try
                {
                    duration = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректное значение. Пусть это будет 500.");
                    duration = 500;
                }

                Console.Beep(frequency, duration);

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();

                Console.Clear();


                #endregion Beep

                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для выхода из приложения.");
                Console.ReadLine();
            }
            catch (ApplicationException ex)
            {
                String msg = "Ошибка приложения:" + ex.Message;
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
