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
    public class ProductService : GenericService<Product>, IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
             : base(productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<PaginationModel<Product>> GetProductsByCategoryId(int restaurantId,int categoryId,int pageIndex=0,int pageSize=10)
        {
            try
            {
                var data = await productRepository.GetAll()
                       .Where(x => x.CategoryId == categoryId && x.RestaurantId == restaurantId)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync();

                var totalItems = await productRepository.GetAll()
                                       .Where(x => x.CategoryId == categoryId).LongCountAsync();

                return new PaginationModel<Product>(pageIndex, pageSize, totalItems, data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
