using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.MonitoringChecks.Models;
using Monitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.Services
{
    public class FeedService: IFeedService
    {
        private readonly IFeedRepository _feedRepository;

        public FeedService(IFeedRepository feedRepository)
        {
            _feedRepository = feedRepository;
        }

        public async Task<Check> GetFeedStatus(string feedtype)
        {

            return await _feedRepository.GetFeedStatus(feedtype);
        }
    }
}
