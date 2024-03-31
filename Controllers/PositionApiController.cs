using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PositionApiController : Controller
    {
        private readonly PositionServices _positionServices;
        public PositionApiController(PositionServices positionServices)
        {
            _positionServices = positionServices;
        }

        [HttpGet("/GetAllPosition")]
        public async Task<IActionResult> GetAllPosition()
        {
            var result = await _positionServices.GetAllPosition();
            return Ok(result);
        }

        [HttpGet("/GetPositionById")]
        public async Task<IActionResult> GetPositionById(string id)
        {
            var result = await _positionServices.GetPositionById(id);
            return Ok(result);
        }

        [HttpGet("/GetPositionByName")]
        public async Task<IActionResult> GetPositionByName(string name)
        {
            var result = await _positionServices.GetPositionByName(name);
            return Ok(result);
        }

        [HttpGet("/CountStaffByPositionId")]
        public async Task<IActionResult> CountStaffByPositionId(string id)
        {
            var result = await _positionServices.CountStaffByPositionId(id);
            return Ok(result);
        }

        [HttpPost("/CreatePosition")]
        public async Task<IActionResult> CreatePosition(Position position)
        {
            var result = await _positionServices.CreatePosition(position);
            return Ok(result);
        }

        [HttpPut("/UpdatePosition")]
        public async Task<IActionResult> UpdatePosition(Position position)
        {
            var result = await _positionServices.UpdatePosition(position);
            return Ok(result);
        }

        [HttpPut("/AddStaffInPosition")]
        public async Task<IActionResult> AddStaffInPosition(Position position)
        {
            var result = await _positionServices.AddStaffInPosition(position);
            return Ok(result);
        }

        [HttpDelete("/DeletePosition")]
        public async Task<IActionResult> DeletePosition(string id)
        {
            var result = await _positionServices.DeletePosition(id);
            return Ok(result);
        }

        [HttpDelete("/DeleteStaffPosition")]
        public async Task<IActionResult> DeleteStaffPosition(string id, string staffId)
        {
            var result = await _positionServices.DeleteStaffPosition(id, staffId);
            return Ok(result);
        }
    }
}
