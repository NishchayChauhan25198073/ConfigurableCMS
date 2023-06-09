using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
using System.ServiceModel;

namespace CMS.Grpc.Contracts.SQLServer.Interface
{
    [ServiceContract]
    public interface IGrpcServiceSQLServer
    {
        [OperationContract]
        Task<string> SayHelloAsync(string request, CallContext callcontext);
    }
}
