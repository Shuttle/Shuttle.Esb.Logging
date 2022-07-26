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
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterAssembleMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnSerializeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterSerializeMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnEncryptMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterEncryptMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnCompressMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }

        public void Execute(OnAfterCompressMessage pipelineEvent)
        {
            Trace(pipelineEvent);
        }
    }
}