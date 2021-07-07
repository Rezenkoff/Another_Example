using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Infrastructure.Repositories
{
    public class SeoRawCategoryUrlDataRepository : ISeoRawDataRepository<RawSeoModel>
    {
        public Task<IEnumerable<AdditionalPromoModel>> GetAdditionalPromoPropertiesList (int nodeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RawSeoModel>> GetRawUrlData (int batchSize, int batchStep)
        {
            throw new System.NotImplementedException();
        }
    }
}
