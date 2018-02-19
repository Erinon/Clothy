using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string userId);
        Task AddUser(User user);
        Task<List<Item>> GetItemsFromCart(string userId);
        Task AddToCart(string userId, Guid itemId);
        Task RemoveFromCart(string userId, Guid itemId);
    }
}
