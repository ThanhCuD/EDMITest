using EDMITest.Entity;
using EDMITest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDMITest.Services
{
    public interface IElectricMeterService
    {
        Task Create(CreateElectricMeterParamModel param);
        Task<List<SearchElectricMeterResultModel>> Search(string param);
        Task<ElectricMeter> GetById(string param);
        Task Update(UpdateElectricMeterParamModel param);
        Task Remove(string param);
    }
}
