using CMS.Grpc.Contracts.SQLServer.Interface;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace CMS.Grpc.Contracts.SQLServer
{
    public class SQLServerGrpcClient
    {
        private readonly GrpcChannel channel;
        private readonly IGrpcServiceSQLServer client;

        public SQLServerGrpcClient(string address)
        {
            channel = GrpcChannel.ForAddress(address);
            client = channel.CreateGrpcService<IGrpcServiceSQLServer>();
            RunAsync().Wait();
        }

        private async Task RunAsync()
        {
            var reply = await client.SayHelloAsync(
                new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine($"Greeting: {reply.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
