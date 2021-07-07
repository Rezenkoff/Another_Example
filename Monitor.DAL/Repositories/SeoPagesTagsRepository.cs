using Dapper;
using Microsoft.Extensions.Configuration;
using Monitor.Application.Interfaces;
using Monitor.Application.MonitoringChecks.Models;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Monitor.DAL.Repositories
{
    public class SeoPagesTagsRepository : ISeoPagesTagsRepository
    {
        private readonly string _connectionString;

        public SeoPagesTagsRepository(IConfiguration config)
        {
            if (config["ConnectionStrings:DefaultConnection"] == null)
                throw new ArgumentNullException("config");

            _connectionString = config["ConnectionStrings:DefaultConnection"];
        }

        public async Task<SeoMetaTagsModel> GetMetaTagsByPageExtId(int pageExtId)
        {
            try
            {
                var query = $"SELECT TOP (1) [metaTags] FROM [AutodocShared].[dbo].[SEO_PAGES_TAGS] WHERE PageExtId = @pageExtId";

                using (var connection = new SqlConnection(_connectionString))
                {
                    var stringResult = await connection.QuerySingleAsync<string>(query, new { pageExtId });
                    var result = JsonConvert.DeserializeObject<SeoMetaTagsModel>(stringResult);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
