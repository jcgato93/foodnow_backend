using BackEnd.Models;
using BackEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEndTest.Mocks.Services
{
    public class RestaurantServiceMock : IRestaurantService
    {
        public PaginationModel<Restaurant> GetAll(int pageIndex, int pageSize)
        {
            var data = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="Restaurant1"},
                new Restaurant{Id=2,Name="Restaurant2"}
            };

            return new PaginationModel<Restaurant>(pageIndex, pageSize, data.Count, data);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }     

        public Task<Restaurant> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
