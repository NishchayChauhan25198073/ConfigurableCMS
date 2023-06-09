using CMS.Grpc.Contracts.SQLServer.Interface;
using ProtoBuf.Grpc;

namespace CMS.Grpc.SQLServer.Services
{
    public class GrpcServiceSQLServer : IGrpcServiceSQLServer
    {
        private readonly ILogger<GrpcServiceSQLServer> _logger;
        public GrpcServiceSQLServer(ILogger<GrpcServiceSQLServer> logger)
        {
            _logger = logger;
        }

        public async Task<string> SayHelloAsync(string request, CallContext callcontext)
        {
            return $"Hello {request}";
        }
    }
}