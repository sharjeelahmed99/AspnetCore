using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace aspnetcore.Controllers.Resources
{
    public class VehicalResource
    {
      

        public int ModelId { get; set; }
    
        public bool IsRegistered { get; set; }

       public Contact Contact { get; set; }

        public ICollection<int> Features{get;set;}
        public VehicalResource()
        {
            Features = new Collection<int>();
        }
    }
}