using Android.Content;
using Beauty.Droid;
using Google.Android.Material.BottomNavigation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(ShellCustomRenderer))]
namespace Beauty.Droid {
    public class ShellCustomRenderer : ShellRenderer {
        public ShellCustomRenderer(Context context) : base(context) {
        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem) {
            return new CustomBottomNavAppearance(this);
        }
    }

    internal class CustomBottomNavAppearance : IShellBottomNavViewAppearanceTracker {
        private ShellCustomRenderer _myShellRenderer;

        public CustomBottomNavAppearance(ShellCustomRenderer myShellRenderer) {
            this._myShellRenderer = myShellRenderer;
        }

        public void Dispose() {
            //throw new System.NotImplementedException();
        }

        public void ResetAppearance(BottomNavigationView bottomView) {
            bottomView.ItemIconTintList = null;
            bottomView.ItemIconSize = 80;
        }

        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance) {
            bottomView.ItemIconTintList = null;
            bottomView.ItemIconSize = 80;
        }
    }
}
