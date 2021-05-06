using AnimalShelter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        T IRepository<T>.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Insert(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Remove(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.SaveChanges()
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
