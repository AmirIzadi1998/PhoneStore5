using System.ComponentModel.DataAnnotations;

namespace PhoneStore5.Models
{
    public class PhoneProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(35)]
        public string NameChipset { get; set; }
        [MaxLength(35)]
        public string Camera { get; set; }
        public string Description { get; set; }
        public DateTime? InsertTime { get; set; } = DateTime.Now;
    }
}
