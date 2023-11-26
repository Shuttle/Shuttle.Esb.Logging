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

        public void Execute(OnGetMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnGetMessage pipelineEvent)
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

        public void Execute(OnHandleDistributeMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnHandleDistributeMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterHandleDistributeMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterHandleDistributeMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnSerializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnSerializeTransportMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterSerializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterSerializeTransportMessage pipelineEvent)
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