using System;
using System.Collections.Generic;

namespace Business.DAL.Abstraction
{
    public interface IRepository<T> //Interface générique
    {
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        T Get(int id);
        List<T> GetAll();

    }
}
