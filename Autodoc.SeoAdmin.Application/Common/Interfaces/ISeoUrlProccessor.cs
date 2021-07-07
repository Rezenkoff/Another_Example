using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Application.Common.Interfaces
{
    public interface ISeoUrlProccessor<T>
    {
        Task StartProccess ();
    }
}
