using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Repositories
{
    public interface IOrderRepository
    {
        Task MakeOrder(Order order);
        Task<List<Order>> GetAllOrders();
    }
}
