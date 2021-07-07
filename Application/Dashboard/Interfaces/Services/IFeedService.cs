using Monitor.Application.MonitoringChecks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Application.Dashboard.Interfaces.Services
{
   public interface IFeedService
    {
        Task<Check> GetFeedStatus(string feedtype);
    }
}
