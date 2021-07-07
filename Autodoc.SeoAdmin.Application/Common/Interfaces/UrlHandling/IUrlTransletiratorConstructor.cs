using Autodoc.SeoAdmin.Application.Common.Models;
using System.Collections.Generic;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling
{
    public interface IUrlTransletiratorConstructor<T>
    {
        IUrlTransletiratorConstructor<T> SetNext (IUrlTransletiratorConstructor<T> handler);
        IEnumerable<UrlCombinationModel> Handle (T request);
    }
}
                                    