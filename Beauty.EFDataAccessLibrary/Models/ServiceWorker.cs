using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty.EFDataAccessLibrary.Models {
    public class ServiceWorker {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public TimeSpan Time { get; set; }
        public float Price { get; set; }
        public int SalePercent { get; set; } = 0;
    }
}