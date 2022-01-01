using Beauty.EFDataAccessLibrary.Models;
using Beauty.ViewModels.Shared;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.UI.Views;
using Beauty.Helpers;

namespace Beauty.ViewModels.BarPagesVM.User {
    class UserServicesVm : BaseVm {
        public UserServicesVm() {
            PageLoadingCommand = new Command(async () => {
                CurrentState = LayoutState.Loading;
                using (var httpHelper = new HttpHelper()) {
                    Orders = await httpHelper.GetRequest<ObservableCollection<Order>>("Order/GetOrders");
                }
                CurrentState = Orders.Count == 0 ? LayoutState.Empty : LayoutState.None;
            });
        }
        public ObservableCollection<Order> Orders { get; set; }
    }
}