using System.Collections.Generic;

namespace Shuttle.Esb.Logging
{
    public class ServiceBusLoggingOptions
    {
        public List<string> PipelineEventTypes { get; set; } = new List<string>();
        public List<string> PipelineTypes { get; set; } = new List<string>();
        public bool QueueEvents { get; set; }
        public bool TransportMessageDeferred { get; set; }
        public bool Threading { get; set; }
    }
}