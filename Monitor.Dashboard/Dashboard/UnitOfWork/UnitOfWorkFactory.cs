using Microsoft.Extensions.Configuration;
using Monitor.DAL.Interfaces;
using Monitor.DAL.UnitOfWork;
using System;
using System.Data.SqlClient;

namespace Monitor.Dashboard.Monitoring.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _connectionString;
        public UnitOfWorkFactory(IConfiguration config)
        {
            if (config["ConnectionStrings:DefaultConnection"] == null)
                throw new ArgumentNullException("config");

            _connectionString = config["ConnectionStrings:DefaultConnection"];
        }
        public IUnitOfWork Create()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            return new AdoNetUnitOfWork(connection);
        }
    }
}
