using EDMITest.Entity;
using EDMITest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDMITest.Services
{
    public class WaterMeterService : IWaterMeterService
    {
        public WaterMeterService(EdmiContext edmiContext)
        {
            dbContext = edmiContext;
        }
        private EdmiContext dbContext { get; set; }
        public async Task Create(CreateWaterMeterParamModel param)
        {
            var itemExist = dbContext.Gateways.FirstOrDefault(_ => _.SerialNumber == param.SerialNumber);
            if (itemExist == null)
            {
                var item = new WaterMeter()
                {
                    FirmwareVersion = param.FirmwareVersion,
                    SerialNumber = param.SerialNumber,
                    State = param.State
                };
                dbContext.WaterMeters.Add(item);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<SearchWaterMeterResultModel>> Search(string param)
        {
            var data = await dbContext.WaterMeters.Where(_ => string.IsNullOrEmpty(param) ? true : _.FirmwareVersion.Contains(param)
             || _.SerialNumber.Contains(param) || _.State.Contains(param))
                .Select(_ => new SearchWaterMeterResultModel()
                {
                    Id = _.ID,
                    FirmwareVersion = _.FirmwareVersion,
                    State = _.State,
                    SerialNumber = _.SerialNumber
                }).ToListAsync();
            return data;
        }
        public async Task<WaterMeter> GetById(string param)
        {
            var item = await dbContext.WaterMeters.FirstOrDefaultAsync(_ => _.ID.ToString() == param);
            return item;
        }
        public async Task Update(UpdateWaterMeterParamModel param)
        {
            var item = dbContext.WaterMeters.FirstOrDefault(_ => _.ID.ToString() == param.Id);
            if (item != null)
            {
                item.FirmwareVersion = param.FirmwareVersion;
                item.SerialNumber = param.SerialNumber;
                item.State = param.State;
            }
            dbContext.WaterMeters.Update(item);
            await dbContext.SaveChangesAsync();
        }
        public async Task Remove(string param)
        {
            var item = dbContext.WaterMeters.FirstOrDefault(_ => _.ID.ToString() == param);
            if (item != null)
            {
                dbContext.WaterMeters.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
