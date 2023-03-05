using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.PipelineTransaction;

namespace Shuttle.Esb.Logging
{
    public class InboxMessagePipelineObserver : PipelineObserver<InboxMessagePipelineLogger>,
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
        public InboxMessagePipelineObserver(ILogger<InboxMessagePipelineLogger> logger,
            IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger,
            serviceBusLoggingConfiguration)
        {
        }

        public Task Execute(OnAcknowledgeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterAcknowledgeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterAssessMessageHandling pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterDecompressMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterDecryptMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterDeserializeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterGetMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterHandleMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterSendDeferred pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAssessMessageHandling pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnCompleteTransactionScope pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnDecompressMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnDecryptMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnDeserializeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnDeserializeTransportMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnDisposeTransactionScope pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            return Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public Task Execute(OnHandleMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnProcessIdempotenceMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnSendDeferred pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnStartTransactionScope pipelineEvent)
        {
            return Trace(pipelineEvent);
        }
    }
}