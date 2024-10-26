using System;

namespace Shuttle.Esb.Logging;

public interface IServiceBusLoggingConfiguration
{
    bool ShouldLogPipelineEventType(Type pipelineEventType);
    bool ShouldLogPipelineType(Type pipelineType);
}