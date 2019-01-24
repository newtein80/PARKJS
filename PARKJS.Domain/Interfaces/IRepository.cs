using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARKJS.Domain.Interfaces
{
    //https://slaner.tistory.com/122
    //https://slaner.tistory.com/126
    //https://godffs.tistory.com/209
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T obj);
        T GetById(Guid id);
        IQueryable<T> GetAll();
        void Update(T obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}

/*
 public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    void Add(TEntity obj);
    TEntity GetById(Guid id);
    IQueryable<TEntity> GetAll();
    void Update(TEntity obj);
    void Remove(Guid id);
    int SaveChanges();
}
 */
