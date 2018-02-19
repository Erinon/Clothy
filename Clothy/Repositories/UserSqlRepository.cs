using Clothy.Data;
using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Repositories
{
    public class UserSqlRepository : IUserRepository
    {
        private ClothyDbContext _context;

        public UserSqlRepository(ClothyDbContext context)
        {
            _context = context;
        }

        public Task<User> GetUserById(string userId)
        {
            return _context.Users.SingleAsync(u => u.Id.Equals(userId));
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Item>> GetItemsFromCart(string userId)
        {
            User target = await GetUserById(userId);

            return target.Cart.ToList();
        }

        public async Task AddToCart(string userId, Guid itemId)
        {
            User targetUser = await GetUserById(userId);
            Item targetItem = await _context.Items.SingleAsync(i => i.Id.Equals(itemId));

            targetUser.Cart.Add(targetItem);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCart(string userId, Guid itemId)
        {
            User targetUser = await GetUserById(userId);
            Item targetItem = await _context.Items.SingleAsync(i => i.Id.Equals(itemId));

            targetUser.Cart.Remove(targetItem);

            await _context.SaveChangesAsync();
        }
    }
}
