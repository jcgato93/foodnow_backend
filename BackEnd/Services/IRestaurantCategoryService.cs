using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IRestaurantCategoryService : IGenericService<RestaurantCategory>
    {
        Task<PaginationModel<Category>> GetCategoryByRestaurantId(int restaurantId, int pageIndex = 0,int pageSize= 10);
    }
}
