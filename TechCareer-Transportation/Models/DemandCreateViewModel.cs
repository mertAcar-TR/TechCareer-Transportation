using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class DemandCreateViewModel
    {
        public int DemandId { get; set; }
        
        public int CompanyId { get; set;}

        public int UserId { get; set; }

        [Required]  
        [Display(Name = "Talepleriniz")]
        public string? Text { get; set; }
    }
}