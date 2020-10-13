using System;

namespace W5D4M1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{StandardRoll("d6")} ");
            Console.WriteLine($"{StandardRoll("3d6+12")} ");
            Console.WriteLine($"{StandardRoll("3d6-5")} ");
            Console.WriteLine($"{StandardRoll("2d4")} ");
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

        static int StandardRoll(string diceNotation)
        {
            char[] splittingAt = { 'd', '+', '-' };
            string[] numbers = diceNotation.Split(splittingAt);
            
            int bonus = 0;
            int throws = 1;
            if (numbers[0] != "")
            {
                throws = Int32.Parse(numbers[0]);
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
            /* int bonus = 0;
             string numberOfThrows = diceNotation[0].ToString();
             string numberOfSides = diceNotation[2].ToString();

             int throws = Int32.Parse(numberOfThrows);
             int sides = Int32.Parse(numberOfSides);

             if (diceNotation.Length == 5)
             {
                 string numberOfBonus = diceNotation[4].ToString();
                 bonus = Int32.Parse(numberOfBonus);
             }*/

            return DiceRoll(throws, sides, bonus);
        }

    }
}
