using EDMITest.Models;
using EDMITest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDMITest.Controllers
{
    [Route("api/[controller]")]
    public class ElectricMeterController : ControllerBase
    {
        private IElectricMeterService _service;
        public ElectricMeterController(IElectricMeterService service)
        {
            _service = service;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CreateElectricMeterParamModel param)
        {
            await _service.Create(param);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.Search(string.Empty);
            return Ok(result);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateElectricMeterParamModel param)
        {
            await _service.Update(param);
            return Ok();
        }

        [HttpPost("Remove")]
        public async Task<IActionResult> Remove([FromBody]string param)
        {
            await _service.Remove(param);
            return Ok();
        }
    }
}
