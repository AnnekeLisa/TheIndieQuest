using System;

namespace RecursiveMethods
{
    class Program
    {
        static int Factorial(int n)
        {
            //[n × (n - 1) × (n - 2) × … × 1]

            if (n == 0)
            {
                return 1;
            }
            else 
            {
                return n * Factorial(n-1);
            }

        }

        static void Main(string[] args)
        {

            var random = new Random();
            int magicNumber = random.Next(0,11);

            Console.Write($"{magicNumber}! = ");
            
            Console.WriteLine(Factorial(magicNumber));


        }
    }
}
