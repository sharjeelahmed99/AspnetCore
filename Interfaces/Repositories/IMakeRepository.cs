using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcore.models;

namespace aspnetcore.Interfaces.Repositories
{
    public interface IMakeRepository
    {
        Task<IEnumerable<Make>> GetAll();
        Task<IEnumerable<Model>> GetModels();
    }
}