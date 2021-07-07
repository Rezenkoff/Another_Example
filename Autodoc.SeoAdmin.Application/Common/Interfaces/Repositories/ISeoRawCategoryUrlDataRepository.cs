using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces
{
    public interface ISeoRawCategoryUrlDataRepository
    {
        Task<IEnumerable<RawSeoModel>> GetRawUrlData ();

        Task<IEnumerable<AdditionalPromoModel>> GetAdditionalPromoPropertiesList (int nodeId);
    }

    public interface ISeoRawDataRepository<T>
    {
        Task<IEnumerable<T>> GetRawUrlData (int batchSize, int batchStep);

        
    }
}
