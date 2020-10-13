using System;
using System.Linq;

namespace W5D4M1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{StandardRoll("d6")} ");
            IsStandardDiceNotation("d6");
            
            Console.WriteLine($"{StandardRoll("3d6+12")} ");
            IsStandardDiceNotation("3d6+12");

            Console.WriteLine($"Rolling 3d6*12");
            IsStandardDiceNotation("3d6*12");

            Console.WriteLine($"Rolling 34");
            IsStandardDiceNotation("34");

           // Console.WriteLine($"{StandardRoll("3d6-5")} ");
           // Console.WriteLine($"{StandardRoll("2d4")} ");
        }

        static bool IsStandardDiceNotation(string text)
        {
            bool isStandard = false;
            bool containsInt = text.Any(char.IsDigit);

            foreach (char check in text)
            {
                if (check == 'd')
                {
                    isStandard = true;
                }
            }

            if (containsInt == false)
            {
                isStandard = false;
            }

            if (!isValidUsername(text))
            {
                isStandard = false;
            }

            if (isStandard)
            {
                Console.WriteLine($"Rolling {text} is valid");
            }
            if (!isStandard)
            {
                Console.WriteLine($"Cannot roll {text}. Thats not standard dice notation.");
            }




            return isStandard;
        }

        static bool isValidUsername(string name)
        {
            bool validUsername = true;
            string specialChar = @"\\|_!#$%&/()*=?»«@£§€{}.-;'<>_,";

            foreach (char c in name)
            {
                if (System.Char.IsUpper(c))
                {
                    validUsername = false;
                }

                /*if (System.Char.IsDigit(c))
                {
                    validUsername = true;
                }*/

                foreach (char special in specialChar)
                {
                    if (c == special)
                    {
                        validUsername = false;
                    }
                }
            }
            return validUsername;
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
