using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.Reflection;

namespace Shuttle.Esb.Logging;

public abstract class PipelineObserver<T> :
    IPipelineObserver<OnPipelineStarting>,
    IPipelineObserver<OnPipelineException>,
    IPipelineObserver<OnAbortPipeline>
{
    private readonly Dictionary<Type, int> _eventCounts = new();
    private readonly ILogger<T> _logger;
    private readonly IServiceBusLoggingConfiguration _serviceBusLoggingConfiguration;

    protected PipelineObserver(ILogger<T> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration)
    {
        _logger = Guard.AgainstNull(logger);
        _serviceBusLoggingConfiguration = Guard.AgainstNull(serviceBusLoggingConfiguration);
    }

    public async Task ExecuteAsync(IPipelineContext<OnAbortPipeline> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnPipelineStarting> pipelineContext)
    {
        await TraceAsync(pipelineContext);
    }

    public async Task ExecuteAsync(IPipelineContext<OnPipelineException> pipelineContext)
    {
        var type = pipelineContext.GetType();

        Increment(type);

        var message = $"exception = '{pipelineContext.Pipeline.Exception?.AllMessages()}'";

        _logger.LogError($"[{type.Name}] : pipeline = {pipelineContext.Pipeline.GetType().FullName}{(string.IsNullOrEmpty(message) ? string.Empty : $" / {message}")} / call count = {_eventCounts[type]} / managed thread id = {Environment.CurrentManagedThreadId}");

        await Task.CompletedTask;
    }

    private void Increment(Type type)
    {
        _eventCounts.TryAdd(type, 0);
        _eventCounts[type] += 1;
    }

    protected async Task TraceAsync(IPipelineContext pipelineContext, string message = "")
    {
        var type = Guard.AgainstNull(pipelineContext).GetType();

        if (!_serviceBusLoggingConfiguration.ShouldLogPipelineEventType(type))
        {
            return;
        }

        Increment(type);

        _logger.LogTrace($"[{type.Name}] : pipeline = {pipelineContext.Pipeline.GetType().FullName}{(string.IsNullOrEmpty(message) ? string.Empty : $" / {message}")} / call count = {_eventCounts[type]} / managed thread id = {Environment.CurrentManagedThreadId}");

        await Task.CompletedTask;
    }
}