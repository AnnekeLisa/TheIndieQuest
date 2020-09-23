using System;
using System.Collections.Generic;
using System.Threading;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var streams = new List<int>();
            var symbols = "!@#$%^&*()_+-=[];',.\\/~{}:|<>?";
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                streams.Add(random.Next(0, 80));
            }

            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                for (int x = 0; x < 80; x++)
                {
                    Console.Write(streams.Contains(x) ? symbols[random.Next(0, symbols.Length)] : ' ');
                }

                Console.WriteLine();
                Thread.Sleep(50);

                    if (random.Next(0, 3) == 0 && streams.Count > 1)
                    {
                        streams.RemoveAt(random.Next(0, streams.Count - 1));
                    }
                

                if (random.Next(0, 3) == 0) streams.Add(random.Next(0, 80));
            }
        }
    }
}
