using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IGenericService<TEntity>
        where TEntity : class
    {
        PaginationModel<TEntity> GetAll(int pageIndex,int pageSize);

        Task<TEntity> GetById(int id);

        Task Insert(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);        
    }
}
