using BackEnd.Models;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class PayTypeService : GenericService<PayType>, IPayTypeService
    {
        private PayTypeRepository payTypeRepository;

        public PayTypeService(PayTypeRepository payTypeRepository)
             : base(payTypeRepository)
        {
            this.payTypeRepository = payTypeRepository;
        }
    }
}
