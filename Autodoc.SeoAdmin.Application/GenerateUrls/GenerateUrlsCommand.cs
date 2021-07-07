using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Application.GenerateUrls
{
    public class GenerateUrlsCommand : IRequest
    {

    }

    public class CreateNodeCommandHandler : IRequestHandler<GenerateUrlsCommand>
    {            
        private readonly ISeoUrlProccessor<RawSeoModelArticle> _seoUrlProccessor;

        public CreateNodeCommandHandler (ISeoUrlProccessor<RawSeoModelArticle> seoUrlProccessor)
        {
            _seoUrlProccessor = seoUrlProccessor;
        }

        public async Task<Unit> Handle (GenerateUrlsCommand request, CancellationToken cancellationToken)
        {
            await _seoUrlProccessor.StartProccess();

            return await Task.FromResult(Unit.Value);
        }
    }
}

