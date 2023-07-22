namespace Iggy_SDK.Contracts.Http;

public sealed class OffsetContract
{
	public required int ConsumerId { get; init; }
	public required int PartitionId { get; init; }
	public required ulong Offset { get; init; }
}