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

        public void Execute(OnAcknowledgeMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAcknowledgeMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterAcknowledgeMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterAcknowledgeMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterAssessMessageHandling pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterAssessMessageHandling pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDecompressMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDecompressMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDecryptMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDecryptMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDeserializeMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDeserializeMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterGetMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            await Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public void Execute(OnAfterHandleMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterHandleMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterSendDeferred pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterSendDeferred pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAssessMessageHandling pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAssessMessageHandling pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnCompleteTransactionScope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnCompleteTransactionScope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDecompressMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDecompressMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDecryptMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDecryptMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDeserializeMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDeserializeMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDeserializeTransportMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDisposeTransactionScope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDisposeTransactionScope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnGetMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            await Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public void Execute(OnHandleMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnHandleMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnProcessIdempotenceMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnProcessIdempotenceMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnSendDeferred pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnSendDeferred pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnStartTransactionScope pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStartTransactionScope pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}