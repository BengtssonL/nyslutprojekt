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
            //variabel för switchen
            int val;
            Kund kund = new Kund();
            Arbetare arbetare = new Arbetare();
            Table[] tables;

            //lägger in bord i arrayen med storlek och bordsnummer och sparar det i tables variabeln.
                tables = new Table[]
                 {
                    new Table(4,1),
                    new Table(2, 2),
                    new Table(3, 3),
                    new Table(4, 4),
                    new Table(2, 5),
                    new Table(3, 6),
                    new Table(7, 7)
                };



            while (true)
            {
                //frågar användaren om det är en kund eller arbetare.
                Console.WriteLine("Är du en kund eller arbetare?");
                Console.WriteLine("1. Kund");
                Console.WriteLine("2. Arbetare");
                Console.WriteLine("3. om du vill lämna");

                val = int.Parse(Console.ReadLine());

                //switch för att hantera användarens val 
                switch (val)
                {
                    case 1:
                        //kallar på kundens start
                        Console.Clear();
                        kund.Start(tables);
                        break;

                    case 2:
                        //kallar på arbetarens start som är samma som user. 
                        Console.Clear();
                        arbetare.Start(tables);
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }

        }
    }
}
