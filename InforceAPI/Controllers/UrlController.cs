using InforceAPI.Services;
using InforceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InforceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Url>>> GetAllUrls()
        {
            var response = await _urlService.GetAllUrls();
            return response;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Url>> GetUrl(int id)
        {
            var response = await _urlService.GetUrl(id);
            if (response == null) return NotFound(response);
            return Ok(response);    
        }
        [HttpGet("byShort")]
        public async Task<ActionResult<Url>> GetUrl(string shortUrl)
        {
            var response = await _urlService.GetUrlByShort(shortUrl);
            if (response == null) return NotFound("No such urls");
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> AddUrl(Url request)
        {
            var response = await _urlService.AddUrl(request);
            if (response == null) return BadRequest("Url already exist");
            return Ok(response);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUrl(int id)
        {
            var response = await _urlService.DeleteUrl(id);
            if (response == null) return NotFound("Wrong id");
            return Ok("Success");
        }
        [HttpDelete("DeleteAll")]
        public async Task<ActionResult> DeleteAllUrls()
        {
            await _urlService.DeleteAllUrls();
            return Ok("Success");
        }
    }
}
