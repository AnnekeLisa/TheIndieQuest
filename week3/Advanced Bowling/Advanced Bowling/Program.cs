using System;
using System.Collections.Generic;

namespace Bowling_Pins
{
    class Program
    {
        static int KnockPinOnPath(int pathNumber, List<bool> pinsStanding)
        {
            int numberOfKnockedDownPins = 0;
            var random = new Random();
            int randomNewPath = random.Next(0, 3);
            int tiltChance = random.Next(0, 100);

            if(tiltChance <= 25)
            {
                pathNumber++;
            }
            else if(tiltChance >= 75)
            {
                pathNumber--;
            }
            
            if (pathNumber == 1)
            {
                if (pinsStanding[0])
                {
                    pinsStanding[0] = false;
                    numberOfKnockedDownPins++;
                }
                else
                {
                    return 0;
                }
            }
            else if (pathNumber == 2)
            {
                if (pinsStanding[4])
                {
                    pinsStanding[4] = false;
                    numberOfKnockedDownPins++;
                }
                else
                {
                    return 0;
                }
            }
            else if (pathNumber == 3)
            {

                if (pinsStanding[7])
                {
                    pinsStanding[7] = false;
                    numberOfKnockedDownPins++;
                }
                else if(pinsStanding[1]) 
                {
                    pinsStanding[1] = false;
                    numberOfKnockedDownPins++;
                }
                else
                {
                    return 0;
                }
            }
            else if (pathNumber == 4)
            {
                if (pinsStanding[9])
                {
                    pinsStanding[9] = false;
                    numberOfKnockedDownPins++;
                }
                else if(pinsStanding[5])
                {
                    pinsStanding[5] = false;
                    numberOfKnockedDownPins++;
                }
                else
                {
                    return 0;
                }
            }
            else if (pathNumber == 5)
            {
                if (pinsStanding[8])
                {
                    pinsStanding[8] = false;
                    numberOfKnockedDownPins++;
                }
                else if(pinsStanding[2])
                {
                    pinsStanding[2] = false;
                    numberOfKnockedDownPins++;
                }
                else
                {
                    return 0;
                }
            }
            else if (pathNumber == 6)
            {
                if (pinsStanding[6])
                {
                    pinsStanding[6] = false;
                    numberOfKnockedDownPins++;
                }
                else
                {
                    return 0;
                }
            }
            else if (pathNumber == 7)
            {
                if (pinsStanding[3])
                {
                    pinsStanding[3] = false;
                    numberOfKnockedDownPins++;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

            //Determine on which path to knock down aother pin

            int newInputNumber = 0;
            

            for (int knock = 0; knock < 2; knock++)
            {

                if (randomNewPath == 1 && pathNumber < 7)
                {
                    newInputNumber = pathNumber + 1;
                }
                else if (randomNewPath == 2 && pathNumber > 0)
                {
                    newInputNumber = pathNumber - 1;
                }
                else
                {
                    newInputNumber = pathNumber + 0;
                }

                numberOfKnockedDownPins += KnockPinOnPath(newInputNumber, pinsStanding);
            }

            return numberOfKnockedDownPins;
        }

        static void Main(string[] args)
        {

            for (int round = 0; round < 5; round++)
            {
                var random = new Random();
                int firstRoll = 0;
                int secondRoll = 0;
                var pinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                int numberPressed = 1;

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
                            Console.Write("    ");
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
                            Console.Write("    ");
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
                            Console.Write("    ");
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

                    if (numberPressed == 1)
                    {
                        Console.WriteLine("Where do you want to roll the ball?(1-7):");
                        string inputText = Console.ReadLine();
                        int pathNumber = Int32.Parse(inputText);
                        firstRoll = KnockPinOnPath(pathNumber, pinsStanding);
                    }
                    else if(numberPressed == 2)
                    {
                        Console.WriteLine("Where do you want to roll the ball?(1-7):");
                        string inputText = Console.ReadLine();
                        int pathNumber = Int32.Parse(inputText);
                        secondRoll = KnockPinOnPath(pathNumber, pinsStanding);
                    }
                    else
                    {
                        Console.WriteLine("Press enter to try again...");
                        numberPressed = 0;
                        Console.ReadLine();
                    }

                    numberPressed++;

                    Console.Clear();
                }
            }
        }
    }
}
