using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo.Classes
{
    public class Gonderen : DbObjectHD
    {
        public Gonderen(string adi)
        {
            Adi = adi;
        }
        public Gonderen()
        {

        }

        public string Adi { get; set; }
    }
}
