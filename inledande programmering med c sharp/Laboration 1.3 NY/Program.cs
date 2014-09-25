using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_1._3_NY
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            count = ReadInt("Ange antal löner att mata in: ");

            ProcessSalaries(count);

        }

        private static void ProcessSalaries(int count)
        {
        }

        private static int ReadInt(string prompt)
        {
            string input;
            int löner_input = 0;

            for (int col = 0; col >= 0 && col <= 1; col++)
            {
                Console.Write(prompt);
                input = Console.ReadLine();


                try
                {
                    löner_input = int.Parse(input);

                    if (löner_input > 2000000000)
                    {
                        throw new OverflowException();
                    }

                    if (löner_input <= 0)
                    {
                        throw new ArgumentNullException();
                    }
                    col++;
                }

                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel summa! Tal större än 2000000000.");
                    Console.ResetColor();
                    col--;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel format!");
                    Console.ResetColor();
                    col--;
                }
                catch (ArgumentNullException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel summa! 0 eller ett negativt tal!");
                    Console.ResetColor();
                    col--;
                }

            }


            
            return löner_input;
            
        }
    }
}
