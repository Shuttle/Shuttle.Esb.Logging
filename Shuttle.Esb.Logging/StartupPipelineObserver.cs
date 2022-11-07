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

        public void Execute(OnStarting pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnConfigure pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterConfigure pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnCreatePhysicalQueues pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterCreatePhysicalQueues pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnStartInboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartInboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnStartControlInboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartControlInboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnStartOutboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartOutboxProcessing pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnStartDeferredMessageProcessing pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartDeferredMessageProcessing pipelineEvent)
        {
            Trace(pipelineEvent);
        }
    }
}