using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcore.Controllers.Resources;
using aspnetcore.models;
using aspnetcore.Persistence;
using AspnetCore.Controllers.Resources;
using AspnetCore.models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore.Controllers
{
    public class FeatureController : Controller
    {
        private readonly AspnetCoreDbContext context;
        private readonly IMapper mapper;
        public FeatureController(AspnetCoreDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
         [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
           var features =  await context.Features.ToListAsync();
           return mapper.Map<List<Feature>,List<FeatureResource>>(features);
        }

    }
}