using Beauty.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beauty.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
            page.BindingContext = new AuthPageVM();
        }
    }
}