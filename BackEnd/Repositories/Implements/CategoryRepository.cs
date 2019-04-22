using BackEnd.Contexts;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Implements
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {        
        public CategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {            
        }       
    }
}
