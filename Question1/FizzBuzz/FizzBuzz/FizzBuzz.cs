using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class FizzBuzz
    {
        static void Main(string[] args)
        {
            Console.Write("Input the limit: ");
            int limit = int.Parse(Console.ReadLine());
            int max = 1;
            int multi = 10;

            for (int x = 0; x < 5; x++)
            {
                max *= multi;
            }

            if (limit > 0 && limit < (2 * max))
            {
                for (int i = 1; i <= limit; i++)
                {

                    if (i % 3 == 0)
                    {
                        Console.Write("Fizz");
                    }
                    if (i % 5 == 0)
                    {
                        Console.Write("Buzz");
                    }

                    if (!((i % 3 == 0) || (i % 5 == 0) || (i % 15 == 0)))
                    {
                        Console.Write(i);
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Out of bounds limit");
            }

            Console.ReadKey();
        }
    }
}
