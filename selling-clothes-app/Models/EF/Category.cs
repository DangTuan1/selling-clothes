using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace selling_clothes_app.Models.EF
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
            ProductCategoryMapping = new HashSet<ProductCategoryMapping>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductCategoryMapping> ProductCategoryMapping { get; set; }
    }
}
