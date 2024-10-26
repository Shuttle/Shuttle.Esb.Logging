using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging;

public class StartupPipelineObserver : PipelineObserver<StartupPipelineLogger>,
    IPipelineObserver<OnStarting>,
    IPipelineObserver<OnCreatePhysicalQueues>,
    IPipelineObserver<OnAfterCreatePhysicalQueues>,
    IPipelineObserver<OnConfigureThreadPools>,
    IPipelineObserver<OnAfterConfigureThreadPools>,
    IPipelineObserver<OnStartThreadPools>,
    IPipelineObserver<OnAfterStartThreadPools>
{
    public StartupPipelineObserver(ILogger<StartupPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) 
        : base(logger, serviceBusLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnStarting> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnCreatePhysicalQueues> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterCreatePhysicalQueues> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnConfigureThreadPools> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterConfigureThreadPools> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnStartThreadPools> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterStartThreadPools> pipelineContext)
    {
        await Trace(pipelineContext);
    }
}