using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Beauty.Stores {
    class UserDataStore {
        public static async Task Initializate() {
            UserName = await SecureStorage.GetAsync("UserName");
            UserEmail = await SecureStorage.GetAsync("UserEmail");
            UserId = await SecureStorage.GetAsync("UserId");
            UserToken = await SecureStorage.GetAsync("UserToken");
            UserRole = await SecureStorage.GetAsync("UserRole");
        }
        public static string UserName { get; private set; }
        public static string UserEmail { get; private set; }
        public static string UserId { get; private set; }
        public static string UserToken { get; private set; }
        public static string UserRole { get; private set; }
    }
}