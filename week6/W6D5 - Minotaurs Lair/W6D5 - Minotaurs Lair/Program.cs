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
            Console.CursorVisible = false;

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
            var random = new Random();
            int minotaurXPos = 0;
            int minotaurYPos = 0;

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
                    if (level[x, y] == 'M')
                    {
                        minotaurXPos = x;
                        minotaurYPos = y;
                    }

                    //Precalculating the forest

                    if (y < height / 6)
                    {
                        int treechance = random.Next(0, 100);

                        if (treechance < 35)
                        {
                            level[x, y] = '♠';
                            continue;
                        }
                    }
                }
            }

            Console.WriteLine($"Get ready for: {levelName}!");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            DrawMap(playerXPos,playerYPos);



            //updating player position
            while(true)
            {
                
                ConsoleKeyInfo playerInput = Console.ReadKey();

                if (playerInput.Key == ConsoleKey.LeftArrow)
                {
                    if (level[playerXPos - 1, playerYPos] == ' ')
                    {
                        playerXPos -= 1;
                    }
                    else if(level[playerXPos - 1, playerYPos] == '♠')
                    {
                        playerXPos -= 1;
                    }
                    else if (level[playerXPos - 1, playerYPos] == 'M')
                    {
                        playerXPos -= 1;
                    }
                }
                else if (playerInput.Key == ConsoleKey.RightArrow)
                {
                    if (level[playerXPos + 1, playerYPos] == ' ')
                    {
                        playerXPos += 1;
                    }
                    else if (level[playerXPos + 1, playerYPos] == '♠')
                    {
                        playerXPos += 1;
                    }
                    else if (level[playerXPos + 1, playerYPos] == 'M')
                    {
                        playerXPos += 1;
                    }
                }
                else if (playerInput.Key == ConsoleKey.UpArrow)
                {
                    if (level[playerXPos, playerYPos - 1] == ' ')
                    {
                        playerYPos -= 1;
                    }
                    else if (level[playerXPos, playerYPos - 1] == '♠')
                    {
                        playerYPos -= 1;
                    }
                    else if (level[playerXPos, playerYPos - 1] == 'M')
                    {
                        playerYPos -= 1;
                    }
                }
                else if (playerInput.Key == ConsoleKey.DownArrow)
                {
                    if (level[playerXPos, playerYPos + 1] == ' ')
                    {
                        playerYPos += 1;
                    }
                    else if (level[playerXPos, playerYPos + 1] == '♠')
                    {
                        playerYPos += 1;
                    }
                    else if (level[playerXPos, playerYPos + 1] == 'M')
                    {
                        playerYPos += 1;
                    }
                }
                else if (playerInput.Key == ConsoleKey.Escape)
                {
                    return;
                }

                if(level[playerXPos,playerYPos] == level[minotaurXPos, minotaurYPos])
                {
                    Console.WriteLine("You have found the mighty minotaur. \"I have been waiting for another soul for many years... finally...\"");
                    Console.WriteLine("press enter to continue...");
                    ConsoleKeyInfo minotaurConversation = Console.ReadKey();

                    if (minotaurConversation.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\"Sooo.... can you show me the way out of here?\"");
                        Console.WriteLine("Congratulations, you win!!! Whooo!");
                    }
                }

                DrawMap(playerXPos, playerYPos);
            }
            
        }

        static void DrawMap(int playerXPos, int playerYPos)
        {
            Console.SetCursorPosition(0, 0);

            //level[playerXPos, playerYPos] = '☺';
            
            //Writing(Drawing) the chars into the console:

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    //Drawing player
                    if (x == playerXPos && y == playerYPos)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('☺');
                        continue;
                    }

                    //Drawing the forest
                    if(level[x,y] == '♠')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    //Space at starting point

                    if (level[x, y] == 'S')
                    {
                        Console.Write(" ");
                        continue;
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
