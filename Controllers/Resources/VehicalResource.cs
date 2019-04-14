using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using aspnetcore.models;

namespace aspnetcore.Controllers.Resources
{
    public class VehicalResource
    {
          public int Id { get; set; }
        public ModelResource Model{get;set;}
           public MakeResource Make{get;set;}

        public bool IsRegistered { get; set; }

       
        public Contact Contact { get; set; }

        public DateTime LastUpdated { get; set; }

        public ICollection<FeatureResource> Features{get;set;}
        public VehicalResource()
        {
            Features = new Collection<FeatureResource>();
        }
    }
}