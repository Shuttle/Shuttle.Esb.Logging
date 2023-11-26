using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class DispatchTransportMessagePipelineObserver : PipelineObserver<DispatchTransportMessagePipelineLogger>,
        IPipelineObserver<OnFindRouteForMessage>,
        IPipelineObserver<OnAfterFindRouteForMessage>,
        IPipelineObserver<OnSerializeTransportMessage>,
        IPipelineObserver<OnAfterSerializeTransportMessage>,
        IPipelineObserver<OnDispatchTransportMessage>,
        IPipelineObserver<OnAfterDispatchTransportMessage>
    {
        public DispatchTransportMessagePipelineObserver(ILogger<DispatchTransportMessagePipelineLogger> logger,
            IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger,
            serviceBusLoggingConfiguration)
        {
        }

        public void Execute(OnFindRouteForMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnFindRouteForMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterFindRouteForMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterFindRouteForMessage pipelineEvent)
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
    }
}