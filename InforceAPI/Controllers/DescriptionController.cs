using InforceAPI.Models;
using InforceAPI.Services.DescriptionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InforceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private readonly IDescriptionService _descriptionService;
        public DescriptionController(IDescriptionService descriptionService)
        {
            _descriptionService = descriptionService;
        }
        [HttpGet]
        public async Task<ActionResult<Description>> GetDescription()
        {
            var response = await _descriptionService.GetDescription();
            if (response == null) return NotFound("Sorry, description wasnt found");
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> AddDescription(Description description)
        {
            await _descriptionService.AddDescription(description);
            return Ok("Success");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateDescription(Description description)
        {
           var response = await _descriptionService.UpdateDescription(description);
            if(response == null) return BadRequest("Something went wrong!");
            return Ok(response);
        }
    }
}
