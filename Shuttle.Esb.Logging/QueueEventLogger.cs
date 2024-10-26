using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Esb.Logging;

public class QueueEventLogger : IHostedService
{
    private readonly ILogger<QueueEventLogger> _logger;
    private readonly List<IQueue> _queues = new();
    private readonly IQueueService _queueService;
    private readonly ServiceBusLoggingOptions _serviceBusLoggingOptions;

    public QueueEventLogger(IOptions<ServiceBusLoggingOptions> serviceBusLoggingOptions, ILogger<QueueEventLogger> logger, IQueueService queueService)
    {
        _serviceBusLoggingOptions = Guard.AgainstNull(Guard.AgainstNull(serviceBusLoggingOptions).Value);
        _logger = Guard.AgainstNull(logger);
        _queueService = Guard.AgainstNull(queueService);

        if (!_serviceBusLoggingOptions.QueueEvents)
        {
            return;
        }

        _queueService.QueueCreated += OnQueueCreated;
        _queueService.QueueDisposing += OnQueueDisposing;
        _queueService.QueueDisposed += OnQueueDisposed;
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

    private void LogTrace(object? sender, Func<IQueue, string> messageFunc)
    {
        if (sender is IQueue queue)
        {
            _logger.LogTrace(messageFunc(queue));
        }
        else
        {
            _logger.LogTrace("[LogTrace] : sender != IQueue");
        }
    }

    private void OnQueueCreated(object? sender, QueueEventArgs args)
    {
        _queues.Add(args.Queue);

        _logger.LogTrace($"[OnQueueCreated] : uri = '{args.Queue.Uri}'");

        args.Queue.MessageAcknowledged += QueueOnMessageAcknowledged;
        args.Queue.MessageEnqueued += QueueOnMessageEnqueued;
        args.Queue.MessageReceived += QueueOnMessageReceived;
        args.Queue.MessageReleased += QueueOnMessageReleased;
        args.Queue.Operation += QueueOnOperation;
    }

    private void OnQueueDisposed(object? sender, QueueEventArgs args)
    {
        _logger.LogTrace($"[IQueueService.Created] : uri = '{args.Queue.Uri}'");
    }

    private void OnQueueDisposing(object? sender, QueueEventArgs args)
    {
        _logger.LogTrace($"[IQueueService.Dispose] : uri = '{args.Queue.Uri}'");
    }

    private void QueueOnMessageAcknowledged(object? sender, MessageAcknowledgedEventArgs e)
    {
        LogTrace(sender, queue => $"[{queue.Uri.Uri.Scheme}.MessageAcknowledged] : queue = '{queue.Uri.QueueName}' / managed thread id = {Environment.CurrentManagedThreadId}");
    }

    private void QueueOnMessageEnqueued(object? sender, MessageEnqueuedEventArgs e)
    {
        LogTrace(sender, queue => $"[{queue.Uri.Uri.Scheme}.MessageEnqueued] : queue = '{queue.Uri.QueueName}' / message type = '{e.TransportMessage.MessageType}' / message id = '{e.TransportMessage.MessageId}' / managed thread id = {Environment.CurrentManagedThreadId}");
    }

    private void QueueOnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        LogTrace(sender, queue => $"[{queue.Uri.Uri.Scheme}.MessageReceived] : queue = '{queue.Uri.QueueName}' / managed thread id = {Environment.CurrentManagedThreadId}");
    }

    private void QueueOnMessageReleased(object? sender, MessageReleasedEventArgs e)
    {
        LogTrace(sender, queue => $"[{queue.Uri.Uri.Scheme}.MessageReleased] : queue = '{queue.Uri.QueueName}' / managed thread id = {Environment.CurrentManagedThreadId}");
    }

    private void QueueOnOperation(object? sender, OperationEventArgs e)
    {
        LogTrace(sender, queue => $"[{queue.Uri.Uri.Scheme}.Operation] : queue = '{queue.Uri.QueueName}' / operation name = '{e.Name}' / managed thread id = {Environment.CurrentManagedThreadId}");
    }
}