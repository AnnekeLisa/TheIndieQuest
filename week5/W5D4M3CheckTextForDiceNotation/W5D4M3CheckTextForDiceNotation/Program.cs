using System;
using System.Linq;

namespace W5D4M3CheckTextForDiceNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string phrase = "To use the magic potion of dragon breath, first roll d8. If you roll 2 or higher, you manage to open the potion. Now roll 5d4+5 to see how many seconds the spell will last. Finally, the damage of the flames will be 2d6 per second.";
            string[] words = phrase.Split(' ');
            int rollCount = 0;
            int totalRollCount = 0;

            foreach(string word in words)
            {
                if (IsStandardDiceNotation(word))
                {
                    rollCount += 1;
                    totalRollCount += totalRolls(word);
                }
            }
            Console.WriteLine($"{phrase}");
            Console.WriteLine();
            Console.WriteLine($"Standard Dice Notations in text: {rollCount}");
            Console.WriteLine($"The players have to roll {totalRollCount} times.");
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

            /*if (isStandard)
            {
                Console.WriteLine($"Rolling {text} is valid");
            }
            if (!isStandard)
            {
                Console.WriteLine($"Cannot roll {text}. Thats not standard dice notation.");
            }*/

            return isStandard;
        }

        static bool isValidUsername(string name)
        {
            bool validUsername = true;
            string specialChar = @"\\|_!#$%&/()=?»«@£§€{}-;'<>_,";

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

        static int totalRolls (string diceNotation)
        {
            string[] numbers = diceNotation.Split('d', '+', '-');

            int rolls = 0;
            if (numbers[0] != "")
            {
                rolls = Int32.Parse(numbers[0]);
            }
            else
            {
                rolls = 1;
            }

            return rolls;
        }
    }
}
