using System;

namespace DiceRolling
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int diceRoll = random.Next(1,7);
            int total = 0;

            while(diceRoll != 6)
            {
                Console.WriteLine($"The player rolled: {diceRoll}");
                total = total + diceRoll;
                diceRoll = random.Next(1, 7);

            }

            if(diceRoll == 6)
            {
                Console.WriteLine($"The player rolled: {diceRoll}");
                total = total + diceRoll;
            }

            Console.WriteLine($"Total: {total}");
        }
    }
}
