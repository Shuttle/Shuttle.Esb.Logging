using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public abstract class PipelineObserver<T>
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
        
        protected void Trace(IPipelineEvent pipelineEvent, string message = "")
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            var type = pipelineEvent.GetType();

            if (!_serviceBusLoggingConfiguration.ShouldLogPipelineEventType(type))
            {
                return;
            }

            if (!_eventCounts.ContainsKey(type))
            {
                _eventCounts.Add(type, 0);
            }

            _eventCounts[type] += 1;

            _logger.LogTrace($"{DateTime.Now:O} - [{type.Name} (thread {System.Threading.Thread.CurrentThread.ManagedThreadId}) / {_eventCounts[type]}]{(string.IsNullOrEmpty(message) ? string.Empty : $" : {message}")}");
        }
    }
}