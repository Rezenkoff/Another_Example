using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces
{
    public interface IConstructorsSequenceBuilder<T>
    {
        IUrlTransletiratorConstructor<T> BuildChain ();    
    }
}
