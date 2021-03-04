using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class SelectMany
    {
        static string[] presidents = {
                "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
                "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
                "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
                "Monroe", "Nixon", "Pierce", "Polk", "Reagan", "Roosevelt", "Taft",
                "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

        public static void Demo1()
        {
            IEnumerable<char> chars = presidents.SelectMany(p => p.ToArray());
            chars.WriteLine();
            /*
             A
             d
             a
             m
             s
             A
             r
             t
             ...
             */
        }
        public static void Demo2()
        {
            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var employeeOptions = employees
              .SelectMany(e => empOptions
                                 .Where(eo => eo.id == e.id)
                                 .Select(eo => new
                                 {
                                     id = eo.id,
                                     optionsCount = eo.optionsCount
                                 }));

            foreach (var item in employeeOptions)
                Console.WriteLine(item);
            /*
                { id = 1, optionsCount = 2 }
                { id = 2, optionsCount = 10000 }
                { id = 2, optionsCount = 10000 }
                { id = 2, optionsCount = 10000 }
                { id = 3, optionsCount = 5000 }
                { id = 3, optionsCount = 7500 }
                { id = 3, optionsCount = 7500 }
                { id = 4, optionsCount = 1500 }
                { id = 101, optionsCount = 2 }
             */
        }
        public static void Demo3()
        {
            IEnumerable<char> chars = presidents
             .SelectMany((p, i) => i < 5 ? p.ToArray() : new char[] { });

            foreach (char ch in chars)
                Console.WriteLine(ch);
        }

        //  This class will be used by several examples.
        public class Employee
        {
            public int id;
            public string firstName;
            public string lastName;

            public static ArrayList GetEmployeesArrayList()
            {
                ArrayList al = new ArrayList();

                al.Add(new Employee { id = 1, firstName = "Joe", lastName = "Rattz" });
                al.Add(new Employee { id = 2, firstName = "William", lastName = "Gates" });
                al.Add(new Employee { id = 3, firstName = "Anders", lastName = "Hejlsberg" });
                al.Add(new Employee { id = 4, firstName = "David", lastName = "Lightman" });
                al.Add(new Employee { id = 101, firstName = "Kevin", lastName = "Flynn" });
                return (al);
            }

            public static Employee[] GetEmployeesArray()
            {
                return ((Employee[])GetEmployeesArrayList().ToArray(typeof(Employee)));
            }
        }

        //  This class will be used by several examples.
        public class EmployeeOptionEntry
        {
            public int id;
            public long optionsCount;
            public DateTime dateAwarded;

            public static EmployeeOptionEntry[] GetEmployeeOptionEntries()
            {
                EmployeeOptionEntry[] empOptions = new EmployeeOptionEntry[] {
                    new EmployeeOptionEntry {
                      id = 1,
                      optionsCount = 2,
                      dateAwarded = DateTime.Parse("1999/12/31") },
                    new EmployeeOptionEntry {
                      id = 2,
                      optionsCount = 10000,
                      dateAwarded = DateTime.Parse("1992/06/30")  },
                    new EmployeeOptionEntry {
                      id = 2,
                      optionsCount = 10000,
                      dateAwarded = DateTime.Parse("1994/01/01")  },
                    new EmployeeOptionEntry {
                      id = 3,
                      optionsCount = 5000,
                      dateAwarded = DateTime.Parse("1997/09/30") },
                    new EmployeeOptionEntry {
                      id = 2,
                      optionsCount = 10000,
                      dateAwarded = DateTime.Parse("2003/04/01")  },
                    new EmployeeOptionEntry {
                      id = 3,
                      optionsCount = 7500,
                      dateAwarded = DateTime.Parse("1998/09/30") },
                    new EmployeeOptionEntry {
                      id = 3,
                      optionsCount = 7500,
                      dateAwarded = DateTime.Parse("1998/09/30") },
                    new EmployeeOptionEntry {
                      id = 4,
                      optionsCount = 1500,
                      dateAwarded = DateTime.Parse("1997/12/31") },
                    new EmployeeOptionEntry {
                      id = 101,
                      optionsCount = 2,
                      dateAwarded = DateTime.Parse("1998/12/31") }
                };

                return (empOptions);
            }
        }
    }
}
