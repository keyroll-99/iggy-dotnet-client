using Iggy_SDK_Tests.Utils.Topics;
using Iggy_SDK.Contracts;
using Iggy_SDK.Contracts.Http;

namespace Iggy_SDK_Tests.Utils.Streams;

internal static class StreamFactory
{
	internal static StreamRequest CreateStreamRequest()
	{
		return new StreamRequest
		{
			Name = "Test Topic" + Random.Shared.Next(1, 69),
			StreamId = Random.Shared.Next(1, 10),
		};
	}

	internal static StreamResponse CreateStreamResponse()
	{
		var responses = new List<TopicResponse>();
		var topicResponse = TopicFactory.CreateTopicsResponse();
		responses.Add(topicResponse);
		return new StreamResponse
		{
			Id = Random.Shared.Next(1, 10),
			Name = "Test Topic" + Random.Shared.Next(1, 69),
			TopicsCount = Random.Shared.Next(1, 10),
			Topics = responses
		};
	}
	internal static StreamResponse CreateStreamsResponse()
	{
		return new StreamResponse
		{
			Id = Random.Shared.Next(1, 10),
			Name = "Test Topic" + Random.Shared.Next(1, 69),
			TopicsCount = Random.Shared.Next(1, 10),
		};
	}
}