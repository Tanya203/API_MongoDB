using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentApiController : Controller
    {
        private readonly DepartmentServices _departmentServices;
        public DepartmentApiController(DepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet("/GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _departmentServices.GetAllDepartment();
            return Ok(result);
        }

        [HttpGet("/GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(string id)
        {
            var result = await _departmentServices.GetDepartmentById(id);
            return Ok(result);
        }

        [HttpGet("/GetDepartmentByName")]
        public async Task<IActionResult> GetDepartmentByName(string name)
        {
            var result = await _departmentServices.GetDepartmentByName(name);
            return Ok(result);
        }

        [HttpGet("/CountStaffByDepartmentId")]
        public async Task<IActionResult> CountStaffByDepartmentId(string id)
        {
            var result = await _departmentServices.CountStaffByDepartmentId(id);
            return Ok(result);
        }

        [HttpPost("/CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            var result = await _departmentServices.CreateDepartment(department);
            return Ok(result);
        }

        [HttpPut("/UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            var result = await _departmentServices.UpdateDepartment(department);
            return Ok(result);
        }

        [HttpPut("/AddStaffInDepartment")]
        public async Task<IActionResult> AddStaffInDepartment(Department department)
        {
            var result = await _departmentServices.AddStaffInDepartment(department);
            return Ok(result);
        }

        [HttpDelete("/DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            var result = await _departmentServices.DeleteDepartment(id);
            return Ok(result);
        }

        [HttpDelete("/DeleteStaffDepartment")]
        public async Task<IActionResult> DeleteStaffDepartment(string id, string staffId)
        {
            var result = await _departmentServices.DeleteStaffDepartment(id, staffId);
            return Ok(result);
        }
    }
}
