using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

var client = new HttpClient(new CustomHttpClientHandler());
await client.GetAsync("https://www.google.com");
Console.WriteLine("Success!");

class CustomHttpClientHandler : HttpClientHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) 
        => base.SendAsync(request, cancellationToken);
}
