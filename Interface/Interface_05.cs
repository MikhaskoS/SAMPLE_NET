using System;

// Переопределение реализаций интерфейсов
//            IUIControl
//           /          \
//      IEditText       IDropList
//           \          /
//             ComboBox
//                |
//           FancyComboBox
namespace ISample
{
    using S5;
    public class Sample5
    {
        public static void Demo()
        {
            FancyComboBox fc = new FancyComboBox();
            fc.Paint();
            ((IUIControl)fc).Paint();
            ((IEditBox)fc).Paint();
        }
    }
    namespace S5
    {
        public interface IUIControl
        {
            void Paint();
            void Show();
        }
        public interface IEditBox : IUIControl
        {
            void SelectText();
        }
        public interface IDropList : IUIControl
        {
            void ShowList();
        }
        public class ComboBox : IEditBox, IDropList
        {
            public void Paint() { Console.WriteLine("ComboBox.Paint()"); }
            public void Show() { }
            public void SelectText() { }
            public void ShowList() { }
        }
        public class FancyComboBox : ComboBox
        {
            // требуется слово new (!!!), поскольку методы,
            // реализуемые интерфейсом не являются виртуальными
            public new void Paint() { Console.WriteLine("FancyComboBox.Paint()"); }

            // Чтобы FancyComboBox не реализовывал интерфейс IUIControl
            // в классе ComboBox функцию следовало определить как виртуальную
            // public virtual void Paint() { Console.WriteLine("ComboBox.Paint()"); }
            // а здесь написать 
            // public override void Paint() { Console.WriteLine("FancyComboBox.Paint()"); }
        }
    }
}

// FancyComboBox.Paint()
// ComboBox.Paint()
// ComboBox.Paint()
// Для продолжения нажмите любую клавишу . . .