using System;

namespace TankMission
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var random = new Random();
            int tankDistance = random.Next(40, 71);

            Console.WriteLine("Oh no! Ryssen kommer!\nWhat´s your name commander?");

            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Clear();

            while (tankDistance > 0)
            {

                Console.WriteLine($"Welcome to the battlefield, {name}");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("_/");

                for (int groundBetweenTankAndArtillery = 0; groundBetweenTankAndArtillery < tankDistance; groundBetweenTankAndArtillery++)
                {
                    Console.Write("_");
                }

                Console.Write("T");

                int remainingGround = 80 - tankDistance - 3;

                for (int remainingGroundloop = 0; remainingGroundloop < remainingGround; remainingGroundloop++)
                {
                    Console.Write("_");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                
                

                    

                    Console.WriteLine($"Aim your shot, {name}! How far do you shoot?");
                    string fireDistance = Console.ReadLine();

                    int fireDistanceInteger = Int32.Parse(fireDistance);

                    Console.WriteLine();
                    Console.Write("  ");

                    for (int fireDistanceGround = 0; fireDistanceGround < fireDistanceInteger - 1; fireDistanceGround++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write("*");


                    if (fireDistanceInteger < tankDistance + 1)
                    {
                        Console.WriteLine("That was too short!");
                    }
                    else if (fireDistanceInteger > tankDistance + 1)
                    {
                        Console.WriteLine("That was too far!");
                    }
                    else
                    {
                        Console.WriteLine("Tank tanked!");
                        break;
                    }

                    

                    int moveTankForward = random.Next(1, 16);
                    tankDistance -= moveTankForward;
                Console.WriteLine("Press enter to continue...");

                Console.ReadLine();

                Console.Clear();

            }

                Console.Write("You lost! The world is doomed.");
                Console.WriteLine();
                Console.WriteLine();
                
            
            //Console.WriteLine($"{tankDistance + 1}, {fireDistanceInteger}");
        }
    }
}
