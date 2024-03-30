using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

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

    }
}
