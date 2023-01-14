using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public enum Types
    {
        available,
        outOfStock
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string photo { get; set; }
        public string Description { get; set; }
        public Types Type { get; set; }
    }
}