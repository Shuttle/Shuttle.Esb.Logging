using System;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Logging
{
    public static class ServiceBusLoggingOptionsExtensions
    {
        public static ServiceBusLoggingOptions AddPipelineType(this ServiceBusLoggingOptions serviceBusLoggingOptions, Type type)
        {
            Guard.AgainstNull(type, nameof(type));

            if (serviceBusLoggingOptions.PipelineTypes == null)
            {
                throw new InvalidOperationException(Resources.PipelineTypesNullException);
            }

            serviceBusLoggingOptions.PipelineTypes.Add(type.AssemblyQualifiedName);

            return serviceBusLoggingOptions;
        }

        public static ServiceBusLoggingOptions AddPipelineEventType(this ServiceBusLoggingOptions serviceBusLoggingOptions, Type type)
        {
            Guard.AgainstNull(type, nameof(type));

            if (serviceBusLoggingOptions.PipelineTypes == null)
            {
                throw new InvalidOperationException(Resources.PipelineTypesNullException);
            }

            serviceBusLoggingOptions.PipelineTypes.Add(type.AssemblyQualifiedName);

            return serviceBusLoggingOptions;
        }

    }
}