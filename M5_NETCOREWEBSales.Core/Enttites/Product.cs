﻿using System;
using System.Collections.Generic;

#nullable disable

namespace M5_NETCOREWEBSales.Core.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}