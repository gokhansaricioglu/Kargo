using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo.Classes.CrudFacade
{
    //Eğer Tablolarımda temel CRUD harici bir işlem yapacak isem 
    //Crud classından inherit alan yeni bir class açıp o class'a yazıyorum
    public class PaketCrud<T> : KargoCrudSD<T> where T : Paket
    {
        public PaketCrud(DbContext database, DbSet<T> currentTable) : base(database, currentTable)
        {
            //Bir üstteki classın constructoruna bu constructordan gelen verileri at
            //Auto-Generated
        }


        public bool PaketDurumuGuncelle(string paketId, PaketDurumu paketDurumu)
        {
            try
            {
                var entity = Find(paketId);
                entity.PaketDurumu = paketDurumu;
                _database.Entry(entity).CurrentValues.SetValues(entity);
                _database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
