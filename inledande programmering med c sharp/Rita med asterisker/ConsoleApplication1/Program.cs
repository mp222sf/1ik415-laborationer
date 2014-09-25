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
            // Loopar raderna. Max 25 rader.
            for (int row = 1; row <= 25; row++)
            {
                // Gör inskutning på varannan rad.
                if (row % 2 == 0)
                {
                    Console.Write(" ");
                }

                // Skiftar mellan tre olika färger.
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

                // Loopar stjärnor på varje rad. Max 39 stjärnor.
                for (int col = 1; col <= 39; col++)
                {
                    Console.Write("* ");
                }

                // Radbrytning.
                Console.WriteLine();
            }
            
            // Återställer färgen till vit.
            Console.ResetColor();
        }
    }
}
