using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.PipelineTransaction;

namespace Shuttle.Esb.Logging
{
    public class ControlInboxMessagePipelineObserver : PipelineObserver<ControlInboxMessagePipelineLogger>,
        IPipelineObserver<OnGetMessage>,
        IPipelineObserver<OnAfterGetMessage>,
        IPipelineObserver<OnDeserializeTransportMessage>,
        IPipelineObserver<OnAfterDeserializeTransportMessage>,
        IPipelineObserver<OnDecompressMessage>,
        IPipelineObserver<OnAfterDecompressMessage>,
        IPipelineObserver<OnDecryptMessage>,
        IPipelineObserver<OnAfterDecryptMessage>,
        IPipelineObserver<OnDeserializeMessage>,
        IPipelineObserver<OnAfterDeserializeMessage>,
        IPipelineObserver<OnStartTransactionScope>,
        IPipelineObserver<OnAssessMessageHandling>,
        IPipelineObserver<OnAfterAssessMessageHandling>,
        IPipelineObserver<OnProcessIdempotenceMessage>,
        IPipelineObserver<OnHandleMessage>,
        IPipelineObserver<OnAfterHandleMessage>,
        IPipelineObserver<OnCompleteTransactionScope>,
        IPipelineObserver<OnDisposeTransactionScope>,
        IPipelineObserver<OnSendDeferred>,
        IPipelineObserver<OnAfterSendDeferred>,
        IPipelineObserver<OnAcknowledgeMessage>,
        IPipelineObserver<OnAfterAcknowledgeMessage>
    {
        public ControlInboxMessagePipelineObserver(ILogger<ControlInboxMessagePipelineLogger> logger,
            IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger,
            serviceBusLoggingConfiguration)
        {
        }

        public void Execute(OnAcknowledgeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterAcknowledgeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterAssessMessageHandling pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterDecompressMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterDecryptMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterDeserializeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterGetMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterHandleMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterSendDeferred pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAssessMessageHandling pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnCompleteTransactionScope pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDecompressMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDecryptMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDeserializeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDisposeTransactionScope pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public void Execute(OnHandleMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnProcessIdempotenceMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnSendDeferred pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnStartTransactionScope pipelineEvent)
        {
            Trace(pipelineEvent);
        }
    }
}