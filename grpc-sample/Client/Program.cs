using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Service;

namespace Client
{
    internal static class Program
    {
        private static async Task Main()
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var channel = GrpcChannel.ForAddress("https://grpc-service",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Greeter.GreeterClient(channel);
            
            var helloRequest = new HelloRequest
            {
                Name = "GreeterClient"
            };
            
            var reply = await client.SayHelloAsync(helloRequest);
            
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}