using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Codigo { get; set; }
        public string Description { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
    }
}
