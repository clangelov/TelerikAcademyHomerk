// Implement the data structure linked list.
// Define a class ListItem<T> that has two fields: value(of type T) and NextItem(of type ListItem<T>).
// Define additionally a class LinkedList<T> with a single field FirstElement(of type ListItem<T>).
namespace Task11.ImplementLinkedList
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var someLinkedList = new MyLinkedList<int>();

            someLinkedList.Add(50);
            someLinkedList.Add(5);
            someLinkedList.Add(25);

            int counter = 1;
            foreach (var item in someLinkedList)
            {
                Console.WriteLine("{0}. Value is {1}", counter, item);
                counter++;
            }
        }
    }
}
