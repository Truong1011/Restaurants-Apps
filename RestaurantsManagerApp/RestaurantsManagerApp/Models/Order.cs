using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantsManagerApp.Models
{
    public class Order
    {

        [Key]
        public int OrderId { get; set; } // Primary Key

        [Required]
        public int UserId { get; set; } // Foreign Key -> Users

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation Property

        [Required]
        public int DishId { get; set; } // Foreign Key -> Dishes
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [ForeignKey("DishId")]
        public Dishes Dishes { get; set; } // Navigation Property
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ngày tạo
    }
}
