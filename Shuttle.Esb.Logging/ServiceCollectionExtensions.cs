using System;
using Microsoft.Extensions.DependencyInjection;
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
            });

            services.AddPipelineModule<StartupPipelineLogger>();
            services.AddPipelineModule<ShutdownPipelineLogger>();
            services.AddPipelineModule<InboxMessagePipelineLogger>();
            services.AddPipelineModule<ControlInboxMessagePipelineLogger>();
            services.AddPipelineModule<OutboxPipelineLogger>();
            services.AddPipelineModule<DeferredMessagePipelineLogger>();
            services.AddPipelineModule<DispatchTransportMessagePipelineLogger>();
            services.AddPipelineModule<TransportMessagePipelineLogger>();

            services.AddSingleton<IServiceBusLoggingConfiguration, ServiceBusLoggingConfiguration>();

            return services;
        }
    }
}
