using System;
using System.Collections.Generic;

namespace DnD_Abilities_and_Basilisk
{
    class Program
    {

        static void Main(string[] args)
        {
            //AbilityRoll();

            var warriors = new List<string> { "Matej", "David", "Johanna", "Anni" };
            var random = new Random();
            int d8 = random.Next(1, 9);
            int d6 = random.Next(1, 7);
            int basiliskHealth = 0;

            for (int i = 0; i < 8; i++)
            {
                basiliskHealth = basiliskHealth + d8;
                d8 = random.Next(1, 9);
            }

            basiliskHealth = basiliskHealth + 16;

            Console.WriteLine($"The Basilisk was a great danger for the village. \nOur last hope lies in the hands of our four heros: {warriors[0]}, {warriors[1]}, {warriors[2]}, and {warriors[3]}! \n");
            Console.WriteLine($"The basilisk with {basiliskHealth} HP appears!");
            Console.WriteLine($"{warriors[0]}, {warriors[1]}, {warriors[2]}, and {warriors[3]} attack!");

            while (basiliskHealth > 0 && warriors.Count>0)
            {
                foreach (var warrior in warriors)
                {
                    if (basiliskHealth > 0)
                    {
                        int attack = random.Next(1, 5);
                        Console.WriteLine($"{warrior} attacks: {attack}");
                        basiliskHealth = basiliskHealth - attack;
                        if (basiliskHealth > 0)
                        {
                            Console.WriteLine($"Basilisk Health: {basiliskHealth}");
                        }

                        else
                        {
                            Console.WriteLine($"Basilisk Health: 0 \n");
                        }

                    }
                }

                int pickWarrior = random.Next(0, warriors.Count);

                if (warriors.Count > 0)
                {

                    int constitutionRoll = random.Next(1, 21);

                    constitutionRoll += 5;

                    Console.WriteLine($"The basilisk uses petrifying gaze on {warriors[pickWarrior]}.");
                    Console.WriteLine($"{warriors[pickWarrior]} rolled a {constitutionRoll}.");

                    if (constitutionRoll > 14)
                    {
                        Console.WriteLine($"Lucky. {warriors[pickWarrior]} was not affected.");
                    }
                    else
                    {
                        Console.WriteLine($"I am sorry, but {warriors[pickWarrior]} turned into stone.");
                        warriors.Remove(warriors[pickWarrior]);
                    }

                }

                
            }

            if (warriors.Count == 0)
            {
                Console.WriteLine($"The warriors died. Everything is doomed...");
            }
            else
            {
                Console.WriteLine($"Basilisk died. Yay, we are the greatest heroes in the wooooorld!!");
            }

        }
        static void AbilityRoll()
        {
            var random = new Random();
            var rolls = new List<int> { 4, 4, 4, 4 };
            int score = 0;
            var scoreList = new List<int> { };

            for (int rollAmount = 0; rollAmount < 6; rollAmount++)
            {
                rolls.Clear();
                rolls.Add(random.Next(1, 7));
                rolls.Add(random.Next(1, 7));
                rolls.Add(random.Next(1, 7));
                rolls.Add(random.Next(1, 7));
                rolls.Sort();

                score = rolls[1] + rolls[2] + rolls[3];
                scoreList.Add(score);

                Console.WriteLine($"You rolled {rolls[0]},{rolls[2]},{rolls[1]} and {rolls[3]}. Your ability score is {score}.");
            }
            Console.WriteLine($"Your available ability scores are: {scoreList[0]}, {scoreList[1]}, {scoreList[2]}, {scoreList[3]}, {scoreList[4]}, {scoreList[5]}.");
        }
    }
}
