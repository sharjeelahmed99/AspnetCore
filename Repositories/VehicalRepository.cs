using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore.Interfaces.Repositories;
using aspnetcore.models;
using aspnetcore.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.Repositories
{
    public class VehicalRepository : IVehicalRepository
    {
        private readonly AspnetCoreDbContext context;

        public VehicalRepository(AspnetCoreDbContext context)
        {
            this.context = context;
        }


        public void Add(Vehical vehical)
        {
            context.Add(vehical);
        }
        public void Remove(Vehical vehical)
        {
            context.Remove(vehical);
        }
        public async Task<Vehical> GetVehicalWithFeature(int id)
        {
            return await this.context.Vehicals.Include(i => i.Features).FirstAsync(i => i.Id == id);

        }
        public async Task<Vehical> GetVehical(int id, bool includeRelated = true)
        {
            if (!includeRelated)
            {
                return await this.context.Vehicals.FindAsync(id);
            }
            return await this.context.Vehicals
                      .Include(i => i.Features).ThenInclude(vf => vf.Feature)
                      .Include(i => i.Model).ThenInclude(m => m.Make)
                      .SingleOrDefaultAsync(v => v.Id == id);

        }
        public async Task<IEnumerable<Vehical>> GetVehicles(Filter filter)
        {

            var query = this.context.Vehicals
                       .Include(i => i.Features).ThenInclude(vf => vf.Feature)
                       .Include(i => i.Model).ThenInclude(m => m.Make).AsQueryable();

            if (filter.MakeId.HasValue)
            {
                query = query.Where(v => v.Model.MakeId == filter.MakeId.Value);
            }
            if (filter.ModelId.HasValue)
            {
                query = query.Where(v => v.Model.Id == filter.ModelId.Value);
            }

            return await query.ToListAsync();

        }
    }
}