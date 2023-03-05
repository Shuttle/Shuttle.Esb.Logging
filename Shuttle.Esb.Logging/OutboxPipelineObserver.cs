using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class OutboxPipelineObserver : PipelineObserver<OutboxPipelineLogger>,
        IPipelineObserver<OnGetMessage>,
        IPipelineObserver<OnAfterGetMessage>,
        IPipelineObserver<OnDeserializeTransportMessage>,
        IPipelineObserver<OnAfterDeserializeTransportMessage>,
        IPipelineObserver<OnDispatchTransportMessage>,
        IPipelineObserver<OnAfterDispatchTransportMessage>,
        IPipelineObserver<OnAcknowledgeMessage>,
        IPipelineObserver<OnAfterAcknowledgeMessage>
    {
        public OutboxPipelineObserver(ILogger<OutboxPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger, serviceBusLoggingConfiguration)
        {
        }

        public Task Execute(OnGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            return Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public Task Execute(OnAfterGetMessage pipelineEvent)
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