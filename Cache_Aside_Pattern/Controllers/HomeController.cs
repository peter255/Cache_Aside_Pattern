using Cache_Aside_Pattern.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Cache_Aside_Pattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public HomeController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string cacheKey = $"data_{id}";
            var data = _applicationService.GetData(cacheKey);

            if (string.IsNullOrEmpty(data))
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string cacheKey = $"data_{id}";
            _applicationService.RemoveData(cacheKey);

            return Ok();
        }
    }
}