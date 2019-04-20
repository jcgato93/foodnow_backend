using BackEnd.Models;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private ProductRepository productRepository;

        public ProductService(ProductRepository productRepository)
             : base(productRepository)
        {
            this.productRepository = productRepository;
        }
    }
}
