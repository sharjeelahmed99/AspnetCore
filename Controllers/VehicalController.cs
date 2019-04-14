using System;
using System.Threading.Tasks;
using aspnetcore.Controllers.Resources;
using aspnetcore.models;
using aspnetcore.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> CreateVehical([FromBody] SaveVehicalResource vehicalResource)
        {
          

            var vehical = mapper.Map<SaveVehicalResource, Vehical>(vehicalResource);
            vehical.LastUpdated = DateTime.Now;
            this.context.Vehicals.Add(vehical);
            await this.context.SaveChangesAsync();
         
            var result=mapper.Map<Vehical,SaveVehicalResource>(vehical);
            return Ok(result);
            //1004484480
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehical(int id, [FromBody] SaveVehicalResource vehicalResource)
        {
            if(!ModelState.IsValid)
            {
            return BadRequest(ModelState);
            }

            var vehical = await this.context.Vehicals.FindAsync(id);
            if(vehical==null)
            {
                return NotFound();
            }
            mapper.Map<SaveVehicalResource, Vehical>(vehicalResource,vehical);
            vehical.LastUpdated = DateTime.Now;
         
            await this.context.SaveChangesAsync();
         
            var result=mapper.Map<Vehical,SaveVehicalResource>(vehical);
            return Ok(result);
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehical(int id)
        {
            if(!ModelState.IsValid)
            {
            return BadRequest(ModelState);
            }

            var vehical = await this.context.Vehicals.FindAsync(id);
            if(vehical==null)
            {
                return NotFound();
            }
            this.context.Remove(vehical);
            await this.context.SaveChangesAsync();
             return Ok(id);
           
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetVehical(int id)
        {
            if(!ModelState.IsValid)
            {
            return BadRequest(ModelState);
            }

            var vehical = await this.context.Vehicals
            .Include(i=>i.Features).ThenInclude(vf=>vf.Feature)
            .Include(i=>i.Model).ThenInclude(m=>m.Make)
            .SingleOrDefaultAsync(v=>v.Id==id);
            if(vehical==null)
            {
                return NotFound();
            }
           
            var vResource= mapper.Map<Vehical,VehicalResource>(vehical);
             return Ok(vResource);
           
        }
    }
}
}