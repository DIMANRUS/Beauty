using Beauty.EFDataAccessLibrary.Contexts;
using Beauty.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Beauty.API.Controllers {
    [Route("/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase {
        private UserManager<User> _userManager;
        private ApplicationDbContext _db;
        public UserController(UserManager<User> userManager, ApplicationDbContext db) {
            _userManager = userManager;
            _db = db;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id) {
            if (id is not null)
                return Ok(await _db.Users.SingleOrDefaultAsync(record => record.Id == id));
            return BadRequest("Data null");
        }
    }
}
