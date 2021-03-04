using System;
using System.Collections.ObjectModel;

/* 
 * Настраиваемые коллекции.
• для запуска события, когда элемент добавляется или удаляется;
• для обновления свойств из-за добавления или удаления элемента;
• для обнаружения “несанкционированной” операции добавления/удаления и генерации исключения
 */
namespace CollectionsSample
{
    class CollectionProxy
    {
        public static void Demo()
        {
            Zoo zoo = new Zoo();
            zoo.Animals.Add(new Animal("Kangaroo", 10));
            zoo.Animals.Add(new Animal("Mr Sea Lion", 20));

            foreach (Animal a in zoo.Animals)
                Console.WriteLine(a.Name);
        }
    }


    public class Zoo // Класс, который откроет доступ к AnimalCollection. 
    {
        // Обычно он может иметь дополнительные члены. 
        public readonly AnimalCollection Animals;
        public Zoo()
        {
            Animals = new AnimalCollection(this);
        }

    }
    public class Animal
    {
        public string Name;
        public int Popularity;
        public Zoo zoo { get; internal set; }
        public Animal(string name, int popularity)
        {
            Name = name;
            Popularity = popularity;
        }

    }

    public class AnimalCollection : Collection<Animal>
    {
        // AnimalCollection - уже полностью функционирующий список животных. 
        // Collection<T> Этот базовый класс предназначен для упрощения разработчиками с
        // оздания пользовательской коллекции. Разработчикам рекомендуется расширять 
        // этот базовый класс, а не создавать собственные.

        Zoo zoo;
        public AnimalCollection(Zoo zoo)
        { 
            this.zoo = zoo; 
        }

        protected override void InsertItem(int index, Animal item)
        {
            base.InsertItem(index, item);
            item.zoo = zoo;
        }

        protected override void SetItem(int index, Animal item)
        {
            base.SetItem(index, item);
            item.zoo = zoo;
        }
        protected override void RemoveItem(int index)
        {
            this[index].zoo = null;
            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            foreach (Animal a in this)
                a.zoo = null;
            base.ClearItems();
        }
    }
}
