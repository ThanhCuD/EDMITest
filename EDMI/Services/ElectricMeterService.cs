using EDMITest.Entity;
using EDMITest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDMITest.Services
{
    public class ElectricMeterService : IElectricMeterService
    {
        public ElectricMeterService(EdmiContext edmiContext)
        {
            dbContext = edmiContext;
        }
        private EdmiContext dbContext { get; set; }
        public async Task Create(CreateElectricMeterParamModel param)
        {
            var item = dbContext.ElectricMeters.FirstOrDefault(_ =>_.SerialNumber == param.SerialNumber);
            if (item == null)
            {
                var electricMeter = new ElectricMeter()
                {
                    FirmwareVersion = param.FirmwareVersion,
                    SerialNumber = param.SerialNumber,
                    State = param.State
                };
                dbContext.ElectricMeters.Add(electricMeter);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<SearchElectricMeterResultModel>> Search(string param)
        {
            var data = dbContext.ElectricMeters.Where(_ => string.IsNullOrEmpty(param) ? true : _.FirmwareVersion.Contains(param)
            || _.SerialNumber.Contains(param) || _.State.Contains(param))
                .Select(_ => new SearchElectricMeterResultModel()
                {
                    Id = _.ID,
                    FirmwareVersion = _.FirmwareVersion,
                    State = _.State,
                    SerialNumber = _.SerialNumber
                });
            return await Task.FromResult(data.ToList());
        }
        public async Task<ElectricMeter> GetById(string param)
        {
            var item = await Task.FromResult(dbContext.ElectricMeters.FirstOrDefault(_ => _.ID.ToString() == param));
            return item;
        }
        public async Task Update(UpdateElectricMeterParamModel param)
        {
            var item = await dbContext.ElectricMeters.FirstOrDefaultAsync(_ => _.ID.ToString() == param.Id);
            if (item != null)
            {
                item.FirmwareVersion = param.FirmwareVersion;
                item.SerialNumber = param.SerialNumber;
                item.State = param.State;
            }
            dbContext.ElectricMeters.Update(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task Remove(string param)
        {
            var item = dbContext.ElectricMeters.FirstOrDefault(_ => _.ID.ToString() == param);
            if (item != null)
            {
                dbContext.ElectricMeters.Remove(item);
               await dbContext.SaveChangesAsync();
            }
        }
    }
}
