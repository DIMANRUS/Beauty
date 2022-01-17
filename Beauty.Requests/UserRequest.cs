using System.ComponentModel.DataAnnotations;
using Beauty.Responses;

namespace Beauty.Requests {
    public class UserRequest : UserResponse {
        public string NewPassword { get; set; }
        [Required]
        public string CurrentPassword { get; set; }
    }
}