using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging;

public class OutboxPipelineLogger : IHostedService
{
    private readonly ILogger<OutboxPipelineLogger> _logger;
    private readonly IPipelineFactory _pipelineFactory;
    private readonly Type _pipelineType = typeof(OutboxPipeline);
    private readonly IServiceBusLoggingConfiguration _serviceBusLoggingConfiguration;

    public OutboxPipelineLogger(ILogger<OutboxPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration, IPipelineFactory pipelineFactory)
    {
        _logger = Guard.AgainstNull(logger);
        _serviceBusLoggingConfiguration = Guard.AgainstNull(serviceBusLoggingConfiguration);
        _pipelineFactory = Guard.AgainstNull(pipelineFactory);

        if (_serviceBusLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
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
        if (_serviceBusLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
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

        args.Pipeline.RegisterObserver(new OutboxPipelineObserver(_logger, _serviceBusLoggingConfiguration));
    }
}