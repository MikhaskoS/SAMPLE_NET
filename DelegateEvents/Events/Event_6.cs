using System;

namespace EventsSmple
{
    // В этом примере мы cоздаем коллекцию и с помощью
    // событий сигнализируем о действиях над коллекцией

    using MyCollections;
    using TestEvents;

    class Sample6
    {
        public static void Demo()
        {
            ListWithChangedEvent list = new ListWithChangedEvent();
            EventListener listener = new EventListener(list);

            list.Add("item 1");
            list[0] = "item_correct";
            list.Clear();
            listener.Detach();
        }
    }
}

namespace MyCollections
{
    using System.Collections;

    public delegate void ChangedEventHandler(object sender, myEventArgs e);

    public class myEventArgs : EventArgs
    {
        public string TypeChanged;
    }

    /// <summary>
    /// Наследник ArrayList
    /// </summary>
    public class ListWithChangedEvent : ArrayList
    {
        public event ChangedEventHandler Changed;
        protected virtual void OnChanged(myEventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        // переопределяем методы
        public override int Add(object value)
        {
            // индекс, по которому было добавлено
            // значение
            int i = base.Add(value);
            myEventArgs _args = new myEventArgs();
            _args.TypeChanged = "Add";
            OnChanged(_args);
            return i;
        }
        public override void Clear()
        {
            base.Clear();
            myEventArgs _args = new myEventArgs();
            _args.TypeChanged = "Clear";
            OnChanged(_args);
        }
        public override object this[int index]
        {
            set
            {
                base[index] = value;
                myEventArgs _args = new myEventArgs();
                _args.TypeChanged = "Changed";
                OnChanged(_args);
            }
        }
    }
}

namespace TestEvents
{
    using MyCollections;

    /// <summary>
    /// 
    /// </summary>
    class EventListener
    {
        private ListWithChangedEvent List;
        public EventListener(ListWithChangedEvent list)
        {
            List = list;
            List.Changed += new ChangedEventHandler(ListChanged);
        }
        private void ListChanged(object sender, myEventArgs e)
        {
            Console.WriteLine("This is called when the event fires. Args = {0}", e.TypeChanged );
        }
        public void Detach()
        {
            List.Changed -= new ChangedEventHandler(ListChanged);
            List = null;
        }
    }
}


