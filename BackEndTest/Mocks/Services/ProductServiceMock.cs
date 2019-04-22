using BackEnd.Models;
using BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEndTest.Mocks.Services
{
    public class ProductServiceMock : IProductService
    {
        public Task<PaginationModel<Product>> GetProductsByCategoryId(int categoryId, int pageIndex = 0, int pageSize = 10)
        {
            if (categoryId > 0)
            {
                var data = new List<Product>()
              {
                    new Product{Id=1,Name = "Product1",CategoryId=categoryId,Price=2000,RestaurantId=1},
                    new Product{Id=2,Name = "Product2",CategoryId=categoryId,Price=30000,RestaurantId=1}
              };

                var totalItems = 2;

                Task<PaginationModel<Product>> result = Task.Run(() => (
                    new PaginationModel<Product>(pageIndex, pageSize, totalItems, data)
                ));

                return result;
            }
            else
            {
                Task<PaginationModel<Product>> result = Task.Run(() => (
                    new PaginationModel<Product>(pageIndex, pageSize, 0, new List<Product>())
                ));

                return result;
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PaginationModel<Product> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
