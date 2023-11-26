using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Pipelines;

namespace Shuttle.Esb.Logging
{
    public class TransportMessagePipelineObserver : PipelineObserver<TransportMessagePipelineLogger>,
        IPipelineObserver<OnAssembleMessage>,
        IPipelineObserver<OnAfterAssembleMessage>,
        IPipelineObserver<OnSerializeMessage>,
        IPipelineObserver<OnAfterSerializeMessage>,
        IPipelineObserver<OnEncryptMessage>,
        IPipelineObserver<OnAfterEncryptMessage>,
        IPipelineObserver<OnCompressMessage>,
        IPipelineObserver<OnAfterCompressMessage>
    {
        public TransportMessagePipelineObserver(ILogger<TransportMessagePipelineLogger> logger,
            IServiceBusLoggingConfiguration serviceBusLoggingConfiguration) : base(logger, serviceBusLoggingConfiguration)
        {
        }

        public void Execute(OnAssembleMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAssembleMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterAssembleMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterAssembleMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnSerializeMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnSerializeMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterSerializeMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterSerializeMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnEncryptMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnEncryptMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterEncryptMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterEncryptMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnCompressMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnCompressMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }

        public void Execute(OnAfterCompressMessage pipelineEvent)
        {
            Trace(pipelineEvent).GetAwaiter().GetResult();
        }

        public async Task ExecuteAsync(OnAfterCompressMessage pipelineEvent)
        {
            await Trace(pipelineEvent);
        }
    }
}