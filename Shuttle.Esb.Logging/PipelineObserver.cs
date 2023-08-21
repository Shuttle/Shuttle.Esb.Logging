using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public abstract class PipelineObserver<T> :
        IPipelineObserver<OnPipelineStarting>,
        IPipelineObserver<OnPipelineException>,
        IPipelineObserver<OnAbortPipeline>
    {
        private readonly ILogger<T> _logger;
        private readonly IServiceBusLoggingConfiguration _serviceBusLoggingConfiguration;

        private readonly Dictionary<Type, int> _eventCounts = new Dictionary<Type, int>();

        protected PipelineObserver(ILogger<T> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration)
        {
            Guard.AgainstNull(logger, nameof(logger));
            Guard.AgainstNull(serviceBusLoggingConfiguration, nameof(serviceBusLoggingConfiguration));

            _logger = logger;
            _serviceBusLoggingConfiguration = serviceBusLoggingConfiguration;
        }
        
        protected Task Trace(IPipelineEvent pipelineEvent, string message = "")
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            var type = pipelineEvent.GetType();

            if (!_serviceBusLoggingConfiguration.ShouldLogPipelineEventType(type))
            {
                return Task.CompletedTask;
            }

            if (!_eventCounts.ContainsKey(type))
            {
                _eventCounts.Add(type, 0);
            }

            _eventCounts[type] += 1;

            _logger.LogTrace($"[{type.Name} (thread {System.Threading.Thread.CurrentThread.ManagedThreadId}) / {_eventCounts[type]}]{(string.IsNullOrEmpty(message) ? string.Empty : $" : {message}")}");

            return Task.CompletedTask;
        }

        public Task Execute(OnAbortPipeline pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnPipelineStarting pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnPipelineException pipelineEvent)
        {
            return Trace(pipelineEvent, $"exception = '{pipelineEvent.Pipeline.Exception?.Message}'");
        }
    }
}