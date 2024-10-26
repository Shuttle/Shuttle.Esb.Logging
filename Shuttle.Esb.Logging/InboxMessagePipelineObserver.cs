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
    IPipelineObserver<OnEvaluateMessageHandling>,
    IPipelineObserver<OnAfterEvaluateMessageHandling>,
    IPipelineObserver<OnProcessIdempotenceMessage>,
    IPipelineObserver<OnHandleMessage>,
    IPipelineObserver<OnAfterHandleMessage>,
    IPipelineObserver<OnSendDeferred>,
    IPipelineObserver<OnAfterSendDeferred>,
    IPipelineObserver<OnAcknowledgeMessage>,
    IPipelineObserver<OnAfterAcknowledgeMessage>
{
    public InboxMessagePipelineObserver(ILogger<InboxMessagePipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) 
        : base(logger, serviceBusLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAcknowledgeMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterAcknowledgeMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterEvaluateMessageHandling> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDecompressMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDecryptMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDeserializeMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDeserializeTransportMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterGetMessage> pipelineContext)
    {
        Guard.AgainstNull(pipelineContext);

        await Trace(pipelineContext, $"working = {pipelineContext.Pipeline.State.GetWorking()} / has message = {pipelineContext.Pipeline.State.GetReceivedMessage() != null}");
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterHandleMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterSendDeferred> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnEvaluateMessageHandling> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDecompressMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDecryptMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDeserializeMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDeserializeTransportMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnGetMessage> pipelineContext)
    {
        await Trace(Guard.AgainstNull(pipelineContext), $"working = {pipelineContext.Pipeline.State.GetWorking()} / has message = {pipelineContext.Pipeline.State.GetReceivedMessage() != null}");
    }

    public async Task ExecuteAsync(IPipelineContext<OnHandleMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnProcessIdempotenceMessage> pipelineContext)
    {
        await Trace(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnSendDeferred> pipelineContext)
    {
        await Trace(pipelineContext);
    }
}