using System.ServiceModel;
using System.Threading.Tasks;

namespace Servers
{
    [ServiceContract]
    public interface IRService
    {
        [OperationContract]
        Task<string> GetItinerary(string origin, string dest);
    }
}