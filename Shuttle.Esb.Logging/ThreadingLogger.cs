﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging;

public class ThreadingLogger : IHostedService
{
    private readonly ILogger<ThreadingLogger> _logger;
    private readonly IPipelineFactory _pipelineFactory;
    private readonly Type _pipelineType = typeof(StartupPipeline);
    private readonly ServiceBusLoggingOptions _serviceBusLoggingOptions;

    public ThreadingLogger(IOptions<ServiceBusLoggingOptions> serviceBusLoggingOptions, ILogger<ThreadingLogger> logger, IPipelineFactory pipelineFactory)
    {
        _serviceBusLoggingOptions = Guard.AgainstNull(Guard.AgainstNull(serviceBusLoggingOptions).Value);
        _logger = Guard.AgainstNull(logger);
        _pipelineFactory = Guard.AgainstNull(pipelineFactory);

        if (_serviceBusLoggingOptions.Threading)
        {
            _pipelineFactory.PipelineCreated += OnPipelineCreated;
        }
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_serviceBusLoggingOptions.Threading)
        {
            _pipelineFactory.PipelineCreated -= OnPipelineCreated;
        }

        await Task.CompletedTask;
    }

    private void OnPipelineCreated(object? sender, PipelineEventArgs args)
    {
        if (args.Pipeline.GetType() != _pipelineType)
        {
            return;
        }

        args.Pipeline.AddObserver(new ThreadingObserver(_logger));
    }
}