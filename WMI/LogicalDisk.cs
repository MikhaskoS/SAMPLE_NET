using System;
using System.Management;

// На примере класса Win32_LogicalDisk увидим, каким образом
// можно извлекать информацию о всех доступных методах класса,
// свойствах, а также экземплярах класса.
// Полное описание класса тут:

//ms-help://MS.MSDNQTR.v90.en/wmisdk/wmi/win32_logicaldisk.htm

namespace WMI
{
    class Sample1
    {
        public static void LogicalDiskSample()
        {
            //// Управляющий класс
            ManagementClass diskClass = new ManagementClass("Win32_LogicalDisk");
            // true - если объекты, возвращенные от WMI, должны содержать 
            // измененные сведения; 
            diskClass.Options.UseAmendedQualifiers = true;


            //------- описание класса
            // Коллекция объектов QualifierData
            QualifierDataCollection qualifierCollection = diskClass.Qualifiers;
            // QualifierData - содержит сведения относительно WMI описателя
            foreach (QualifierData q in qualifierCollection)
            {
                Console.WriteLine(q.Name + " = " + q.Value);
            }
            Console.WriteLine(new string('-', 45));
            //------------------------------------------------

            //------- Доступные методы класса
            Console.WriteLine("\n Доступные методы класса... ");
            MethodDataCollection diskMethods = diskClass.Methods;
            foreach (MethodData method in diskMethods)
            {
                Console.WriteLine("Метод = " + method.Name);
            }
            Console.WriteLine(new string('-', 45));
            //------------------------------------------------
            // то же, но через нумератор
            //MethodDataCollection.MethodDataEnumerator diskEnumerator =
            //           diskClass.Methods.GetEnumerator();
            //while (diskEnumerator.MoveNext())
            //{
            //    MethodData method = diskEnumerator.Current;
            //    Console.WriteLine("Method = " + method.Name);
            //}
            //Console.WriteLine(new string('-', 45));
            //-------------------------------------------------

            //------- Свойства класса
            ManagementObject diskС = new ManagementObject("Win32_LogicalDisk.DeviceID='C:'");
            PropertyDataCollection.PropertyDataEnumerator propertyEnumerator = diskС.Properties.GetEnumerator();
            while (propertyEnumerator.MoveNext())
            {
                PropertyData p = (PropertyData)propertyEnumerator.Current;
                Console.WriteLine("Найденое свойство: " + p.Name);
            }
            Console.WriteLine(new string('-', 45));
            //------------------------------------------------

            //------- Экземпляры класса
            Console.WriteLine("\n Теперь отыщем все диски... ");
            // Получим коллекцию всех экземпляров класса
            ManagementObjectCollection disks = diskClass.GetInstances();
            // Перечислитель коллекции
            ManagementObjectCollection.ManagementObjectEnumerator disksEnumerator =
                disks.GetEnumerator();
            while (disksEnumerator.MoveNext())
            {
                ManagementObject disk = (ManagementObject)disksEnumerator.Current;
                Console.WriteLine("Найден диск: " + disk["deviceid"]);
                Console.WriteLine("Размер: " + disk["Size"]);
            }
            Console.WriteLine(new string('-', 45));
            //------------------------------------------------


            // Получение сведений о методе класса
            MethodData m = diskClass.Methods["SetPowerState"];
            Console.WriteLine("Name: " + m.Name);
            Console.WriteLine("Origin: " + m.Origin);
            // аргументы
            ManagementBaseObject inParams = m.InParameters;
            foreach (PropertyData pdata in inParams.Properties)
            {
                Console.WriteLine();
                Console.WriteLine("InParam_Name: " + pdata.Name);
                Console.WriteLine("InParam_Type: " + pdata.Type);
            }
            // Возвращаемые значения
            ManagementBaseObject outParams = m.OutParameters;
            foreach (PropertyData pdata in outParams.Properties)
            {
                Console.WriteLine();
                Console.WriteLine("OutParam_Name: " + pdata.Name);
                Console.WriteLine("OutParam_Type: " + pdata.Type);
            }
        }
    }
}
