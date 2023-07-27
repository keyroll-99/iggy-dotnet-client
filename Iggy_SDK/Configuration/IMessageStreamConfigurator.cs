using System.Net.Http.Headers;
using Iggy_SDK.Contracts.Http;
using Iggy_SDK.Enums;

namespace Iggy_SDK.Configuration;

public interface IMessageStreamConfigurator
{
    public string BaseAdress { get; set; } 
    public Protocol Protocol { get; set; }
    public IEnumerable<HttpRequestHeaderContract>? Headers { get; set; }
    public int ReceiveBufferSize { get; set; }
    public int SendBufferSize { get; set; }
}