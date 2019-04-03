using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcore.Controllers.Resources;
using aspnetcore.models;
using aspnetcore.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.Controllers
{
    public class MakesController : Controller
    {
        private readonly AspnetCoreDbContext context;
        private readonly IMapper mapper;

        public MakesController(AspnetCoreDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
           var makes =  await context.Makes.Include(m => m.Models).ToListAsync();
           return mapper.Map<List<Make>,List<MakeResource>>(makes);
        }
    }
}