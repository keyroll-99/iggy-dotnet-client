using Iggy_SDK.Contracts;
using Iggy_SDK.Contracts.Http;
using Iggy_SDK.Utils;

namespace Iggy_SDK.MessageStream;

public interface IMessageClient
{
	Task SendMessagesAsync(int streamId, int topicId, MessageSendRequest request);
	Task<IEnumerable<MessageResponse>> PollMessagesAsync(MessageFetchRequest request);
}