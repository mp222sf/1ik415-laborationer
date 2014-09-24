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

                for (int col2 = 0; col2 <= 1 && col2 >= 0; col2++)
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
                        col2++;
                        ProcessSalaries(count);
                    }
                    catch (OverflowException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel! Talet du angivit är större än 2000000000.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        col2--;
                    }

                    catch (FormatException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel format! Det du angivit är inte ett heltal.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        col2--;
                    }

                    catch (ArgumentNullException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel! Talet du har angivit är ett för litet tal (0 och negativa tal).");
                        Console.BackgroundColor = ConsoleColor.Black;
                        col2--;
                    }
                    catch (ArgumentException)
                    {

                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel! Du angav endast 1 lön. Minimum är 2.");
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine();
                        Console.WriteLine("Tryck tagent för att fortsätta - ESC avslutar");
                        Console.BackgroundColor = ConsoleColor.Black;

                        ConsoleKeyInfo inläsning_konsol_knapp;

                        inläsning_konsol_knapp = Console.ReadKey();
                        Console.WriteLine();




                        if (inläsning_konsol_knapp.Key != ConsoleKey.Escape)
                        {

                        }
                        else
                        {
                            break;
                        }

                        col2--;



                    }
                }

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Tryck tagent för att fortsätta - ESC avslutar");
                Console.BackgroundColor = ConsoleColor.Black;

               
                ConsoleKeyInfo inläsning_konsol_knapp2;

                inläsning_konsol_knapp2 = Console.ReadKey();
                Console.WriteLine();

                if (inläsning_konsol_knapp2.Key != ConsoleKey.Escape)
                {

                }
                else
                {
                    break;
                }

            }  

        }

        private static void ProcessSalaries(int count)
        {

            // Deklarera variablar.
            int löner_värde;
            double löner_median;

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
                löner_median = löner[löner.Length / 2 - 1] + löner[(löner.Length / 2)];
                löner_median = Convert.ToDouble(löner_median / 2);
                löner_median = Math.Round(löner_median);
                Console.WriteLine("{0,-27} {1} {2,10} kr", "Medianlön", ":", Convert.ToInt32(löner_median));
            }
            else
            {

                löner_median = löner.Length / 2;
                Console.WriteLine("{0,-27} {1} {2,10} kr", "Medianlön", ":", löner[Convert.ToInt32(löner_median)]);
                
            }




            Console.WriteLine("{0,-27} {1} {2,10} kr", "Medellön", ":", Convert.ToInt32(löner.Average()));
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
