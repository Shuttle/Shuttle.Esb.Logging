using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class ShutdownPipelineObserver : PipelineObserver<ShutdownPipelineLogger>,
        IPipelineObserver<OnStopping>,
        IPipelineObserver<OnStopped>
    {
        public ShutdownPipelineObserver(ILogger<ShutdownPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger, serviceBusLoggingConfiguration)
        {
        }

        public void Execute(OnStopping pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnStopped pipelineEvent)
        {
            Trace(pipelineEvent);
        }
    }
}