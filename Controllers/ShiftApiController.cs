using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShiftApiController : Controller
    {
        private readonly ShiftServices _shiftServices;

        public ShiftApiController(ShiftServices shiftServices)
        {
            _shiftServices = shiftServices;
        }

        [HttpGet("/GetAllShift")]
        public async Task<IActionResult> GetAllShift()
        {
            var result = await _shiftServices.GetAllShift();
            return Ok(result);
        }

        [HttpGet("/GetShiftById")]
        public async Task<IActionResult> GetShiftById(string id)
        {
            var result = await _shiftServices.GetShiftById(id);
            return Ok(result);
        }

        [HttpGet("/GetShiftByName")]
        public async Task<IActionResult> GetShiftByName(string name)
        {
            var result = await _shiftServices.GetShiftByName(name);
            return Ok(result);
        }

        [HttpPost("/CreateShift")]
        public async Task<IActionResult> CreateShift(Shift shift)
        {
            var result = await _shiftServices.CreateShift(shift);
            return Ok(result);
        }

        [HttpPut("/UpdateShift")]
        public async Task<IActionResult> UpdateShift(Shift shift)
        {
            var result = await _shiftServices.UpdateShift(shift);
            return Ok(result);
        }

        [HttpDelete("/DeleteShift")]
        public async Task<IActionResult> DeleteShift(string id)
        {
            var result = await _shiftServices.DeleteShift(id);
            return Ok(result);
        }
    }
}
