using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.API.Models {
    public class Service {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public ICollection<ServiceWorker> ServicesWorkers { get; set; }
    }
}
