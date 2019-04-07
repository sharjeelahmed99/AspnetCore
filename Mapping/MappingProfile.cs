using System.Linq;
using aspnetcore.Controllers.Resources;
using aspnetcore.models;
using AspnetCore.Controllers.Resources;
using AspnetCore.models;
using AutoMapper;

namespace aspnetcore.Mapping
{
    public class MappingProfile:Profile
    {
       public MappingProfile()
       {
           //Domain to Resources
           CreateMap<Make,MakeResource>();
           CreateMap<Model,ModelResource>();
           CreateMap<Feature,FeatureResource>();
           CreateMap<Vehical,VehicalResource>()
           .ForMember(i=>i.Contact,opt=>opt.MapFrom(i=> new Contact()
           {Email=i.ContactEmail,Phone=i.ContactPhone,Name=i.ContactName}))
           .ForMember(i=>i.Features,opt=>opt.MapFrom(d=>d.Features.Select(vf=>vf.FeatureId)));



           //Resouces to domian 
          CreateMap<VehicalResource,Vehical>()
          .ForMember(i=> i.ContactEmail,opt=> opt.MapFrom(i=>i.Contact.Email))
          .ForMember(i=> i.ContactName,opt=> opt.MapFrom(i=>i.Contact.Name))
          .ForMember(i=> i.ContactPhone,opt=> opt.MapFrom(i=>i.Contact.Phone))
        .ForMember(i=> i.Features,opt=> opt.MapFrom(i=>i.Features.Select(id=>new VehicalFeature(){FeatureId=id})));

       }
    }
}