using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore.Controllers.Resources
{
    public class SaveVehicalResource
    {
      

        public int ModelId { get; set; }
    
        public bool IsRegistered { get; set; }
        [Required]

       public Contact Contact { get; set; }

        public ICollection<int> Features{get;set;}
        public SaveVehicalResource()
        {
            Features = new Collection<int>();
        }
    }
}