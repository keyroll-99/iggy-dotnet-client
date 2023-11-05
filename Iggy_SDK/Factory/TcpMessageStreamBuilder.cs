using Iggy_SDK.Configuration;
using Iggy_SDK.Contracts.Http;
using Iggy_SDK.IggyClient.Implementations;
using Iggy_SDK.MessagesDispatcher;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Threading.Channels;
namespace Iggy_SDK.Factory;

internal class TcpMessageStreamBuilder
{
    private readonly Socket _socket;
    private readonly MessageBatchingSettings _messageBatchingOptions;
    private readonly MessagePollingSettings _messagePollingSettings;
    private Channel<MessageSendRequest>? _channel;
    private MessageSenderDispatcher? _messageSenderDispatcher;
    private readonly ILoggerFactory _loggerFactory;
    private TcpMessageInvoker? _messageInvoker;

    internal TcpMessageStreamBuilder(Socket socket, IMessageStreamConfigurator options, ILoggerFactory loggerFactory)
    {
        var sendMessagesOptions = new MessageBatchingSettings();
        var messagePollingOptions = new MessagePollingSettings();
        options.MessagePollingSettings.Invoke(messagePollingOptions);
        options.MessageBatchingSettings.Invoke(sendMessagesOptions);
        _messageBatchingOptions = sendMessagesOptions;
        _messagePollingSettings = messagePollingOptions;
        _socket = socket;
        _loggerFactory = loggerFactory;
    }
    //TODO - this channel will probably need to be refactored, to accept a lambda instead of MessageSendRequest
    internal TcpMessageStreamBuilder WithSendMessagesDispatcher()
    {
        if (_messageBatchingOptions.Enabled)
        {
            _channel = Channel.CreateBounded<MessageSendRequest>(_messageBatchingOptions.MaxRequests);
            _messageInvoker = new TcpMessageInvoker(_socket);
            _messageSenderDispatcher =
                new MessageSenderDispatcher(_messageBatchingOptions, _channel, _messageInvoker, _loggerFactory);
        }
        else
        {
            _messageInvoker = new TcpMessageInvoker(_socket);
        }
        return this;
    }
    internal TcpMessageStream Build()
    {
        _messageSenderDispatcher?.Start();
        return _messageBatchingOptions.Enabled switch
        {
            true => new TcpMessageStream(_socket, _channel, _messagePollingSettings, _loggerFactory),
            false => new TcpMessageStream(_socket, _channel, _messagePollingSettings, _loggerFactory, _messageInvoker)
        };
    }
    
}