using BackEnd.Models;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class RestaurantCategoryService : GenericService<RestaurantCategory>, IRestaurantCategoryService
    {
        private RestaurantCategoryRepository restaurantCategoryRepository;

        public RestaurantCategoryService(RestaurantCategoryRepository restaurantCategoryRepository)
             : base(restaurantCategoryRepository)
        {
            this.restaurantCategoryRepository = restaurantCategoryRepository;
        }
    }
}
