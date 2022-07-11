using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using System.Reflection;

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
            using (var context = new PRN231_BlogContext(connectionString))
            {
                var item = context.Tags.Find(id);
                if (item == null) return;
                context.Tags.Remove(item);
                context.SaveChanges();
            }
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

        public IEnumerable<Tag> GetByName(string name)
        {
            var result = new List<Tag>();
            if (String.IsNullOrEmpty(name))
            {
                result = GetAll().ToList();
            }
            else
            {
                using (var context = new PRN231_BlogContext(connectionString))
                {
                    result = context.Tags.Where(t => t.Title == name).ToList();
                }
            }
            return result;
        }

        public void Save(Tag entity)
        {
            using (var context = new PRN231_BlogContext(connectionString))
            {
                var result = context.Tags.Find(entity.Id);
                if (result == null) return;
                context.Tags.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(Tag entity)
        {
            using (var context = new PRN231_BlogContext(connectionString))
            {
                context.Entry<Tag>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
