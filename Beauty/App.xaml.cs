using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Beauty.Views;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace Beauty
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string userId = "";
            var task = Task.Factory.StartNew(async()
                => userId = await SecureStorage.GetAsync("user"));
            task.Wait();
            MainPage = new NavigationPage((userId is null) ? new AuthPage() : new BottomBarPage());
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
