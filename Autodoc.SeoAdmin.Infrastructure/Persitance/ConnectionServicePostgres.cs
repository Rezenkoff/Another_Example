using Autodoc.SeoAdmin.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Autodoc.SeoAdmin.Infrastructure.Persitance
{
    public class ConnectionServicePostgres  : IConnectionService
    {
        private readonly IConfiguration _configuration;
        public ConnectionServicePostgres (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection ()
        {
            var connectionString = _configuration.GetSection("ConnectionStrings:AutodocPostgresDbConnection")?.Value;

            return new NpgsqlConnection(connectionString);
        }
    }
}
