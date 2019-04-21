using System.Threading.Tasks;
using aspnetcore.Interfaces;

namespace aspnetcore.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AspnetCoreDbContext context;

        public UnitOfWork(AspnetCoreDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}