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
    public class FeedChekPromCommand : IRequest<CommandResult>, ICommand<CommandResult>
    {
        

        public CheckSettings CheckSettings => new CheckSettings
        {
            Priority = PrioritiesEnum.High,
            Service = "Feed Prom",
            Type = CheckTypeEnum.FeedChekPromProd,
            EnvironmentId = (int)EnvironmentsEnum.Prod,
            CheckFullDescription = "Проверка размера фида  Prom"
        };

    }
    public class CheckFeedPromHandler : IRequestHandler<FeedChekPromCommand, CommandResult>
    {

        private readonly IFeedService _feedService;
   
        public CheckFeedPromHandler(IFeedService feedService)
        {
            _feedService = feedService ?? throw new ArgumentNullException(nameof(feedService));
        }

        public async Task<CommandResult> Handle(FeedChekPromCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult { Success = true };
            var check = new FeedsCheck(_feedService);
            result.CheckModel = await check.CheckFeeds(request.CheckSettings, "Prom");
            return result;
        }

    }
}
