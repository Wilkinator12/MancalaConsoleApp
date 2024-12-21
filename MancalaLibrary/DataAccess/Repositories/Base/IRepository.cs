using System;
using System.Collections.Generic;
using System.Text;

namespace MancalaLibrary.DataAccess.Repositories.Base
{
    public interface IRepository<T>
    {
        T Insert(T entity);
        List<T> ReadAll();
        T ReadById(int id);
        T Update(T entity);
        T Upsert(T entity);
        bool Delete(int id);
    }
}
