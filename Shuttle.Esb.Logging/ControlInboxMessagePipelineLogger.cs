﻿using System;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class ControlInboxMessagePipelineLogger
    {
        private readonly Type _pipelineType = typeof(ControlInboxMessagePipeline);

        public ControlInboxMessagePipelineLogger(ILogger<ControlInboxMessagePipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration, IPipelineFactory pipelineFactory)
        {
            Guard.AgainstNull(logger, nameof(logger));
            Guard.AgainstNull(serviceBusLoggingConfiguration, nameof(serviceBusLoggingConfiguration));
            Guard.AgainstNull(pipelineFactory, nameof(pipelineFactory));

            if (!serviceBusLoggingConfiguration.ShouldLogPipelineType(_pipelineType))
            {
                return;
            }

            pipelineFactory.PipelineCreated += (sender, args) =>
            {
                if (args.Pipeline.GetType() != _pipelineType)
                {
                    return;
                }

                args.Pipeline.RegisterObserver(new ControlInboxMessagePipelineObserver(logger, serviceBusLoggingConfiguration));
            };
        }
    }
}