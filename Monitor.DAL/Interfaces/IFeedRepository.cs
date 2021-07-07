using Monitor.Application.MonitoringChecks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.DAL.Interfaces
{
    public interface IFeedRepository
    {
         Task<Check> GetFeedStatus(string feedType);
    }
}
