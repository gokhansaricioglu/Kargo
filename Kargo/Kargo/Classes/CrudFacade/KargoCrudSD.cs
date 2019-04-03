using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo.Classes.CrudFacade
{
    //Temel veritabanı işlemlerini SD için yapmak için
    public class KargoCrudSD<T> : ICargoRepository<T> where T : DbObjectSD
    {
        protected DbContext _database; //üzerinde çalışacağım veritabanı
        protected DbSet<T> _currentTable;//üzerinde çalışacağım tabloseti
        public KargoCrudSD(DbContext database, DbSet<T> currentTable)
        {
            _database = database;
            _currentTable = currentTable;
        }
        public List<T> Records
        {
            get
            {
                return _currentTable.Where(x=> x.GecerliMi == true).ToList();
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                entity.GecerliMi = false;
                _database.Entry(entity).CurrentValues.SetValues(entity);//Update
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
                var entity = Find(id);
                entity.GecerliMi = false;
                _database.Entry(entity).CurrentValues.SetValues(entity);//Update
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
            var entitty = Records.FirstOrDefault(x => x.Id == id);
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
