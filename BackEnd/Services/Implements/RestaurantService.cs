using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class RestaurantService : GenericService<Restaurant>, IRestaurantService
    {
        private IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
             : base(restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }
    }
}
