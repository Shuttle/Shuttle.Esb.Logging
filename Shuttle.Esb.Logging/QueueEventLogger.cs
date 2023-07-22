using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using System;

namespace Shuttle.Esb.Logging
{
    public class QueueEventLogger : IPipelineFeature
    {
        private readonly ILogger<QueueEventLogger> _logger;

        public QueueEventLogger(IOptions<ServiceBusLoggingOptions> serviceBusLoggingOptions, ILogger<QueueEventLogger> logger, IQueueService queueService)
        {
            Guard.AgainstNull(serviceBusLoggingOptions, nameof(serviceBusLoggingOptions));
            Guard.AgainstNull(serviceBusLoggingOptions.Value, nameof(serviceBusLoggingOptions.Value));

            if (!serviceBusLoggingOptions.Value.QueueEvents)
            {
                return;
            }

            _logger = Guard.AgainstNull(logger, nameof(logger));

            Guard.AgainstNull(queueService, nameof(queueService)).QueueCreated += (sender, args) =>
            {
                args.Queue.MessageAcknowledged += QueueOnMessageAcknowledged;
                args.Queue.MessageEnqueued += QueueOnMessageEnqueued;
                args.Queue.MessageReceived += QueueOnMessageReceived;
                args.Queue.MessageReleased += QueueOnMessageReleased;
                args.Queue.OperationCompleted += QueueOnOperationCompleted;
            };
        }
        private void QueueOnOperationCompleted(object sender, OperationCompletedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"{DateTime.Now:O} - [{queue.Uri.Uri.Scheme}.OperationCompleted (thread {System.Threading.Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}' / operation name = '{e.Name}'");
        }

        private void QueueOnMessageReleased(object sender, MessageReleasedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"{DateTime.Now:O} - [{queue.Uri.Uri.Scheme}.MessageReleased (thread {System.Threading.Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}'");
        }

        private void QueueOnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"{DateTime.Now:O} - [{queue.Uri.Uri.Scheme}.MessageReceived (thread {System.Threading.Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}'");
        }

        private void QueueOnMessageEnqueued(object sender, MessageEnqueuedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"{DateTime.Now:O} - [{queue.Uri.Uri.Scheme}.MessageEnqueued (thread {System.Threading.Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}' / type = '{e.TransportMessage.MessageType}'");
        }

        private void QueueOnMessageAcknowledged(object sender, MessageAcknowledgedEventArgs e)
        {
            var queue = (IQueue)sender;

            _logger.LogTrace($"{DateTime.Now:O} - [{queue.Uri.Uri.Scheme}.MessageAcknowledged (thread {System.Threading.Thread.CurrentThread.ManagedThreadId})] : queue = '{queue.Uri.QueueName}'");
         }
    }
}