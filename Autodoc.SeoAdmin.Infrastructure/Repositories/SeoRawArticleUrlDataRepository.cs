using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Application.Interfaces;
using Autodoc.SeoAdmin.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace Autodoc.SeoAdmin.Infrastructure.Repositories
{
    public class SeoRawArticleUrlDataRepository : ISeoRawDataRepository<RawSeoModelArticle>
    {
        private readonly IConnectionService _connectionServie;
        
        public SeoRawArticleUrlDataRepository(IConnectionService connectionServie)
        {
            _connectionServie = connectionServie;
        }
        public async Task<IEnumerable<RawSeoModelArticle>> GetRawUrlData (int batchSize, int batchStep)
        {
            using (var db = _connectionServie.GetConnection())
            {
                string processQuery = @$"SELECT als.id,
                                        asp.articleid,
                                        asp.articlename AS articlename,
                                        atap.namerus AS nodename,
                                        atap.nodeid,
                                        asup.suppliername AS suppliername,
                                        asp.supplierid,
                                        aos.statusname AS outstatus,
                                        als.outstatusid AS outgoingstatus,
                                        ais.statusname AS inputstatus,
                                        als.inputstatusid AS incomingstatus
                                        FROM autodoc.link_seotogen_article als
                                        LEFT JOIN autodoc.tree_auto_part atap ON als.nodeid = atap.nodeid
                                        LEFT JOIN autodoc.seourlparamarticles asp ON asp.id = als.paramartid
                                        LEFT JOIN autodoc.suppliers asup ON asup.supplierid = als.supplierid
                                        JOIN autodoc.generationstatus aos ON aos.id = als.outstatusid
                                        JOIN autodoc.linkingstatus ais ON ais.id = als.inputstatusid
                                        ORDER BY als.id
                                        LIMIT { batchSize } OFFSET { batchStep }";
                var result = await db.QueryAsync<RawSeoModelArticle>(processQuery);

                return result;
            }
        }
    }
}
