using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreislerDoga
{
    class Könyv
    {
        public string Cím { get; set; }
        public string Típus { get; set; }

        public static List<Könyv> könyvek = new List<Könyv>();
        public static List<string> könyv_types = new List<string> { "Romantikus regények", "Történelmi regények", "Misztikus könyvek" };



        public Könyv(string cím, string típus)
        {
            Cím = cím;
            Típus = típus;
        }

        public override string ToString()
        {
            return Cím + " " + Típus;
        }

    }
}
