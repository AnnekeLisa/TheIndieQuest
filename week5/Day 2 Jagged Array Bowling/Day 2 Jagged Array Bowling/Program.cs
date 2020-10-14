using System;
using System.Collections.Generic;

namespace Bowling_Pins
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int[][] bowlingFrames = new int[10][];
            int[] pointsGained = new int[10];
            int[] frameScores = new int[10];
            int currentScore = 0;

            //Precalculating Rolls:

            for (int round = 0; round < 10; round++)
            {
                int firstRoll = random.Next(11);
                int secondRoll = random.Next(11 - firstRoll);

                if (round == 9)
                {
                    if (firstRoll == 10)
                    {
                        secondRoll = random.Next(11);
                        int thirdRoll = random.Next(11 - bowlingFrames[round][1]);

                        bowlingFrames[round] = new int[3] { firstRoll, secondRoll, thirdRoll };
                    }
                    else if (secondRoll + firstRoll == 10)
                    {
                        int thirdRoll = random.Next(11);
                        bowlingFrames[round] = new int[3] { firstRoll, secondRoll, thirdRoll };
                    }
                    else
                    {
                        bowlingFrames[round] = new int[2] { firstRoll, secondRoll };
                    }
                }

                else
                {
                    if (firstRoll == 10)
                    {
                        bowlingFrames[round] = new int[1] { firstRoll };
                    }
                    else
                    {
                        bowlingFrames[round] = new int[2] { firstRoll, secondRoll };
                    }
                }
            }

            //Drawing Phase

            for (int round = 0; round < 10; round++)
            {
                int[] currentFrameRolls = bowlingFrames[round];
                int knockedPins = 0;
                int currentPoints = pointsGained[round];

                foreach (int roll in currentFrameRolls)
                {
                    knockedPins += roll;
                }

                if (currentFrameRolls.Length == 1)
                {
                    if (round == 9 ) // Strike at frame 9
                    {
                        currentPoints = knockedPins + bowlingFrames[round + 1][0] + bowlingFrames[round + 1][2];
                    }
                    else if ( bowlingFrames[round + 1].Length == 1) // 2 Strikes
                    {
                        currentPoints = knockedPins + bowlingFrames[round + 1][0] + bowlingFrames[round + 2][0];
                    }
                    else  //Strike
                    {
                        currentPoints = knockedPins + bowlingFrames[round + 1][0] + bowlingFrames[round + 1][1];
                    }
                }

                if (currentFrameRolls.Length == 2)
                {
                    if (knockedPins == 10) //Spare
                    {
                        currentPoints = knockedPins + bowlingFrames[round + 1][0];
                    }
                    else
                    {
                        currentPoints = knockedPins;
                    }
                }

                if (currentFrameRolls.Length == 3) //last frame strike or spare
                {
                    currentPoints = knockedPins;
                }

                
                currentScore += currentPoints;

                Console.WriteLine($"Frame {round + 1}");
                    Console.WriteLine($"First Roll: {currentFrameRolls[0]} ");
                    if (currentFrameRolls.Length >= 2)
                    {
                        Console.WriteLine($"Second Roll: {currentFrameRolls[1]}");
                    }
                    if (currentFrameRolls.Length == 3)
                    {
                        Console.WriteLine($"Third Roll: {currentFrameRolls[2]}");
                    }
                    Console.WriteLine($"Knocked down pins: {knockedPins}");
                    Console.WriteLine($"Points gained: {currentPoints}");
                    Console.WriteLine($"Score: {currentScore}");
                    Console.WriteLine();
            }
        }
    }
}
