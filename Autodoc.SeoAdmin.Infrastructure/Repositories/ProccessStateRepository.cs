using Autodoc.SeoAdmin.Application.Common.Interfaces.Repositories;
using Autodoc.SeoAdmin.Application.Common.Models;
using Autodoc.SeoAdmin.Application.Interfaces;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Infrastructure.Repositories
{
    public class ProccessStateRepository  : IProccessStateRepository
    {
        private readonly IConnectionService _connectionServie;
        public ProccessStateRepository(IConnectionService connectionServie)
        {
            _connectionServie = connectionServie;
        }
        public async Task<ProccessingStateModel> GetSavedState (int pageTypeId)
        {
            var state = new ProccessingStateModel();

            using (var db = _connectionServie.GetConnection())
            {
                string processQuery = @$"
                                SELECT 
                                batchsize AS BatchSize, 
                                batchstep AS BatchStep, 
                                kindtypeid AS PageType, 
                                proccessdatetime AS ProccessingTime,
                                status AS ProccessingTime
                                FROM autodoc.poccessstate WHERE kindtypeid = { pageTypeId }";

                return (await db.QueryAsync<ProccessingStateModel>(processQuery)).FirstOrDefault() ?? state; 
            }
        }

        public async Task SaveProccessedState (ProccessingStateModel stateModel)
        {
            using (var db = _connectionServie.GetConnection())
            {
                string processQuery = @$"DO
                $do$
                BEGIN
                IF NOT EXISTS (SELECT kindtypeid FROM autodoc.poccessstate WHERE kindtypeid = { stateModel.PageType }) THEN
                    INSERT INTO autodoc.poccessstate (batchsize, batchstep, kindtypeid, proccessdatetime, status)
	                VALUES ({ stateModel.BatchSize }, { stateModel.BatchStep }, { stateModel.PageType }, '{ stateModel.ProccessingTime }', { (int)stateModel.ProccessStatus });
                ELSE
                    UPDATE autodoc.poccessstate SET batchsize = { stateModel.BatchSize }, batchstep = { stateModel.BatchStep }, kindtypeid = { stateModel.PageType }, proccessdatetime = '{ stateModel.ProccessingTime }', status = { (int)stateModel.ProccessStatus } WHERE kindtypeid = { stateModel.PageType };
                END IF;
                END;
                $do$";

                await db.QueryAsync(processQuery);
            }
        }
    }
}
