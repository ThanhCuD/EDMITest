using EDMITest.Entity;
using EDMITest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDMITest.Services
{
    public class GatewaysServiceService : IGatewaysServiceService
    {
        public GatewaysServiceService(EdmiContext edmiContext)
        {
            dbContext = edmiContext;
        }
        private EdmiContext dbContext { get; set; }
        public async Task Create(CreateGatewaysParamModel param)
        {
            var itemExist = dbContext.Gateways.FirstOrDefault(_ => _.SerialNumber == param.SerialNumber);
            if (itemExist == null)
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
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<SearchGatewaysResultModel>> Search(string param)
        {
            var data = await dbContext.Gateways.Where(_ => string.IsNullOrEmpty(param) ? true : _.FirmwareVersion.Contains(param)
             || _.SerialNumber.Contains(param) || _.State.Contains(param))
                .Select(_ => new SearchGatewaysResultModel()
                {
                    Id = _.ID,
                    FirmwareVersion = _.FirmwareVersion,
                    State = _.State,
                    SerialNumber = _.SerialNumber,
                    IP = _.IP,
                    Port = _.Port
                }).ToListAsync();
            return data;
        }
        public async Task<Gateways> GetById(string param)
        {
            var item = await dbContext.Gateways.FirstOrDefaultAsync(_ => _.ID.ToString() == param);
            return item;
        }
        public async Task Update(UpdateGatewaysParamModel param)
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
            await dbContext.SaveChangesAsync();
        }

        public async Task Remove(string param)
        {
            var item = dbContext.Gateways.FirstOrDefault(_ => _.ID.ToString() == param);
            if (item != null)
            {
                dbContext.Gateways.Remove(item);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
