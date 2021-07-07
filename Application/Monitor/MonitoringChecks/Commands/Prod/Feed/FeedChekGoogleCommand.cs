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
    public class FeedChekGoogleCommand : IRequest<CommandResult>, ICommand<CommandResult>
    {
        

        public CheckSettings CheckSettings => new CheckSettings
        {
            Priority = PrioritiesEnum.High,
            Service = "Feed Google",
            Type = CheckTypeEnum.FeedChekGoogleProd,
            EnvironmentId = (int)EnvironmentsEnum.Prod,
            CheckFullDescription = "Проверка размера фида  Google"
        };

    }
    public class CheckFeedGoogleHandler : IRequestHandler<FeedChekGoogleCommand, CommandResult>
    {

        private readonly IFeedService _feedService;
   
        public CheckFeedGoogleHandler(IFeedService feedService)
        {
            _feedService = feedService ?? throw new ArgumentNullException(nameof(feedService));
        }

        public async Task<CommandResult> Handle(FeedChekGoogleCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult { Success = true };
            var check = new FeedsCheck(_feedService);
            result.CheckModel = await check.CheckFeeds(request.CheckSettings, "Google");
            return result;
        }

    }
}
