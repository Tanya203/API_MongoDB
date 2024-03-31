using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StaffApiContriller : Controller
    {
        private readonly StaffServices _staffServices; 
        public StaffApiContriller(StaffServices staffServices)
        {
            _staffServices = staffServices;
        }

        [HttpGet("/GetAllStaff")]
        public async Task<IActionResult> GetAllStaff()
        {
            var result = await _staffServices.GetAllStaff();
            return Ok(result);
        }

        [HttpGet("/GetStaffById")]
        public async Task<IActionResult> GetStaffById(string id)
        {
            var result = await _staffServices.GetStaffById(id);
            return Ok(result);
        }       

        [HttpPost("/CreateStaff")]
        public async Task<IActionResult> CreateStaff(Staff staff)
        {
            var result = await _staffServices.CreateStaff(staff);
            return Ok(result);
        }

        [HttpPut("/UpdateStaff")]
        public async Task<IActionResult> UpdateStaff(Staff staff)
        {
            var result = await _staffServices.UpdateStaff(staff);
            return Ok(result);
        }

        [HttpDelete("/DeleteStaff")]
        public async Task<IActionResult> DeleteStaff(string id)
        {
            var result = await _staffServices.DeleteStaff(id);
            return Ok(result);
        }

    }
}
