using Iggy_SDK.Enums;

namespace Iggy_SDK.Contracts.Http;

public sealed class OffsetRequest
{
	public required ConsumerType ConsumerType { get; init; }
	public required int StreamId { get; init; }
	public required int TopicId { get; init; }
	public required int ConsumerId { get; init; }
	public required int PartitionId { get; init; }
}