using System;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int warriorHealth = random.Next(10,61);
            

            Console.WriteLine($" Warrior HP: {warriorHealth}");
            Console.WriteLine("Regenerate spell is cast!");

            for (int turn = 0; warriorHealth < 50; turn++)
            {
                warriorHealth = warriorHealth + 10;
                Console.WriteLine($"Warrior HP: {warriorHealth}");
            }
            
                Console.WriteLine("Regenerate spell is complete.");
            
        }
    }
}
