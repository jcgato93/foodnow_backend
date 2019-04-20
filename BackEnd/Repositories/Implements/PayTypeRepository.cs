using BackEnd.Contexts;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Implements
{
    public class PayTypeRepository : GenericRepository<PayType>, IPayTypeRepository
    {
        public PayTypeRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
