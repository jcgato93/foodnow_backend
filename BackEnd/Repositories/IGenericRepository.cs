using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable
         where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Insert(TEntity entity);

        void Update(int id, TEntity entity);

        Task Delete(int id);

        Task Save();
    }
}
