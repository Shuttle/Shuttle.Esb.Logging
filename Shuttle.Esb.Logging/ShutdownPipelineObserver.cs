using System.Threading.Tasks;
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

        public Task Execute(OnStopping pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnStopped pipelineEvent)
        {
            return Trace(pipelineEvent);
        }
    }
}