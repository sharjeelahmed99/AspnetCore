using System.Threading.Tasks;
using aspnetcore.models;

namespace aspnetcore.Interfaces.Repositories
{
    public interface IVehicalRepository
    {
        Task<Vehical> GetVehical(int id, bool includeRelated = true);
        void Add(Vehical vehical);
        void Remove(Vehical vehical);
        Task<Vehical> GetVehicalWithFeature(int id);
    }
}