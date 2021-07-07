using Monitor.Application.Interfaces;
using Monitor.Application.MonitoringChecks.Models;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Monitor.Application.MonitoringChecks
{
    public class ProductMetatagsCheckBetaCommand : IRequest<CommandResult>,  ICommand<CommandResult>
    {
        public CheckSettings CheckSettings => new CheckSettings
        {
            Priority = PrioritiesEnum.Medium,
            Service = "Meta tags check for product",
            Type = CheckTypeEnum.ProductMetaTagsBeta,
            EnvironmentId = (int)EnvironmentsEnum.Beta,
            CheckFullDescription = "Проверка тегов rel, next, canonical, index, follow на странице товара oc90"
        };
    }

    public class ProductMetatagsCheckProdHandler : IRequestHandler<ProductMetatagsCheckProdCommand, CommandResult>
    {
        private IHttpRequestService _httpService;
        private readonly ISeoPagesTagsRepository _seoPagesTagsRepository;

        public ProductMetatagsCheckProdHandler(IHttpRequestService httpService, ISeoPagesTagsRepository seoPagesTagsRepository)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            _seoPagesTagsRepository = seoPagesTagsRepository ?? throw new ArgumentNullException(nameof(seoPagesTagsRepository));
        }

        public async Task<CommandResult> Handle(ProductMetatagsCheckProdCommand request, CancellationToken cancellationToken)
        {
            var oc90ArtId = -84669;
            var expectedMetaTags = await _seoPagesTagsRepository.GetMetaTagsByPageExtId(oc90ArtId);
            
            var result = new CommandResult();
            result.Success = true;
            var check = new ProductMetatagsCheck(_httpService);
            result.CheckModel = await check.CheckMetaInfo(request.CheckSettings, expectedMetaTags);

            return result;
        }
    }
}
