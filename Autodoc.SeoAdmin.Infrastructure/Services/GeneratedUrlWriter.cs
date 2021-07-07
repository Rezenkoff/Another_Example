using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Application.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Infrastructure.Services
{
    public class GeneratedUrlWriter : IGeneratedUrlWriter
    {
        private readonly IConnectionService _connectionServie;
        public GeneratedUrlWriter(IConnectionService connectionServie)
        {
            _connectionServie = connectionServie;
        }
        public async Task WriteGeneratedUrls (IEnumerable<UrlCombinationModel> generatedModelsList)
        {
            using (var db = _connectionServie.GetConnection())
            {
                string processQuery = @$"INSERT INTO autodoc.generatedurlsarticles(linkid, generatedurl, hashcode, lastdate, createdate, statusid) VALUES";
                var last = generatedModelsList.Last();
                foreach (var item in generatedModelsList)
                {
                    var comm = !last.Equals(item) ? "," : "";
                    processQuery += $"({item.SeoParamId},'{item.TransliteratedUrl}','{item.HashCode}','{item.LastAccess.ToString("yyyy-MM-dd")}','{item.Created.ToString("yyyy-MM-dd")}',{(int)item.GenerationStatus}){comm}";
                }
                await db.QueryAsync(processQuery);
            }
        }
    }
}
