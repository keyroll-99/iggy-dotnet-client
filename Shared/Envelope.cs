using System.Text.Json;
using System.Text.Json.Serialization;
using Iggy_SDK.SerializationConfiguration;

namespace Shared;

public sealed class Envelope
{
	private JsonSerializerOptions _jsonSerializerOptions = new();

	public Envelope()
	{
		_jsonSerializerOptions.PropertyNamingPolicy = new ToSnakeCaseNamingPolicy();
		_jsonSerializerOptions.WriteIndented = true;
		}
	[JsonPropertyName("message_type")]
	public string MessageType { get; set; }
	
	[JsonPropertyName("payload")]
	public string Payload { get; set; }

	public Envelope New<T>(string messageType, T payload) where T : ISerializableMessage
	{
		return new Envelope
		{
			MessageType = messageType,
			Payload = JsonSerializer.Serialize(payload, _jsonSerializerOptions)
		};
	}
}