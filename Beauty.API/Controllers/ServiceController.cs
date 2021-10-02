using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beauty.EFDataAccessLibrary.Contexts;
using Beauty.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Beauty.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ServiceController : Controller
    {
        ApplicationDbContext _db;
        public ServiceController(ApplicationDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public async Task<IEnumerable<ServiceCategory>> GetServicesAndCategories() =>
            await _db.ServiceCategories.Include(x => x.Services).ToListAsync();
    }
}
