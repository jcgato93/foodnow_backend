﻿using BackEnd.Contexts;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Implements
{
    public class RestaurantCategoryRepository : GenericRepository<RestaurantCategory>, IRestaurantCategoryRepository
    {
        public RestaurantCategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
