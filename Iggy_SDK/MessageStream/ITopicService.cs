using Iggy_SDK.Contracts;
using Iggy_SDK.Contracts.Http;
using Iggy_SDK.Utils;

namespace Iggy_SDK.MessageStream;

public interface ITopicClient
{
	Task<IEnumerable<TopicResponse>> GetTopicsAsync(int streamId);
	Task<TopicResponse> GetTopicByIdAsync(int streamId, int topicId);
	Task CreateTopicAsync(int streamId, TopicRequest topic);
	Task DeleteTopicAsync(int streamId, int topicId);
}