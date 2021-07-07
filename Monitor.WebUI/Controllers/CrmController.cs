using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Monitor.Application.Dashboard.Models.BitrixModels;
using Monitor.Application.Interfaces;
using Monitor.Dashboard.Settings;
using System;
using System.Threading.Tasks;

namespace Monitor.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrmController : ControllerBase
    {
        private readonly ISignalRNotificationsService _signalRNotificationsService;
        private readonly BitrixSettings _bitrixSettings;

        public CrmController(ISignalRNotificationsService signalRNotificationsService, IOptions<BitrixSettings> bitrixSettingsAccessor)
        {
            _signalRNotificationsService = signalRNotificationsService ?? throw new ArgumentNullException(nameof(signalRNotificationsService));
            _bitrixSettings = bitrixSettingsAccessor.Value ?? throw new ArgumentNullException(nameof(_bitrixSettings));
        }

        [HttpGet("onCrmDealAdd")]
        public async Task<IActionResult> OnCrmDealAdd([FromQuery]OnCrmNewDealModel model)
        {
            if (model.Token != _bitrixSettings.BitrixWebhookToken)
            {
                return BadRequest();
            }
            await _signalRNotificationsService.DashboardNotify(model);
            return Ok();
        }
    }
}