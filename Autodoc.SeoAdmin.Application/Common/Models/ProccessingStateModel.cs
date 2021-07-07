using Autodoc.SeoAdmin.Domain.Enum;
using System;

namespace Autodoc.SeoAdmin.Application.Common.Models
{
    public class ProccessingStateModel
    {
        public int BatchSize { get; set; } = 100;
        public int BatchStep { get; set; } = 0;
        public int PageType { get; set; } = 11; //change to real id        
        public string ProccessingTime { get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); } }
        public ProccessStatusEnum ProccessStatus { get; set; } = ProccessStatusEnum.Active;

        public void IncrementBatchStep ()
        {
            BatchStep += BatchSize;
        }
    }
}
