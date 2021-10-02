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
using System.Text.Json.Serialization;
using System.Linq;

namespace Beauty.ViewModels.BarPagesVM.User {
    class SearchServicePageVM : BaseVM {
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions() {
            ReferenceHandler = ReferenceHandler.Preserve
        };
        public SearchServicePageVM() {
            PageLoadingCommand = new Command(async () => {
                CurrentState = LayoutState.Loading;
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("UserToken"));
                var json = await httpClient.GetStringAsync("https://api.beauty.dimanrus.ru/Service");
                _serviceCategories = JsonSerializer.Deserialize<IEnumerable<ServiceCategory>>(json, jsonOptions);
                ServiceCategoties = _serviceCategories.Select(x => x.CategoryName).ToList();
                ServiceCategoties.Insert(0, "Категории");
                NotifyPropertyChanged(nameof(ServiceCategoties));
                CurrentState = LayoutState.None;
            });
        }
        IEnumerable<ServiceCategory> _serviceCategories { get; set; }
        public IList<string> ServiceCategoties { get; set; }
        public string ServiceCategorySelected { get; set; } = "Категории";
        public ObservableCollection<ServiceWorker> ServicesWorkers { get; private set; }
    }
}