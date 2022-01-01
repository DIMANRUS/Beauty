namespace Beauty.API.Controllers;
[Route("[controller]")]
[Authorize]
public class ServiceController : Controller {
    private readonly ApplicationDbContext _db;
    public ServiceController(ApplicationDbContext context) {
        _db = context;
    }
    private readonly  JsonSerializerOptions _options = new () {
        ReferenceHandler = ReferenceHandler.Preserve
    };
    [HttpGet]
    public async Task<string> GetServicesAndCategories() =>
       JsonSerializer.Serialize<IEnumerable<ServiceCategory>>(await _db.ServiceCategories
           .Include(x => x.Services)
           .ToListAsync(), _options);

    [HttpGet("ServicesWorkers")]
    public async Task<string> GetSericesWorkers() =>
        JsonSerializer.Serialize<IEnumerable<WorkerService>>(await _db.WorkerServices
            .Include(x => x.Service)
            .Include(x => x.User)
            .ToListAsync(), _options);

    [HttpGet("ServicesWorkersByUserId/{id}")]
    public async Task<string> GetWorkerServiceByUserId(int id) =>
        JsonSerializer.Serialize<IEnumerable<WorkerService>>(await _db.WorkerServices
            .Include(x => x.Service)
            .Include(x => x.User)
            .Where(x => x.UserId == id)
            .ToListAsync(), _options);
}