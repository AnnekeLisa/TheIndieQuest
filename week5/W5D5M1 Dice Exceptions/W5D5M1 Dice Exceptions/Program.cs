using System;
using System.Linq;

namespace W5D4M3CheckTextForDiceNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Rolling 3d6: {StandardRoll("3d6")}");
            string roll = "3d-6";
            try
            {
                Console.WriteLine(StandardRoll(roll));

            }
            catch (Exception e)
            {
                Console.Write($"Cannot roll {roll}...");
                Console.Write(e.Message);
                Console.WriteLine();
            }
            string nextroll = "r2d2";
            try
            {
                Console.WriteLine(StandardRoll(nextroll));
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.Write($"Cannot roll {nextroll}...");
                Console.Write(e.Message);
                Console.WriteLine();
            }
            string nextnextroll = "abc";
            try
            {
                Console.WriteLine(StandardRoll(nextnextroll));
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.Write($"Cannot roll {nextnextroll}...");
                Console.Write(e.Message);
                Console.WriteLine();
            }
        }

        
        static int StandardRoll(string diceNotation)
        {
            char[] splittingAt = { 'd', '+', '-' };
            string[] numbers = diceNotation.Split(splittingAt);

            bool dPresent = false;

            foreach (char check in diceNotation)
            {
                if (check == 'd')
                {
                    dPresent = true;
                }
            }

            if (dPresent == false)
            {
                throw new ArgumentException($"there is a 'd' missing in {diceNotation}");
            }

            int bonus = 0;
            int throws = 1;

            int nextToD = diceNotation.IndexOf('d') + 1;

            if (diceNotation[0] == '-' || diceNotation[nextToD] == '-')
            {
                throw new ArgumentException($"negative numbers involved");
            }

            if (numbers[0] != "")
            {
                try
                {
                    throws = Int32.Parse(numbers[0]);
                }
                catch (Exception e)
                {
                    //Console.WriteLine($"{numbers[0]} is not an integer.");
                    throw new ArgumentException("number of rolls is not an integer.");
                }
            }

            int sides = Int32.Parse(numbers[1]);
            if (numbers.Length == 3)
            {
                if (diceNotation.IndexOf('-') > -1)
                {
                    bonus = -(Int32.Parse(numbers[2]));
                }
                else
                {
                    bonus = Int32.Parse(numbers[2]);
                }
            }

            return DiceRoll(throws, sides, bonus);
        }

        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            int diceRoll = 0;
            var random = new Random();

            for (int i = 0; i < numberOfRolls; i++)
            {
                int roll = random.Next(1, diceSides + 1);
                diceRoll = diceRoll + roll;
            }

            return diceRoll + fixedBonus;
        }
    }
}
