using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothy.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Category()
        {

        }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((Category)obj).Id.Equals(Id);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
