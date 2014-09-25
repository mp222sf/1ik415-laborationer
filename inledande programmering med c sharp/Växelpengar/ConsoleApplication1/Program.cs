using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Växelpengar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarera variablar.
            double exact_amount_to_pay;
            int cash_to_pay;
            int amount_of_cash_paid;
            int cash_back;
            string input;
            double rounding_off_amount;

            while (true)
            {
                try
                {
                    Console.Write("Ange totalsumma     : ");
                    exact_amount_to_pay = double.Parse(Console.ReadLine());
                    if (exact_amount_to_pay > int.MaxValue)
                    {
                        throw new OverflowException();
                    }
                    break;
                }
                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("För stor summa!");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel format!");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }


            // Kolla så att beloppet är större än 0.50 kr.
            if (exact_amount_to_pay < 0.50)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Beloppet är mindre än 0,50 kr och är därför ingen giltig summa. Kan inte genomföra köpet.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Ange erhållet belopp: ");
                        input = Console.ReadLine();
                        amount_of_cash_paid = int.Parse(input);

                        if (amount_of_cash_paid > 2000000000)
                        {
                            throw new OverflowException();
                        }
                        break;
                    }
                    catch (OverflowException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("För stor summa!");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    catch (FormatException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel format!");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }

                // Räkna öresavrundning.
                cash_to_pay = (int)Math.Round(exact_amount_to_pay);
                rounding_off_amount = cash_to_pay - exact_amount_to_pay;
                rounding_off_amount = (double)Math.Round(rounding_off_amount, 2);

                // Räkna "pengar tillbaka".
                cash_back = amount_of_cash_paid - cash_to_pay;

             
                // Summan att betala ska vara mindre än mottaget belopp.
                if (cash_to_pay > amount_of_cash_paid)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erhållet belopp är mindre än {0} kr. Det saknas {1} kr att betala.", cash_to_pay, cash_to_pay - amount_of_cash_paid);
                    Console.WriteLine("Kan därför inte genomföra köpet");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                else
                {

                    // Skriver ut kvittot.
                    Console.WriteLine("");
                    Console.WriteLine("KVITTO");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("{0,-19} {1} {2,16:c}", "Totalt", ":", exact_amount_to_pay);
                    Console.WriteLine("{0,-19} {1} {2,16:c}", "Öresavrundning", ":", rounding_off_amount);
                    Console.WriteLine("{0,-19} {1} {2,16:c}", "Att betala", ":", cash_to_pay);
                    Console.WriteLine("{0,-19} {1} {2,16:c}", "Kontant", ":", amount_of_cash_paid);
                    Console.WriteLine("{0,-19} {1} {2,16:c}", "Tillbaka", ":", cash_back);
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("");

                    // Räknar ut antal av varje sedel/mynt.

                    if (cash_back > 500)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "500-lappar", ":", cash_back / 500);
                        cash_back %= 500;
                    }

                    if (cash_back > 100)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "100-lappar", ":", cash_back / 100);
                        cash_back %= 100;
                    }

                    if (cash_back > 50)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "50-lappar", ":", cash_back / 50);
                        cash_back %= 50;
                    }

                    if (cash_back > 20)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "20-lappar", ":", cash_back / 20);
                        cash_back %= 20;
                    }

                    if (cash_back > 10)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "10-kronor", ":", cash_back / 10);
                        cash_back %= 10;
                    }

                    if (cash_back > 5)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "5-kronor", ":", cash_back / 5);
                        cash_back %= 5;
                    }

                    if (cash_back > 1)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "1-kronor", ":", cash_back / 1);
                        cash_back %= 1;
                    }


                  
                }
            }

        }
    }
}
