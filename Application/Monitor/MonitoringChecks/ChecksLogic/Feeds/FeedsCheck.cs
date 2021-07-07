using MediatR;
using Monitor.Application.Dashboard.Interfaces;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.MonitoringChecks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Application.Monitor.MonitoringChecks.ChecksLogic.Feeds
{
    public class FeedsCheck 
    {
        IFeedService _feedService;
        public FeedsCheck(IFeedService feedService)
        {
            _feedService = feedService;
        }

        public async Task<Check> CheckFeeds(CheckSettings settings, string feedName)
        {
            Check result  = await _feedService.GetFeedStatus(feedName);
            result.Settings = settings;

            return result;

        }

    }
}
