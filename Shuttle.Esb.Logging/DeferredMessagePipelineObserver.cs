using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class DeferredMessagePipelineObserver : PipelineObserver<DeferredMessagePipelineLogger>,
        IPipelineObserver<OnGetMessage>,
        IPipelineObserver<OnAfterGetMessage>,
        IPipelineObserver<OnDeserializeTransportMessage>,
        IPipelineObserver<OnAfterDeserializeTransportMessage>,
        IPipelineObserver<OnProcessDeferredMessage>,
        IPipelineObserver<OnAfterProcessDeferredMessage>
    {
        public DeferredMessagePipelineObserver(ILogger<DeferredMessagePipelineLogger> logger,
            IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger,
            serviceBusLoggingConfiguration)
        {
        }

        public Task Execute(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterGetMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnDeserializeTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            return Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public Task Execute(OnProcessDeferredMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterProcessDeferredMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }
    }
}