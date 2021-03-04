using System;
using System.Globalization;

class Sample1
{
    public static void DateTimeSample()
    {
        // текущие дата и время
        Console.WriteLine("DateTime.Now = " + DateTime.Now.ToString());
        // текущая местная дата
        Console.WriteLine("DateTime.Today = " + DateTime.Today.ToString());
        // всемирное скоординированное время
        Console.WriteLine("DateTime.UtcNow = " + DateTime.UtcNow.ToString());
        Console.WriteLine(new string('-', 35));

        // Примеры форматирования
        Console.WriteLine("d - " + DateTime.Now.ToString("d"));
        Console.WriteLine("D - " + DateTime.Now.ToString("D"));
        Console.WriteLine("f - " + DateTime.Now.ToString("f"));
        Console.WriteLine("F - " + DateTime.Now.ToString("F"));
        Console.WriteLine("g - " + DateTime.Now.ToString("g"));
        Console.WriteLine("G - " + DateTime.Now.ToString("G"));
        Console.WriteLine("m - " + DateTime.Now.ToString("m"));
        Console.WriteLine("r - " + DateTime.Now.ToString("r"));
        Console.WriteLine("s - " + DateTime.Now.ToString("s"));
        Console.WriteLine("t - " + DateTime.Now.ToString("t"));
        Console.WriteLine("T - " + DateTime.Now.ToString("T"));
        Console.WriteLine("u - " + DateTime.Now.ToString("u"));
        Console.WriteLine("U - " + DateTime.Now.ToString("U"));
        Console.WriteLine("y - " + DateTime.Now.ToString("y"));
        Console.WriteLine(new string('-', 35));

        Console.WriteLine(TimeZone.CurrentTimeZone.DaylightName);
        Console.WriteLine(TimeZone.CurrentTimeZone.StandardName);

        // текущая дата
        DateTime dt_Japan = new DateTime(DateTime.Now.Year,
        DateTime.Now.Month,
        DateTime.Now.Day,
        DateTime.Now.Hour,
        DateTime.Now.Minute,
        DateTime.Now.Second,
        DateTime.Now.Millisecond,
        new JapaneseCalendar());

        DateTime dt_Julian = new DateTime(DateTime.Now.Year,
        DateTime.Now.Month,
        DateTime.Now.Day,
        DateTime.Now.Hour,
        DateTime.Now.Minute,
        DateTime.Now.Second,
        DateTime.Now.Millisecond,
        new JulianCalendar());

        // алгебраические операции над временем
        TimeSpan ts = new TimeSpan(4, 0, 0); // временной интервал
        Console.WriteLine(dt_Japan.ToString(DateTimeFormatInfo.CurrentInfo));
        // добавим к dt 4 часа
        Console.WriteLine((dt_Japan + ts).ToString(DateTimeFormatInfo.CurrentInfo));
        // вычтем из ts 15 минут
        Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));

        // Еще один пример
        DateTime dt_my = new DateTime(1976, 9, 9);
        // Посмотрим, что это за день недели:
        Console.WriteLine("День {0} - это {1}", dt_my.Date, dt_my.DayOfWeek);
    }
}
