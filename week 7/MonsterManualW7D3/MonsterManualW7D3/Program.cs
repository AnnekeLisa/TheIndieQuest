using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace MonsterManualW7D3
{
    class Program
    {
        //defining Monster Class, Amor Information Class and Armor Type Enum
        class MonsterEntry
        {
            public string Name;
            public string Description;
            public string Alignment;
            public string HitPoints;
            public ArmorInformation Armor = new ArmorInformation();
        }

        class ArmorInformation
        {
            public int Class;
            public ArmorType Type;
        }

        enum ArmorType
        {
            Unspecified,
            Natural,
            Leather,
            StuddedLeather,
            Hide,
            ChainShirt,
            ChainMail,
            ScaleMail,
            Plate,
            Other
        }

        static void Main(string[] args)
        {
            //declaring variables & get data from file

            string path = @"MonsterManual.txt";
            string readData = File.ReadAllText(path);
            string[] monsterData = readData.Split("\n\n");
            var monsterEntries = new List<MonsterEntry>();
            int listNumber = 0;
            
            var searchResults = new List<MonsterEntry>();

            //create monsterEntries out of the txt data
            foreach(string block in monsterData)
            {
                string[] blockLines = block.Split("\n");
                var monsterEntry = new MonsterEntry();

                //assigning name, description, alignment, hitpoints:
                monsterEntry.Name = blockLines[0];
                string[] descriptionAlignment = blockLines[1].Split(",");
                monsterEntry.Description = descriptionAlignment[0];
                monsterEntry.Alignment = descriptionAlignment[1];
                monsterEntry.HitPoints = blockLines[2];

                //assigning armor
                //blockline[3] structure: Armor Class: 17 (Natural Armor)
                string armorSubstring = blockLines[3].Substring(13);

                //assigning armor class
                string[] armorWords = armorSubstring.Split('(',')');
                monsterEntry.Armor.Class = int.Parse(armorWords[0]);

                //assigning armor type
                monsterEntry.Armor.Type = ArmorType.Unspecified;
                
                if (armorWords.Length > 1)
                {
                    switch (armorWords[1].ToLowerInvariant())
                    {
                        case "natural armor":
                            monsterEntry.Armor.Type = ArmorType.Natural;
                            break;
                        case "leather armor":
                            monsterEntry.Armor.Type = ArmorType.Leather;
                            break;
                        case "studded leather":
                            monsterEntry.Armor.Type = ArmorType.StuddedLeather;
                            break;
                        case "hide armor":
                            monsterEntry.Armor.Type = ArmorType.Hide;
                            break;
                        case "chain shirt":
                            monsterEntry.Armor.Type = ArmorType.ChainShirt;
                            break;
                        case "chain mail":
                            monsterEntry.Armor.Type = ArmorType.ChainMail;
                            break;
                        case "scale mail":
                            monsterEntry.Armor.Type = ArmorType.ScaleMail;
                            break;
                        case "plate":
                            monsterEntry.Armor.Type = ArmorType.ScaleMail;
                            break;
                        default:
                            monsterEntry.Armor.Type = ArmorType.Other;
                            break;
                    }
                }
                //add defined monster to list of monsterEntries 
                monsterEntries.Add(monsterEntry);
            }

            //start application: monster manual

            Console.WriteLine("MONSTER MANUAL");
            Console.WriteLine();
            Console.WriteLine("Do you want to search by (n)ame or by (a)rmorclass?");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine();


            //searching by armor
            if (choice == 'a')
            {
                string[] armorTypeNames = Enum.GetNames(typeof(ArmorType));
                int number = 0;

                //Display armor type list
                foreach (string name in armorTypeNames)
                {
                    number++;
                    Console.WriteLine($"{number}: {name}");
                }

                //Player chooses armortype, save the choice in a string
                Console.WriteLine();
                Console.WriteLine("Enter Number: ");
                string armorNumberStringInput = Console.ReadLine();
                int armorNumberInput = Int32.Parse(armorNumberStringInput);
                
                string selectedArmorName = armorTypeNames[armorNumberInput - 1];
                ArmorType selectedArmor = Enum.Parse<ArmorType>(selectedArmorName);

                //go through all monsterEntries and case by case select the right monsters to display

                foreach (MonsterEntry monster in monsterEntries)
                {
                    if (monster.Armor.Type == selectedArmor)
                    {
                        searchResults.Add(monster);
                    }
                }
            }
            //search by name/search for monster in list
            else
            {   //user searches for monstername once and repeats as long as no name is found
                do
                {
                    Console.WriteLine("Search for your favorite monster: ");
                    string playerSearch = Console.ReadLine();
                    Console.WriteLine();

                    foreach (MonsterEntry monster in monsterEntries)
                    {
                        var name = monster.Name;
                        //look for match by checking for equal string with .IndexOf (returns -1 if false)
                        int match = name.ToLowerInvariant().IndexOf(playerSearch.ToLowerInvariant());

                        if (match != -1)
                        {
                            searchResults.Add(monster);
                        }
                    }
                } while (searchResults.Count == 0);
            }

            MonsterEntry selectedMonster;
            //jump to displaying info if only one search result is found
            if (searchResults.Count == 1)
            {
                selectedMonster = searchResults[0];
            }
            //if more search results, list them in a numbered list
            else
            {
                foreach (MonsterEntry item in searchResults)
                {
                    listNumber++;
                    Console.WriteLine($"{listNumber}: {item.Name}");
                }

                //user chooses which monster to display information of
                Console.WriteLine();
                Console.WriteLine("Which monster do you want to know more about? Enter number: ");
                string playerNumberStringInput = Console.ReadLine();
                int playerNumberInput = Int32.Parse(playerNumberStringInput);
                selectedMonster = searchResults[playerNumberInput - 1];
            }

            //Display information about specific monster
            Console.WriteLine();
            Console.WriteLine($"Displaying Information about {selectedMonster.Name}: ");
            Console.WriteLine($"Name: {selectedMonster.Name}");
            Console.WriteLine($"Description: {selectedMonster.Description}");
            Console.WriteLine($"Alignment: {selectedMonster.Alignment}");
            Console.WriteLine($"{selectedMonster.HitPoints}");
            Console.WriteLine($"Armor Class: {selectedMonster.Armor.Class}");
            Console.WriteLine($"Armor Type: {selectedMonster.Armor.Type}");

            Console.ReadLine();
        }
    }
}
