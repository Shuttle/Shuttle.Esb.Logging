using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Logging
{
    public class TransportMessageDeferredLogger : IHostedService
    {
        private readonly IDeferTransportMessageObserver _deferTransportMessageObserver;
        private readonly ILogger<TransportMessageDeferredLogger> _logger;
        private readonly ServiceBusLoggingOptions _serviceBusLoggingOptions;

        public TransportMessageDeferredLogger(IOptions<ServiceBusLoggingOptions> serviceBusLoggingOptions, ILogger<TransportMessageDeferredLogger> logger, IDeferTransportMessageObserver deferTransportMessageObserver)
        {
            Guard.AgainstNull(serviceBusLoggingOptions, nameof(serviceBusLoggingOptions));

            _serviceBusLoggingOptions = Guard.AgainstNull(serviceBusLoggingOptions.Value, nameof(serviceBusLoggingOptions.Value));
            _logger = Guard.AgainstNull(logger, nameof(logger));
            _deferTransportMessageObserver = Guard.AgainstNull(deferTransportMessageObserver, nameof(deferTransportMessageObserver));

            if (_serviceBusLoggingOptions.TransportMessageDeferred)
            {
                _deferTransportMessageObserver.TransportMessageDeferred += OnTransportMessageDeferred;
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_serviceBusLoggingOptions.TransportMessageDeferred)
            {
                _deferTransportMessageObserver.TransportMessageDeferred -= OnTransportMessageDeferred;
            }

            await Task.CompletedTask;
        }

        private void OnTransportMessageDeferred(object sender, TransportMessageDeferredEventArgs args)
        {
            Guard.AgainstNull(args, nameof(args));

            _logger.LogTrace($"[TransportMessageDeferred (thread {Thread.CurrentThread.ManagedThreadId})] : message id = '{args.TransportMessage.MessageId}' / message type = '{args.TransportMessage.MessageType}'");
        }
    }
}