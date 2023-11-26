using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class StartupPipelineObserver : PipelineObserver<StartupPipelineLogger>,
        IPipelineObserver<OnStarting>,
        IPipelineObserver<OnCreatePhysicalQueues>,
        IPipelineObserver<OnAfterCreatePhysicalQueues>,
        IPipelineObserver<OnStartInboxProcessing>,
        IPipelineObserver<OnAfterStartInboxProcessing>,
        IPipelineObserver<OnStartControlInboxProcessing>,
        IPipelineObserver<OnAfterStartControlInboxProcessing>,
        IPipelineObserver<OnStartOutboxProcessing>,
        IPipelineObserver<OnAfterStartOutboxProcessing>,
        IPipelineObserver<OnStartDeferredMessageProcessing>,
        IPipelineObserver<OnAfterStartDeferredMessageProcessing>
    {
        public StartupPipelineObserver(ILogger<StartupPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger, serviceBusLoggingConfiguration)
        {
        }

        public void Execute(OnStarting pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStarting pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnCreatePhysicalQueues pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnCreatePhysicalQueues pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterCreatePhysicalQueues pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterCreatePhysicalQueues pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnStartInboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStartInboxProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartInboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartInboxProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnStartControlInboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStartControlInboxProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartControlInboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartControlInboxProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnStartOutboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStartOutboxProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartOutboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartOutboxProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnStartDeferredMessageProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStartDeferredMessageProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartDeferredMessageProcessing pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartDeferredMessageProcessing pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}