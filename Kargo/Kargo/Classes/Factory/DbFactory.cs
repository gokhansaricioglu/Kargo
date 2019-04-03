using Kargo.Classes.CrudFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo.Classes.Factory
{
    //Her yere yazemak yerine bir yere yazıp kullanmak -> Factory Design Pattern
    public static class DbFactory
    {
        //Birden fazla kez üretilmesini engellemek için ->Singleton
        private static volatile KargoContext _db = null;
        public static KargoContext Db
        {
            get
            {
                if (_db == null)
                {
                    _db = new KargoContext();
                }
                return _db;
            }
        }
        public static volatile KargoCrudHD<Gonderen> _gonderenkargoCrud = null;
        public static KargoCrudHD<Gonderen> GonderenKargoCrud
        {
            get
            {
                if (_gonderenkargoCrud == null)
                {
                    _gonderenkargoCrud = new KargoCrudHD<Gonderen>(Db, Db.Gonderenler);
                }
                return _gonderenkargoCrud;
            }
        }

        private static volatile PaketCrud<Paket> _paketCrud = null;
        public static PaketCrud<Paket> PaketCrud
        {
            get
            {
                if (_paketCrud == null)
                {
                    _paketCrud = new PaketCrud<Paket>(Db, Db.Paketler);
                }
                return _paketCrud;
            }
        }
    }
}
