using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItemById(Guid id);
        Task AddItem(Item item);
        Task<List<Item>> GetItemsByCategoryId(Guid catId);
        Task<List<Item>> GetAllItems();
        Task RemoveItem(Guid itemId);
        Task EditItem(Item item);
    }
}
