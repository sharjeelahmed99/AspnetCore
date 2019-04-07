using System.ComponentModel.DataAnnotations;

namespace aspnetcore.Controllers.Resources
{
    public class Contact 
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
    }
}