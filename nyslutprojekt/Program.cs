using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    class program
    {
        static void Main(string[] args)
        {
            Restaurangbokning bokningssytem = new Restaurangbokning();
            bokningssytem.Start();
        }
    }
}
