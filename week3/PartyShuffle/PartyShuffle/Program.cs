using System;
using System.Collections.Generic;

namespace PartyShuffle
{
    class Program
    {

        static void ShuffleList(List<string> names)
        {
            // To shuffle an array a of n elements(indices 0..n - 1):
            //for i from n−1 downto 1 do
            //j ← random integer such that 0 ≤ j ≤ i
            //exchange a[j] and a[i]
            var random = new Random();

            for(int i = 0; i < names.Count; i++)
            {
                int shuffleNumber = random.Next(0, names.Count);
                string store = names[i];
                names[i] = names[shuffleNumber];
                names[shuffleNumber] = store;
            }

            return;
        }

        static void Main(string[] args)
        {

            var names = new List<string> { "Matej", "Hilda", "Anni", "David", "Matts", "Nor", "Chirs" };

            string JoinedList = string.Join(", ", names);
            Console.WriteLine($"{JoinedList}");
            Console.WriteLine();

            Console.WriteLine("Shuffeling...");
            Console.WriteLine();

            ShuffleList(names);
            string JoinedShuffledList = string.Join(", ", names);
            Console.WriteLine($"{JoinedShuffledList}");
        }
    }
}
