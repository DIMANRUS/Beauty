using System.ComponentModel.DataAnnotations;

namespace Beauty.Requests {
    public class LoginModelRequest {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}