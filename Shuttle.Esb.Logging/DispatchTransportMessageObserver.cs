using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class DispatchTransportMessagePipelineObserver : PipelineObserver<DispatchTransportMessagePipelineLogger>,
        IPipelineObserver<OnFindRouteForMessage>,
        IPipelineObserver<OnAfterFindRouteForMessage>,
        IPipelineObserver<OnSerializeTransportMessage>,
        IPipelineObserver<OnAfterSerializeTransportMessage>,
        IPipelineObserver<OnDispatchTransportMessage>,
        IPipelineObserver<OnAfterDispatchTransportMessage>
    {
        public DispatchTransportMessagePipelineObserver(ILogger<DispatchTransportMessagePipelineLogger> logger,
            IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger,
            serviceBusLoggingConfiguration)
        {
        }

        public Task Execute(OnFindRouteForMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterFindRouteForMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnSerializeTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterSerializeTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnDispatchTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterDispatchTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }
    }
}