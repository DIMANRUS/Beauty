using Xamarin.Forms;
using Beauty.Pages;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Beauty.Stores;

namespace Beauty {
    public partial class App : Application {
        public App() {
            InitializeComponent();
            Current.UserAppTheme = OSAppTheme.Light;
            //string userId = "";
            //var task = Task.Factory.StartNew(async ()
            //    => userId = await SecureStorage.GetAsync("UserToken"));
            //task.Wait();
            Task loadUserDataTask = Task.Factory.StartNew(async () => await UserDataStore.Initializate());
            loadUserDataTask.Wait();
            MainPage = (UserDataStore.UserId is null) ? new AuthPage() : new BottomBarPage();
        }
    }
}