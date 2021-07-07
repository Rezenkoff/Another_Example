using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Application.Dashboard.Models.BitrixModels
{
    public class BitrixResponseUser
    {
        public List<UserModel> Result { get; set; }
        public int Total { get; set; }
        public BitrixResponseTimeModel Time { get; set; }
    }
}
