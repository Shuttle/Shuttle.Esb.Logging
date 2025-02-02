using System;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Logging;

public static class ServiceBusLoggingOptionsExtensions
{
    public static ServiceBusLoggingOptions AddPipelineEventType<T>(this ServiceBusLoggingOptions serviceBusLoggingOptions)
    {
        return serviceBusLoggingOptions.AddPipelineEventType(typeof(T));
    }

    public static ServiceBusLoggingOptions AddPipelineEventType(this ServiceBusLoggingOptions serviceBusLoggingOptions, Type type)
    {
        if (serviceBusLoggingOptions.PipelineEventTypes == null)
        {
            throw new InvalidOperationException(Resources.PipelineTypesNullException);
        }

        serviceBusLoggingOptions.PipelineEventTypes.Add(Guard.AgainstNullOrEmptyString(Guard.AgainstNull(type).AssemblyQualifiedName));

        return serviceBusLoggingOptions;
    }

    public static ServiceBusLoggingOptions AddPipelineType<T>(this ServiceBusLoggingOptions serviceBusLoggingOptions)
    {
        return serviceBusLoggingOptions.AddPipelineType(typeof(T));
    }

    public static ServiceBusLoggingOptions AddPipelineType(this ServiceBusLoggingOptions serviceBusLoggingOptions, Type type)
    {
        if (serviceBusLoggingOptions.PipelineTypes == null)
        {
            throw new InvalidOperationException(Resources.PipelineTypesNullException);
        }

        serviceBusLoggingOptions.PipelineTypes.Add(Guard.AgainstNullOrEmptyString(Guard.AgainstNull(type).AssemblyQualifiedName));

        return serviceBusLoggingOptions;
    }
}