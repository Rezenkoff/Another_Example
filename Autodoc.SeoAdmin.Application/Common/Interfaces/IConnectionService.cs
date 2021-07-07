using System.Data;

namespace Autodoc.SeoAdmin.Application.Interfaces
{
    public interface IConnectionService
    {
        IDbConnection GetConnection ();
    }
}
