using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Dao
{
    internal class TagDao : BaseDao<Tag>
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAll()
        {

        }

        public Tag GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Tag GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(Tag entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Tag entity)
        {
            throw new NotImplementedException();
        }
    }
}
