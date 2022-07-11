using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public interface BaseDao<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public T GetByName(string name);
        public void Update(T entity);
        public void DeleteById(int id);
        public void Save(T entity);
    }
}
