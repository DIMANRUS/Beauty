namespace Beauty.Shared.Responses {
    public class UserResponse {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }   
        public string UserName { get; set; }
        public byte[] Photo { get; set; }
    }
}