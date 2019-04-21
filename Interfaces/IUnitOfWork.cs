using System.Threading.Tasks;

namespace aspnetcore.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}