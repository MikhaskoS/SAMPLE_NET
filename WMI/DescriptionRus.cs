using System;
using System.Management; // эту ссылку следует добавить (Add Reference...)

namespace WMI
{
    // https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-account
    public enum Win32_Class
    {
        Win32_Account,
        Win32_BootConfiguration,
        Win32_Desktop,
        Win32_Environment,
        Win32_Process,
        Win32_ProcessStartup,
        Win32_TimeZone,
        Win32_UserDesktop
    }

    public static class Sample2
    {
        public static void Description()
        {
            // получим массив из перечисления
            Win32_Class[] colors = (Win32_Class[])Enum.GetValues(typeof(Win32_Class));

            foreach (Win32_Class color in colors)
            {
                ManagementClass cl = new ManagementClass(color.ToString());
                cl.Options.UseAmendedQualifiers = true;
                Console.WriteLine(cl.Qualifiers["Description"].Value);
                Console.WriteLine(new string('-', 45));
            }
        }

    }
}