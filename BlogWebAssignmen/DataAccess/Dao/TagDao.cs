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
        private string connectionString;
        internal TagDao(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAll()
        {
            var result = new List<Tag>();
            using (var context = new PRN231_BlogContext(connectionString))
            {
                result = context.Tags.ToList();
            }
            return result;
        }

        public Tag GetById(int id)
        {
            var result = new Tag();
            using (var context = new PRN231_BlogContext(connectionString))
            {
                result = context.Tags.Where(t => t.Id == id).FirstOrDefault();
            }
            return result;
        }

        public Tag GetByName(string name)
        {
            var result = new Tag();
            using (var context = new PRN231_BlogContext(connectionString))
            {
                result = context.Tags.Where(t => t.Title == name).FirstOrDefault();
            }
            return result;
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
