using EDMITest.Models;
using System.Collections.Generic;
using System.Linq;

namespace EDMITest.Services
{
    public interface IElectricMeterService
    {
        void Create(CreateElectricMeterParamModel param);
        List<SearchElectricMeterResultModel> Search(string param);
        ElectricMeter GetById(string param);
        void Update(UpdateElectricMeterParamModel param);
        void Remove(string param);
    }
    public class ElectricMeterService : IElectricMeterService
    {
        private EdmiContext dbContext = new EdmiContext();
        public void Create(CreateElectricMeterParamModel param)
        {
            var electricMeter = new ElectricMeter()
            {
                FirmwareVersion = param.FirmwareVersion,
                SerialNumber = param.SerialNumber,
                State = param.State
            };
            dbContext.ElectricMeters.Add(electricMeter);
            dbContext.SaveChanges();
        }
        public List<SearchElectricMeterResultModel> Search(string param)
        {
            var data = dbContext.ElectricMeters.Where(_ => string.IsNullOrEmpty(param) ? true : _.FirmwareVersion.Contains(param)
            || _.SerialNumber.Contains(param) || _.State.Contains(param))
                .Select(_ => new SearchElectricMeterResultModel()
                {
                    Id = _.ID.ToString(),
                    FirmwareVersion = _.FirmwareVersion,
                    State = _.State,
                    SerialNumber = _.SerialNumber
                }).ToList();
            return data;
        }
        public ElectricMeter GetById(string param)
        {
            var item = dbContext.ElectricMeters.FirstOrDefault(_ => _.ID.ToString() == param);
            return item;
        }
        public void Update(UpdateElectricMeterParamModel param)
        {
            var item = dbContext.ElectricMeters.FirstOrDefault(_ => _.ID.ToString() == param.Id);
            if (item != null)
            {
                item.FirmwareVersion = param.FirmwareVersion;
                item.SerialNumber = param.SerialNumber;
                item.State = param.State;
            }
            dbContext.ElectricMeters.Update(item);
            dbContext.SaveChanges();
        }

        public void Remove(string param)
        {
            var item = dbContext.ElectricMeters.FirstOrDefault(_ => _.ID.ToString() == param);
            if (item != null)
            {
                dbContext.ElectricMeters.Remove(item);
                dbContext.SaveChanges();
            }
        }
    }
}
