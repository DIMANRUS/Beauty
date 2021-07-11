using System.ComponentModel.DataAnnotations;

namespace Beauty.API.ViewModels {
    public class ResetPasswordVM {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}