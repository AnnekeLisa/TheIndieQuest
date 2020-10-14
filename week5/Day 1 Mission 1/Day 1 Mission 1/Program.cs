using System;

namespace Day_1_Mission_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDayDescription(3, 1, 1672);
        }

        static void CreateDayDescription(int day, int season, int year)
        {
            string[] seasons = { "Spring", "Summer", "Fall", "Winter" };

            Console.WriteLine($"{IntToOrd(day)} day of {seasons[season]} in the year {year}!");
            string currentSeason = seasons[season];
            return;
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

            if (lastDigit == 1)
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
