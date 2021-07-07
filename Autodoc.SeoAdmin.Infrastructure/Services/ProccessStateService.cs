using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Application.Common.Interfaces.Repositories;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Application.Interfaces;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Infrastructure.Services
{
    public class ProccessStateService : IProccessStateService
    {
        private readonly IConnectionService _connectionServie;
        private readonly IProccessStateRepository _proccessStateRepository;
        public ProccessStateService (IConnectionService connectionServie, IProccessStateRepository proccessStateRepository)
        {
            _connectionServie = connectionServie;
            _proccessStateRepository = proccessStateRepository;
        }
        



    }
}
