using System;
using System.Collections.Generic;

namespace Bowling_Pins
{
    class Program
    {
        static void Main(string[] args)
        {

            


            for(int round = 0; round < 5; round++)
            {
                var random = new Random();
                int firstRoll = random.Next(0, 11);
                int stillStanding = 10 - firstRoll;
                int secondRoll = random.Next(0, stillStanding + 1);
                var pinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                int enterPressed = 1;

                for (int roll = 0; roll < 3; roll++)
                {
                    Console.WriteLine("Score: ");

                    Console.Write("+-----+");
                    Console.WriteLine("");
                    if (roll == 0)
                    {
                        Console.Write($"| | | |");
                    }
                    else if (roll == 1)
                    {
                        Console.Write($"| |{firstRoll}| |");
                    }
                    else if (roll == 2)
                    {
                        Console.Write($"| |{firstRoll}|{secondRoll}|");
                    }

                    Console.WriteLine("");
                    Console.Write("| ----|");
                    Console.WriteLine("");
                    Console.Write("|     |");
                    Console.WriteLine("");
                    Console.Write("+-----+");
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("Current Pins: ");
                    Console.WriteLine();

                    for (int pinIndex = 0; pinIndex < 4; pinIndex++)
                    {
                        if (pinsStanding[pinIndex])
                        {
                            Console.Write("0   ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }

                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("  ");

                    for (int pinIndex = 4; pinIndex <= 6; pinIndex++)
                    {
                        if (pinsStanding[pinIndex])
                        {
                            Console.Write("0   ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }

                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("    ");

                    for (int pinIndex = 7; pinIndex <= 8; pinIndex++)
                    {
                        if (pinsStanding[pinIndex])
                        {
                            Console.Write("0   ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("      ");


                    if (pinsStanding[9])
                    {
                        Console.Write("0   ");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("1 2 3 4 5 6 7");
                    Console.WriteLine();

                    if (enterPressed < 3)
                    {
                        Console.WriteLine("Where do you want to roll the ball?(1-7):");
                    }
                    else
                    {
                        Console.WriteLine("Press enter to try again...");
                        enterPressed = 0;
                    }

                    Console.ReadLine();
                    enterPressed++;
                    Console.Clear();


                    int pinsToRemove = roll == 0 ? firstRoll : secondRoll;

                    if (roll < 2)
                    {

                        for (int pindown = 0; pindown < pinsToRemove; pindown++)
                        {
                            int pickrandomPin;

                            do
                            {
                                pickrandomPin = random.Next(10);
                            } while (pinsStanding[pickrandomPin] == false);


                            pinsStanding[pickrandomPin] = false;

                        }
                    }

                    else if (roll == 2)
                    {
                        for (int pinIndex = 0; pinIndex < pinsStanding.Count; pinIndex++)
                        {
                            pinsStanding[pinIndex] = true;
                        }
                    }

                }
            }

        }
    }
}
