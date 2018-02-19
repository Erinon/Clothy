using Clothy.Data;
using Clothy.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Repositories
{
    public class ItemSqlRepository : IItemRepository
    {
        private ClothyDbContext _context;

        public ItemSqlRepository(ClothyDbContext context)
        {
            _context = context;
        }

        public Task<Item> GetItemById(Guid id)
        {
            return _context.Items.SingleAsync(i => i.Id.Equals(id));
        }

        public Task<List<Item>> GetItemsByCategoryId(Guid catId)
        {
            return _context.Items.Where(i => i.CategoryId.Equals(catId))
                                 .OrderBy(i => i.Price)
                                 .ToListAsync();
        }

        public async Task AddItem(Item item)
        {
            _context.Items.Add(item);

            await _context.SaveChangesAsync();
        }

        public Task<List<Item>> GetAllItems()
        {
            return _context.Items.OrderBy(i => i.Name)
                                 .ToListAsync();
        }

        public async Task RemoveItem(Guid itemId)
        {
            _context.Items.Remove(await GetItemById(itemId));

            await _context.SaveChangesAsync();
        }

        public async Task EditItem(Item item)
        {
            Item target = await GetItemById(item.Id);

            target.Name = item.Name;
            target.Price = item.Price;
            target.Description = item.Description;
            target.Sizes = item.Sizes;
            target.Picture = item.Picture;
            target.CategoryId = item.CategoryId;

            await _context.SaveChangesAsync();
        }
    }
}
