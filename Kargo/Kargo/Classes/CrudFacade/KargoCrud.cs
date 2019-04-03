using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo.Classes.CrudFacade
{
    //Temel veritabanı işlemlerini yapmak için
    public class KargoCrudHD<T> : ICargoRepository<T> where T : DbObjectHD
    {
        private DbContext _database; //üzerinde çalışacağım veritabanı
        private DbSet<T> _currentTable;//üzerinde çalışacağım tabloseti
        public KargoCrudHD(DbContext database, DbSet<T> currentTable)
        {
            _database = database;
            _currentTable = currentTable;
        }
        public List<T> Records
        {
            get
            {
                return _currentTable.ToList();
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                _currentTable.Remove(entity);
                _database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                _currentTable.Remove(Find(id));
                _database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public T Find(string id)
        {
            var entitty = _currentTable.FirstOrDefault(x => x.Id == id);
            if (entitty != null)
            {
                return entitty;
            }
            else
            {
                return null;
            }
        }
        public bool Insert(T entity)
        {
            try
            {
                _currentTable.Add(entity);
                _database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(T oldEntity, T newEntity)
        {
            try
            {
                _database.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                _database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Update(string id, T newEntity)
        {
            try
            {
                var oldEntity = Find(id);
                _database.Entry(oldEntity).CurrentValues.SetValues(newEntity);
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
