using System;


namespace TypeBase
{
    class Sample14
    {
        public static void Demo()
        {
            // Представляет глобальный уникальный идентификатор (GUID)
            Guid g = Guid.NewGuid(); 
            Console.WriteLine(g.ToString()); // 0d57629c-7d6e-4847-97cb-9e2fc25083fe
        }
    }
}
