using aspnetcore.models;
using AspnetCore.models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.Persistence
{
    public class AspnetCoreDbContext:DbContext
    {
        public AspnetCoreDbContext(DbContextOptions<AspnetCoreDbContext> options)
        :base(options)
        {            
        }
        public DbSet<Make> Makes { get; set; }
         public DbSet<Feature> Features { get; set; }
    }
}