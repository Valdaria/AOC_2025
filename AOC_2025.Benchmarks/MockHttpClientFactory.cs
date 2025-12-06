using System.Net;

namespace AOC_2025.Benchmarks;

public class MockHttpClientFactory : IHttpClientFactory
{
    private readonly string _cookie;

    public MockHttpClientFactory(string cookie)
    {
        _cookie = cookie;
    }

    public HttpClient CreateClient(string name)
    {
        // var handler = new MockHttpMessageHandler();
        var client = new HttpClient()
        {
            BaseAddress = new Uri("https://adventofcode.com/2025/day/")
        };
        client.DefaultRequestHeaders.Add("Cookie", $"session={_cookie}");
        return client;
    }
}

// public class MockHttpMessageHandler : HttpMessageHandler
// {
//     protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//     {
//         return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
//         {
//             Content = new StringContent("")
//         });
//     }
// }
