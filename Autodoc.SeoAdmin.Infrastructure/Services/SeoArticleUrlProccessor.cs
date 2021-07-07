using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Domain.Entities;

namespace Autodoc.SeoAdmin.Infrastructure.Services
{
    public class SeoArticleUrlProccessor : SeoUrlProccessorBase<RawSeoModelArticle>
    {
        //change to dynmamic get
        public override int PageType { get { return 11; } }
        public SeoArticleUrlProccessor (
            ISeoRawDataRepository<RawSeoModelArticle> seoRawDataRepository,
            IConstructorsSequenceBuilder<RawSeoModelArticle> sequenceBuilder,
            IProccessStateService poccessStateService,
            IGeneratedUrlWriter generatedUrlsWriter) : base(seoRawDataRepository, sequenceBuilder, poccessStateService, generatedUrlsWriter)
        {

        }
    }
}

