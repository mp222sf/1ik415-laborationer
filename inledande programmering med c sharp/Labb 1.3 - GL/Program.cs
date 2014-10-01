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
                // Loopar inläsningen av antal löner.
                //for (int col2 = 0; col2 <= 1 && col2 >= 0; col2++)
                //{
                    // Kollar att "Antal löner..." är ett korrekt värde. Kastar undantag vid fel.
                    //try
                    //{
                        // Läser in ett värde från ReadInt metoden.
                        count = ReadInt("Ange antal löner att mata in: ");
                        //if (count > int.MaxValue)
                        //{
                        //    throw new OverflowException();
                        //}
                        //if (count <= 0)
                        //{
                        //    throw new ArgumentNullException();
                        //}
                        //if (count == 1)
                        //{
                        //    throw new ArgumentException();
                        //}
                        //col2++;
                        // Är "Antal löner..." ett korrekt värde så startas metoden ProcessSalaries.
                        ProcessSalaries(count);
                    //}
                    //catch (OverflowException)
                    //{
                    //    Console.BackgroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Fel! Talet du angivit är för stort.");
                    //    Console.ResetColor();
                    //    col2--;
                    //}
                    //catch (FormatException)
                    //{
                    //    Console.BackgroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Fel format! Det du angivit är inte ett heltal.");
                    //    Console.ResetColor();
                    //    col2--;
                    //}
                    //catch (ArgumentNullException)
                    //{
                    //    Console.BackgroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Fel! Talet du har angivit är ett för litet tal (0 eller negativt tal).");
                    //    Console.ResetColor();
                    //    col2--;
                    //}
                    //catch (ArgumentException)
                    //{
                    //    // Har "Antal löner..." värdet 1 ställs frågan om programmet ska avslutas.
                    //    // För att fortsätta - tryck valfri knapp (förutom ESC)
                    //    Console.WriteLine();
                    //    Console.BackgroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Fel! Du angav endast 1 lön. Minimum är 2.");
                    //    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    //    Console.WriteLine();
                    //    Console.WriteLine("Tryck valfri tagent för att fortsätta - ESC avslutar");
                    //    Console.ResetColor();

                    //    // Vid ESC avslutas programmet. Startas annars om.
                    //    ConsoleKeyInfo inläsning_konsolknapp;
                    //    Console.WriteLine();
                    //    inläsning_konsolknapp = Console.ReadKey();

                    //    if (inläsning_konsolknapp.Key != ConsoleKey.Escape)
                    //    {
                    //        // Loopar om och kör inläsning av "Antal löner..." igen.
                    //    }
                    //    else
                    //    {
                    //        break;
                    //    }

                    //    col2--;
                    //}
                //}
                
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Tryck valfri tagent för att fortsätta - ESC avslutar");
                Console.ResetColor();

                // Avslutar programmet om ESC matas in.
                ConsoleKeyInfo inläsning_konsol_knapp2;
                inläsning_konsol_knapp2 = Console.ReadKey();
                Console.WriteLine();

                if (inläsning_konsol_knapp2.Key != ConsoleKey.Escape)
                {
                    // Loopar om och kör programmet igen.
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

            // Läs in "Antal löner...". Loopa vid felkod.
            //for (int col = 0; col < count; col++)
            //{
                //try
                //{
                    löner_värde = ReadInt(String.Format("Ange lön nummer {0}           : ", col + 1));

                    //if (löner_värde > 2000000000)
                    //{
                    //    throw new OverflowException();
                    //}
                    //if (löner_värde <= 0)
                    //{
                    //    throw new ArgumentNullException();
                    //}
                   
                    löner[col] = löner_värde;
                    löner_kopia[col] = löner_värde;
                //}

                //catch (OverflowException)
                //{
                //    Console.BackgroundColor = ConsoleColor.Red;
                //    Console.WriteLine("Fel summa! Tal större än 2000000000.");
                //    Console.ResetColor();
                //    col--;
                //}
                //catch (FormatException)
                //{
                //    Console.BackgroundColor = ConsoleColor.Red;
                //    Console.WriteLine("Fel format!");
                //    Console.ResetColor();
                //    col--;
                //}
                //catch (ArgumentNullException)
                //{
                //    Console.BackgroundColor = ConsoleColor.Red;
                //    Console.WriteLine("Fel summa! 0 eller ett negativt tal!");
                //    Console.ResetColor();
                //    col--;
                //}
            //}

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");

            // Sorterar Array.
            Array.Sort(löner);

            // Räknar median vid udda och jämna tal.
            if (löner.Length % 2 == 0)
            {
                löner_median = löner[löner.Length / 2 - 1] + löner[(löner.Length / 2)];
                löner_median = löner_median / 2;
                löner_median = löner_median + 0.5;
                Console.WriteLine("{0,-27} {1} {2,15:c0}", "Medianlön", ":", (int)löner_median);
            }
            else
            {
                löner_median = löner.Length / 2;
                Console.WriteLine("{0,-27} {1} {2,15:c0}", "Medianlön", ":", löner[(int)löner_median]);
            }

            // Räknar medelvärde och lönespridning.
            Console.WriteLine("{0,-27} {1} {2,15:c0}", "Medellön", ":", (int)(löner.Average() + 0.5));
            Console.WriteLine("{0,-27} {1} {2,15:c0}", "Lönespridning", ":", Convert.ToInt32(löner[löner.Length - 1] - löner[0]));
            Console.WriteLine("----------------------------------------------");

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

            

            for (int col = 0; col <= 0 && col >= 1; col++)
            {
                string input;
                int löner_input;

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
                    {
                        throw new ArgumentException();
                    }
                    
                    
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

                
                break;
                
                
            }
            return löner_input;

        }


    }
}
