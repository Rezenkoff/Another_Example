using Autodoc.SeoAdmin.Application.Common.Models;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces.Repositories
{
    public interface IProccessStateRepository
    {
        Task SaveProccessedState (ProccessingStateModel stateModel);

        Task<ProccessingStateModel> GetSavedState (int pageTypeId);
    }
}
