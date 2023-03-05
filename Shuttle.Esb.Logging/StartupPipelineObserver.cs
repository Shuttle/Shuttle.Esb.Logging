using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class StartupPipelineObserver : PipelineObserver<StartupPipelineLogger>,
        IPipelineObserver<OnStarting>,
        IPipelineObserver<OnConfigure>,
        IPipelineObserver<OnAfterConfigure>,
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

        public Task Execute(OnStarting pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnConfigure pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterConfigure pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnCreatePhysicalQueues pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterCreatePhysicalQueues pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnStartInboxProcessing pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterStartInboxProcessing pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnStartControlInboxProcessing pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterStartControlInboxProcessing pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnStartOutboxProcessing pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterStartOutboxProcessing pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnStartDeferredMessageProcessing pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterStartDeferredMessageProcessing pipelineEvent)
        {
            return Trace(pipelineEvent);
        }
    }
}