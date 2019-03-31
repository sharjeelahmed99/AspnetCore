using aspnetcore.Controllers.Resources;
using aspnetcore.models;
using AutoMapper;

namespace aspnetcore.Mapping
{
    public class MappingProfile:Profile
    {
       public MappingProfile()
       {
           CreateMap<Make,MakeResource>();
           CreateMap<Model,ModelResource>();
       }
    }
}