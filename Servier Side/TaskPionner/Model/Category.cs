using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPionner.Model
{
    public class Category
    {
        
        [Key]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [RegularExpression(@"(^\D*$)|(\w+\d)", ErrorMessage = "Name cat Must Character")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"\d*$", ErrorMessage = "amount Must Number")]
        public int amount { get; set; }

        [Required]
        [RegularExpression(@"\d*$", ErrorMessage = "serviced Must Number")]
        [ForeignKey("ser")]
        public int service_id { get; set; }
        public virtual Services? ser { get; set; }
     }
}
