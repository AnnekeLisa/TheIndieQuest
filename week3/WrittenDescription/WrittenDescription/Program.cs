﻿using System;

namespace WrittenDescription
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 132;
            Console.WriteLine($"{IntToOrd(num)}");
        }

        static string IntToOrd(int num)
        {
            
            int lastDigit = num % 10;
            int secondtolast;

            if (num > 10)
            {
                secondtolast = (num / 10) % 10;


                if (secondtolast == 1)
                {
                    return $"{num}th";
                }

            }

            if(lastDigit == 1)
            {
                return $"{num}st";
            }

            if (lastDigit == 2)
            {
                return $"{num}nd";
            }

            if (lastDigit == 3)
            {
                return $"{num}rd";
            }

            else
            {
                return $"{num}th";
            }

            
        }


    }

}
