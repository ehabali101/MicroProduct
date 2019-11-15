using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Product.Domain
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

    }
}
