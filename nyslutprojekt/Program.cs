using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //hade tänkt använda så att kund och arbetare kan få tillgång till varandras bokningar. 
            List<string> bookings = new List<string>();

            //variabel för switchen
            int val;
            User program = new User();
            Kund kund = new Kund();

            Arbetare arbetare = new Arbetare();

            while (true)
            {
                //frågar användaren om det är en kund eller arbetare.
                Console.WriteLine("Är du en kund eller arbetare?");
                Console.WriteLine("1. Kund");
                Console.WriteLine("2. Arbetare");

                val = int.Parse(Console.ReadLine());

                //switch för att hantera användarens val 
                switch (val)
                {
                    case 1:
                        //kallar på kundens start
                        Console.Clear();
                        kund.Start();
                        break;

                    case 2:
                        //kallar på arbetarens start som är samma som user. 
                        Console.Clear();
                        arbetare.Start();
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }

        }
    }
}
