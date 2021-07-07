using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Application.Interfaces
{
    public interface IMetaTemplateLoader
    {
        IEnumerable<MetaTagTemplateModel> LoadTemplates ();
    }
}
