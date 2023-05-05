using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    class User
    {
        //privata 2 dimensionella arrays för bookningar och bord. 
        private int[,] tables;
        private int[,] bookings;
        private int numBookings;

        //en constructor som skapar bord med platser och nummer samt en array för bokningar där 10 är max antal bokningar 
        //och sedan sparar den bordsnummer och antal gäster
        public User()
        {
            tables = new int[,] { { 1, 2 }, { 2, 4 }, { 3, 4 }, { 4, 4 }, { 5, 4 }, { 6, 4 }, { 7, 6 }, { 8, 6 }, { 9, 8 }, { 10, 8 } };
            bookings = new int[10, 2];
            numBookings = 0;
        }

        //virtuell metod som gör att den kan bli overriden i subclasserna. 
        public virtual void Start()
        {
            Console.WriteLine("Välkommen till restaurangen!");
            Console.WriteLine("--------------------------");

            // skapar en loop
            while (true)
            {

                Console.WriteLine("\nVad vill du göra?");
                Console.WriteLine("1. Boka ett bord");
                Console.WriteLine("2. Visa befintliga bokningar");
                Console.WriteLine("3. Avsluta programmet");

                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        Console.Clear();
                        BookTable();
                        break;

                    case "2":
                        Console.Clear();
                        ShowBookings();
                        break;

                    case "3":
                        Console.WriteLine("Tack för besöket, välkommen åter!");
                        Console.ReadLine();
                        return;


                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

            }
        }

        //metod för att boka bord. 
        public void BookTable()
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
            for (int i = 0; i < tables.GetLength(0); i++)
            {
                if (party <= tables[i, 1])
                {
                    tableIndex = i;
                    foundTable = true;
                    break;
                }
            }
            //ifall det inte finns ett bord får man ett felmedelande
            if (!foundTable)
            {
                Console.WriteLine("Tyvärr finns det inga lediga bord som rymmer det antal gäster du angav.");
            }
            
            else
            {
                //här står det vilket bord man fått
                Console.WriteLine($"Det lediga bordet med nummer {tables[tableIndex, 0]} har bokats för {name} med {party} gäster.");
                //programmet sparar vilket bord och hur många man var.
                bookings[numBookings, 0] = tables[tableIndex, 0];
                bookings[numBookings, 1] = party;
                //lägger till en bokning i numBookings.
                numBookings++;

                //skapar en ny array som är ett nummer mindre än den tidigare. 
                int[,] newTables = new int[tables.GetLength(0) - 1, 2];
                int j = 0;

                //kopierar in alla bord i den nya arrayen förutom det som nyss blivit bokat. 
                for (int i = 0; i < tables.GetLength(0); i++)
                {
                    if (i != tableIndex)
                    {
                        newTables[j, 0] = tables[i, 0];
                        newTables[j, 1] = tables[i, 1];
                        j++;
                    }
                }
                //sätter tables till newtables vilket gör att man inte kan boka bokade bord. 
                tables = newTables;
            }
        }
        //metod för att se bokningar. 
        public void ShowBookings()
        {
            //om numbookings är 0 får man felmedelande 
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
                }
            }
        }
    }
}
