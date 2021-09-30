using Beauty.EFDataAccessLibrary.Models;
using Beauty.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Text.Json;
using Xamarin.CommunityToolkit.UI.Views;

namespace Beauty.ViewModels.BarPagesVM.User {
    class UserServicesVM : BaseVM {
        public UserServicesVM() {
            PageLoadingCommand = new Command(async () =>
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("UserToken"));
                var jsonResult = await httpClient.GetStreamAsync($"https://api.beauty.dimanrus.ru/Order/GetOrders");
                Orders = await JsonSerializer.DeserializeAsync<ObservableCollection<Order>>(jsonResult);
                if(Orders.Count == 0)
                    CurrentState = LayoutState.Empty;
                else
                    CurrentState = LayoutState.None;
            });
        }
        public ObservableCollection<Order> Orders { get; set; }
        public ICommand PageLoadingCommand { get; set; }
    }
}