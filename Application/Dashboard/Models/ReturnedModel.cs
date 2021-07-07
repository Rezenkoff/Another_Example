using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Application.Dashboard.Models
{
    public class ReturnedMonthModel
    {
        public int orderReturned {get;set;}
        public int orderSuccess {get;set;}
        public double VDReturned { get; set; }
        public double VDSuccess { get; set; }
        public double AutoReturned { get; set; }
        public double AutoReturned_RetPartRet { get; set; }

        public ReturnedMonthModel(int oR, int oS, double vdR, double vdS, int aR, int aR_RPR)
        {
            orderReturned = oR;
            orderSuccess = oS;
            VDReturned = vdR;
            VDSuccess = vdS;
            AutoReturned = aR;
            AutoReturned_RetPartRet = aR_RPR;
        }
    }
}
