using API_MongoDB.Models;
using API_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_MongoDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContractTypeApiController : Controller
    {
        private readonly ContractTypeServices _contractTypeServices;
        public ContractTypeApiController(ContractTypeServices contractTypeServices)
        {
            _contractTypeServices = contractTypeServices;
        }

        [HttpGet("/GetAllContractType")]
        public async Task<IActionResult> GetAllContractType()
        {
            var result = await _contractTypeServices.GetAllContractType();
            return Ok(result);
        }

        [HttpGet("/GetContractTypeById")]
        public async Task<IActionResult> GetAContractTypeById(string id)
        {
            var result = await _contractTypeServices.GetContractTypeById(id);
            return Ok(result);
        }

        [HttpGet("/GetContractTypeByName")]
        public async Task<IActionResult> GetAContractTypeByName(string name)
        {
            var result = await _contractTypeServices.GetContractTypeByName(name);
            return Ok(result);
        }

        [HttpPost("/CreateContractType")]
        public async Task<IActionResult> CreateContractTypeByName(ContractType contractType)
        {
            var result = await _contractTypeServices.CreateContractType(contractType);
            return Ok(result);
        }

        [HttpPut("/UpdateContractType")]
        public async Task<IActionResult> UpdateContractType(ContractType contractType)
        {
            var result = await _contractTypeServices.UpdateContractType(contractType);
            return Ok(result);
        }

        [HttpDelete("/DeleteContractType")]
        public async Task<IActionResult> DeleteContractType(string id)
        {
            var result = await _contractTypeServices.DeleteContractType(id);
            return Ok(result);
        }
    }
}
