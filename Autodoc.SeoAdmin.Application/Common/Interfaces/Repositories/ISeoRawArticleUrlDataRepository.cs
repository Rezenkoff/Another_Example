using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces
{
    public interface ISeoRawArticleUrlDataRepository
    {
        Task<IEnumerable<RawSeoModelArticle>> GetRawUrlData (int batchSize, int batchStep);
    }
}
