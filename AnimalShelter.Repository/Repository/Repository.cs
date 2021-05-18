using AnimalShelter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly ShelterDbContext _shelterDbContext;
        private DbSet<T> entities;

        public Repository(ShelterDbContext shelterDbContext)
        {
            _shelterDbContext = shelterDbContext;
            entities = _shelterDbContext.Set<T>();
        }

        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if(entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _shelterDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _shelterDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _shelterDbContext.SaveChanges();
        }
    }
}
