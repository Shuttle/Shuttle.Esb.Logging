using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class StartupPipelineObserver : PipelineObserver<StartupPipelineLogger>,
        IPipelineObserver<OnStarting>,
        IPipelineObserver<OnCreatePhysicalQueues>,
        IPipelineObserver<OnAfterCreatePhysicalQueues>,
        IPipelineObserver<OnConfigureThreadPools>,
        IPipelineObserver<OnAfterConfigureThreadPools>,
        IPipelineObserver<OnStartThreadPools>,
        IPipelineObserver<OnAfterStartThreadPools>
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

        public void Execute(OnConfigureThreadPools pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnConfigureThreadPools pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterConfigureThreadPools pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterConfigureThreadPools pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnStartThreadPools pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnStartThreadPools pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterStartThreadPools pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartThreadPools pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}