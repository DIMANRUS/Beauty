using System.Text.Json.Serialization;

namespace Beauty.Shared.Responses {
    public class UserResponse {
        public string Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }   
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("photo")]
        public byte[] Photo { get; set; }
    }
}