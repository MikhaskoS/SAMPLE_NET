using System;
using System.Management;

// �� ������� ������ Win32_LogicalDisk ������, ����� �������
// ����� ��������� ���������� � ���� ��������� ������� ������,
// ���������, � ����� ����������� ������.
// ������ �������� ������ ���:

//ms-help://MS.MSDNQTR.v90.en/wmisdk/wmi/win32_logicaldisk.htm

namespace WMI
{
    class Sample1
    {
        public static void LogicalDiskSample()
        {
            //// ����������� �����
            ManagementClass diskClass = new ManagementClass("Win32_LogicalDisk");
            // true - ���� �������, ������������ �� WMI, ������ ��������� 
            // ���������� ��������; 
            diskClass.Options.UseAmendedQualifiers = true;


            //------- �������� ������
            // ��������� �������� QualifierData
            QualifierDataCollection qualifierCollection = diskClass.Qualifiers;
            // QualifierData - �������� �������� ������������ WMI ���������
            foreach (QualifierData q in qualifierCollection)
            {
                Console.WriteLine(q.Name + " = " + q.Value);
            }
            Console.WriteLine(new string('-', 45));
            //------------------------------------------------

            //------- ��������� ������ ������
            Console.WriteLine("\n ��������� ������ ������... ");
            MethodDataCollection diskMethods = diskClass.Methods;
            foreach (MethodData method in diskMethods)
            {
                Console.WriteLine("����� = " + method.Name);
            }
            Console.WriteLine(new string('-', 45));
            //------------------------------------------------
            // �� ��, �� ����� ���������
            //MethodDataCollection.MethodDataEnumerator diskEnumerator =
            //           diskClass.Methods.GetEnumerator();
            //while (diskEnumerator.MoveNext())
            //{
            //    MethodData method = diskEnumerator.Current;
            //    Console.WriteLine("Method = " + method.Name);
            //}
            //Console.WriteLine(new string('-', 45));
            //-------------------------------------------------

            //------- �������� ������
            ManagementObject disk� = new ManagementObject("Win32_LogicalDisk.DeviceID='C:'");
            PropertyDataCollection.PropertyDataEnumerator propertyEnumerator = disk�.Properties.GetEnumerator();
            while (propertyEnumerator.MoveNext())
            {
                PropertyData p = (PropertyData)propertyEnumerator.Current;
                Console.WriteLine("�������� ��������: " + p.Name);
            }
            Console.WriteLine(new string('-', 45));
            //------------------------------------------------

            //------- ���������� ������
            Console.WriteLine("\n ������ ������ ��� �����... ");
            // ������� ��������� ���� ����������� ������
            ManagementObjectCollection disks = diskClass.GetInstances();
            // ������������� ���������
            ManagementObjectCollection.ManagementObjectEnumerator disksEnumerator =
                disks.GetEnumerator();
            while (disksEnumerator.MoveNext())
            {
                ManagementObject disk = (ManagementObject)disksEnumerator.Current;
                Console.WriteLine("������ ����: " + disk["deviceid"]);
                Console.WriteLine("������: " + disk["Size"]);
            }
            Console.WriteLine(new string('-', 45));
            //------------------------------------------------


            // ��������� �������� � ������ ������
            MethodData m = diskClass.Methods["SetPowerState"];
            Console.WriteLine("Name: " + m.Name);
            Console.WriteLine("Origin: " + m.Origin);
            // ���������
            ManagementBaseObject inParams = m.InParameters;
            foreach (PropertyData pdata in inParams.Properties)
            {
                Console.WriteLine();
                Console.WriteLine("InParam_Name: " + pdata.Name);
                Console.WriteLine("InParam_Type: " + pdata.Type);
            }
            // ������������ ��������
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
