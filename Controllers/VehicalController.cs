using System.Threading.Tasks;
using aspnetcore.Controllers.Resources;
using aspnetcore.models;
using aspnetcore.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.Controllers
{
    [Route("/api/vehical")]
    public class VehicalController : Controller
    {
        private readonly IMapper mapper;
        private readonly AspnetCoreDbContext context;
        public VehicalController(AspnetCoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehical(VehicalResource vehicalResource)
        {
            var vehical = mapper.Map<VehicalResource, Vehical>(vehicalResource);
            this.context.Vehicals.Add(vehical);
            await this.context.SaveChangesAsync();
         
            var result=mapper.Map<Vehical,VehicalResource>(vehical);
            return Ok(result);
            //1004484480
        }
    }
}