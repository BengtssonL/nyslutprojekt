using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    abstract class User
    {
        protected Table[] tables;
        private int[,] bookings; 
        private int numBookings = 0;

        public User(Table[] tables, int[,] bookings, int numBookings)
        {
            this.tables = tables;
            this.bookings = bookings;
            this.numBookings = numBookings;
            
        }

        public User()
        {
            // Startar tables arrayen som en tom array
            this.tables = new Table[0]; 
            // starta bookings arrayen som har plats för 10 bokningar
            this.bookings = new int[10, 2]; 
            this.numBookings = 0;
        }

        //virtuell metod som gör att den kan bli overriden i subclasserna. 
        public abstract void Start(Table[] tables);


        //metod för att boka bord. 
        public void BookTable(Table[] tables)
        {
            //frågar om namn och antal gäster
            Console.Write("Ange ditt namn: ");
            string name = Console.ReadLine();
            Console.Write("Ange antal gäster: ");
            var partyasstring = Console.ReadLine();

            int party;

            //testar att parsa partyasstring och om det inte funkar ber den använadren att skriva om.
            //Om det funkar updateras party med det nya värdet
            while (!int.TryParse(partyasstring, out party))
            {
                Console.WriteLine("skriv ett nummer tack :)");
                partyasstring = Console.ReadLine();
            }


            bool foundTable = false;
            int tableIndex = 0;
            //kollar ifall det finns ett bord för gruppen
            for (int i = 0; i < tables.Length; i++)
            {
                if (!tables[i].Isbooked && party <= tables[i].Size)
                {
                    tableIndex = i;
                    foundTable = true;
                    break;
                }
            }
            //ifall det inte finns ett bord får man det här meddelandet
            if (!foundTable)
            {
                Console.WriteLine("Tyvärr finns det inga lediga bord som rymmer det antal gäster du angav.");
            }
            else
            {
                //här står det vilket bord man fått
                Console.WriteLine($"Det lediga bordet med nummer {tables[tableIndex].TableNumber} har bokats för {name} med {party} gäster.");
                //programmet sparar vilket bord och hur många man var.
                bookings[numBookings, 0] = tables[tableIndex].TableNumber;
                bookings[numBookings, 1] = party;
                //lägger till en bokning i numBookings.
                numBookings++;

                //tables.isbooked ändras till true
                tables[tableIndex].Isbooked = true;

                //skapar en ny array som är ett nummer mindre än den tidigare. 
                Table[] newTables = new Table[tables.Length - 1];
                int j = 0;
                for (int i = 0; i < tables.Length; i++)
                {
                    if (i != tableIndex)
                    {
                        newTables[j] = tables[i];
                        j++;
                    }
                }
                tables = newTables;
            }
        }
        //metod för att se bokningar. 
        public void ShowBookings()
        {
            //om numbookings är 0 får man detta meddelandet
            if (numBookings == 0)
            {
                Console.WriteLine("Det finns inga bokningar just nu.");
            }
            else
            {
                Console.WriteLine("Befintliga bokningar:");
                Console.WriteLine("---------------------");

                //en for loop som håller på tills i är lika med numBookings
                for (int i = 0; i < numBookings; i++)
                {
                    Console.WriteLine($"Bord {bookings[i, 0]} är bokat för {bookings[i, 1]} gäster.");
                    Console.WriteLine($"Det är {numBookings} antal bokningar");
                }
            }
        }
    }
}
