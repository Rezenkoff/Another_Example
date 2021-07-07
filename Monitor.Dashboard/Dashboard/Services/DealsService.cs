using Monitor.Application.Dashboard.Interfaces.Provides;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Dashboard.Models;
using Monitor.Application.Dashboard.Models.Constants;
using Monitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.Services
{
    public class DealsService : IDealsService
    {
        private readonly IBitrixProvider _bitrixProvider;
        private readonly IOrderRepository _orderRepository;
        private  string stateReturn;
        private  string stateReturnVD;
        private  string stateVD;
        private  string autoReturned;
        private  string autoRet_RetPartRet;

        public DealsService(IBitrixProvider bitrixProvider, IOrderRepository orderRepository)
        {
            _bitrixProvider = bitrixProvider;
            _orderRepository = orderRepository;

            InitUrl();
        }

        private void InitUrl()
        {
            stateReturn = $"&filter[STAGE_ID][0]={BitrixConstants.RequestReturn}" +
                          $"&filter[STAGE_ID][1]={BitrixConstants.AutoReturn}" +
                          $"&filter[STAGE_ID][2]={BitrixConstants.PartsReturn}" +
                          $"&filter[STAGE_ID][3]={BitrixConstants.Return}" +
                          $"&filter[STAGE_ID][4]={BitrixConstants.AutoReturnSTO_1}" +
                          $"&filter[STAGE_ID][5]={BitrixConstants.PartsReturnSTO_1}" +
                          $"&filter[STAGE_ID][6]={BitrixConstants.ReturnSTO}" +
                          $"&filter[STAGE_ID][7]={BitrixConstants.ReturnProduct}" +
                          $"&filter[STAGE_ID][8]={BitrixConstants.PartsReturnProduct}" +
                          $"&filter[STAGE_ID][9]={BitrixConstants.AutoReturnSTO_2}" +
                          $"&filter[STAGE_ID][10]={BitrixConstants.ReturnProductSTO}" +
                          $"&filter[STAGE_ID][11]={BitrixConstants.PartsReturnSTO_2}" +
                          $"&filter[STAGE_ID][12]={BitrixConstants.ReturnSucces}";

            stateReturnVD = $"&filter[STAGE_ID][0]={BitrixConstants.RequestReturn_2}" +
                            $"&filter[STAGE_ID][1]={BitrixConstants.AutoRequestReturn}" +
                            $"&filter[STAGE_ID][2]={BitrixConstants.PartsReturn}" +
                            $"&filter[STAGE_ID][3]={BitrixConstants.Return}" +
                            $"&filter[STAGE_ID][4]={BitrixConstants.AutoReturnSTO_1}" +
                            $"&filter[STAGE_ID][5]={BitrixConstants.PartsReturnSTO_1}" +
                            $"&filter[STAGE_ID][6]={BitrixConstants.ReturnSTO}" +
                            $"&filter[STAGE_ID][7]={BitrixConstants.RequestReturn}" +
                            $"&filter[STAGE_ID][8]={BitrixConstants.AutoReturn}" +
                            $"&filter[STAGE_ID][9]={BitrixConstants.ReturnProduct}" +
                            $"&filter[STAGE_ID][10]={BitrixConstants.PartsReturnProduct}" +
                            $"&filter[STAGE_ID][11]={BitrixConstants.AutoReturnSTO_2}" +
                            $"&filter[STAGE_ID][12]={BitrixConstants.ReturnProductSTO}" +
                            $"&filter[STAGE_ID][13]={BitrixConstants.PartsReturnSTO_2}" +
                            $"&filter[STAGE_ID][14]={BitrixConstants.ReturnSucces}";

            stateVD = $"&filter[STAGE_ID][0]={BitrixConstants.NotRequest}" +
                      $"&filter[STAGE_ID][1]={BitrixConstants.InWork}" +
                      $"&filter[STAGE_ID][2]={BitrixConstants.Selection}" +
                      $"&filter[STAGE_ID][3]={BitrixConstants.Expectation}" +
                      $"&filter[STAGE_ID][4]={BitrixConstants.Processing}" +
                      $"&filter[STAGE_ID][5]={BitrixConstants.WaitingPay}" +
                      $"&filter[STAGE_ID][6]={BitrixConstants.PreparingToShip}" +
                      $"&filter[STAGE_ID][7]={BitrixConstants.InTransit}" +
                      $"&filter[STAGE_ID][8]={BitrixConstants.ReadyForExtradition}" +
                      $"&filter[STAGE_ID][9]={BitrixConstants.DealIsSuccessful}";

            autoReturned = $"&filter[STAGE_ID][0]={BitrixConstants.AutoRequestReturn}" +
                           $"&filter[STAGE_ID][1]={BitrixConstants.AutoReturnSTO_1}" +
                           $"&filter[STAGE_ID][2]={BitrixConstants.AutoReturn}" +
                           $"&filter[STAGE_ID][3]={BitrixConstants.AutoReturnSTO_2}";


            autoRet_RetPartRet = $"&filter[STAGE_ID][0]={BitrixConstants.PartsReturn}" +
                                 $"&filter[STAGE_ID][1]={BitrixConstants.Return}" +
                                 $"&filter[STAGE_ID][2]={BitrixConstants.PartsReturnSTO_1}" +
                                 $"&filter[STAGE_ID][3]={BitrixConstants.ReturnSTO}" +
                                 $"&filter[STAGE_ID][4]={BitrixConstants.RequestReturn}" +
                                 $"&filter[STAGE_ID][5]={BitrixConstants.ReturnProduct}" +
                                 $"&filter[STAGE_ID][6]={BitrixConstants.PartsReturnProduct}" +
                                 $"&filter[STAGE_ID][7]={BitrixConstants.ReturnProductSTO}" +
                                 $"&filter[STAGE_ID][8]={BitrixConstants.PartsReturnSTO_2}";
               
        }

        public async Task<DealsModel> GetDeals()
        {
            var newDealsCount = await _bitrixProvider.GetDealsCount(BitrixConstants.NotProcessed);

            var inWorkDealCount = await _bitrixProvider.GetDealsCount(BitrixConstants.InWork);
            var selectionDealsCount = await _bitrixProvider.GetDealsCount(BitrixConstants.Selection);
            var expectationDealsCount = await _bitrixProvider.GetDealsCount(BitrixConstants.Expectation);
            var processingDealsCount = await _bitrixProvider.GetDealsCount(BitrixConstants.Processing);
            var inWorkDealsCountTotal = inWorkDealCount + selectionDealsCount + expectationDealsCount + processingDealsCount;
            var readyForExtraditionDeaslCountFromBitrix = await _bitrixProvider.GetDealsCount(BitrixConstants.ReadyForExtradition);
            var requestReturnFromBitrix = await _bitrixProvider.GetDealsCount(BitrixConstants.RequestReturn);

            var dataFromAutodoc = await _orderRepository.GetDealCountByOrderStatusId();

            int awaitingPaymentDealCount = 0;
            int paidDealsCount = 0;
            int preparingToShip = 0;
            int inTransitDealsCount = 0;
            //int readyForExtraditionDeaslCountFromDb = 0;
            int issuedDealsCount = 0;

            foreach (var d in dataFromAutodoc)
            {
                switch ((int)d.Key)
                {
                    case 9:
                        awaitingPaymentDealCount = (int)d.Value;
                        break;
                    case 10:
                        paidDealsCount = (int)d.Value;
                        break;
                    case 3:
                        preparingToShip = (int)d.Value;
                        break;
                    case 4:
                        inTransitDealsCount = (int)d.Value;
                        break;
                    //case 6:
                    //    readyForExtraditionDeaslCountFromDb = (int)d.Value;
                    //    break;
                    case 7:
                        issuedDealsCount = (int)d.Value;
                        break;
                }
            }

            var preparingToShipDealsCountTotal = paidDealsCount + preparingToShip;
            var readyForExtraditionDeaslCountTotal = /*readyForExtraditionDeaslCountFromDb +*/ readyForExtraditionDeaslCountFromBitrix;

            var result = new DealsModel()
            {
                NewDealsCount = newDealsCount,
                InWorkDealsCount = inWorkDealsCountTotal,
                AwaitingPaymentDealsCount = awaitingPaymentDealCount,
                PreparingToShipDealsCount = preparingToShipDealsCountTotal,
                InTransitDealsCount = inTransitDealsCount,
                ReadyForExtraditionDealsCount = readyForExtraditionDeaslCountTotal,
                IssuedDealsCount = issuedDealsCount,
                RequestReturnCount = requestReturnFromBitrix,
                Total = newDealsCount + inWorkDealsCountTotal + awaitingPaymentDealCount + preparingToShipDealsCountTotal 
                    + inTransitDealsCount + readyForExtraditionDeaslCountTotal + issuedDealsCount
            };

            return result;
        }

        public async Task<ConversionModel> GetConversion() {

            var successfullDealsPerDay = await _bitrixProvider.GetSuccessfullDealsCountBaseOnDate((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss"), "");
            var allDealDay             = await _bitrixProvider.GetLeads((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss"), "");

            var successfullDealsPerMonth = await _bitrixProvider.GetSuccessfullDealsCountBaseOnDate((DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss"), "");
            var allDealMonth             = await _bitrixProvider.GetLeads((DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss"), "");

            return new ConversionModel(successfullDealsPerDay.Item1,
                                       allDealDay,
                                       successfullDealsPerMonth.Item1,
                                       allDealMonth);
        }

        public async Task<SuccessfullDealsModel> SuccessfullDeals()
        {
            var succesDeals = new SuccessfullDealsModel();

            var managersList = await _orderRepository.GetManagers();

            int allDealsDay = await _bitrixProvider.GetLeads((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss"), "");
            int allDealsMonth = await _bitrixProvider.GetLeads((DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss"), "");

            foreach (var m in managersList)
            {
                (int, int) succesDealsDay = await _bitrixProvider.GetSuccessfullDealsForEachManager((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss"), m.Key.ToString());                                     // succes deals per day for manager
                //int allDealsDay = await _bitrixProvider.GetLeads((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss"), m.Key.ToString());                                                                      // all deals per day for manager
                (int, int) succesDealsMonth = await _bitrixProvider.GetSuccessfullDealsForEachManager((DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss"), m.Key.ToString());  // succes deals per month for manager
                //int allDealsMonth = await _bitrixProvider.GetLeads((DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss"), m.Key.ToString());                                   // all deals per month for manager
                string photoManager = await _bitrixProvider.GetPhotoManagerById(m.Key.ToString());

                succesDeals.managerList.Add(new ManagerDeals(m.Key,    //id manager
                                                             m.Value,  //name of manager
                                                             succesDealsDay.Item1,
                                                             succesDealsDay.Item2,
                                                             allDealsDay,
                                                             succesDealsMonth.Item1,
                                                             succesDealsMonth.Item2,
                                                             allDealsMonth,
                                                             photoManager));
            }

            return succesDeals;
        }

        public async Task<ReturnedMonthModel> GetReturnedMonth(bool recount = false)
        {
            //int returnedMonth = await _bitrixProvider.GetReturnedMonthCount(stateReturn);
            int returnedMonth = await _orderRepository.GetCountOfReturnedByMonth();
            int countSalesMonth = await _orderRepository.GetCountOfSalesByMonth();

            double returnedMonthVD = await _bitrixProvider.GetReturnedMonthSumOpportunity(stateReturnVD, 0, recount);
            double sumVD = await _bitrixProvider.GetReturnedMonthSumOpportunity(stateVD, 1, recount);

            //int autoRet = await _bitrixProvider.GetReturnedMonthCount(autoReturned);
            //int autoRet_R_PR = await _bitrixProvider.GetReturnedMonthCount(autoRet_RetPartRet);
            int autoRet = await _orderRepository.GetCountOfAutoReturnedByMonth();
            int autoRet_R_PR = await _orderRepository.GetCountOfReturnedAndPartReturnedByMonth();

            return new ReturnedMonthModel(returnedMonth, countSalesMonth, returnedMonthVD, sumVD, autoRet, autoRet_R_PR);
        }
    }
}
