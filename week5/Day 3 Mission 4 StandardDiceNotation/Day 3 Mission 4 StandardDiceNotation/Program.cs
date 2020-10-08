using System;

namespace Day_3_Mission_4_StandardDiceNotation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Your ten 1d6 rolls: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{StandardRoll("1d6")} ");
            }

            Console.WriteLine();
            Console.Write("Your ten 3d4 rolls: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{StandardRoll("3d4")} ");
            }

            Console.WriteLine();
            Console.Write("Your ten 8d8 rolls: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{StandardRoll("8d8")} ");
            }

            Console.WriteLine();
            Console.Write("Your ten 1d8b5 rolls: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{StandardRoll("1d8b5")} ");
            }

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
            int bonus = 0;
            string numberOfThrows = diceNotation[0].ToString();
            string numberOfSides = diceNotation[2].ToString();

            int throws = Int32.Parse(numberOfThrows);
            int sides = Int32.Parse(numberOfSides);

            if (diceNotation.Length == 5)
            {
                string numberOfBonus = diceNotation[4].ToString();
                bonus = Int32.Parse(numberOfBonus);
            }

            return DiceRoll(throws, sides, bonus);
        }

    }
}
