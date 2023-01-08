using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaskPionner.Model
{
    public class Services
    {

       
        [Key]
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Name Must less than 30 char")]
        [RegularExpression(@"(^\D*$)|(\w+\d)", ErrorMessage ="Name Must Character")]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(100, ErrorMessage = "Description Must less than 100 char")]
        [RegularExpression(@"(^\D*$)|(\w+\d)", ErrorMessage = "Description Must Character")]
        public string Description { get; set; } = ""; 
        
    }
}
