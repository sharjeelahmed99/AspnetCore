using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcore.Controllers.Resources;
using aspnetcore.Interfaces.Repositories;
using aspnetcore.models;
using aspnetcore.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.Controllers
{
    [Route("/api/make")]
    public class MakesController : Controller
    {
        private readonly AspnetCoreDbContext context;
        private readonly IMapper mapper;
        private readonly IMakeRepository makeRepository;

        public MakesController(AspnetCoreDbContext context, IMapper mapper, IMakeRepository makeRepository)
        {
            this.mapper = mapper;
            this.makeRepository = makeRepository;
            this.context = context;

        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<MakeResource>> GetAll()
        {
            var makes = await makeRepository.GetAll();
            return mapper.Map<IEnumerable<Make>, IEnumerable<MakeResource>>(makes);
        }

        [HttpGet("models")]
        [Authorize]
        public async Task<IEnumerable<ModelResource>> GetModels()
        {
            var models = await makeRepository.GetModels();
            return mapper.Map<IEnumerable<Model>, IEnumerable<ModelResource>>(models);
        }
    }
}