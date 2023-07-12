using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Exceptions;
using WebApplicationDemo.Services.Interfaces;

namespace WebApplicationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        private ICounterServiceAsync _counterService;

        public CounterController(ICounterServiceAsync counterService)
        {
            _counterService = counterService;
        }

        [HttpGet(nameof(GetCurrentCounter))]
        public async Task<IActionResult> GetCurrentCounter()
        {
            try
            {
                return new OkObjectResult(await _counterService.GetCounter());
            }
            catch(FileSystemException)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet(nameof(IncrementCounter))]
        public async Task<IActionResult> IncrementCounter()
        {
            try
            {
                await _counterService.Increment();
                return new OkObjectResult("SUCCESS!");
            }
            catch(FileSystemException)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
