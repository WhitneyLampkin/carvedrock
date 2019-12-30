using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductTypeEnum Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset IntroducedAt { get; set; }
        public string PhotoFileName { get; set; }
        public List<ProductReview> Reviews { get; set; }
    }
}
