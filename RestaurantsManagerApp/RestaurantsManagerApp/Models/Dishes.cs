using System.ComponentModel.DataAnnotations;

namespace RestaurantsManagerApp.Models
{
    public class Dishes
    {
        [Key]
        public int DishId { get; set; } // Primary Key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Tên món ăn

        [MaxLength(50)]
        public Category Category { get; set; } = Category.appetizer; // Danh mục (khai vị, món chính, tráng miệng

        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; } // Giá món ăn

        [Required]
        public bool IsAvailable { get; set; } = true; // Trạng thái (true = đang có, false = hết hàng)

        [MaxLength(255)]
        public string ImageUrl { get; set; } // Đường dẫn hình ảnh món ăn (nếu có)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ngày tạo món

        public DateTime? UpdatedAt { get; set; }
    }

    public enum Category
    {
        //khai vị, món chính, tráng miệng
        appetizer =0,
        main = 1,
        dessert = 2,
    }
}
