using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using System;

namespace Shuttle.Esb.Logging
{
    public class TransportMessageDeferredLogger : IPipelineFeature
    {
        public TransportMessageDeferredLogger(IOptions<ServiceBusLoggingOptions> serviceBusLoggingOptions, ILogger<TransportMessageDeferredLogger> logger, IDeferTransportMessageObserver deferTransportMessageObserver)
        {
            Guard.AgainstNull(serviceBusLoggingOptions, nameof(serviceBusLoggingOptions));
            Guard.AgainstNull(serviceBusLoggingOptions.Value, nameof(serviceBusLoggingOptions.Value));

            if (!serviceBusLoggingOptions.Value.TransportMessageDeferred)
            {
                return;
            }

            Guard.AgainstNull(logger, nameof(logger));

            Guard.AgainstNull(deferTransportMessageObserver, nameof(deferTransportMessageObserver)).TransportMessageDeferred += (sender, args) => 
            {
                logger.LogTrace($"{DateTime.Now:O} - [TransportMessageDeferred (thread {System.Threading.Thread.CurrentThread.ManagedThreadId})] : message id = '{args.TransportMessage.MessageId}' / message type = '{args.TransportMessage.MessageType}'");
            };
        }
    }
}