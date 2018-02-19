using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Sizes { get; set; }
        public string Picture { get; set; }
        public Guid CategoryId { get; set; }
        public IList<User> Carts { get; set; }

        public Item()
        {

        }

        public Item(string name, double price, string description, string sizes, string picture, Guid catId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
            Sizes = sizes;
            Picture = picture;
            CategoryId = catId;

            Carts = new List<User>();
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((Item)obj).Id.Equals(Id);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
