using MediatR;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Interfaces;
using Monitor.Application.Monitor.MonitoringChecks.ChecksLogic.Feeds;
using Monitor.Application.MonitoringChecks.ChecksLogic;
using Monitor.Application.MonitoringChecks.ChecksLogic.API.Delivery.Models;
using Monitor.Application.MonitoringChecks.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Application.MonitoringChecks.Commands.Prod.Feed
{
    public class FeedChekPriceCommand : IRequest<CommandResult>, ICommand<CommandResult>
    {
        

        public CheckSettings CheckSettings => new CheckSettings
        {
            Priority = PrioritiesEnum.High,
            Service = "Feed Price",
            Type = CheckTypeEnum.FeedChekPriceProd,
            EnvironmentId = (int)EnvironmentsEnum.Prod,
            CheckFullDescription = "Проверка размера прайса"
        };

    }
    public class CheckFeedProdHandler : IRequestHandler<FeedChekPriceCommand, CommandResult>
    {

        private readonly IFeedService _feedService;
   
        public CheckFeedProdHandler(IFeedService feedService)
        {
            _feedService = feedService ?? throw new ArgumentNullException(nameof(feedService));
        }

        public async Task<CommandResult> Handle(FeedChekPriceCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult { Success = true };
            var check = new FeedsCheck(_feedService);
            result.CheckModel = await check.CheckFeeds(request.CheckSettings, "Price");
            return result;
        }

    }
}
