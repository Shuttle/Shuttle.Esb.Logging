using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging;

public class InboxMessagePipelineObserver : PipelineObserver<InboxMessagePipelineLogger>,
    IPipelineObserver<OnGetMessage>,
    IPipelineObserver<OnAfterGetMessage>,
    IPipelineObserver<OnDeserializeTransportMessage>,
    IPipelineObserver<OnAfterDeserializeTransportMessage>,
    IPipelineObserver<OnDecompressMessage>,
    IPipelineObserver<OnAfterDecompressMessage>,
    IPipelineObserver<OnDecryptMessage>,
    IPipelineObserver<OnAfterDecryptMessage>,
    IPipelineObserver<OnDeserializeMessage>,
    IPipelineObserver<OnAfterDeserializeMessage>,
    IPipelineObserver<OnHandleMessage>,
    IPipelineObserver<OnAfterHandleMessage>,
    IPipelineObserver<OnAcknowledgeMessage>,
    IPipelineObserver<OnAfterAcknowledgeMessage>
{
    public InboxMessagePipelineObserver(ILogger<InboxMessagePipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) 
        : base(logger, serviceBusLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAcknowledgeMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterAcknowledgeMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDecompressMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDecryptMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDeserializeMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDeserializeTransportMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterGetMessage> pipelineContext)
    {
        Guard.AgainstNull(pipelineContext);

        await TraceAsync(pipelineContext, $"working = {pipelineContext.Pipeline.State.GetWorking()} / has message = {pipelineContext.Pipeline.State.GetReceivedMessage() != null}");
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterHandleMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDecompressMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDecryptMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDeserializeMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDeserializeTransportMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnGetMessage> pipelineContext)
    {
        await TraceAsync(Guard.AgainstNull(pipelineContext), $"working = {pipelineContext.Pipeline.State.GetWorking()} / has message = {pipelineContext.Pipeline.State.GetReceivedMessage() != null}");
    }

    public async Task ExecuteAsync(IPipelineContext<OnHandleMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }
}