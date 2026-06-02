using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webesshop.Models
{
    internal class Felhasznalok
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FelhasznaloNev { get; set; }
        public string TeljesNev { get; set; }
        public string Jelszo { get; set; }

        public Felhasznalok(string felhasznaloNev, string teljesNev, string jelszo)
        {
            FelhasznaloNev = felhasznaloNev;
            TeljesNev = teljesNev;
            Jelszo = jelszo;
        }

        public Felhasznalok()
        {
        }
    }
}
