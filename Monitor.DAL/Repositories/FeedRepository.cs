using Microsoft.Extensions.Configuration;
using Monitor.Application.MonitoringChecks.Models;
using Monitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.DAL.Repositories
{
    public class FeedRepository : IFeedRepository
    {

        private readonly string _connectionString;
        private IConfiguration _config;
        public FeedRepository(IConfiguration config)
        {
            if (config["ConnectionStrings:DefaultConnection"] == null)
                throw new ArgumentNullException("config");
            _config = config;
            _connectionString = config["ConnectionStrings:DefaultConnection"];
        }
        public async Task<Check> GetFeedStatus(string feedType)
        {
            Check check = new Check();
            check.State = new CheckState
            {
                Description = "Information not found",
                Status = StatusesEnum.WARNING
            };
            decimal minSize;
            if (!Decimal.TryParse(_config["Feeds:" + feedType], out minSize))
            {
                check.State = new CheckState
                {
                    Description = feedType + ":NoFeedMinimalSizeInConfig",
                    Status = StatusesEnum.WARNING
                };
                return check;
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand())
                {
                    connection.Open();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "[dbo].[GetFeedInformation]";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedType", feedType));
                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {

                        while (reader.Read())
                        {
                            int size = (int)reader["Size"];
                            decimal sizeConverted = size > 0 ? (decimal)(size / 1024) / 1024 : 0; ;

                            string _description = reader["Exception"].ToString();
                            _description = _description.Length > 1 ? _description
                                : " FileSize: " + sizeConverted.ToString("#.##") + "МБ "
                                + " MinFileSize: " + minSize.ToString("#.##") + "МБ " + _description;

                            check.State = new CheckState
                            {
                                StatusChangeTime = (DateTime)reader["LastUpdate"],
                                Description = _description,
                                Status = sizeConverted > minSize ? StatusesEnum.OK : StatusesEnum.CRITICAL
                            };
                        }
                    }
                }

                return check;
            }
        }
    }
}
