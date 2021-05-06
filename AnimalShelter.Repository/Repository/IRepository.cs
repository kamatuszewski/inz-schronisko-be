using AnimalShelter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Repository.Repository
{
    public interface IRepository<T> where  T: BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(int Id);
        void Insert(T entity);
        void update(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
