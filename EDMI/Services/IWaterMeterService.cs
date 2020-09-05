using EDMITest.Entity;
using EDMITest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDMITest.Services
{
    public interface IWaterMeterService
    {
        Task Create(CreateWaterMeterParamModel param);
        Task<List<SearchWaterMeterResultModel>> Search(string param);
        Task<WaterMeter> GetById(string param);
        Task Update(UpdateWaterMeterParamModel param);
        Task Remove(string param);
    }
}
