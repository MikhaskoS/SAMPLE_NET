using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsSample
{
    class SampleIndexer
    {
        public static void Demo()
        {
            DayCollection week = new DayCollection();
            System.Console.WriteLine(week["Fri"]);        // 5
        }
    }

    public interface ISomeInterface
    {
        // Так декларируется индексатор в интерфейсе
        int this[int index]
        {
            get;
            set;
        }
    }


    class DayCollection
    {
        string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

        // This method finds the day or returns an Exception if the day is not found
        private int GetDay(string testDay)
        {

            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == testDay)
                {
                    return j;
                }
            }

            // если не нашли - генерируем исключение
            throw new System.ArgumentOutOfRangeException(testDay, "testDay must be in the form \"Sun\", \"Mon\", etc");
        }

        // индекс - название дня недели
        public int this[string day]
        {
            get
            {
                return (GetDay(day));
            }
        }

        // индекс - обычный
        //public string this[int index]
        //{
        //    get
        //    {
        //        return days[index];
        //    }
        //    set
        //    {
        //        days[index] = value;
        //    }
        //}

        // новый синтаксис
        public string this[int index]
        {
            get => days[index];
            set => days[index] = value;
        }
    }
}
