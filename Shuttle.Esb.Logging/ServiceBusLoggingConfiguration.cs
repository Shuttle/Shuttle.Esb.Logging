using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Logging
{
    public class ServiceBusLoggingConfiguration : IServiceBusLoggingConfiguration
    {
        private readonly List<Type> _pipelineTypes = new List<Type>();
        private readonly List<Type> _pipelineEventTypes = new List<Type>();
        
        public ServiceBusLoggingConfiguration(IOptions<ServiceBusLoggingOptions> serviceBusLoggingOptions, ILogger<ServiceBusLoggingConfiguration> logger)
        {
            Guard.AgainstNull(serviceBusLoggingOptions, nameof(serviceBusLoggingOptions));
            Guard.AgainstNull(serviceBusLoggingOptions.Value, nameof(serviceBusLoggingOptions.Value));
            Guard.AgainstNull(logger, nameof(logger));

            foreach (var pipelineType in serviceBusLoggingOptions.Value.PipelineTypes)
            {
                try
                {
                    _pipelineTypes.Add(Type.GetType(pipelineType));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }    
            }

            foreach (var pipelineEventType in serviceBusLoggingOptions.Value.PipelineEventTypes)
            {
                try
                {
                    _pipelineEventTypes.Add(Type.GetType(pipelineEventType));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
        }

        public bool ShouldLogPipelineType(Type pipelineType)
        {
            Guard.AgainstNull(pipelineType, nameof(pipelineType));

            return !_pipelineTypes.Any() || _pipelineTypes.Contains(pipelineType);
        }

        public bool ShouldLogPipelineEventType(Type pipelineEventType)
        {
            Guard.AgainstNull(pipelineEventType, nameof(pipelineEventType));

            return !_pipelineEventTypes.Any() || _pipelineEventTypes.Contains(pipelineEventType);
        }
    }
}