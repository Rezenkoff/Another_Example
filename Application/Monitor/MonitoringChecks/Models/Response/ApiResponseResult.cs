﻿using System.Collections.Generic;

namespace Monitor.Application.MonitoringChecks.Models
{
    public class ApiResponseResult
    {
        public bool Success { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}
