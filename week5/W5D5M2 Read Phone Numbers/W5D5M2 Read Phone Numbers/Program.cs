using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace W5D5M2_Read_Phone_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Anni\Documents\GitHub\TheIndieQuest\week5\W5D5M2 Read Phone Numbers\message.txt";
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);

            string[] wordsOfReadText = readText.Split(' ', '.', ',');
            var phoneNumbers = new List<string>();

            foreach(string word in wordsOfReadText)
            {
                if (IsPhoneNumber(word))
                {
                    phoneNumbers.Add(word);
                }
            }

            Console.WriteLine($"Phone numbers in this file: {String.Join(", ", phoneNumbers)}");

        }

        static bool IsPhoneNumber(string word)
        {
            bool containsNumber = false;
            bool containsInt = word.Any(char.IsDigit);

            if(containsInt == true)
            {
                containsNumber = true;
            }

            return containsNumber;
        }

    }
}
