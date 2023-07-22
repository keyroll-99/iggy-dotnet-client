namespace Iggy_SDK.Utils;

public sealed class Result
{
	public required bool IsSuccess { get; init; }
	public ErrorModel? Error { get; init; }
	
	public static Result Success() => new() { IsSuccess = true };
}