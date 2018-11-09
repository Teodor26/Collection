using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public interface IforItem
    {
        object Value { get; set; }
        int Index { get; set; }
        IforItem Next { get; set; }
    }

    public interface Actions
    {
        void Add(IforItem item);
        void Remove(int index);
        void GetValue(int index);
        void PrintAll();
    }
    public class Item : IforItem
    {
        public object Value { get; set; }
        public int Index { get; set; }
        public IforItem Next { get; set; }
    }


    public class Collection : Actions
    {
        private IforItem First { get; set; }

        public void Add(IforItem item)
        {
            if (First == null)
            {
                First = item;
                item.Index = 0;
            }
            else
            {
                var current = First;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                item.Index = current.Index + 1;
                current.Next = item;
            }
        }

        public void GetValue(int index)
        {
            var current = First;
            bool last = false;
            do
            {
                if (current.Index == index)
                {
                    Console.WriteLine(current.Value);
                    last = true;
                }
                current = current.Next;
                if (current.Next == null && last != true)
                {
                    Console.WriteLine(current.Value);
                }
            } while (current.Next != null);

        }
        public void PrintAll()
        {
            if (First == null)
            {
                Console.WriteLine("No Values");
            }
            else
            {
                var current = First;
                do
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                    if (current.Next == null)
                    {
                        Console.WriteLine(current.Value);
                    }
                }
                while (current.Next != null);
            }
        }

        public void Remove(int index)
        {
            var current = First;            

            while (current.Next != null)
            {
                if(index == 0)
                {
                    current = current.Next;
                    First = current;
                    while(current.Next != null)
                    {
                        current.Index = current.Index - 1;
                        current = current.Next;
                        if(current.Next == null)
                        {
                            current.Index = current.Index - 1;
                        }
                    }
                    break;
                }
                if (current.Next == null)
                {
                    while (current.Next != null)
                    {

                        //Console.WriteLine("This item has been deleted: " + current.Next.Next.Value);
                        current = current.Next;
                    }
                    current.Next = null;
                    break;
                }
                else if (current.Index == index - 1)
                {
                    current.Next = current.Next.Next;
                    break;
                }
                else current = current.Next;
            }

            while (current.Next != null)
            {
                if ((current.Next.Index - current.Index) == 2)
                {
                    current.Next.Index = current.Next.Index - 1;
                }
                current = current.Next;
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Collection collection = new Collection();
            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();
            Item item5 = new Item();
            item1.Value = "Alex";
            item2.Value = "Emma";
            item3.Value = "Olha";
            item4.Value = 21234;
            item5.Value = "Ivan";
            collection.Add(item1);
            collection.Add(item2);
            collection.Add(item3);
            collection.Add(item4);
            collection.Add(item5);
            collection.PrintAll();
            Console.WriteLine();
            collection.Remove(0);  
            
            Console.WriteLine();
            collection.PrintAll();
            collection.Remove(0);
            Console.WriteLine();
            collection.PrintAll();
            Console.WriteLine();
            collection.Remove(1);
            collection.PrintAll();
            Console.ReadLine();

        }
    }
}
