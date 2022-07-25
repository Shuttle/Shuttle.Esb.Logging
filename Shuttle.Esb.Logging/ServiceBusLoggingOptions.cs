using System;
using System.Collections.Generic;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Logging
{
    public class ServiceBusLoggingOptions
    {
        public List<string> PipelineTypes { get; set; } = new List<string>();
        public List<string> PipelineEventTypes { get; set; } = new List<string>();
    }
}