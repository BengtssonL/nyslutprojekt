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


        static void Main(string[] args)
        {
        }
    }
}
