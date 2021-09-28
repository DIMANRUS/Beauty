using Beauty.EFDataAccessLibrary.Contexts;
using Beauty.EFDataAccessLibrary.Models;
using Beauty.Shared.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.API.Controllers {
    [Route("/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase {
        ApplicationDbContext _db;
        public OrderController(ApplicationDbContext db) {
            _db = db;
        }
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders() {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var id = new TokenHelper(accessToken).GetNameIdentifer();
            return await _db.Orders.Where(x => x.UserId == id).ToListAsync();
        }
    }
}