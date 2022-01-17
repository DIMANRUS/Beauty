using System.ComponentModel.DataAnnotations;

namespace Beauty.Requests {
    public class RegistrationModelRequest {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public bool IsSelfEmployed { get; set; }
    }
}
