using System.ServiceModel;
using System.Threading.Tasks;

namespace ProxyAndCacheService
{
    [ServiceContract]
    public interface IPCService
    {
        [OperationContract]
        Task<string> GetClosestStation(string coords, string ville);
    }
}