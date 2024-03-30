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
    }
}
