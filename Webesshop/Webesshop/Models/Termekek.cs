using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webesshop.Models
{
    internal class Termekek
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Ar { get; set; }
        public string Kategoria { get; set; }

        public Termekek(string nev, int ar, string kategoria)
        {
            Nev = nev;
            Ar = ar;
            Kategoria = kategoria;
        }

        public Termekek()
        {
        }
    }
}
