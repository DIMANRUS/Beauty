namespace Beauty.API.Controllers;

[Route("/[controller]/[action]")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase {
    private readonly ApplicationDbContext _db;
    public OrderController(ApplicationDbContext db) {
        _db = db;
    }
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders() {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        if (accessToken == null)
            return BadRequest("Token null");
        var id = new TokenHelper(accessToken).GetNameIdentifer();
        return await _db.Orders.Where(x => x.UserId == id).ToListAsync();
    }
}