using Beauty.EFDataAccessLibrary.Models;
using Beauty.ViewModels.Shared;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.UI.Views;
using Beauty.Helpers;

namespace Beauty.ViewModels.BarPagesVM.User {
    class UserServicesVM : BaseVM {
        public UserServicesVM()
        {
            PageLoadingCommand = new Command(async () =>
            {
                CurrentState = LayoutState.Loading;
                Orders = await HttpHelper.GetRequest<ObservableCollection<Order>>("Order/GetOrders");
                if (Orders.Count == 0)
                    CurrentState = LayoutState.Empty;
                else
                    CurrentState = LayoutState.None;
            });
        }
        public ObservableCollection<Order> Orders { get; set; }
    }
}