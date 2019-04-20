using BackEnd.Models;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class BranchService : GenericService<Branch>, IBranchService
    {
        private BranchRepository genericRepository;

        public BranchService(BranchRepository genericRepository)
             : base(genericRepository)
        {
            this.genericRepository = genericRepository;
        }
    }
}
