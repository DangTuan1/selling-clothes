using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace selling_clothes_app.Models.EF
{
    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        [StringLength(150)]
        public string CustomerName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }

        public string Region { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
    }
}