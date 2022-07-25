using System;
using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Logging
{
    public class ServiceBusLoggingBuilder
    {
        private ServiceBusLoggingOptions _serviceBusLoggingOptions = new ServiceBusLoggingOptions();

        public ServiceBusLoggingOptions Options
        {
            get => _serviceBusLoggingOptions;
            set => _serviceBusLoggingOptions = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IServiceCollection Services { get; }

        public ServiceBusLoggingBuilder(IServiceCollection services)
        {
            Guard.AgainstNull(services, nameof(services));

            Services = services;
        }
    }
}