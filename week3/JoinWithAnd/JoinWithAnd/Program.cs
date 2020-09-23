using System;
using System.Collections.Generic;

namespace JoinWithAnd
{
    class Program
    {
        static void Main(string[] args)
        {
            var warriors = new List<string> { "Johanna", "Matts", "Nor", "David" };

            Console.WriteLine($"Our heroes: {JoinWithAnd(warriors, false)}");
            
        }

        static string JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
            int count = items.Count;

            if(count == 0)
            {
                return "";
            }
            else if (count == 1)
            {
                return items[0];
            }
            else if (count == 2)
            {
                return items[0] + " and " + items[1];
            }
            else
            {
                var itemsCopy = new List<string>(items);

                if(useSerialComma == true)
                {
                    itemsCopy[itemsCopy.Count - 1] = ($"and {itemsCopy[itemsCopy.Count - 1]}");
                    return String.Join(", ", itemsCopy);
                }
                else
                {
                    itemsCopy[itemsCopy.Count - 2] = ($"{ itemsCopy[itemsCopy.Count - 2]} and { itemsCopy[itemsCopy.Count - 1]}");
                    itemsCopy.RemoveAt(itemsCopy.Count - 1);
                    return String.Join(", ", itemsCopy);
                }
            }

           
               

        }


    }
}
