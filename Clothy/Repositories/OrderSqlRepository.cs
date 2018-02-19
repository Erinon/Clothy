using Clothy.Data;
using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Repositories
{
    public class OrderSqlRepository : IOrderRepository
    {
        private ClothyDbContext _context;

        public OrderSqlRepository(ClothyDbContext context)
        {
            _context = context;
        }

        public Task<List<Order>> GetAllOrders()
        {
            return _context.Orders.OrderBy(o => o.DateCreated)
                                  .ToListAsync();
        }

        public async Task MakeOrder(Order order)
        {
            _context.Orders.Add(order);

            (await _context.Users.SingleAsync(u => u.Id.Equals(order.UserId)))
                                 .Cart.Clear();

            await _context.SaveChangesAsync();
        }
    }
}
