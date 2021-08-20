using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Beauty.API.Models {
    public class User : IdentityUser {
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public bool IsSelfEmployed { get; set; }
        public ICollection<ServiceWorker> ServicesWorkers { get; set; }
    }
}