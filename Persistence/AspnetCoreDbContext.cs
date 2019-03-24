using Microsoft.EntityFrameworkCore;

namespace aspnetcore.Persistence
{
    public class AspnetCoreDbContext:DbContext
    {
        public AspnetCoreDbContext(DbContextOptions<AspnetCoreDbContext> options)
        :base(options)
        {
            
        }
    }
}