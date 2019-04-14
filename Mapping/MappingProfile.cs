using System.Linq;
using aspnetcore.Controllers.Resources;
using aspnetcore.models;
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
           CreateMap<Vehical,SaveVehicalResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new Contact { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone } ))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            CreateMap<Vehical,VehicalResource>()
             .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make ))
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new Contact { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone } ))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new FeatureResource(){Id= vf.Feature.Id,name=vf.Feature.Name })));


           //Resouces to domian 
          CreateMap<SaveVehicalResource,Vehical>()
           .ForMember(i=> i.Id,opt=> opt.Ignore())
          .ForMember(i=> i.ContactEmail,opt=> opt.MapFrom(i=>i.Contact.Email))
          .ForMember(i=> i.ContactName,opt=> opt.MapFrom(i=>i.Contact.Name))
          .ForMember(i=> i.ContactPhone,opt=> opt.MapFrom(i=>i.Contact.Phone))
            .ForMember(v => v.Features, opt => opt.Ignore())
              .AfterMap((vr, v) => {
                // Remove unselected features
                var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                foreach (var f in removedFeatures)
                  v.Features.Remove(f);

                // Add new features
                var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicalFeature { FeatureId = id });   
                foreach (var f in addedFeatures)
                    v.Features.Add(f);

              });
    }
}
}