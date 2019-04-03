using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo.Classes
{
  
    // Veritabanı tabloları ile normal classları ayırt edebilmek için
    public abstract class DbObject
    {
        public string Id { get; set; }
        public string OlusturanKisi { get; set; }
        public DbObject()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
