using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
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
    }
}
