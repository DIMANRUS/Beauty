using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty.EFDataAccessLibrary.Models {
    public class Order {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public User Worker { get; set; }
        public int UserId { get; set; }
        public int ServiceWorkerId { get; set; }
        public ServiceWorker ServiceWorker { get; set; }
        public decimal Price { get; set; }
        public DateTime Start { get; set; }
    }
}