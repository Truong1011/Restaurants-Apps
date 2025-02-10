using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantsManagerApp.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public int DishId { get; set; }

        [ForeignKey("DishId")]
        public Dishes Dish { get; set; }

        [Required]
        public int Quantity { get; set; } // Số lượng món ăn

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } // Tổng giá

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Trạng thái (Pending, Completed...)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ngày tạo

        public DateTime? UpdatedAt { get; set; } // Ngày cập nhật
    }
}

