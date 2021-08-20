using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Beauty.Pages;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace Beauty
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Application.Current.UserAppTheme = OSAppTheme.Light;
            string userId = "";
            var task = Task.Factory.StartNew(async ()
                => userId = await SecureStorage.GetAsync("UserToken"));
            task.Wait();
            MainPage = (userId is null) ? new AuthPage() : new BottomBarPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
