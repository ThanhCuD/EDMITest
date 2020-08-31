using EDMITest.Models;
using System.Collections.Generic;
using System.Linq;

namespace EDMITest.Services
{
    public interface IWaterMeterService
    {
        void Create(CreateWaterMeterParamModel param);
        List<SearchWaterMeterResultModel> Search(string param);
        WaterMeter GetById(string param);
        void Update(UpdateWaterMeterParamModel param);
        void Remove(string param);
    }
    public class WaterMeterService : IWaterMeterService
    {
        private EdmiContext dbContext = new EdmiContext();
        public void Create(CreateWaterMeterParamModel param)
        {
            var item = new WaterMeter()
            {
                FirmwareVersion = param.FirmwareVersion,
                SerialNumber = param.SerialNumber,
                State = param.State
            };
            dbContext.WaterMeters.Add(item);
            dbContext.SaveChanges();
        }
        public List<SearchWaterMeterResultModel> Search(string param)
        {
            var data = dbContext.WaterMeters.Where(_ => string.IsNullOrEmpty(param) ? true : _.FirmwareVersion.Contains(param)
            || _.SerialNumber.Contains(param) || _.State.Contains(param))
                .Select(_ => new SearchWaterMeterResultModel()
                {
                    Id = _.ID.ToString(),
                    FirmwareVersion = _.FirmwareVersion,
                    State = _.State,
                    SerialNumber = _.SerialNumber
                }).ToList();
            return data;
        }
        public WaterMeter GetById(string param)
        {
            var item = dbContext.WaterMeters.FirstOrDefault(_ => _.ID.ToString() == param);
            return item;
        }
        public void Update(UpdateWaterMeterParamModel param)
        {
            var item = dbContext.WaterMeters.FirstOrDefault(_ => _.ID.ToString() == param.Id);
            if (item != null)
            {
                item.FirmwareVersion = param.FirmwareVersion;
                item.SerialNumber = param.SerialNumber;
                item.State = param.State;
            }
            dbContext.WaterMeters.Update(item);
            dbContext.SaveChanges();
        }

        public void Remove(string param)
        {
            var item = dbContext.WaterMeters.FirstOrDefault(_ => _.ID.ToString() == param);
            if (item != null)
            {
                dbContext.WaterMeters.Remove(item);
                dbContext.SaveChanges();
            }
        }
    }
}
