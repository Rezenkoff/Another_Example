﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Application.MonitoringChecks.Models
{
    public class CheckWebModel
    {
        public int EnvironmentId { get; set; }
        public DateTime LastCheckTime { get; set; }
        public DateTime StatusChangeTime { get; set; }
        public double ExecutionDuration { get; set; }
        public StatusesEnum Status { get; set; }
        public string Service { get; set; }
        public string CheckFullDescription { get; set; }
        public string Description { get; set; }
        public PrioritiesEnum Priority { get; set; }
        public CheckTypeEnum Type { get; set; }
        public string DiagnosticsInfo { get; set; } = "";//
    }
}
