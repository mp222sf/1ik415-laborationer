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
            double cash_to_pay;
            int amount_of_cash_paid;
            double cash_back;
            string input;
            double rounding_off_amount;
            int five_hundred_skr;
            int one_hundred_skr;
            int fifty_skr;
            int twenty_skr;
            int ten_skr;
            int five_skr;
            int one_skr;


            while (true)
            {
                try
                {
                    Console.Write("Ange totalsumma     : ");
                    exact_amount_to_pay = double.Parse(Console.ReadLine());
                    if (exact_amount_to_pay > 2000000000)
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
                cash_to_pay = (uint)Math.Round(exact_amount_to_pay);
                rounding_off_amount = cash_to_pay - exact_amount_to_pay;
                rounding_off_amount = (double)Math.Round(rounding_off_amount, 2);

                // Räkna "pengar tillbaka".
                cash_back = amount_of_cash_paid - cash_to_pay;

                // Räkna hur mycket av varje sedel eller mynt.
                five_hundred_skr = (int)cash_back / 500;
                one_hundred_skr = (int)cash_back % 500 / 100;
                fifty_skr = (int)cash_back % 500 % 100 / 50;
                twenty_skr = (int)cash_back % 500 % 100 % 50 / 20;
                ten_skr = (int)(cash_back % 500 % 100 % 50 % 20) / 10;
                five_skr = (int)(cash_back % 500 % 100 % 50 % 20 % 10) / 5;
                one_skr = (int)(cash_back % 500 % 100 % 50 % 20 % 10 % 5) / 1;

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
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("{0,-19} {1} {2,11}", "Totalt", ":", exact_amount_to_pay + " kr");
                    Console.WriteLine("{0,-19} {1} {2,11}", "Öresavrundning", ":", rounding_off_amount + " kr");
                    Console.WriteLine("{0,-19} {1} {2,11}", "Att betala", ":", cash_to_pay + " kr");
                    Console.WriteLine("{0,-19} {1} {2,11}", "Kontant", ":", amount_of_cash_paid + " kr");
                    Console.WriteLine("{0,-19} {1} {2,11}", "Tillbaka", ":", cash_back + " kr");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("");

                    // Kontrollerar att sedlar/mynt är större än 1.
                    if (five_hundred_skr >= 1)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "500-lappar", ":", (int)cash_back / 500);
                    }

                    if (one_hundred_skr >= 1)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "100-lappar", ":", (int)cash_back % 500 / 100);
                    }

                    if (fifty_skr >= 1)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "50-lappar", ":", (int)cash_back % 500 % 100 / 50);
                    }

                    if (twenty_skr >= 1)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "20-lappar", ":", (int)cash_back % 500 % 100 % 50 / 20);
                    }

                    if (ten_skr >= 1)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "10-kronor", ":", (int)cash_back % 500 % 100 % 50 % 20 / 10);
                    }

                    if (five_skr >= 1)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "5-kronor", ":", (int)cash_back % 500 % 100 % 50 % 20 % 10 / 5);
                    }

                    if (one_skr >= 1)
                    {
                        Console.WriteLine("{0,-19} {1} {2}", "1-kronor", ":", (int)cash_back % 500 % 100 % 50 % 20 % 10 % 5 / 1);
                    }
                }
            }

        }
    }
}
