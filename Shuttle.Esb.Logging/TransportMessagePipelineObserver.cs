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

        public Task Execute(OnAssembleMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterAssembleMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnSerializeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterSerializeMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnEncryptMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterEncryptMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnCompressMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }

        public Task Execute(OnAfterCompressMessage pipelineEvent)
        {
            return Trace(pipelineEvent);
        }
    }
}