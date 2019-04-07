using System.ComponentModel.DataAnnotations.Schema;
using AspnetCore.models;

namespace aspnetcore.models
{ 
    [Table("VehicalFeatures")]
    public class VehicalFeature
    {
        public int VehicalId { get; set; }
        public int FeatureId { get; set; }
        public Vehical Vehical { get; set; }
        public Feature Feature { get; set; }
    }
}