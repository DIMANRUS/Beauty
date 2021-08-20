using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beauty.API.Controllers {
    [Route("/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class DataController : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(10);
    }
}
