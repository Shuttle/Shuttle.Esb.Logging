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

        public void Execute(OnGetMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            await Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public void Execute(OnAfterGetMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterGetMessage pipelineEvent)
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

        public void Execute(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnDispatchTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnDispatchTransportMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterDispatchTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterDispatchTransportMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
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
    }
}