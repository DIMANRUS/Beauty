using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace Beauty.API.Controllers {
    [Route("[controller]")]
    [Authorize]
    public class ServiceController : Controller {
        ApplicationDbContext _db;
        public ServiceController(ApplicationDbContext context) {
            _db = context;
        }
        JsonSerializerOptions options = new JsonSerializerOptions {
            ReferenceHandler = ReferenceHandler.Preserve
        };
        [HttpGet]
        public async Task<string> GetServicesAndCategories() =>
           JsonSerializer.Serialize<IEnumerable<ServiceCategory>>(await _db.ServiceCategories
               .Include(x => x.Services)
               .ToListAsync(), options);

        [HttpGet("ServicesWorkers")]
        public async Task<string> GetSericesWorkers() =>
            JsonSerializer.Serialize<IEnumerable<WorkerService>>(await _db.WorkerServices
                .Include(x => x.Service)
                .Include(x => x.User)
                .ToListAsync(), options);

        [HttpGet("ServicesWorkersByUserId/{id}")]
        public async Task<string> GetWorkerServiceByUserId(int id) =>
            JsonSerializer.Serialize<IEnumerable<WorkerService>>(await _db.WorkerServices
                .Include(x => x.Service)
                .Include(x => x.User)
                .Where(x => x.UserId == id)
                .ToListAsync(), options);
    }
}