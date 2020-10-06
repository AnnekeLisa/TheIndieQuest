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

            for (int multipleRoads = 0; multipleRoads < 4; multipleRoads++)
            {
                int direction = random.Next(0, 4);
                int randomStartRoadX = random.Next(0, width);
                int randomStartRoadY = random.Next(0, height);

                GenerateRoad(roads, randomStartRoadX, randomStartRoadY, direction);
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
    }
}