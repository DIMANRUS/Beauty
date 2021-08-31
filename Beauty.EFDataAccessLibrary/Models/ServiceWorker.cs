using System;

namespace Beauty.EFDataAccessLibrary.Models {
    public class ServiceWorker {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }
        public int SalePercent { get; set; } = 0;
    }
}