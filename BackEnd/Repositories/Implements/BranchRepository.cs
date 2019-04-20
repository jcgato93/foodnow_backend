using BackEnd.Contexts;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Implements
{
    public class BranchRepository: GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
