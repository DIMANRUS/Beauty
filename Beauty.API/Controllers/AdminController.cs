using Beauty.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.API.Controllers {
    [Route("/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpGet("{roleName}")]
        public async Task AddRoles(string roleName) {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
            User user = await _userManager.FindByNameAsync("DIMANRUS");
            await _userManager.AddToRoleAsync(user, "Admin");
        }
    }
}