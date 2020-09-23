using System;
using System.Collections.Generic;
using System.Net;

namespace DnDMonsterBattleMethods
{
    class Program
    {
       

        static void Main(string[] args)
        {
            //AbilityRoll();

            var warriors = new List<string> {"Matej", "David", "Johanna", "Anni" };
            var random = new Random();
            int d8 = random.Next(1, 9);
            int d6 = random.Next(1, 7);
            string monster = "Orc";
            int monsterHealth = 15;
            int difficultyRoll = 12;

           

            monsterHealth = DiceRoll(2,8,6);
            difficultyRoll = 12;

            Console.WriteLine($"The {monster} was a great danger for the village. \nOur last hope lies in the hands of our four heros: {warriors[0]}, {warriors[1]}, {warriors[2]}, and {warriors[3]}! \n");
            Console.WriteLine($"The {monster} with {monsterHealth} HP appears!");
            Console.WriteLine($"{warriors[0]}, {warriors[1]}, {warriors[2]}, and {warriors[3]} attack!\n");

            

            SimulateBattle(warriors, monster, monsterHealth, difficultyRoll);

            monsterHealth = DiceRoll(9, 8);
            monster = "Mage";
            difficultyRoll = 20;

            SimulateBattle(warriors, monster, monsterHealth, difficultyRoll);

            monsterHealth = DiceRoll(8, 10, 40);
            monster = "Troll";
            difficultyRoll = 18;

            SimulateBattle(warriors, monster, monsterHealth, difficultyRoll);



            if (warriors.Count > 0)
            {
                warriors.ForEach(Console.WriteLine);
                Console.WriteLine("survived! Whew!");
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


        static void SimulateBattle(List<string> warriors, string monster, int monsterHealth, int difficultyRoll)
        {

            var random = new Random();

            while (monsterHealth > 0 && warriors.Count > 0)
            {
                foreach (var warrior in warriors)
                {
                    if (monsterHealth > 0)
                    {
                        int attack = DiceRoll(2,6);

                        Console.WriteLine($"{warrior} attacks: {attack}");
                        monsterHealth = monsterHealth - attack;
                        if (monsterHealth > 0)
                        {
                            Console.WriteLine($"{monster} Health: {monsterHealth}");
                        }

                        else
                        {
                            Console.WriteLine($"{monster} Health: 0 \n");
                        }

                    }
                }

                int pickWarrior = random.Next(0, warriors.Count);

                if (warriors.Count > 0 && monsterHealth > 0)
                {

                    int constitutionRoll = DiceRoll(1,20,5);

                    

                    Console.WriteLine($"The {monster} attacks {warriors[pickWarrior]}.");
                    Console.WriteLine($"{warriors[pickWarrior]} rolled a {constitutionRoll}.");

                    if (constitutionRoll > difficultyRoll)
                    {
                        Console.WriteLine($"Lucky. {warriors[pickWarrior]} was not affected.\n");
                    }
                    else
                    {
                        Console.WriteLine($"I am sorry, but {warriors[pickWarrior]} turned into stone.\n");
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
                Console.WriteLine($"{monster} died. We did it!!!\n");
               
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