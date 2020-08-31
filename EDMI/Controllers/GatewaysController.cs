using EDMITest.Models;
using EDMITest.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDMITest.Controllers
{
    [Route("api/[controller]")]
    public class GatewaysController : ControllerBase
    {
        private IGatewaysServiceService _service;

        public GatewaysController(IGatewaysServiceService service)
        {
            _service = service;
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody]CreateGatewaysParamModel param)
        {
            try
            {
                _service.Create(param);
                return Ok();
            }
            catch (Exception ex)
            {
                var message = "";
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(new { message = "Error: " + message });
            }
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _service.Search(string.Empty);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = "";
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(new { message = "Error: " + message });
            }
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var result = _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = "";
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(new { message = "Error: " + message });
            }
        }
        [HttpPost("Update")]
        public IActionResult Update([FromBody]UpdateGatewaysParamModel param)
        {
            try
            {
                _service.Update(param);
                return Ok();
            }
            catch (Exception ex)
            {
                var message = "";
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(new { message = "Error: " + message });
            }
        }

        [HttpPost("Remove")]
        public IActionResult Remove([FromBody]string param)
        {
            try
            {
                _service.Remove(param);
                return Ok();
            }
            catch (Exception ex)
            {
                var message = "";
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(new { message = "Error: " + message });
            }
        }
    }
}
