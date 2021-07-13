using System;
using Android.Content;
using Android.Views;
using Beauty.Droid;
using Google.Android.Material.BottomNavigation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Provider.CalendarContract;

[assembly: ExportRenderer(typeof(Shell), typeof(ShellCustomRenderer))]
namespace Beauty.Droid
{
    public class ShellCustomRenderer : ShellRenderer
    {
        public ShellCustomRenderer(Context context) : base(context)
        {
        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new CustomBottomNavAppearance();
        }
    }

    public class CustomBottomNavAppearance : IShellBottomNavViewAppearanceTracker
    {
        public void Dispose()
        {

        }

        public void ResetAppearance(BottomNavigationView bottomView)
        {

        }

        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.ItemIconTintList = null;
            bottomView.ItemIconSize = 100;
        }
    }
}
