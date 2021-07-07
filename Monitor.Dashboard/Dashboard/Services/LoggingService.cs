using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Dashboard.Monitoring.UnitOfWork;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly IUnitOfWorkFactory _uowf;

        public LoggingService(IUnitOfWorkFactory uowf)
        {
            _uowf = uowf ?? throw new ArgumentNullException("unit of work");
        }

        public async Task<int> GetOrderCount(DateTime from, DateTime to, int mode)
        {
            var result = 0;

            using (var uow = _uowf.Create())
            {
                using (var sqlCommand = uow.CreateCommand() as SqlCommand)
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "[dbo].[GetOrderForStatistic]";
                    sqlCommand.Parameters.AddWithValue("@DateFrom", from);
                    sqlCommand.Parameters.AddWithValue("@DateTo", to);
                    sqlCommand.Parameters.AddWithValue("@Mode", mode);

                    var exec = await sqlCommand.ExecuteScalarAsync();
                    if (exec != null && !string.IsNullOrEmpty(exec.ToString()))
                        result = Convert.ToInt32(exec.ToString());
                }
            }
            return result;
        }

        public async Task<long> GetReturnedOrderSumm(DateTime from, DateTime to)
        {
            long result = 0;

            using (var uow = _uowf.Create())
            {
                using (var sqlCommand = uow.CreateCommand() as SqlCommand)
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "[dbo].[GetReturnedOrderSumm]";
                    sqlCommand.Parameters.AddWithValue("@DateFrom", from);
                    sqlCommand.Parameters.AddWithValue("@DateTo", to);

                    var exec = await sqlCommand.ExecuteScalarAsync();
                    if (exec != null && !string.IsNullOrEmpty(exec.ToString()))
                        result = Convert.ToInt64(exec);
                }
            }

            return result;
        }
    }
}
