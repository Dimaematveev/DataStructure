using SDS.BL.Model;
using System;

namespace SDS.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(2);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.Add(5);
            ConWrite(list);

            list.RemoveFirst(2);
            list.RemoveFirst(5);
            list.RemoveAll(4);
            ConWrite(list);

            list.Clear();
            ConWrite(list);
            Console.ReadLine();
        }

        private static void ConWrite(LinkedList<int> list)
        {
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
