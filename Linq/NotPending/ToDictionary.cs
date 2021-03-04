using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class ToDictionary
    {
        public static void Demo1()
        {
            #region 
            Dictionary<int, Employee> eDictionary1 =
                Employee.GetEmployeesArray().ToDictionary(k => k.id);

            eDictionary1.PrintArray();

            Employee e1 = eDictionary1[2];
            //Console.WriteLine("Employee whose id == 2 is {0} {1}", e1.firstName, e1.lastName);
            #endregion

            #region
            //---------------------------------------------------------------------------
            Dictionary<string, Employee2> eDictionary2 = Employee2.GetEmployeesArray()
             .ToDictionary(k => k.id, new MyStringifiedNumberComparer());

            Employee2 e2 = eDictionary2["2"];
            //Console.WriteLine("Employee whose id == \"2\" : {0} {1}",
            //  e2.firstName, e2.lastName);

            e2 = eDictionary2["000002"];
            //Console.WriteLine("Employee whose id == \"000002\" : {0} {1}",
            //  e2.firstName, e2.lastName);
            //----------------------------------------------------------------------------
            #endregion

            #region
            Dictionary<int, string> eDictionary3 = Employee.GetEmployeesArray()
              .ToDictionary(k => k.id,
                            i => string.Format("{0} {1}",   //  elementSelector
                              i.firstName, i.lastName));

            string name3 = eDictionary3[2];
            //Console.WriteLine("Employee whose id == 2 is {0}", name3);
            //----------------------------------------------------------------------------
            #endregion

            #region
            Dictionary<string, string> eDictionary4 = Employee2.GetEmployeesArray()
              .ToDictionary(k => k.id,                           //  keySelector
                            i => string.Format("{0} {1}",        //  elementSelector 
                              i.firstName, i.lastName),
                            new MyStringifiedNumberComparer());  //  comparer

            string name4 = eDictionary4["2"];
            //Console.WriteLine("Employee whose id == \"2\" : {0}", name4);

            name4 = eDictionary4["000002"];
            //Console.WriteLine("Employee whose id == \"000002\" : {0}", name4);
            #endregion
        }

        public class Employee
        {
            public int id;
            public string firstName;
            public string lastName;

            public static ArrayList GetEmployeesArrayList()
            {
                ArrayList al = new ArrayList
                {
                    new Employee { id = 1, firstName = "Joe", lastName = "Rattz" },
                    new Employee { id = 2, firstName = "William", lastName = "Gates" },
                    new Employee { id = 3, firstName = "Anders", lastName = "Hejlsberg" },
                    new Employee { id = 4, firstName = "David", lastName = "Lightman" },
                    new Employee { id = 101, firstName = "Kevin", lastName = "Flynn" }
                };
                return (al);
            }

            public static Employee[] GetEmployeesArray()
            {
                return ((Employee[])GetEmployeesArrayList().ToArray(typeof(Employee)));
            }
        }

        public class Employee2
        {
            public string id;
            public string firstName;
            public string lastName;

            public static ArrayList GetEmployeesArrayList()
            {
                ArrayList al = new ArrayList
                {
                    new Employee2 { id = "1", firstName = "Joe", lastName = "Rattz" },
                    new Employee2 { id = "2", firstName = "William", lastName = "Gates" },
                    new Employee2 { id = "3", firstName = "Anders",  lastName = "Hejlsberg"},
                    new Employee2 { id = "4", firstName = "David", lastName = "Lightman" },
                    new Employee2 { id = "101", firstName = "Kevin", lastName = "Flynn" }
                };
                return (al);
            }

            public static Employee2[] GetEmployeesArray()
            {
                return ((Employee2[])GetEmployeesArrayList().ToArray(typeof(Employee2)));
            }
        }

        public class MyStringifiedNumberComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return (Int32.Parse(x) == Int32.Parse(y));
            }

            public int GetHashCode(string obj)
            {
                return Int32.Parse(obj).ToString().GetHashCode();
            }
        }
    }
}
