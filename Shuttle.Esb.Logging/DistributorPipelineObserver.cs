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

        public void Execute(OnGetMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnHandleDistributeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterHandleDistributeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnSerializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterSerializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDispatchTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterDispatchTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAcknowledgeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterAcknowledgeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }
    }
}