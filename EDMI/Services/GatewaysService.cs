using EDMITest.Models;
using System.Collections.Generic;
using System.Linq;

namespace EDMITest.Services
{
    public interface IGatewaysServiceService
    {
        void Create(CreateGatewaysParamModel param);
        List<SearchGatewaysResultModel> Search(string param);
        Gateways GetById(string param);
        void Update(UpdateGatewaysParamModel param);
        void Remove(string param);
    }
    public class GatewaysServiceService : IGatewaysServiceService
    {
        private EdmiContext dbContext = new EdmiContext();
        public void Create(CreateGatewaysParamModel param)
        {
            var item = new Gateways()
            {
                FirmwareVersion = param.FirmwareVersion,
                SerialNumber = param.SerialNumber,
                State = param.State,
                IP = param.IP,
                Port = param.Port
            };
            dbContext.Gateways.Add(item);
            dbContext.SaveChanges();
        }
        public List<SearchGatewaysResultModel> Search(string param)
        {
            var data = dbContext.Gateways.Where(_ => string.IsNullOrEmpty(param) ? true : _.FirmwareVersion.Contains(param)
            || _.SerialNumber.Contains(param) || _.State.Contains(param))
                .Select(_ => new SearchGatewaysResultModel()
                {
                    Id = _.ID.ToString(),
                    FirmwareVersion = _.FirmwareVersion,
                    State = _.State,
                    SerialNumber = _.SerialNumber,
                    IP = _.IP,
                    Port = _.Port
                }).ToList();
            return data;
        }
        public Gateways GetById(string param)
        {
            var item = dbContext.Gateways.FirstOrDefault(_ => _.ID.ToString() == param);
            return item;
        }
        public void Update(UpdateGatewaysParamModel param)
        {
            var item = dbContext.Gateways.FirstOrDefault(_ => _.ID.ToString() == param.Id);
            if (item != null)
            {
                item.FirmwareVersion = param.FirmwareVersion;
                item.SerialNumber = param.SerialNumber;
                item.State = param.State;
                item.IP = param.IP;
                item.Port = param.Port;
            }
            dbContext.Gateways.Update(item);
            dbContext.SaveChanges();
        }

        public void Remove(string param)
        {
            var item = dbContext.Gateways.FirstOrDefault(_ => _.ID.ToString() == param);
            if (item != null)
            {
                dbContext.Gateways.Remove(item);
                dbContext.SaveChanges();
            }
        }
    }
}
