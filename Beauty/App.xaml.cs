using Xamarin.Forms;
using Beauty.Pages;
using System.Threading.Tasks;
using Beauty.Stores;

namespace Beauty {
    public partial class App {
        public App() {
            InitializeComponent();
            Current.UserAppTheme = OSAppTheme.Light;
            Task loadUserDataTask = Task.Factory.StartNew(async () => await UserDataStore.Initializate());
            loadUserDataTask.Wait();
            MainPage = (UserDataStore.UserId is null) ? new AuthPage() : new BottomBarPage();
        }
    }
}