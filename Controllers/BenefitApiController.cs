using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BenefitApiController : Controller
    {
        private readonly BenefitServices _benefitServices;
        public BenefitApiController(BenefitServices benefitServices)
        {
            _benefitServices = benefitServices;
        }

        [HttpGet("/GetAllBenefit")]
        public async Task<IActionResult> GetAllBenefit()
        {
            var result = await _benefitServices.GetAllBenefit();
            return Ok(result);
        }

        [HttpGet("/CountStaffByBenefitId")]
        public async Task<IActionResult> CountStaffByBenefitId(string id)
        {
            var result = await _benefitServices.CountStaffByBenefitId(id);
            return Ok(result);
        }

        [HttpGet("/GetBenefitById")]
        public async Task<IActionResult> GetBenefitById(string id)
        {
            var result = await _benefitServices.GetBenefitById(id);
            return Ok(result);
        }

        [HttpGet("/GetBenefitByName")]
        public async Task<IActionResult> GetBenefitByName(string name)
        {
            var result = await _benefitServices.GetBenefitByName(name);
            return Ok(result);
        }

        [HttpPost("/CreateBenefit")]
        public async Task<IActionResult> CreateBenefit(Benefit benefit)
        {
            var result = await _benefitServices.CreateBenefit(benefit);
            return Ok(result);
        }

        [HttpPut("/UpdateBenefit")]
        public async Task<IActionResult> UpdateBenefit(Benefit benefit)
        {
            var result = await _benefitServices.UpdateBenefit(benefit);
            return Ok(result);
        }

        [HttpPut("/AddStaffInBenefit")]
        public async Task<IActionResult> AddStaffInBenefit(Benefit benefit)
        {
            var result = await _benefitServices.AddStaffInBenefit(benefit);
            return Ok(result);
        }

        [HttpDelete("/DeleteBenefit")]
        public async Task<IActionResult> DeleteBenefit(string id)
        {
            var result = await _benefitServices.DeleteBenefit(id);
            return Ok(result);
        }

        [HttpDelete("/DeleteStaffBenefit")]
        public async Task<IActionResult> DeleteStaffBenefit(string id, string staffId)
        {
            var result = await _benefitServices.DeleteStaffBenefit(id, staffId);
            return Ok(result);
        }
    }
}
