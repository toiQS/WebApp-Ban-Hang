﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.Order
{
    public class Creates
    {
        [Key]
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        [Display(Name = "ID Đơn Hàng")]
        public int IdOrder { get; set; }
        
        [ForeignKey("Users")]
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        [Display(Name = "ID Người Dùng")]
        public int IdUser { get; set; }
        
        [ForeignKey("Order.Product")]
<<<<<<< Updated upstream
        [Display(Name = "ID Sản Phẩm")]
        public string IdProduct { get; set; }
        [Display(Name = "Ghi Chú")]
        public string TextNote { get; set; }
=======

        [Display(Name = "ID Sản Phẩm")]
        public string IdProduct { get; set; }

        [Display(Name = "Ghi Chú")]
        public string TextNote { get; set; }

>>>>>>> Stashed changes
        [Display(Name = "Tổng Cộng")]
        public uint Total { get; set; }
    }
}
