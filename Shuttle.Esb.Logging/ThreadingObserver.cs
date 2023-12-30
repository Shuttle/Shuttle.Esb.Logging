using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.Threading;

namespace Shuttle.Esb.Logging
{
    public class ThreadingObserver :
        IPipelineObserver<OnAfterStartInboxProcessing>,
        IPipelineObserver<OnAfterStartControlInboxProcessing>,
        IPipelineObserver<OnAfterStartOutboxProcessing>,
        IPipelineObserver<OnAfterStartDeferredMessageProcessing>,
        IDisposable
    {
        private readonly ILogger<ThreadingLogger> _logger;
        private readonly IServiceBusConfiguration _serviceBusConfiguration;
        private readonly List<IProcessorThreadPool> _wiredProcessorThreadPools = new List<IProcessorThreadPool>();
        private readonly List<ProcessorThread> _wiredProcessorThreads = new List<ProcessorThread>();

        public ThreadingObserver(ILogger<ThreadingLogger> logger, IServiceBusConfiguration serviceBusConfiguration)
        {
            _logger = Guard.AgainstNull(logger, nameof(logger));
            _serviceBusConfiguration = Guard.AgainstNull(serviceBusConfiguration, nameof(serviceBusConfiguration));
        }

        public void Dispose()
        {
            _wiredProcessorThreads.ForEach(item =>
            {
                item.ProcessorException -= OnProcessorException;
                item.ProcessorExecuting -= OnProcessorExecuting;
                item.ProcessorThreadActive -= OnProcessorThreadActive;
                item.ProcessorThreadStarting -= OnProcessorThreadStarting;
                item.ProcessorThreadStopped -= OnProcessorThreadStopped;
                item.ProcessorThreadStopping -= OnProcessorThreadStopping;
                item.ProcessorThreadOperationCanceled -= OnProcessorThreadOperationCanceled;
            });

            _wiredProcessorThreadPools.ForEach(item => item.ProcessorThreadCreated -= OnProcessorThreadCreated);
        }

        public void Execute(OnAfterStartControlInboxProcessing pipelineEvent)
        {
            ExecuteAsync(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartControlInboxProcessing pipelineEvent)
        {
            if (!_serviceBusConfiguration.HasControlInbox())
            {
                return;
            }

            Wire(pipelineEvent.Pipeline.State.Get<IProcessorThreadPool>("ControlInboxThreadPool"));

            await Task.CompletedTask;
        }

        public void Execute(OnAfterStartDeferredMessageProcessing pipelineEvent)
        {
            ExecuteAsync(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartDeferredMessageProcessing pipelineEvent)
        {
            if (!_serviceBusConfiguration.HasInbox() || !_serviceBusConfiguration.Inbox.HasDeferredQueue())
            {
                return;
            }

            Wire(pipelineEvent.Pipeline.State.Get<IProcessorThreadPool>("DeferredMessageThreadPool"));

            await Task.CompletedTask;
        }

        public void Execute(OnAfterStartInboxProcessing pipelineEvent)
        {
            ExecuteAsync(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartInboxProcessing pipelineEvent)
        {
            if (!_serviceBusConfiguration.HasInbox())
            {
                return;
            }

            Wire(pipelineEvent.Pipeline.State.Get<IProcessorThreadPool>("InboxThreadPool"));

            await Task.CompletedTask;
        }

        public void Execute(OnAfterStartOutboxProcessing pipelineEvent)
        {
            ExecuteAsync(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterStartOutboxProcessing pipelineEvent)
        {
            if (!_serviceBusConfiguration.HasOutbox())
            {
                return;
            }

            Wire(pipelineEvent.Pipeline.State.Get<IProcessorThreadPool>("OutboxThreadPool"));

            await Task.CompletedTask;
        }

        private void OnProcessorException(object sender, ProcessorThreadExceptionEventArgs e)
        {
            _logger.LogTrace($@"{DateTime.Now:O} - [ProcessorException] : name = '{e.Name}' / processor = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId} / exception = '{e.Exception}'");
        }

        private void OnProcessorExecuting(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"{DateTime.Now:O} - [ProcessorExecuting] : name = '{e.Name}' / execution count = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void OnProcessorThreadActive(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"{DateTime.Now:O} - [ProcessorThreadActive] : name = '{e.Name}' / execution count = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void OnProcessorThreadCreated(object sender, ProcessorThreadCreatedEventArgs e)
        {
            _wiredProcessorThreads.Add(e.ProcessorThread);

            e.ProcessorThread.ProcessorException += OnProcessorException;
            e.ProcessorThread.ProcessorExecuting += OnProcessorExecuting;
            e.ProcessorThread.ProcessorThreadActive += OnProcessorThreadActive;
            e.ProcessorThread.ProcessorThreadStarting += OnProcessorThreadStarting;
            e.ProcessorThread.ProcessorThreadStopped += OnProcessorThreadStopped;
            e.ProcessorThread.ProcessorThreadStopping += OnProcessorThreadStopping;
            e.ProcessorThread.ProcessorThreadOperationCanceled += OnProcessorThreadOperationCanceled;
        }

        private void OnProcessorThreadOperationCanceled(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"{DateTime.Now:O} - [ProcessorThreadOperationCanceled] : name = '{e.Name}' / execution count = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void OnProcessorThreadStarting(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"{DateTime.Now:O} - [ProcessorThreadStarting] : name = '{e.Name}' / execution count = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void OnProcessorThreadStopped(object sender, ProcessorThreadStoppedEventArgs e)
        {
            _logger.LogTrace($@"{DateTime.Now:O} - [ProcessorThreadStopped] : name = '{e.Name}' / execution count = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId} / aborted = '{e.Aborted}'");
        }

        private void OnProcessorThreadStopping(object sender, ProcessorThreadEventArgs e)
        {
            _logger.LogTrace($@"{DateTime.Now:O} - [ProcessorThreadStopping] : name = '{e.Name}' / execution count = {((ProcessorThread)sender).Processor.GetType().FullName} / managed thread id = {e.ManagedThreadId}");
        }

        private void Wire(IProcessorThreadPool processorThreadPool)
        {
            Guard.AgainstNull(processorThreadPool, nameof(processorThreadPool));

            _wiredProcessorThreadPools.Add(processorThreadPool);

            processorThreadPool.ProcessorThreadCreated += OnProcessorThreadCreated;
        }
    }
}