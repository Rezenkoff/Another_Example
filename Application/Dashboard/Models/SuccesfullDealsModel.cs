using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Application.Dashboard.Models
{
    public class SuccessfullDealsModel
    {
        public List<ManagerDeals> managerList = new List<ManagerDeals>();
    }

    public class ManagerDeals
    {
        public ManagerDeals(int id, string name, int successfullDealDay, int successfullDealDayMoney, int allDealDay, int successfullDealMonth, int successfullDealMonthMoney, int allDealMonth, string photoUrl)
        {
            IdCrm = id;
            Name = name;
            SuccessfullDealsDay = successfullDealDay;
            SuccessfullDealsDayMoney = successfullDealDayMoney;
            AllDealsDay = allDealDay;
            SuccessfullDealsMonth = successfullDealMonth;
            SuccessfullDealsMonthMoney = successfullDealMonthMoney;
            AllDealsMonth = allDealMonth;
            PhotoUrl = photoUrl;
        }
        public int IdCrm { get; set; }
        public string Name { get; set; }
        public int SuccessfullDealsDay {get;set;}
        public int SuccessfullDealsDayMoney {get;set;}
        public int AllDealsDay { get; set; }
        public int SuccessfullDealsMonth { get; set; }
        public int SuccessfullDealsMonthMoney { get; set; }
        public int AllDealsMonth { get; set; }
        public string PhotoUrl { get; set; }
    }
}
