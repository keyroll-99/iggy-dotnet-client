namespace Iggy_SDK.Messages;

public interface IMessage
{
	public ulong Id { get; set; }
	//Base64 encoded payload
	public string Payload { get; set; }
}