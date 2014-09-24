using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {



            for (int row = 1; row <= 25; row++)
            {



                if (IsEven(row))
                {
                    Console.Write(" ");
                }
                
                for (int col = 1; col <= 39; col++)
                {
                    switch (row % 3)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }
                    Console.Write("* ");
                }

                Console.WriteLine();



             }
            Console.ForegroundColor = ConsoleColor.White;
           }

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

    }
}
