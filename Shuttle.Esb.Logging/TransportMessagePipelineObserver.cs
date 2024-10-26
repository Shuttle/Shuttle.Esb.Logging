using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging;

public class TransportMessagePipelineObserver : PipelineObserver<TransportMessagePipelineLogger>,
    IPipelineObserver<OnAssembleMessage>,
    IPipelineObserver<OnAfterAssembleMessage>,
    IPipelineObserver<OnSerializeMessage>,
    IPipelineObserver<OnAfterSerializeMessage>,
    IPipelineObserver<OnEncryptMessage>,
    IPipelineObserver<OnAfterEncryptMessage>,
    IPipelineObserver<OnCompressMessage>,
    IPipelineObserver<OnAfterCompressMessage>
{
    public TransportMessagePipelineObserver(ILogger<TransportMessagePipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) 
        : base(logger, serviceBusLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAssembleMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterAssembleMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnSerializeMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterSerializeMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnEncryptMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterEncryptMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnCompressMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterCompressMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }
}