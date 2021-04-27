using System.Collections.Generic;

namespace DIO.Series.Repository
{
    public interface IRepository<T>
    {
        List<T> ListAll();

        T GetById(int id);

        void Create(T entity);

        void Delete(int id);

        void Update(int id, T entity);

        int GetNextId();
    }
}