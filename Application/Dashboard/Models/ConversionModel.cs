using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Application.Dashboard.Models
{
    public class ConversionModel
    {
        public ConversionModel(int _successfullDealsPerDay, 
                               int _allDealDay,
                               int _successfullDealsPerMonth,
                               int _allDealMonth)           
        {
            SuccesfulDealsDay = _successfullDealsPerDay;
            AllDealsDay = _allDealDay;
            SuccesfulDealsMonth = _successfullDealsPerMonth;
            AllDealsMonth = _allDealMonth;
        }

        public int SuccesfulDealsDay { get; set; }
        public int AllDealsDay { get; set; }

        public int SuccesfulDealsMonth{ get; set; }
        public int AllDealsMonth { get; set; }
    }
}
