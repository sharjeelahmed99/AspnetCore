using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcore.Interfaces;
using aspnetcore.Interfaces.Repositories;
using aspnetcore.models;
using aspnetcore.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        private readonly AspnetCoreDbContext context;
        private readonly IMapper mapper;

        public MakeRepository(AspnetCoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<Make>> GetAll()
        {
            return await this.context.Makes.Include(m => m.Models).ToListAsync();

        }
        public async Task<IEnumerable<Model>> GetModels()
        {
            return await this.context.Models.ToListAsync();

        }


    }
}