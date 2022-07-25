using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class OutboxPipelineObserver : 
        IPipelineObserver<OnGetMessage>,
        IPipelineObserver<OnAfterGetMessage>,
        IPipelineObserver<OnDeserializeTransportMessage>,
        IPipelineObserver<OnAfterDeserializeTransportMessage>,
        IPipelineObserver<OnDispatchTransportMessage>,
        IPipelineObserver<OnAfterDispatchTransportMessage>,
        IPipelineObserver<OnAcknowledgeMessage>,
        IPipelineObserver<OnAfterAcknowledgeMessage>,
        IPipelineObserver<OnPipelineStarting>,
        IPipelineObserver<OnPipelineException>,
        IPipelineObserver<OnAbortPipeline>
    {
        private readonly ILogger<OutboxPipelineLogger> _logger;
        private readonly IServiceBusLoggingConfiguration _serviceBusLoggingConfiguration;

        private readonly Dictionary<Type, int> _eventCounts = new Dictionary<Type, int>();

        public OutboxPipelineObserver(ILogger<OutboxPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration)
        {
            Guard.AgainstNull(logger, nameof(logger));
            Guard.AgainstNull(serviceBusLoggingConfiguration, nameof(serviceBusLoggingConfiguration));
            
            _logger = logger;
            _serviceBusLoggingConfiguration = serviceBusLoggingConfiguration;
        }

        public void Execute(OnGetMessage pipelineEvent)
        {
            Guard.AgainstNull(pipelineEvent, nameof(pipelineEvent));

            Trace(pipelineEvent, $"working = {pipelineEvent.Pipeline.State.GetWorking()} / has message = {pipelineEvent.Pipeline.State.GetReceivedMessage() != null}");
        }

        public void Execute(OnAfterGetMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterDeserializeTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnDispatchTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterDispatchTransportMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAcknowledgeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterAcknowledgeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAbortPipeline pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnPipelineStarting pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnPipelineException pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        private void Trace(IPipelineEvent pipelineEvent, string message = "")
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

            _logger.LogTrace($"[{type.Name} (thread {System.Threading.Thread.CurrentThread.ManagedThreadId}) / {_eventCounts[type]}]{(string.IsNullOrEmpty(message) ? string.Empty : $" : {message}")}");
        }
    }
}