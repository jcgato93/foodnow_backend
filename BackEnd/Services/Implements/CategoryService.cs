using BackEnd.Models;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private CategoryRepository categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
             : base(categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
    }
}
