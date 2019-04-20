using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services.Implements
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
             : base(orderRepository)
        {
            this.orderRepository = orderRepository;
        }
    }
}
