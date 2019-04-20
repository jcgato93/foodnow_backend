using BackEnd.Models;
using BackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class PayTypeService : GenericService<PayType>, IPayTypeService
    {
        private IPayTypeRepository payTypeRepository;

        public PayTypeService(IPayTypeRepository payTypeRepository)
             : base(payTypeRepository)
        {
            this.payTypeRepository = payTypeRepository;
        }
    }
}
