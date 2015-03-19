namespace _02.GenericClassProject
{
    using System;
    class TestGeneric
    {
        static void Main()
        {
            // creating an initial array
            GenericList<int> testArray = new GenericList<int>(4);
            Console.WriteLine("The GenericList has {0} elements", testArray.Count);
            Console.WriteLine("The initial capacity is {0}\n", testArray.Capacity);

            // adding elemnts
            for (int i = 1; i < 5; i++)
            {
                testArray.Add(i * 5);
            }
            Console.WriteLine("Now in the GenericList you have {0} elements ", testArray.Count);
            Console.WriteLine("The object at position 1 is {0}\n", testArray[1]);

            // test To.String() method
            Console.WriteLine("ToString {0}\n", testArray);

            // test InsertAt method and FindElementIndex method
            var insertInt = 30;
            testArray.InsertAt(1, insertInt);   
         
            Console.WriteLine("Capacity after AutoGrow is {0}", testArray.Capacity);
            Console.WriteLine("You can find {0} at index {1}"
                , insertInt, testArray.FindElementIndex(insertInt));
            Console.WriteLine("ToString {0}\n", testArray);

            // test RemoveAt method
            testArray.RemoveAt(1);

            Console.WriteLine("Now on position 1 is {0} and the count is {1}", testArray[1], testArray.Count);
            Console.WriteLine("ToString {0}\n", testArray);

            // test Min and Max
            Console.WriteLine("The smallest element is {0} and the biggest is {1}\n"
                , testArray.MinT(), testArray.MaxT());

            // test Clear method
            testArray.ClearList();
            Console.WriteLine("After clear there are {0} elements in the array\n", testArray.Count);
        }
    }
}
