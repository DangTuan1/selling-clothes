using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(150)]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductCategoryMapping> ProductCategoryMapping { get; set; }
    }
}
