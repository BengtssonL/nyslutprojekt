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
                        BookTable();
                        break;

                    case "2":
                        ShowBookings();
                        break;

                    case "3":
                        Console.WriteLine("Tack för besöket, välkommen åter!");
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

            }
        }
        private void BookTable()
        {
            Console.Write("Ange ditt namn: ");
            string name = Console.ReadLine();
            Console.Write("Ange antal gäster: ");
            int party = int.Parse(Console.ReadLine());

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
                bookings[numBookings, 2] = DateTime.Now.DayOfYear;
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
        private void ShowBookings()
        {

        }
    }
}

