using Microsoft.Extensions.Options;
using Monitor.Application.Dashboard.Interfaces.Provides;
using Monitor.Application.Dashboard.Models.BitrixModels;
using Monitor.Application.Dashboard.Models.Constants;
using Monitor.Dashboard.Settings;
using Monitor.Persistence.Dashboard;
using Monitor.Persistence.Dashboard.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace Monitor.Dashboard.Monitoring.Providers
{
    public class BitrixProvider : IBitrixProvider
    {
        private readonly IOptions<BitrixSettings> _bitrixSettings;
        private DashboardContext _context;

        public BitrixProvider(IOptions<BitrixSettings> bitrixSettings, DashboardContext context)
        {
            _bitrixSettings = bitrixSettings;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> GetDealsCount(string dealStage)
        {
            var url = _bitrixSettings.Value.BitrixUrl + $"crm.deal.list?filter[STAGE_ID]={dealStage}&filter[=CATEGORY_ID]=0";

            using (var client = new HttpClient())
            {

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var deals = JsonConvert.DeserializeObject<BitrixResponseModel>(responseString);
                    return deals.Total;
                }
                else
                {
                    return -1;
                }
            }
        }

        public async Task<(int, int)> GetSuccessfullDealsCountBaseOnDate(string date, string managerId)
        {
            var url = _bitrixSettings.Value.BitrixUrl + $"crm.deal.list?filter[>DATE_MODIFY]={date}&filter[STAGE_ID][0]=22&filter[STAGE_ID][1]=FINAL_INVOICE&filter[STAGE_ID][2]=1&filter[STAGE_ID][3]=WON" + managerId;

            using (var client = new HttpClient())
            {
                int sum = 0;
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var deals = JsonConvert.DeserializeObject<BitrixResponseModel>(responseString);
                    if (!String.IsNullOrEmpty(managerId))
                    {
                        sum = GetTotalSumSuccessfullDeals(deals);
                    }
                    return (deals.Total, sum);
                }
                else
                {
                    return (-1, -1);
                }
            }
        }

        private int GetTotalSumSuccessfullDeals(BitrixResponseModel deals)
        {
            double sum = 0;
            try
            {
                //deals.Result.ForEach(d => { sum += double.Parse(d.OPPORTUNITY); });

                foreach (var d in deals.Result)
                {
                    sum += double.Parse(d.OPPORTUNITY, provider: CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {

            }
            return (int)sum;
        }

        public async Task<int> GetTelephony(string dateFrom, string dateTo = "", int callFailedCode = 0, int minCallDuration = 0)
        {
            var url = _bitrixSettings.Value.BitrixUrl + $"voximplant.statistic.get?filter[CALL_TYPE]=2&filter[>CALL_START_DATE]={dateFrom}";
            if (callFailedCode > 0)
            {
                url += $"&filter[CALL_FAILED_CODE]={callFailedCode}";
            }
            if (!string.IsNullOrEmpty(dateTo))
            {
                url += $"&filter[<CALL_START_DATE]={dateTo}";
            }
            if (minCallDuration > 0)
            {
                url += $"&filter[>CALL_DURATION]={minCallDuration}";
            }

            using (var client = new HttpClient())
            {

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var telephony = JsonConvert.DeserializeObject<BitrixResponseTelephony>(responseString);
                    return telephony.Total;
                }
                else
                {
                    return -1;
                }
            }
        }

        public async Task<int> GetLeads(string date, string managerId)
        {
            if (!String.IsNullOrEmpty(managerId))
            {
                managerId = $"&filter[ASSIGNED_BY_ID]={managerId}";
            }

            var urlAllDeal = _bitrixSettings.Value.BitrixUrl + $"crm.deal.list?filter[>DATE_MODIFY]={date}" + managerId;
            var urlTestAndDuableDeal = _bitrixSettings.Value.BitrixUrl + $"crm.deal.list?filter[>DATE_MODIFY]={date}" + managerId + "&filter[STAGE_ID][0]=LOSE&filter[STAGE_ID][1]=3";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(urlAllDeal);
                var responseSecond = await client.GetAsync(urlTestAndDuableDeal);

                if (response.IsSuccessStatusCode && responseSecond.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var deals = JsonConvert.DeserializeObject<BitrixResponseTelephony>(responseString);

                    responseString = await responseSecond.Content.ReadAsStringAsync();
                    var dealsTest = JsonConvert.DeserializeObject<BitrixResponseTelephony>(responseString);

                    return deals.Total - dealsTest.Total;
                }
                else
                {
                    return -1;
                }
            }
        }

        public async Task<(int, int)> GetSuccessfullDealsForEachManager(string date, string managerId)
        {
            if (!String.IsNullOrEmpty(managerId))
            {
                managerId = $"&filter[ASSIGNED_BY_ID]={managerId}";
            }
            return await GetSuccessfullDealsCountBaseOnDate(date, managerId);
        }

        public async Task<string> GetPhotoManagerById(string managerId)
        {
            try
            {
                var url = _bitrixSettings.Value.BitrixUrl + $"user.get?ID={managerId}";

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();

                        var photo = JsonConvert.DeserializeObject<BitrixResponseUser>(responseString);
                        return photo.Result.Count > 0 ? photo.Result[0].PERSONAL_PHOTO : "";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch
            {
                return "";
            }

        }

        public async Task<int> GetReturnedMonthCount(string states)
        {
            string date = (DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss");

            var url = _bitrixSettings.Value.BitrixUrl + $"crm.deal.list?filter[>DATE_MODIFY]={date}" + states;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var deals = JsonConvert.DeserializeObject<BitrixResponseModel>(responseString);

                    return deals.Total;
                }
                else
                {
                    return -1;
                }
            }
        }

        public async Task<double> GetReturnedMonthSumOpportunity(string states, int category, bool needRecount)
        {
            string date = (DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss");
            string url = _bitrixSettings.Value.BitrixUrl + $"crm.deal.list?filter[>DATE_MODIFY]={date}" + states;

            var efReturnedOrderNew = new EFReturnedOrder();
            efReturnedOrderNew.Category = category;
            efReturnedOrderNew.DateQuery = DateTime.Now;

            var objReturnedOld = _context.ReturnedOrder.OrderByDescending(x => x.DateQuery).Where(x => x.Category == category).FirstOrDefault();

            if (objReturnedOld == null || needRecount)
            {
                efReturnedOrderNew = await CountSumAgain(states, category);
                _context.ReturnedOrder.AddRange(efReturnedOrderNew);
                await _context.SaveChangesAsync();
            }
            else
            {
                //efReturnedOrderNew = await CountSumToAdd(states, category, objReturnedOld);
                efReturnedOrderNew.Sum_Opportunity = objReturnedOld.Sum_Opportunity;
            }
                     
            return efReturnedOrderNew.Sum_Opportunity;
        }

        private async Task<EFReturnedOrder> CountSumToAdd(string states, int category, EFReturnedOrder efReturnedOrderOld)
        {
            double countOpportunity = 0;
            var efReturnedOrderNew = new EFReturnedOrder();
            var bitrixRespMod = new BitrixResponseModelNext();
            string date = (DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss");
            string url = _bitrixSettings.Value.BitrixUrl + $"crm.deal.list?filter[>DATE_MODIFY]={date}" + states;
            int start = efReturnedOrderOld.Last_Next;

            try
            {      
                url += $"&start={start}";

                do
                {
                    bitrixRespMod = await GetRequest(url);
                    double getTotalSum = GetTotalSumOpportunity(bitrixRespMod);
                    countOpportunity += getTotalSum;

                    if (bitrixRespMod.Next != null)
                    {
                        start = (int)bitrixRespMod.Next;
                        url += $"&start={start}";
                    }
                    else
                    {
                        efReturnedOrderNew.Sum_Opportunity = (efReturnedOrderOld.Sum_Opportunity - efReturnedOrderOld.Sum_Opportunity_Tail) + countOpportunity;
                        efReturnedOrderNew.Sum_Opportunity_Tail = getTotalSum;
                        efReturnedOrderNew.Last_Next = start;
                        efReturnedOrderNew.Total = bitrixRespMod.Total;
                        efReturnedOrderNew.Category = category;
                        efReturnedOrderNew.DateQuery = DateTime.Now;
                    }

                } while (bitrixRespMod.Next != null);

            }
            catch (Exception ex)
            {

            }

            return efReturnedOrderNew;
        }

        private async Task<EFReturnedOrder> CountSumAgain(string states, int category)
        {
            double countOpportunity = 0;
            var bitrixRespMod = new BitrixResponseModelNext();
            var efReturnedOrderNew = new EFReturnedOrder();
            string date = (DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss");
            string url = _bitrixSettings.Value.BitrixUrl + $"crm.deal.list?filter[>DATE_MODIFY]={date}" + states;
            int start = 0;
            
            try
            {
                do
                {
                    bitrixRespMod = await GetRequest(url);
                    double getTotalSum = GetTotalSumOpportunity(bitrixRespMod);
                    countOpportunity += getTotalSum;

                    if (bitrixRespMod.Next != null)
                    {
                        start = (int)bitrixRespMod.Next;
                        url += $"&start={start}";
                    }
                    else
                    {                       
                        efReturnedOrderNew.Sum_Opportunity = countOpportunity;
                        efReturnedOrderNew.Sum_Opportunity_Tail = getTotalSum;
                        efReturnedOrderNew.Last_Next = start;
                        efReturnedOrderNew.Total = bitrixRespMod.Total;
                        efReturnedOrderNew.Category = category;
                        efReturnedOrderNew.DateQuery = DateTime.Now;                        
                    }                   
                } while (bitrixRespMod.Next != null);
            }
            catch (Exception ex)
            {

            }

            return efReturnedOrderNew;
        }

        private async Task<BitrixResponseModelNext> GetRequest(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var deals = JsonConvert.DeserializeObject<BitrixResponseModelNext>(responseString);

                    return deals;
                }
                else
                {
                    return null;
                }

            }
        }

        private double GetTotalSumOpportunity(BitrixResponseModelNext deals)
        {
            double sum = 0;
            try
            {
                foreach (var d in deals.Result)
                {
                    if (!String.IsNullOrEmpty(d.OPPORTUNITY))
                    {
                        sum += double.Parse(d.OPPORTUNITY, provider: CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sum;
        }
    }

}
