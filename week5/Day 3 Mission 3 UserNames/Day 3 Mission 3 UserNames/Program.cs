using System;

namespace Day_3_Mission_3_UserNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Anneke123";

            if (isValidUsername(name))
            {
                Console.WriteLine($"{name} is a valid user name.");
            }
            if (!isValidUsername(name))
            {
                Console.WriteLine($"{name} is not a valid user name. Please only use lower case characters and numbers.");
            }
        }

        static bool isValidUsername(string name)
        {
            bool validUsername = true;
            string specialChar = @"\\|_!#$%&/()=?»«@£§€{}.-;'<>_,";

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

                foreach(char special in specialChar)
                {
                    if (c == special)
                    {
                        validUsername = false;
                    }
                }
            }
            return validUsername;
        }
    }
}
