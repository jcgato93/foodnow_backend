using BackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class GenericService<TEntity>:IGenericService<TEntity>
        where TEntity : class
    {
        private IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Delete(int id)
        {
            try
            {
              await _genericRepository.Delete(id);

              await _genericRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PaginationModel<TEntity> GetAll(int pageIndex, int pageSize)
        {

            var totalItems = _genericRepository.GetAll().LongCount();

            var itemOnPage=_genericRepository.GetAll()
                    .Skip(pageSize *pageIndex)
                    .Take(pageSize)
                    .ToList();

            var model = new PaginationModel<TEntity>(pageIndex, pageSize, totalItems, itemOnPage);

            return model;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task Insert(TEntity entity)
        {
            try
            {
                await _genericRepository.Insert(entity);

                await _genericRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(int id, TEntity entity)
        {
            try
            {
                _genericRepository.Update(id, entity);

                await _genericRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); throw;
            }
            
        }
    }
}
