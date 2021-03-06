using MediatR;
using Monitor.Application.Interfaces;
using Monitor.Application.MonitoringChecks.ChecksLogic.HTML;
using Monitor.Application.MonitoringChecks.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Application.MonitoringChecks.Commands.Beta.HTML
{
    public class DesktopVersionCheckCommand : IRequest<CommandResult>, ICommand<CommandResult>
    {
        public CheckSettings CheckSettings => new CheckSettings
        {
            Priority = PrioritiesEnum.High,
            Service = "Desktop Markup Check",
            Type = CheckTypeEnum.HtmlDesktopBeta,
            EnvironmentId = (int)EnvironmentsEnum.Beta,
            CheckFullDescription = "Проверяет возврат десктопной версии сайта"
        };
    }

    public class DesktopVersionCheckCommandHandler : IRequestHandler<DesktopVersionCheckCommand, CommandResult>
    {
        private readonly IHttpRequestService _httpService;

        public DesktopVersionCheckCommandHandler(IHttpRequestService httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }

        public async Task<CommandResult> Handle(DesktopVersionCheckCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult
            {
                Success = true,
                CheckModel = await new LayoutVariantCheck(_httpService).PerformCheck(request.CheckSettings, true)
            };

            return result;
        }
    }
}
