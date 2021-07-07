using Monitor.Application.MonitoringChecks.Models;
using System.Threading.Tasks;

namespace Monitor.Application.Interfaces
{
    public interface ISeoPagesTagsRepository
    {
        Task<SeoMetaTagsModel> GetMetaTagsByPageExtId(int pageExtId);
    }
}
