using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace TaskPionner.Model
{
    [Index(nameof(code), IsUnique = true)]
    [Index(nameof(serial), IsUnique = true)]
    [Index(nameof(operationnumber), IsUnique = true)]


    public class card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(12, ErrorMessage = "Code Must 12 number")]
        [MinLength(12, ErrorMessage = "Code Must 12 number")]
        [RegularExpression(@"\d*$")]
        public string code { get; set; } 
        [Required]
        [MaxLength(12, ErrorMessage = "Serial Must 12 number")]
        [MinLength(12, ErrorMessage = "Serial Must 12 number")]
        [RegularExpression(@"\d*$")]
        public string serial { get; set; } 
        [Required]
        [MaxLength(12, ErrorMessage = "operationnumber Must 12 number")]
        [MinLength(12, ErrorMessage = "operationnumber Must 12 number")]
        [RegularExpression(@"\d*$")]
        public string operationnumber { get; set; } 
        [Required]
        public double price { get; set; }
        [ForeignKey("type")]
        [Required]
        public int catid { get; set; }
        public virtual Category? cat { get; set; }

    }
}
