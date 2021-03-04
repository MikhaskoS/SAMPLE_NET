using System;
using System.Globalization;

class Sample1
{
    public static void DateTimeSample()
    {
        // ������� ���� � �����
        Console.WriteLine("DateTime.Now = " + DateTime.Now.ToString());
        // ������� ������� ����
        Console.WriteLine("DateTime.Today = " + DateTime.Today.ToString());
        // ��������� ����������������� �����
        Console.WriteLine("DateTime.UtcNow = " + DateTime.UtcNow.ToString());
        Console.WriteLine(new string('-', 35));

        // ������� ��������������
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

        // ������� ����
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

        // �������������� �������� ��� ��������
        TimeSpan ts = new TimeSpan(4, 0, 0); // ��������� ��������
        Console.WriteLine(dt_Japan.ToString(DateTimeFormatInfo.CurrentInfo));
        // ������� � dt 4 ����
        Console.WriteLine((dt_Japan + ts).ToString(DateTimeFormatInfo.CurrentInfo));
        // ������ �� ts 15 �����
        Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));

        // ��� ���� ������
        DateTime dt_my = new DateTime(1976, 9, 9);
        // ���������, ��� ��� �� ���� ������:
        Console.WriteLine("���� {0} - ��� {1}", dt_my.Date, dt_my.DayOfWeek);
    }
}
