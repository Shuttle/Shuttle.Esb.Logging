using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceBusLogging(this IServiceCollection services,
            Action<ServiceBusLoggingBuilder> builder = null)
        {
            Guard.AgainstNull(services, nameof(services));

            var serviceBusLoggingBuilder = new ServiceBusLoggingBuilder(services);

            builder?.Invoke(serviceBusLoggingBuilder);

            services.AddOptions<ServiceBusLoggingOptions>().Configure(options =>
            {
                options.PipelineTypes = serviceBusLoggingBuilder.Options.PipelineTypes;
                options.PipelineEventTypes = serviceBusLoggingBuilder.Options.PipelineEventTypes;
                options.QueueEvents = serviceBusLoggingBuilder.Options.QueueEvents;
            });

            services.AddPipelineFeature<QueueEventLogger>();
            services.AddPipelineFeature<TransportMessageDeferredLogger>();
            services.AddPipelineFeature<StartupPipelineLogger>();
            services.AddPipelineFeature<ShutdownPipelineLogger>();
            services.AddPipelineFeature<InboxMessagePipelineLogger>();
            services.AddPipelineFeature<ControlInboxMessagePipelineLogger>();
            services.AddPipelineFeature<OutboxPipelineLogger>();
            services.AddPipelineFeature<DeferredMessagePipelineLogger>();
            services.AddPipelineFeature<DispatchTransportMessagePipelineLogger>();
            services.AddPipelineFeature<TransportMessagePipelineLogger>();

            services.AddSingleton<IServiceBusLoggingConfiguration, ServiceBusLoggingConfiguration>();

            return services;
        }
    }
}
