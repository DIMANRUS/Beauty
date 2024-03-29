﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty.EFDataAccessLibrary.Models {
    public class Service {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string ServiceName { get; set; }
        public int SeviceCategoryId { get; set; }
        public ServiceCategory SeviceCategory { get; set; }
        public List<WorkerService> ServicesWorkers { get; set; } = new List<WorkerService>();
    }
}