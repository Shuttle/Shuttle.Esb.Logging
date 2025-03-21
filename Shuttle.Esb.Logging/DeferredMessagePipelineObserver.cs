﻿using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging;

public class DeferredMessagePipelineObserver : PipelineObserver<DeferredMessagePipelineLogger>,
    IPipelineObserver<OnGetMessage>,
    IPipelineObserver<OnAfterGetMessage>,
    IPipelineObserver<OnDeserializeTransportMessage>,
    IPipelineObserver<OnAfterDeserializeTransportMessage>,
    IPipelineObserver<OnProcessDeferredMessage>,
    IPipelineObserver<OnAfterProcessDeferredMessage>
{
    public DeferredMessagePipelineObserver(ILogger<DeferredMessagePipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) 
        : base(logger, serviceBusLoggingConfiguration)
    {
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterDeserializeTransportMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterGetMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnDeserializeTransportMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnGetMessage> pipelineContext)
    {
        Guard.AgainstNull(pipelineContext);

        await TraceAsync(pipelineContext, $"working = {pipelineContext.Pipeline.State.GetWorking()} / has message = {pipelineContext.Pipeline.State.GetReceivedMessage() != null}");
    }

    public async Task ExecuteAsync(IPipelineContext<OnProcessDeferredMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAfterProcessDeferredMessage> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }
}