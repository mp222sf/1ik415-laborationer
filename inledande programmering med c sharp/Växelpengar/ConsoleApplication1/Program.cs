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
            uint total;
            double rounding_off_amount;
            int five_hundred_skr;
            int one_hundred_skr;
            int fifty_skr;
            int twenty_skr;
            int ten_skr;
            int five_skr;
            int one_skr;

            // här skriver man in de olika beloppen.
            Console.Write("Ange totalsumma     : ");
            input = Console.ReadLine();
            exact_amount_to_pay = double.Parse(input);


            // Kolla så att beloppet är större än 0.50 kr.
            if (exact_amount_to_pay < 0.50)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Beloppet är mindre än 0,50 kr. Kan därför inte genomföra köpet.");
                Console.BackgroundColor = ConsoleColor.Black;
            }

            else
            {

                Console.Write("Ange erhållet belopp: ");
                input = Console.ReadLine();
                amount_of_cash_paid = int.Parse(input);


                // Räkna öresavrundning.
                cash_to_pay = (uint)Math.Round(exact_amount_to_pay);
                rounding_off_amount = cash_to_pay - exact_amount_to_pay;
                rounding_off_amount = (double)Math.Round(rounding_off_amount, 2);

                // Räkna pengar tillbaka.
                cash_back = amount_of_cash_paid - cash_to_pay;

                // Räkna hur mycket av varje sedel eller mynt.
                five_hundred_skr = (int)cash_back / 500;
                one_hundred_skr = (int)cash_back % 500 / 100;
                fifty_skr = (int)cash_back % 500 % 100 / 50;
                twenty_skr = (int)(cash_back % 500 % 100 % 50) / 20;
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
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Totalt              : {0} kr", exact_amount_to_pay);
                    Console.WriteLine("Öresavrundning      : {0} kr", rounding_off_amount);
                    Console.WriteLine("Att betala          : {0} kr", cash_to_pay);
                    Console.WriteLine("Kontant             : {0} kr", amount_of_cash_paid);
                    Console.WriteLine("Tillbaka            : {0} kr", cash_back);
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("");

                    // Kontrollerar om sedlar/mynt är större än 1.
                    if (five_hundred_skr >= 1)
                    {
                        Console.WriteLine("500-lappar          : " + five_hundred_skr);
                    }

                    if (one_hundred_skr >= 1)
                    {
                        Console.WriteLine("100-lappar          : " + one_hundred_skr);
                    }

                    if (fifty_skr >= 1)
                    {
                        Console.WriteLine("50-lappar           : " + fifty_skr);
                    }

                    if (twenty_skr >= 1)
                    {
                        Console.WriteLine("20-lappar           : " + twenty_skr);
                    }

                    if (ten_skr >= 1)
                    {
                        Console.WriteLine("10-kronor           : " + ten_skr);
                    }

                    if (five_skr >= 1)
                    {
                        Console.WriteLine("5-kronor            : " + five_skr);
                    }

                    if (one_skr >= 1)
                    {
                        Console.WriteLine("1-kronor            : " + one_skr);
                    }
                }
            }

        }
    }
}
