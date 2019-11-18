using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.Web.Models;

namespace Product.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
