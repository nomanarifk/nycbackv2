using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using nycWeb.BusinessLogic;
using nycWeb.DTOs;
using nycWeb.Models;
using nycWeb.Services;

namespace nycWeb.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController(RegistrationService _regService, RegistrationSequenceService _seqService) : ControllerBase
    {

        private readonly RegistrationBL regBL = new RegistrationBL(_regService, _seqService);

        [HttpPost("CreateRequestV3")]
        public async Task<IActionResult> CreateRequestv3([FromBody] RegistrationDtoToCreate registration)
        {
            if (registration == null)
                return BadRequest("Invalid registration data.");

            // Proceed with your business logic
            var created = await regBL.CreateNewRegistration(registration);

            return created != null
                ? Ok(created)
                : BadRequest();
        }
    }
}