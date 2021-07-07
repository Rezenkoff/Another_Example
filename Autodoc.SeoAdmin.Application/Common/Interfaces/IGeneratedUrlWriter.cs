using Autodoc.SeoAdmin.Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces
{
    public interface IGeneratedUrlWriter
    {
        Task WriteGeneratedUrls (IEnumerable<UrlCombinationModel> generatedModelsList);
    }
}
