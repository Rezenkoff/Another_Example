using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Autodoc.SeoAdmin.Infrastructure.Persitance
{
    public class ConnectionServiceSql
    {
        private readonly IConfiguration _configuration;
        public ConnectionServiceSql (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection ()
        {
            var connectionString = _configuration.GetSection("ConnectionStrings:AutodocDbConnection")?.Value;

            return new SqlConnection(connectionString);
        }
    }
}
