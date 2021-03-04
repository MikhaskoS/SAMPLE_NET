using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamSample
{
    [Serializable]    // <- этот аттрибут не наследуется!!!
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioID = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    public class JamesBondCar : Car
    {
        public bool canFly;
        public bool canSubmerge;
    }



    /* При обработке типа Person с помощью BinaryFormatter или SoapFormatter обнаружится, 
     * что поля isAlive, personAge и fName сохраняются в выбранном потоке. 
     * Однако тип XmlSerializer не сохранит значение personAge, потому что эта часть 
     * закрытых данных не инкапсулирована в открытом свойстве. Чтобы сохранять personAge с 
     * помощью XmlSerializer, поле personAge понадобится определить как открытое либо 
     * инкапсулировать закрытый член в открытом свойстве.
     */
    [Serializable]
    public class Person
    {
        // Открытое поле. 
        public bool isAlive = true;
        // Закрытое поле. 
        private int personAge = 21;
        // Открытое свойство/закрытые данные. 
        private string fName = string.Empty;
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
    }
}
