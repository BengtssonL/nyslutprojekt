using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    class Table
    {
        public int Size { get; set; }
        public int TableNumber { get;}

        public bool Isbooked { get; set; }
       
        
        public Table(int size, int tableNumber)
        {
            Size = size;
            TableNumber = tableNumber;
            Isbooked = false;
        }


    }
}
