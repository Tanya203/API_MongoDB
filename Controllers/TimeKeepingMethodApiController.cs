using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TimeKeepingMethodApiController : Controller
    {
        private readonly TimeKeepingMethodServices _timeKeepingMethodServices;
        public TimeKeepingMethodApiController(TimeKeepingMethodServices timeKeepingMethodServices)
        {
            _timeKeepingMethodServices = timeKeepingMethodServices;
        }

        [HttpGet("/GetAllTimeKeepingMethod")]
        public async Task<IActionResult> GetAllTimeKeepingMethod()
        {
            var result = await _timeKeepingMethodServices.GetAllTimeKeepingMethod();
            return Ok(result);
        }

        [HttpGet("/GetTimeKeepingMethodById")]
        public async Task<IActionResult> GetTimeKeepingMethodById(string id)
        {
            var result = await _timeKeepingMethodServices.GetTimeKeepingMethodById(id);
            return Ok(result);
        }

        [HttpGet("/GetTimeKeepingMethodByName")]
        public async Task<IActionResult> GetTimeKeepingMethodByName(string name)
        {
            var result = await _timeKeepingMethodServices.GetTimeKeepingMethodByName(name);
            return Ok(result);
        }

        [HttpPost("/CreateTimeKeepingMethod")]
        public async Task<IActionResult> CreateTimeKeepingMethod(TimeKeepingMethod timeKeepingMethod)
        {
            var result = await _timeKeepingMethodServices.CreateTimeKeepingMethod(timeKeepingMethod);
            return Ok(result);
        }

        [HttpPut("/UpdateTimeKeepingMethod")]
        public async Task<IActionResult> UpdateTimeKeepingMethod(TimeKeepingMethod timeKeepingMethod)
        {
            var result = await _timeKeepingMethodServices.UpdateTimeKeepingMethod(timeKeepingMethod);
            return Ok(result);
        }

        [HttpDelete("/DeleteTimeKeepingMethod")]
        public async Task<IActionResult> DeleteTimeKeepingMethod(string id)
        {
            var result = await _timeKeepingMethodServices.DeleteTimeKeepingMethod(id);
            return Ok(result);
        }
    }
}
