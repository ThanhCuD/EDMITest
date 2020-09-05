using EDMITest.Entity;
using EDMITest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDMITest.Services
{
    public interface IGatewaysServiceService
    {
        Task Create(CreateGatewaysParamModel param);
        Task<List<SearchGatewaysResultModel>> Search(string param);
        Task<Gateways> GetById(string param);
        Task Update(UpdateGatewaysParamModel param);
        Task Remove(string param);
    }
}
