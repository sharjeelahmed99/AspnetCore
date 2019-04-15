using System.ComponentModel.DataAnnotations;

namespace aspnetcore.Controllers.Resources
{
    public class Contact 
    {
        [Required]
        public string Name { get; set; }
        
      
     
        public string Email { get; set; }
       
        public string Phone { get; set; }
    }
}