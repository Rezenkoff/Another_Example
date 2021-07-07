using AutoMapper;
using Monitor.Application.Dashboard.Models;
using Monitor.Application.Dashboard.Models.Sales;
using Monitor.Persistence.Dashboard.Models;

namespace Monitor.Dashboard.Mappings
{
    public class DashboardMappingProfile : Profile
    {
        public DashboardMappingProfile()
        {
            CreateMap<EFMontlySalesInfoModel, MonthlySalesInfoModel>();
            CreateMap<MonthlySalesInfoModel, EFMontlySalesInfoModel>();
            CreateMap<EFGoogleAnaliticCache, SessionVisitModel>();
            CreateMap<SessionVisitModel, EFGoogleAnaliticCache>();
        }
    }    
}
