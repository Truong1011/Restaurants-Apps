using System.ComponentModel.DataAnnotations;

namespace RestaurantsManagerApp.Models
{
    public class Tables
    {

        [Key]
        public int TableID { get; set; } // Primary Key

        [Required]
        public int TableNumber { get; set; } // Số bàn (phải là duy nhất)

        [Required]
        public int Capacity { get; set; } // Sức chứa (số người tối đa)

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Available"; // Trạng thái (Available, Occupied...)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ngày tạo

        public DateTime? UpdatedAt { get; set; }
    }
}
