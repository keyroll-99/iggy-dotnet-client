using Iggy_SDK.Enums;
using Iggy_SDK.Messages;

namespace Iggy_SDK.Contracts.Http;

public sealed class MessageSendRequest
{
	public required Keykind KeyKind { get; init; }
	public required int KeyValue { get; init; }
	public required IEnumerable<Message> Messages { get; init; }
}