using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Domain
{
    public class ProductInfo
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
