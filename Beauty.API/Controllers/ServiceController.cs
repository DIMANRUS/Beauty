using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beauty.EFDataAccessLibrary.Contexts;
using Beauty.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

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
           JsonSerializer.Serialize<IEnumerable<ServiceCategory>>(await _db.ServiceCategories.Include(x => x.Services).ToListAsync(), options);
    }
}