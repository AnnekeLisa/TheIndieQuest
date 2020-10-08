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
            DrawMap(75, 20);
        }

        static void DrawMap(int width, int height)
        {
            var roads = new bool[width, height];
            var random = new Random();

            //Calculate multiple intersections

             for (int multipleRoads = 0; multipleRoads < 4; multipleRoads++)
             {
                 int randomStartIntersectionX = random.Next(2, width - 2);
                 int randomStartIntersectionY = random.Next(2, height - 2);

                 GenerateIntersection(roads, randomStartIntersectionX, randomStartIntersectionY);
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

                    if (y == 1 && x == width / 2 - 4)
                    {
                        Console.Write("City Map");
                        x += 7;
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

                    //Drawing the roads

                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (roads[x, y])
                    {

                        //check if this roadposition has neighbouring roads 
                        bool roadUp = false; 
                        bool roadRight = false;
                        bool roadDown = false;
                        bool roadLeft = false;

                        if (roads[x, y - 1])
                        {
                            roadUp = true;
                        }
                        if (roads[x, y + 1])
                        {
                            roadDown = true;
                        }
                        if (roads[x + 1, y])
                        {
                            roadRight = true;
                        }
                        if (roads[x - 1, y])
                        {
                            roadLeft = true;
                        }

                        if(roadUp && roadRight && roadDown && roadLeft)
                        {
                            Console.Write("╬");
                        }
                        else if(roadUp && roadRight && roadDown && roadLeft == false)
                        {
                            Console.Write("╠");
                        }
                        else if (roadUp && roadRight == false && roadDown && roadLeft)
                        {
                            Console.Write("╣");
                        }
                        else if (roadUp && roadRight && !roadDown && roadLeft)
                        {
                            Console.Write("╩");
                        }
                        else if (!roadUp && roadRight && roadDown && roadLeft)
                        {
                            Console.Write("╦");
                        }
                        else if (roadUp && roadRight == false && roadDown == false && roadLeft)
                        {
                            Console.Write("╝");
                        }
                        else if (roadUp == false && roadRight == false && roadDown && roadLeft)
                        {
                            Console.Write("╗");
                        }
                        else if (roadUp && roadRight && roadDown == false && roadLeft == false)
                        {
                            Console.Write("╚");
                        }
                        else if (roadUp == false && roadRight && roadDown && roadLeft == false)
                        {
                            Console.Write("╔");
                        }
                        else if (roadUp && roadRight == false && roadDown && roadLeft == false)
                        {
                            Console.Write("║");
                        }
                        else if (roadUp == false && roadRight && roadDown == false && roadLeft )
                        {
                            Console.Write("═");
                        }
                        else if (!roadUp && !roadRight && roadDown && !roadLeft)
                        {
                            Console.Write("║");
                        }
                        else if (roadUp && !roadRight && !roadDown && !roadLeft)
                        {
                            Console.Write("║");
                        }
                        else if (!roadUp && roadRight && !roadDown && !roadLeft)
                        {
                            Console.Write("═");
                        }
                        else if (!roadUp && !roadRight && !roadDown && roadLeft)
                        {
                            Console.Write("═");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                        continue;
                    }

                    //Drawing empty space

                    Console.Write(" ");
                }

                //Next Line

                Console.WriteLine();
            }
        }
        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
        {
            roads[startX, startY] = true;
            int height = roads.GetLength(1);
            int width = roads.GetLength(0);

            if (direction == 0)
            {
                for(int x = startX; x < width; x++)
                {
                    roads[x, startY] = true;
                }
            }
            
            else if (direction == 1)
            {
                for (int y = startY; y < height; y++)
                {
                    roads[startX, y] = true;
                }
            }

            if (direction == 2)
            {
                for (int x = startX; x > 0; x--)
                {
                    roads[x, startY] = true;
                }

            }
            else if (direction == 3)
            {
                for (int y = startY; y > 0; y--)
                {
                    roads[startX, y] = true;
                }
            }
        }

        static void GenerateIntersection(bool[,] roads, int startX, int startY)
        {
            roads[startX, startY] = true;
            int height = roads.GetLength(1);
            int width = roads.GetLength(0);
            var random = new Random();
            int intersectionRightChance = random.Next(100);
            int intersectionDownChance = random.Next(100);
            int intersectionLeftChance = random.Next(100);
            int intersectionUpChance = random.Next(100);

            if (intersectionRightChance < 70)
            {
                GenerateRoad(roads, startX, startY, 0);
            }
            if (intersectionDownChance < 70)
            {
                GenerateRoad(roads, startX, startY, 1);
            }
            if (intersectionLeftChance < 70)
            {
                GenerateRoad(roads, startX, startY, 2);
            }
            if (intersectionUpChance < 70)
            {
                GenerateRoad(roads, startX, startY, 3);
            }
        }
    }
}