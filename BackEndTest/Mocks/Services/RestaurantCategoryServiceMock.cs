using BackEnd.Models;
using BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndTest.Mocks.Services
{
    public class RestaurantCategoryServiceMock : IRestaurantCategoryService
    {
        public Task<PaginationModel<Category>> GetCategoryByRestaurantId(int restaurantId, int pageIndex = 0, int pageSize = 10)
        {
            if (restaurantId > 0)
            {
                var data = new List<Category>()
              {
                    new Category{Id=1,Name = "Category1"},
                    new Category{Id=2,Name = "Category2"}
              };

                var totalItems = 2;

                Task<PaginationModel<Category>> result = Task.Run(() => (
                    new PaginationModel<Category>(pageIndex, pageSize, totalItems, data)
                ));

                return result;
            }
            else
            {
                Task<PaginationModel<Category>> result = Task.Run(() => (
                    new PaginationModel<Category>(pageIndex, pageSize, 0, new List<Category>())
                ));

                return result;
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PaginationModel<RestaurantCategory> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<RestaurantCategory> GetById(int id)
        {
            throw new NotImplementedException();
        }        

        public Task Insert(RestaurantCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, RestaurantCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
