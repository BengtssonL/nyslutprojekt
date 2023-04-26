using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    class Restaurangbokning
    {

        private int[,] tables;
        private int[,] bookings;
        private int numBookings;

        public Restaurangbokning()
        {
            tables = new int[,] { { 1, 2 }, { 2, 4 }, { 3, 4 }, { 4, 4 }, { 5, 4 }, { 6, 4 }, { 7, 6 }, { 8, 6 }, { 9, 8 }, { 10, 8 } };
            bookings = new int[10, 3];
            numBookings = 0;
        }

        public void Start()
        {
            Console.WriteLine("Välkommen till restaurangen!");
            Console.WriteLine("--------------------------");

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
        public void BookTable()
        {
            Console.Write("Ange ditt namn: ");
            string name = Console.ReadLine();
            Console.Write("Ange antal gäster: ");
            var partyasstring = Console.ReadLine();

            int party;

            while (!int.TryParse(partyasstring, out party))
            {
                Console.WriteLine("skriv ett nummer tack :)");
                partyasstring = Console.ReadLine();
            }
            

            bool foundTable = false;
            int tableIndex = 0;

            for (int i = 0; i < tables.GetLength(0); i++)
            {
                if (party <= tables[i, 1])
                {
                    tableIndex = i;
                    foundTable = true;
                    break;
                }
            }
            if (!foundTable)
            {
                Console.WriteLine("Tyvärr finns det inga lediga bord som rymmer det antal gäster du angav.");
            }
            else
            {
                Console.WriteLine($"Det lediga bordet med nummer {tables[tableIndex, 0]} har bokats för {name} med {party} gäster.");
                bookings[numBookings, 0] = tables[tableIndex, 0];
                bookings[numBookings, 1] = party;
                numBookings++;

                int[,] newTables = new int[tables.GetLength(0) - 1, 2];
                int j = 0;

                for (int i = 0; i < tables.GetLength(0); i++)
                {
                    if (i != tableIndex)
                    {
                        newTables[j, 0] = tables[i, 0];
                        newTables[j, 1] = tables[i, 1];
                        j++;
                    }
                }
                tables = newTables;
            }
        }

        public void ShowBookings()
        {
            if (numBookings == 0)
            {
                Console.WriteLine("Det finns inga bokningar just nu.");
            }
            else
            {
                Console.WriteLine("Befintliga bokningar:");
                Console.WriteLine("---------------------");

                for (int i = 0; i < numBookings; i++)
                {
                    Console.WriteLine($"Bord {bookings[i, 0]} är bokat för {bookings[i, 1]} gäster.");
                }
            }
        }
    }
}

