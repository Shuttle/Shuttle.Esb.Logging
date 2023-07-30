using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class ShutdownPipelineLogger : IHostedService
    {
        private readonly Type _pipelineType = typeof(ShutdownPipeline);
        private readonly ILogger<ShutdownPipelineLogger> _logger;
        private readonly IServiceBusLoggingConfiguration _serviceBusLoggingConfiguration;
        private readonly IPipelineFactory _pipelineFactory;

        public ShutdownPipelineLogger(ILogger<ShutdownPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration, IPipelineFactory pipelineFactory)
        {
            _logger = Guard.AgainstNull(logger, nameof(logger));
            _serviceBusLoggingConfiguration = Guard.AgainstNull(serviceBusLoggingConfiguration, nameof(serviceBusLoggingConfiguration));
            _pipelineFactory = Guard.AgainstNull(pipelineFactory, nameof(pipelineFactory));

            if (_serviceBusLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
            {
                _pipelineFactory.PipelineCreated += OnPipelineCreated;
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnPipelineCreated(object sender, PipelineEventArgs args)
        {
            if (args.Pipeline.GetType() != _pipelineType)
            {
                return;
            }

            args.Pipeline.RegisterObserver(new ShutdownPipelineObserver(_logger, _serviceBusLoggingConfiguration));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (_serviceBusLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
            {
                _pipelineFactory.PipelineCreated -= OnPipelineCreated;
            }

            return Task.CompletedTask;
        }
    }
}