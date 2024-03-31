using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShiftTypeApiController : Controller
    {
        private readonly ShiftTypeServices _shiftTypeServices;
        public ShiftTypeApiController(ShiftTypeServices shiftTypeServices)
        {
            _shiftTypeServices = shiftTypeServices;
        }

        [HttpGet("/GetAllShiftType")]
        public async Task<IActionResult> GetAllShiftType()
        {
            var result = await _shiftTypeServices.GetAllShiftType();
            return Ok(result);
        }

        [HttpGet("/GetShiftTypeById")]
        public async Task<IActionResult> GetShiftTypeById(string id)
        {
            var result = await _shiftTypeServices.GetShiftTypeById(id);
            return Ok(result);
        }

        [HttpGet("/GetShiftTypeByName")]
        public async Task<IActionResult> GetShiftTypeByName(string name)
        {
            var result = await _shiftTypeServices.GetShiftTypeByName(name);
            return Ok(result);
        }

        [HttpPost("/CreateShiftType")]
        public async Task<IActionResult> CreateShiftType(ShiftType shiftType)
        {
            var result = await _shiftTypeServices.CreateShiftType(shiftType);
            return Ok(result);
        }

        [HttpPut("/UpdateShiftType")]
        public async Task<IActionResult> UpdateShiftType(ShiftType shiftType)
        {
            var result = await _shiftTypeServices.UpdateShiftType(shiftType);
            return Ok(result);
        }

        [HttpDelete("/DeleteShiftType")]
        public async Task<IActionResult> DeleteShiftType(string id)
        {
            var result = await _shiftTypeServices.DeleteShiftType(id);
            return Ok(result);
        }
    }
}
