using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging;

public class DispatchTransportMessagePipelineObserver : PipelineObserver<DispatchTransportMessagePipelineLogger>,
    IPipelineObserver<OnFindRouteForMessage>,
    IPipelineObserver<OnAfterFindRouteForMessage>,
    IPipelineObserver<OnSerializeTransportMessage>,
    IPipelineObserver<OnAfterSerializeTransportMessage>,
    IPipelineObserver<OnDispatchTransportMessage>,
    IPipelineObserver<OnAfterDispatchTransportMessage>
{
    public DispatchTransportMessagePipelineObserver(ILogger<DispatchTransportMessagePipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) 
        : base(logger, serviceBusLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnFindRouteForMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterFindRouteForMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnSerializeTransportMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterSerializeTransportMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDispatchTransportMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDispatchTransportMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }
}