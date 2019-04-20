using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class RestaurantCategoryService : GenericService<RestaurantCategory>, IRestaurantCategoryService
    {
        private IRestaurantCategoryRepository restaurantCategoryRepository;

        public RestaurantCategoryService(IRestaurantCategoryRepository restaurantCategoryRepository)
             : base(restaurantCategoryRepository)
        {
            this.restaurantCategoryRepository = restaurantCategoryRepository;
        }
    }
}
