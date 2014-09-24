using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_1._3___GL
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;


            for (int col = 0; col <= 1 && col >= 0; col++)
            {
                try
                {
                    count = ReadInt("Ange antal löner att mata in: ");
                    if (count > 2000000000)
                    {
                        throw new OverflowException();
                    }
                    if (count <= 0)
                    {
                        throw new ArgumentNullException();
                    }
                    if (count == 1)
                    {
                        throw new ArgumentException();
                    }
                    col++;
                }
                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel summa! Tal större än 2000000000.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    col--;
                }

                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel format!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    col--;
                }

                catch (ArgumentNullException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel summa! 0 eller ett negativt tal!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    col--;
                }
                catch (ArgumentException)
                {
                    

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Talet är 1????");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Tryck tagent för att fortsätta - ESC avslutar");


                    
                    col--;

                }
            }



            ProcessSalaries(count);
            

        }

        private static void ProcessSalaries(int count)
        {

            // Deklarera variablar.
            int löner_värde;
            double löner_median_jämnt;
            int löner_median_udda;
            double löner_median_udda_double;

            // Skapa arrayer
            int[] löner = new int[count];
            int[] löner_kopia = new int[count];

            // Läs in antal löner. Loopa vid felkod.
            for (int col = 0; col <= count - 1; col++)
            {
                try
                {

                    
                    löner_värde = ReadInt(String.Format("Ange lön nummer {0}           : ", col + 1));
                    if (löner_värde > 2000000000)
                    {
                        throw new OverflowException();
                    }
                    if (löner_värde <= 0)
                    {
                        throw new ArgumentNullException();
                    }
                   
                    löner[col] = löner_värde;
                    löner_kopia[col] = löner_värde;
                    
                }
                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel summa! Tal större än 2000000000.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    col--;
                }

                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel format!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    col--;
                }

                catch (ArgumentNullException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel summa! 0 eller ett negativt tal!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    col--;
                }
              
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");


            // Sorterar Array.
            Array.Sort(löner);

            // Räknar median, medelvärde och lönespridning.
            if (Is_Even(löner.Length))
            {
                löner_median_jämnt = (löner[löner.Length / 2 - 1] + löner[(löner.Length / 2)]);
                Console.WriteLine("{0,-27} {1} {2,10} kr", "Medianlön", ":", Convert.ToInt32(löner_median_jämnt / 2));
            }
            else
            {

                if (count <= 1)
                {
                    löner_median_udda = Convert.ToInt32(löner.Length / 2 + 0.5);
                    Console.WriteLine("{0,-27} {1} {2,10} kr", "Medianlön", ":", Convert.ToInt32(löner[löner_median_udda]));
                }
                else
                {
                    löner_median_udda_double = löner.Length / 2;
                    löner_median_udda = Convert.ToInt32(löner_median_udda_double);
                    Console.WriteLine("{0,-27} {1} {2,10} kr", "Medianlön", ":", Convert.ToInt32(löner[löner_median_udda]));
                }

            }




            Console.WriteLine(String.Format("{0,-27} {1} {2,10} kr", "Medellön", ":", Convert.ToInt32(löner.Average())));
            Console.WriteLine("{0,-27} {1} {2,10} kr", "Lönespridning", ":", Convert.ToInt32(löner[löner.Length - 1] - löner[0]));

            Console.WriteLine("--------------------------------------------");

            // Skriva ut talen i Arrayen.
            for (int col = 0; col <= count - 1; col++)
            {
               
            Console.Write(String.Format("{0,10}", löner_kopia[col]));
                if (col % 3 == 2)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();


        }

        private static int ReadInt(string prompt)
        {

            string input;
            int löner_input;

            Console.Write(prompt);
            input = Console.ReadLine();
            löner_input = int.Parse(input);

            return löner_input;

        }

        private static bool Is_Even(int value)
        {
            return value % 2 == 0;
        }
    }
}
