using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IProductService : IGenericService<Product>
    {
        Task<PaginationModel<Product>> GetProductsByCategoryId(int restaurantId,int categoryId, int pageIndex = 0, int pageSize = 10);
    }
}
