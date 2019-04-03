using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo.Classes
{
    //Soft Delete yaptığımı belirtmek için
    public abstract class DbObjectSD : DbObject
    {
        public bool GecerliMi { get; set; }
        public DbObjectSD()
        {
            GecerliMi = true;
        }
    }
}
