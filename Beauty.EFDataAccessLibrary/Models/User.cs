using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Beauty.EFDataAccessLibrary.Models {
    public class User : IdentityUser {
        [StringLength(100)]
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public bool IsSelfEmployed { get; set; }
        public List<WorkerService> ServicesWorkers { get; set; } = new List<WorkerService>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}