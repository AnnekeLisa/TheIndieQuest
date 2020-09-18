using System;
using System.Reflection.PortableExecutable;

namespace GelatinousCubeArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int charHealth = 0;
            int cubeHealth = 40;
            int cubeArmyHealth = 0;


            for (int i = 0; i<3; i++)
            {
                charHealth = charHealth + random.Next(1,7);
                
            }
            Console.WriteLine($"A hero with {charHealth} HP was created.");

            for (int c = 0; c < 8; c++)
            {
                cubeHealth = cubeHealth + random.Next(1, 11);
            }

            Console.WriteLine($"A gelatenous cube with {cubeHealth} HP appears!");

            for (int a = 0; a < 100; a++)
            {
                for (int c = 0; c < 8; c++)
                {
                    cubeArmyHealth = cubeArmyHealth + random.Next(1, 11);
                }
                cubeArmyHealth = cubeArmyHealth + 40;
            }

            Console.WriteLine($"An army of gelatenous cubes with the combined HP of {cubeArmyHealth} appears! : O we are all dooooomed!");

        }
    }
}
