using Beauty.Shared.Responses;
using System.ComponentModel.DataAnnotations;

namespace Beauty.Shared.Requests {
    public class UserRequest : UserResponse{
        public string NewPassword { get; set; }
        [Required]
        public string CurrentPassword { get; set; }
    }
}