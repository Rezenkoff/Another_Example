using System.Threading.Tasks;

namespace Monitor.Application.Dashboard.Interfaces.Provides
{
    public interface IBitrixProvider
    {
        Task<int> GetDealsCount(string dealStage);
        Task<(int, int)> GetSuccessfullDealsCountBaseOnDate(string date, string managerId);
        Task<int> GetTelephony(string date, string dateTo = "", int callFailedCode = 0, int minCallDuration = 0);
        Task<int> GetLeads(string date, string managerId);
        Task<(int, int)> GetSuccessfullDealsForEachManager(string date, string managerId);
        Task<string> GetPhotoManagerById(string managerId);
        Task<int> GetReturnedMonthCount(string state);
        Task<double> GetReturnedMonthSumOpportunity(string states, int category, bool needRecount);
    }
}
