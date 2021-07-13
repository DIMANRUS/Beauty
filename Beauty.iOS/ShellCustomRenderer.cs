using Beauty.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(ShellCustomRenderer))]
namespace Beauty.iOS
{
    public class ShellCustomRenderer : ShellRenderer
    {
        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new TabBarAppearance();
        }

    }

    public class TabBarAppearance : IShellTabBarAppearanceTracker
    {
        public void Dispose()
        {

        }

        public void ResetAppearance(UITabBarController controller)
        {


        }

        public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            //UITabBar myTabBar = controller.TabBar;

            //if (myTabBar.Items != null)
            //{
            //    var item = myTabBar.Items[0];

            //    //default icon
            //    item.Image = UIImage.FromBundle("xxx.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

            //    //selected icon
            //    item.SelectedImage = UIImage.FromBundle("xxx.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            //}
        }



        public void UpdateLayout(UITabBarController controller)
        {
        }
    }

}