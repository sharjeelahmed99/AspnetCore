using aspnetcore.models;
using AspnetCore.models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.Persistence
{
    public class AspnetCoreDbContext:DbContext
    {
          public DbSet<Make> Makes { get; set; }
          public DbSet<Feature> Features { get; set; }
            public DbSet<Vehical> Vehicals { get; set; }
        public AspnetCoreDbContext(DbContextOptions<AspnetCoreDbContext> options)
        :base(options)
        {            
        }
      protected override void OnModelCreating(ModelBuilder modelBuilder){
          modelBuilder.Entity<VehicalFeature>().HasKey(vf => new {vf.FeatureId,vf.VehicalId});
      }
    }
}