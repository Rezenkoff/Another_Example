using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Application.UrlProccesing.Commands
{
    public class GenerateUrlsCommand : IRequest
    {
    }

    public class GenerateUrlsCommandHandler : IRequestHandler<GenerateUrlsCommand>
    {

        private readonly ISeoUrlProccessor<RawSeoModelArticle> _seoUrlProccessor;
        public GenerateUrlsCommandHandler (ISeoUrlProccessor<RawSeoModelArticle> seoUrlProccessor)
        {
            _seoUrlProccessor = seoUrlProccessor;
        }

        public async Task<Unit> Handle (GenerateUrlsCommand request, CancellationToken cancellationToken)
        {
            await _seoUrlProccessor.StartProccess();

            return Unit.Value;
        }
    }
}



