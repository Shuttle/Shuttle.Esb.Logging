using System.Collections.Generic;

namespace Shuttle.Esb.Logging;

public class ServiceBusLoggingOptions
{
    public List<string> PipelineEventTypes { get; set; } = new();
    public List<string> PipelineTypes { get; set; } = new();
    public bool QueueEvents { get; set; }
    public bool Threading { get; set; }
    public bool TransportMessageDeferred { get; set; }
}