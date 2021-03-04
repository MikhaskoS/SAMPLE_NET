using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    /* -- В отдельно взятом классе может быть определен только один статический конструктор. 
     *       Другими словами, перегружать статический конструктор нельзя. 
     * -- Статический конструктор не имеет модификатора доступа и не может принимать параметры. 
     * -- Статический конструктор выполняется только один раз вне зависимости от количества 
     *       создаваемых объектов заданного класса. 
     * -- Исполняющая система вызывает статический конструктор, когда создает экземпляр
     *       класса или перед доступом к первому статическому члену из вызывающего кода. 
     * -- Статический конструктор выполняется перед любым конструктором уровня экземпляра.
     * 
     * 
     * Ключевое слово static допускается также применять прямо на уровне класса.
     * Статические классы могут содержать только статические члены.
*/

    class Sample
    {
        public static void Demo()
        {
            //Game.heart = 8;

            Game game1 = new Game();
            Console.WriteLine($"Hearth = {Game.heart}");
            
            Game.heart = 8;

            Game game2 = new Game();
            Console.WriteLine($"Hearth = {Game.heart}");
        }
    }

    class Game
    {
      
        public static int heart;
        private static bool gameState;

        public  Game()
        {
            gameState = true;
            Console.WriteLine("Обычный конструктор");
        }

        // вызывается разово перед всеми другими (без параметров и модификатора доступа)
        static Game()
        {
            heart = 3;
            Console.WriteLine("Статический конструктор");
        }


        public static void EndGame()
        {
            gameState = false;
        }
    }
}
