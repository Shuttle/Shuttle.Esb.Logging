using System;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class OutboxPipelineLogger
    {
        private readonly Type _outboxPipelineType = typeof(OutboxPipeline);

        public OutboxPipelineLogger(ILogger<OutboxPipelineLogger> logger, IServiceBusLoggingConfiguration serviceBusLoggingConfiguration, IPipelineFactory pipelineFactory)
        {
            Guard.AgainstNull(logger, nameof(logger));
            Guard.AgainstNull(serviceBusLoggingConfiguration, nameof(serviceBusLoggingConfiguration));
            Guard.AgainstNull(pipelineFactory, nameof(pipelineFactory));

            if (!serviceBusLoggingConfiguration.ShouldLogPipelineType(_outboxPipelineType))
            {
                return;
            }

            pipelineFactory.PipelineCreated += (sender, args) =>
            {
                if (args.Pipeline.GetType() != _outboxPipelineType)
                {
                    return;
                }

                args.Pipeline.RegisterObserver(new OutboxPipelineObserver(logger, serviceBusLoggingConfiguration));
            };
        }
    }
}