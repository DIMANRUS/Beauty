using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beauty.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyView : ContentView {
        public EmptyView() {
            InitializeComponent();
        }
    }
}