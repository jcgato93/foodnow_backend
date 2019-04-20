using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class BranchService : GenericService<Branch>, IBranchService
    {
        private IBranchRepository genericRepository;

        public BranchService(IBranchRepository genericRepository)
             : base(genericRepository)
        {
            this.genericRepository = genericRepository;
        }
    }
}
