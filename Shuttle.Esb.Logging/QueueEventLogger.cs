using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Logging
{
    public class QueueEventLogger : IHostedService
    {
        private readonly ILogger<QueueEventLogger> _logger;
        private readonly List<IQueue> _queues = new List<IQueue>();
        private readonly IQueueService _queueService;
        private readonly ServiceBusLoggingOptions _serviceBusLoggingOptions;

        public QueueEventLogger(IOptions<ServiceBusLoggingOptions> serviceBusLoggingOptions, ILogger<QueueEventLogger> logger, IQueueService queueService)
        {
            Guard.AgainstNull(serviceBusLoggingOptions, nameof(serviceBusLoggingOptions));

            _serviceBusLoggingOptions = Guard.AgainstNull(serviceBusLoggingOptions.Value, nameof(serviceBusLoggingOptions.Value));
            _logger = Guard.AgainstNull(logger, nameof(logger));
            _queueService = Guard.AgainstNull(queueService, nameof(queueService));

            if (!_serviceBusLoggingOptions.QueueEvents)
            {
                return;
            }

            _queueService.QueueCreated += OnQueueCreated;
            _queueService.QueueDisposing+= OnQueueDisposing;
            _queueService.QueueDisposed+= OnQueueDisposed;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_serviceBusLoggingOptions.QueueEvents)
            {
                foreach (var queue in _queues)
                {
                    queue.MessageAcknowledged -= QueueOnMessageAcknowledged;
                    queue.MessageEnqueued -= QueueOnMessageEnqueued;
                    queue.MessageReceived -= QueueOnMessageReceived;
                    queue.MessageReleased -= QueueOnMessageReleased;
                    queue.Operation -= QueueOnOperation;
                }

                _queueService.QueueCreated -= OnQueueCreated;
                _queueService.QueueDisposing -= OnQueueDisposing;
                _queueService.QueueDisposed -= OnQueueDisposed;
            }
            
            await Task.CompletedTask;
        }

        private void OnQueueCreated(object sender, QueueEventArgs args)
        {
            _queues.Add(args.Queue);

            _logger.LogTrace($"[OnQueueCreated] : uri = '{args.Queue.Uri}'");

            args.Queue.MessageAcknowledged += QueueOnMessageAcknowledged;
            args.Queue.MessageEnqueued += QueueOnMessageEnqueued;
            args.Queue.MessageReceived += QueueOnMessageReceived;
            args.Queue.MessageReleased += QueueOnMessageReleased;
            args.Queue.Operation += QueueOnOperation;
        }

        private void OnQueueDisposing(object sender, QueueEventArgs args)
        {
            _logger.LogTrace($"[IQueueService.Dispose] : uri = '{args.Queue.Uri}'");
        }

        private void OnQueueDisposed(object sender, QueueEventArgs args)
        {
            _logger.LogTrace($"[IQueueService.Created] : uri = '{args.Queue.Uri}'");
        }

        private void QueueOnMessageAcknowledged(object sender, MessageAcknowledgedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"[{queue.Uri.Uri.Scheme}.MessageAcknowledged (thread {Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}'");
        }

        private void QueueOnMessageEnqueued(object sender, MessageEnqueuedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"[{queue.Uri.Uri.Scheme}.MessageEnqueued (thread {Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}' / message type = '{e.TransportMessage.MessageType}' / message id = '{e.TransportMessage.MessageId}'");
        }

        private void QueueOnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"[{queue.Uri.Uri.Scheme}.MessageReceived (thread {Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}'");
        }

        private void QueueOnMessageReleased(object sender, MessageReleasedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"[{queue.Uri.Uri.Scheme}.MessageReleased (thread {Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}'");
        }

        private void QueueOnOperation(object sender, OperationEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"[{queue.Uri.Uri.Scheme}.Operation (thread {Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}' / operation name = '{e.Name}'");
        }
    }
}