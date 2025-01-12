﻿using System;
using System.Collections.Generic;

namespace LWP.ShoppersHubDAL.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
