using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    class Kund : User
    {
        //constructor
        public Kund() : base()
        {

        }
        //overridar start så att den får bara har boka bort och gå tillbaka till första menyn 
        public override void Start()
        {
            //loopar tills man välher case 2 att gå tillbaka till menyn
            while (true)
            {

                Console.WriteLine("\nVad vill du göra?");
                Console.WriteLine("1. Boka ett bord");
                Console.WriteLine("2. gå tillbaka till första menyn");

                int val = int.Parse(Console.ReadLine());


                switch (val)
                {
                    case 1:
                        Console.Clear();
                        BookTable();
                        break;

                    case 2:
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
