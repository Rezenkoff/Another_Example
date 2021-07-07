using MediatR;
using Monitor.Application.Dashboard.Models;
using Monitor.Application.Interfaces;

namespace Monitor.Dashboard.Monitoring.Queries
{
    public class GetConversionQuery : IQuery<ConversionModel>, IRequest<ConversionModel>
    {
    }
}
