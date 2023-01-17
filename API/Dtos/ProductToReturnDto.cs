using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        // DTO is stand for ===> Data Transfere Object
        // DTO is container to moveing Data between Layers , Only Have Set & get   
        // Create an Object To return The Data In The format We Want To Be .
        public int Id { get; set; }
        public string Name { get; set; }
        public string photoUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}