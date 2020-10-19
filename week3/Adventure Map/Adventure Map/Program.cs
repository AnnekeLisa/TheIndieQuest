using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Adventure_Map
{
    class Program
    {
        static void Main(string[] args)
        {

            DrawMap(80, 30);
        }

        static void GenerateCurve(int width, int height, int flowPatternAmount, int chanceOfCurve, int startXposition, List<int> curveValues, List<string> curveElements)
        {
            var curveRandom = new Random();


            int lastElementXPos = 0;

            for (int y = 0; y < height; y++)
            {

                curveValues.Add((width / 10 * startXposition) + lastElementXPos);
                char curvestraight = '|';
                char curveleft = '/';
                char curveright = '\\';

                int elementRandom = curveRandom.Next(0, chanceOfCurve + 1);

                if (elementRandom == 0)
                {
                    lastElementXPos += 0;
                    curveElements.Add("|".PadLeft(flowPatternAmount, curvestraight));
                }
                else if (elementRandom <= chanceOfCurve / 2)
                {
                    lastElementXPos += 1;
                    curveElements.Add(@"\".PadLeft(flowPatternAmount, curveright));
                }
                else if (elementRandom <= chanceOfCurve && elementRandom >= chanceOfCurve / 2)
                {
                    lastElementXPos += -1;
                    curveElements.Add("/".PadLeft(flowPatternAmount, curveleft));
                }
            }
        }


        static void DrawMap(int width, int height)
        {
            //Declaring and assigning variables for precalculation
            var riverValues = new List<int>();
            var riverElements = new List<string>();
            var wallValues = new List<int>();
            var wallElements = new List<string>();
            //GenerateCurve(1, 1, 1, 1, 1, riverValues, riverElements);

            var random = new Random();
            var forestChars = new List<string> { "@", "a", "Q", "O", "o", "P", "A" };
            int lastRiverYPos = 0;
            //List<int> riverXPos = new List<int> { };
            //List<string> riverFlowStringList = new List<string> { };
            List<int> horizontalRoadYPos = new List<int> { };
            string flowpattern = "|||";
            int riverCrossingXPos = 0;
            int riverCrossingYPos = 0;
            int wallCrossingXPos = 0;
            int wallCrossingYPos = 0;
            int lastHorizontalRoadXPos = 0;

            //calculating river
            /* for (int y = 0; y < height; y++)
             {

                 riverXPos.Add((width / 4 * 3) + lastRiverYPos);

                 int riverRandom = random.Next(0, 3);


                 if (riverRandom == 0)
                 {
                     lastRiverYPos += 0;
                     riverFlowStringList.Add("|||");
                 }
                 if (riverRandom == 1)
                 {
                     lastRiverYPos += 1;
                     riverFlowStringList.Add(@"\\\");
                 }
                 if (riverRandom == 2)
                 {
                     lastRiverYPos += -1;
                     riverFlowStringList.Add("///");
                 }
             }*/


            GenerateCurve(width, height, 3, 8, 8, riverValues, riverElements);
            GenerateCurve(width, height, 2, 2, 3, wallValues, wallElements);

            //calculating horizontal road, wall crossing  & river crossing
            for (int x = 0; x < width; x++)
            {
                int currentRoadY = (height / 2) + lastHorizontalRoadXPos;
                horizontalRoadYPos.Add(currentRoadY);

                //here I know the stored x and y value of the road. So I am checking for river and wall crossing:

                int leftRiverEdge = riverValues[currentRoadY];
                int rightRiverEdge = leftRiverEdge + 2;
                if (x >= leftRiverEdge && x <= rightRiverEdge)
                {
                    riverCrossingXPos = x - 4;
                    riverCrossingYPos = currentRoadY;
                    continue;
                }

                int leftWallEdge = wallValues[currentRoadY];
                int rightWallEdge = leftWallEdge + 1;
                if (x >= leftWallEdge && x <= rightWallEdge)
                {
                    wallCrossingXPos = x - 4;
                    wallCrossingYPos = currentRoadY;
                    continue;
                }

                // calculating the direction of the horizontal road

                if (x >= leftRiverEdge - 4 && x <= rightRiverEdge + 4)
                {
                    lastHorizontalRoadXPos += 0;
                    continue;
                }

                if (x == leftWallEdge - 1 || x == rightWallEdge + 1)
                {
                    lastHorizontalRoadXPos += 0;
                    continue;
                }

                int horizontalRoadRandom = random.Next(0, 5);

                if (horizontalRoadRandom == 0 || horizontalRoadRandom == 1 || horizontalRoadRandom == 2)
                {
                    lastHorizontalRoadXPos += 0;
                    continue;
                }
                else if (horizontalRoadRandom == 3)
                {
                    lastHorizontalRoadXPos += 1;
                    continue;
                }
                else if (horizontalRoadRandom == 4)
                {
                    lastHorizontalRoadXPos += -1;
                    continue;
                }
            }


            // Drawing the map

            for (int y = 0; y < height; y++)
            {

                for (int x = 0; x < width; x++)
                {
                    //Declaring variables to store the edges of the map

                    bool horizontalEdge = y == 0 || y == height - 1;
                    bool verticalEdge = x == 0 || x == width - 1;

                    //Drawing title and border

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    if (y == 1 && x == width / 2 - 6)
                    {
                        Console.Write("AdventureMap");
                        x += 11;
                        continue;
                    }

                    if (horizontalEdge && verticalEdge)
                    {
                        Console.Write("+");
                        continue;

                    }
                    else if (horizontalEdge)
                    {
                        Console.Write("-");
                        continue;

                    }
                    else if (verticalEdge)
                    {
                        Console.Write("|");
                        continue;
                    }



                    //Drawing Bridge Railing


                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (y == (riverCrossingYPos - 1) && x == riverCrossingXPos)
                    {
                        Console.Write("=========");
                        x += 9;
                    }

                    if (y == (riverCrossingYPos + 1) && x == riverCrossingXPos)
                    {

                        Console.Write("=========");
                        x += 9;
                    }


                    //Draw Towers
                    
                    if (y == (wallCrossingYPos - 1) && x == wallCrossingXPos + 3)
                    {
                        Console.Write("[]");
                        x += 2;
                    }

                    if (y == (wallCrossingYPos + 1) && x == wallCrossingXPos + 3)
                    {

                        Console.Write("[]");
                        x += 2;
                    }

                    //Drawing the horizontal Road

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    if (y == horizontalRoadYPos[x])
                    {
                        Console.Write("#");
                        //x += 1;
                        continue;
                    }


                    // Drawing the wall

                    
                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (x == wallValues[y])
                    {
                        Console.Write($"{wallElements[y]}");
                        x += 2;
                    }


                    //Draw Moose

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    if (x == 10 && y == 7)
                    {
                        Console.Write(@"  \\_//");
                        x += 7;
                    }

                    if (x == 10 && y == 8)
                    {
                        Console.Write(@" __/''.");
                        x += 7;
                    }

                    if (x == 10 && y == 9)
                    {
                        Console.Write(@"/__ |");
                        x += 5;
                    }

                    if (x == 10 && y == 10)
                    {
                        Console.Write(@"|| ||");
                        x += 5;
                    }

                    //Draw Flowers
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                    for (int floweramount = 0; floweramount < 18; floweramount++)
                    {
                        int flowerX = random.Next(0, width);
                        int flowerY = random.Next(0, height);

                        if (y == flowerY && x == flowerX)
                        {
                            Console.Write("@");
                            x += 1;
                        }
                    }


                    //Drawing the forest

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    int percentage = 100 - (x * 4);
                    int treechance = random.Next(0, 100);

                    if (x < width / 3)
                    {
                        if (treechance < percentage)
                        {
                            Console.Write($"{ forestChars[random.Next(0, forestChars.Count)]}");
                            continue;
                        }
                    }



                    //Drawing the river

                    //Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    if (x == riverValues[y])
                    {
                        Console.Write($"{riverElements[y]}");
                        x += 3;
                    }



                    //Drawing vertical road

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;

                    int verticalRoadXPos = riverValues[y] - 6;
                    int RoadsCrossingPoint = horizontalRoadYPos[verticalRoadXPos];

                    if (x == verticalRoadXPos && y > RoadsCrossingPoint)
                    {
                        Console.Write("#");
                        x += 1;
                    }

                    //Drawing empty space

                    Console.Write(" ");

                }

                //Next Line

                Console.WriteLine();
            }
        }
    }
}
