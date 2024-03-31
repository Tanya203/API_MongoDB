using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WorkScheduleApiController : Controller
    {
        private readonly WorkScheduleServices _workScheduleServices;
        public WorkScheduleApiController(WorkScheduleServices workScheduleServices)
        {
            _workScheduleServices = workScheduleServices;
        }

        [HttpGet("/GetAllWorkSchedule")]
        public async Task<IActionResult> GetAllWorkSchedule()
        {
            var result = await _workScheduleServices.GetAllWorkSchedule();
            return Ok(result);
        }

        [HttpGet("/GetWorkScheduleById")]
        public async Task<IActionResult> GetWorkScheduleById(string id)
        {
            var result = await _workScheduleServices.GetWorkScheduleById(id);
            return Ok(result);
        }

        [HttpGet("/CountStaffByWorkScheduleId")]
        public async Task<IActionResult> CountStaffByWorkScheduleId(string id)
        {
            var result = await _workScheduleServices.CountStaffByWorkScheduleId(id);
            return Ok(result);
        }

        [HttpPost("/CreateWorkSchedule")]
        public async Task<IActionResult> CreateWorkSchedule(WorkSchedule workSchedule)
        {
            var result = await _workScheduleServices.CreateWorkSchedule(workSchedule);
            return Ok(result);
        }

        [HttpPut("/UpdateDetailWorkSchedule")]
        public async Task<IActionResult> UpdateDetailWorkSchedule(WorkSchedule workSchedule)
        {
            var result = await _workScheduleServices.UpdateDetailWorkSchedule(workSchedule);
            return Ok(result);
        }

        [HttpPut("/UpdateWorkSchedule")]
        public async Task<IActionResult> UpdateWorkSchedule(WorkSchedule workSchedule)
        {
            var result = await _workScheduleServices.UpdateWorkSchedule(workSchedule);
            return Ok(result);
        }

        [HttpDelete("/DeleteWorkSchedule")]
        public async Task<IActionResult> DeleteWorkSchedule(string id)
        {
            var result = await _workScheduleServices.DeleteWorkSchedule(id);
            return Ok(result);
        }

        [HttpDelete("/DeleteStaffWorkSchedule")]
        public async Task<IActionResult> DeleteStaffWorkSchedule(string id, string staffId)
        {
            var result = await _workScheduleServices.DeleteStaffWorkSchedule(id, staffId);
            return Ok(result);
        }

    }
}
