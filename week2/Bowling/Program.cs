using System;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {

            var random = new Random();
            
            
            
            int totalFrames = random.Next(1, 11);

            for (int e = 0; e<totalFrames; e++ )
            {
                int firstRoll = random.Next(0, 11);
                int stillStanding = 10 - firstRoll;
                int secondRoll = random.Next(0, stillStanding + 1);
                

                if (firstRoll == 10)
                {
                    Console.WriteLine($"First Roll: X");
                }
                else
                {
                    Console.WriteLine($"First Roll: {firstRoll}");
                }

                if (secondRoll == stillStanding + 1)
                {
                    Console.WriteLine($"Second Roll: /");
                }
                else
                {
                    Console.WriteLine($"Second Roll: {secondRoll}");
                    stillStanding = stillStanding - secondRoll;
                }

            }

            

          


            for (int row = 0; row < totalFrames; row++)
            {
                    Console.Write("+-----+");
                
            }

            Console.WriteLine("");

            for (int row = 0; row < totalFrames; row++)
            {
                Console.Write("| | | |");
            }

            Console.WriteLine("");
            
            for (int row = 0; row < totalFrames; row++)
            {
                Console.Write("| ----|");
            }

            Console.WriteLine("");

            for (int row = 0; row < totalFrames; row++)
            {
                Console.Write("|     |");
            }

            Console.WriteLine("");

            for (int row = 0; row < totalFrames; row++)
            {
                Console.Write("+-----+");
            }

        }
    }
}
