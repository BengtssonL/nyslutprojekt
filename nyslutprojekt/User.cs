using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyslutprojekt
{
    class User
    {
        String name { get; set; }
        int id { get; set; }

        public User()
        {
            Restaurangbokning user = new Restaurangbokning();
            user.BookTable();

        }

    }
}