using Autodoc.SeoAdmin.Domain.Entities;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces
{
    public interface IUrlBuilder
    {
        string Build (RawSeoModel model);
    }
}
