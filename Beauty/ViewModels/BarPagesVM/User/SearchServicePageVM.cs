using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using Beauty.EFDataAccessLibrary.Models;
using Beauty.ViewModels.Shared;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Text.Json;

namespace Beauty.ViewModels.BarPagesVM.User
{
    class SearchServicePageVM : BaseVM
    {
        public SearchServicePageVM()
        {
            PageLoadingCommand = new Command(async () =>
            {
                CurrentState = LayoutState.Loading;
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("UserToken"));
                var json = await httpClient.GetStringAsync("https://api.beauty.dimanrus.ru/Service");
                ServiceCategories = JsonSerializer.Deserialize<IEnumerable<ServiceCategory>>(json);
                CurrentState = LayoutState.None;
            });
        }
        public IEnumerable<ServiceCategory> ServiceCategories { get; set; }
        public Service ServiceSelected { get; set; }
        public ServiceCategory serviceCategorySelected { get; set; }
        public ObservableCollection<ServiceWorker> ServicesWorkers { get; private set; }
    }
}