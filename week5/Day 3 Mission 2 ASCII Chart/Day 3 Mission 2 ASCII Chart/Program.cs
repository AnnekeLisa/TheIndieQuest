using System;

namespace Day_3_Mission_2_ASCII_Chart
{
    class Program
    {
        static void Main(string[] args)
        {
            int asciiCharakterNumber = 0;
            int decimalNumber = 0;

            for (int i = 0; i < 250; i++)
            {
                char asciicharacter = (char)asciiCharakterNumber;

                Console.WriteLine($"{decimalNumber} = {asciicharacter}");

                asciiCharakterNumber++;
                decimalNumber++;
            }
        }
    }
}
