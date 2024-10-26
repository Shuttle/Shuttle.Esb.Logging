using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging;

public class ShutdownPipelineObserver : PipelineObserver<ShutdownPipelineLogger>,
    IPipelineObserver<OnStopping>,
    IPipelineObserver<OnStopped>
{
    public ShutdownPipelineObserver(ILogger<ShutdownPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) 
        : base(logger, serviceBusLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnStopping> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnStopped> pipelineContext)
    {
        await Trace(pipelineContext);
    }
}