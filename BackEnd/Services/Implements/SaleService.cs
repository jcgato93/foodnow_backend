using BackEnd.Models;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class SaleService : GenericService<Sale>, ISaleService
    {
        private SaleRepository saleRepository;

        public SaleService(SaleRepository saleRepository)
             : base(saleRepository)
        {
            this.saleRepository = saleRepository;
        }
    }
}
