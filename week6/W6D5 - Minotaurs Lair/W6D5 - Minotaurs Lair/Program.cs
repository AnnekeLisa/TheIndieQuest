using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace W6D5___Minotaurs_Lair
{
    class Program
    {
        static int width;
        static int height;
        static char[,] level;

        static void Main(string[] args)
        {
            //preparing variables with information from MazeLevel.txt

            string mazeFilePath = "MazeLevel.txt";

            string[] mazeFileLines = File.ReadAllLines(mazeFilePath);
            string levelName = mazeFileLines[0];
            string[] widthAndHeight = mazeFileLines[1].Split('x');

            width = Int32.Parse(widthAndHeight[0]);
            height = Int32.Parse(widthAndHeight[1]);

            level = new char[width, height];
            int playerXPos = 0;
            int playerYPos = 0;

            //Precalculating player start position/ Assigning characters from mazeFileLines into level[,]
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    level[x, y] = mazeFileLines[y + 2][x];
                    if(level[x,y] == 'S')
                    {
                        playerXPos = x;
                        playerYPos = y;
                    }
                }
            }

            DrawMap(playerXPos,playerYPos);
        }

        static void DrawMap(int playerXPos, int playerYPos)
        {
            level[playerXPos, playerYPos] = '☺';
            var random = new Random();

            //Writing(Drawing) the chars into the console:

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    //Drawing player
                    if (level[x, y] == '☺')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{level[x, y]}");
                        continue;
                    }

                    //Drawing the forest

                    if (y < height / 6)
                    {
                        int treechance = random.Next(0, 100);

                        if (treechance < 35)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("♠");
                            continue;
                        }
                    }

                    //Space at starting point

                    if (level[x, y] == 'S')
                    {
                        Console.Write(" ");
                    }

                    //Drawing minotaur
                    if (level[x, y] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{level[x, y]}");
                    }
                    //Drawing rest of the level
                    else
                    {
                        Console.Write($"{level[x, y]}");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
