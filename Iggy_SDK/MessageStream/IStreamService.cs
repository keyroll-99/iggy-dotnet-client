using Iggy_SDK.Contracts;

namespace Iggy_SDK.MessageStream;

public interface IStreamService
{
	Task<bool> CreateStreamAsync(StreamRequest request);
	Task<StreamResponse?> GetStreamByIdAsync(int streamId);
	Task<IEnumerable<StreamResponse>> GetStreamsAsync();
	Task<bool> DeleteStreamAsync(int streamId);

}