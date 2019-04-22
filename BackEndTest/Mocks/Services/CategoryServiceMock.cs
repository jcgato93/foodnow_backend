using BackEnd.Models;
using BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEndTest.Mocks.Services
{
    public class CategoryServiceMock : ICategoryService
    {
        
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PaginationModel<Category> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
