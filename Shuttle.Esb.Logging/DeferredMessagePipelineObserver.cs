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

        public void Execute(OnGetMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            await Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public void Execute(OnProcessDeferredMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnProcessDeferredMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterProcessDeferredMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterProcessDeferredMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}