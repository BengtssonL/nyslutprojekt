using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    class Arbetare : User
    { 
        public Arbetare () : base ()
        {
        }

        public override void Start(Table[] tables)
        {
            while (true)
            {

                Console.WriteLine("\nVad vill du göra?");
                Console.WriteLine("1. Boka ett bord");
                Console.WriteLine("2. Se bokningar");
                Console.WriteLine("3. gå tillbaka till första menyn");

                int val = int.Parse(Console.ReadLine());


                switch (val)
                {
                    case 1:
                        Console.Clear();
                        BookTable(tables);
                        break;

                    case 2:
                        Console.Clear();
                        ShowBookings();
                        Console.ReadLine();
                        return;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("går tillbaka till första menyn");
                        Console.ReadLine();
                        return;

                    //ifall man skriver fel får man ett felmedelande
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }

    }
}
