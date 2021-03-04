using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileStreamSample
{
    class XMLSerializeSample
    {
        // Класс XmlSerializer требует, чтобы все сериализированные типы в графе 
        // объектов поддерживали стандартный конструктор(а потому не забудьте его добавить, 
        // если определяли специальные конструкторы). В противном случае во время выполнения 
        // сгенерируется исключение InvalidOperationException.

        public static void Demo()
        {
            Student student = new Student();
            student.Age = 20;
            student.firstName = "Иван";
            student.lastName = "Иванов";

            SerializeAsXML(student, "data.xml");
            //<? xml version = "1.0" ?>
            //< Student xmlns:xsi = "http://www.w3.org/2001/XMLSchema-instance" xmlns: xsd = "http://www.w3.org/2001/XMLSchema" >
            //      < firstName > Иван </ firstName >
            //      < lastName > Иванов </ lastName >
            //      < Age > 20 </ Age >
            //</ Student >


            Student st = DeSerializeAsXML("data.xml");
            Console.WriteLine(st.firstName);
        }

        static void SerializeAsXML(object objGraph, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Student));

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) 
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in XML format!");
        }

        static Student DeSerializeAsXML(string fileName)
        {
            Student obj = new Student();

            XmlSerializer xmlFormat = new XmlSerializer(typeof(Student));

            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                obj = xmlFormat.Deserialize(fStream) as Student;
            }

            Console.WriteLine("XML файл успешно прочитан!");
            return obj;
        }
    }


    [Serializable]
    public class Student
    {
        // Чтобы поля можно было сериализовать, они должны быть открытыми
        public string firstName;
        public string lastName;
        // Если поле не открыто, оно не будет сериализоваться
        int age;
        // Если мы хотим не нарушать принцип инкапсуляции и при этом
        // сериализовать поле, то должны реализовать доступ к нему через публичное свойство
        public int Age
        {
            get { return age; }
            set { if (value > 0) age = value; }
        }
        // Если конструктор по умолчанию не создан, он создается автоматически !!!
    }
}
