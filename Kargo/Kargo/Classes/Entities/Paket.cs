using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo.Classes
{
    public class Paket :DbObjectSD
    {
        public PaketDurumu PaketDurumu { get; set; }
    }

    public enum PaketDurumu
    {
        Tasimada,
        Subede,
        Yolda,
        TeslimEdildi
    }
}
