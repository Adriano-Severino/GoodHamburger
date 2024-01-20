using GH.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GH.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public class SandwichExtrasController : ControllerBase
    {
        private readonly ISandwichExtrasService _sandwichExtrasService;
        public SandwichExtrasController(ISandwichExtrasService sandwichExtrasService)
        {
            _sandwichExtrasService = sandwichExtrasService;
        }

        [HttpGet()]
        [Route("sandwiches")]
        public async Task<IActionResult> GetSandwiches()
        {
            return await ExecuteAsync(async () => await _sandwichExtrasService.GetSandwiches());
        }

        [HttpGet()]
        [Route("extras")]
        public async Task<IActionResult> GetExtras()
        {
            return await ExecuteAsync(async () => await _sandwichExtrasService.GetExtras());
        }

        [HttpGet()]
        [Route("sandwiches-extras")]
        public async Task<IActionResult> GetSandwichesExtras()
        {
            return await ExecuteAsync(async () => await _sandwichExtrasService.GetSandwichesExtras());
        }
        private async Task<IActionResult> ExecuteAsync(Func<Task<object>> func)
        {
            try
            {
                var result = await func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
