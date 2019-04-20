using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class SaleService : GenericService<Sale>, ISaleService
    {
        private ISaleRepository saleRepository;

        public SaleService(ISaleRepository saleRepository)
             : base(saleRepository)
        {
            this.saleRepository = saleRepository;
        }
    }
}
