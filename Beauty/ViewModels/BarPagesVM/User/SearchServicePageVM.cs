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
using System.Windows.Input;
using Beauty.Helpers;

namespace Beauty.ViewModels.BarPagesVM.User {
    class SearchServicePageVM : BaseVM {
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions() {
            ReferenceHandler = ReferenceHandler.Preserve
        };
        public SearchServicePageVM() {
            PageLoadingCommand = new Command(async () => {
                CurrentState = LayoutState.Loading;
                _serviceCategories = await HttpHelper.GetRequest<IEnumerable<ServiceCategory>>("https://api.beauty.dimanrus.ru/Service");
                ServiceCategoties = _serviceCategories.Select(x => x.CategoryName).ToList();
                ServiceCategoties.Insert(0, "Категории");
                NotifyPropertyChanged(nameof(ServiceCategoties));
                CurrentState = LayoutState.None;
            });
            SelectedCategotyServiceCommand = new Command(() => {
                //if(ServiceCategorySelected == "Категории")
                _serviceCategories = null;
            });
            SelectedServiceCommand = new Command(() => {

            });
        }
        IEnumerable<ServiceCategory> _serviceCategories { get; set; }
        public IList<string> ServiceCategoties { get; set; }
        public IList<string> Services { get; set; }
        public string ServiceCategorySelected { get; set; } = "Категории";
        public string ServiceSelected { get; set; } = "Услуги";
        public ObservableCollection<ServiceWorker> ServicesWorkers { get; private set; }

        #region Commnand
        public ICommand SelectedCategotyServiceCommand { get; private set; }
        public ICommand SelectedServiceCommand { get; private set; }
        #endregion
    }
}