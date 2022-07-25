using System;

namespace Shuttle.Esb.Logging
{
    public interface IServiceBusLoggingConfiguration
    {
        bool ShouldLogPipelineType(Type pipelineType);
        bool ShouldLogPipelineEventType(Type pipelineEventType);
    }
}