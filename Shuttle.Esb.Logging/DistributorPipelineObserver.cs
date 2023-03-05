using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class DistributorPipelineObserver : PipelineObserver<DistributorPipelineLogger>,
        IPipelineObserver<OnGetMessage>,
        IPipelineObserver<OnDeserializeTransportMessage>,
        IPipelineObserver<OnAfterDeserializeTransportMessage>,
        IPipelineObserver<OnHandleDistributeMessage>,
        IPipelineObserver<OnAfterHandleDistributeMessage>,
        IPipelineObserver<OnSerializeTransportMessage>,
        IPipelineObserver<OnAfterSerializeTransportMessage>,
        IPipelineObserver<OnDispatchTransportMessage>,
        IPipelineObserver<OnAfterDispatchTransportMessage>,
        IPipelineObserver<OnAcknowledgeMessage>,
        IPipelineObserver<OnAfterAcknowledgeMessage>
    {
        public DistributorPipelineObserver(ILogger<DistributorPipelineLogger> logger,
            IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger,
            serviceBusLoggingConfiguration)
        {
        }

        public Task Execute(OnGetMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnDeserializeTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnHandleDistributeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterHandleDistributeMessage pipelineEvent)
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

        public Task Execute(OnAcknowledgeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterAcknowledgeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }
    }
}