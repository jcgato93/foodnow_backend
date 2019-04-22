using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PaginationModel<Category>> GetCategoryByRestaurantId(int restaurantId,int pageIndex=0,int pageSize=10)
        {
            try
            {
                var data = await restaurantCategoryRepository.GetAll().Include(x => x.Category)
                        .Where(x => x.RestaurantId == restaurantId)
                        .Select(x => x.Category)
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync();

                var totalItems = await restaurantCategoryRepository.GetAll().Include(x => x.Category)
                                .Where(x => x.RestaurantId == restaurantId).LongCountAsync();

                return new PaginationModel<Category>(pageIndex, pageSize, totalItems, data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
