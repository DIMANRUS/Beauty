using System.Collections.Generic;
using System.Collections.ObjectModel;
using Beauty.EFDataAccessLibrary.Models;
using Beauty.ViewModels.Shared;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Linq;
using System.Windows.Input;
using Beauty.Helpers;

namespace Beauty.ViewModels.BarPagesVM.User {
    class SearchServicePageVm : BaseVm {
        //private readonly JsonSerializerOptions _jsonOptions = new () {
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};
        public SearchServicePageVm() {
            PageLoadingCommand = new Command(async () => {
                CurrentState = LayoutState.Loading;
                using (HttpHelper httpHelper = new ()) {
                    ServiceCategories = await httpHelper.GetRequest<IEnumerable<ServiceCategory>>("https://api.beauty.dimanrus.ru/Service");
                }
                ServiceCategoties = ServiceCategories.Select(x => x.CategoryName).ToList();
                ServiceCategoties.Insert(0, "Категории");
                NotifyPropertyChanged(nameof(ServiceCategoties));
                CurrentState = LayoutState.None;
            });
            SelectedCategotyServiceCommand = new Command(() => {
                //if(ServiceCategorySelected == "Категории")
                ServiceCategories = null;
            });
            SelectedServiceCommand = new Command(() => {

            });
        }
        IEnumerable<ServiceCategory> ServiceCategories { get; set; }
        public IList<string> ServiceCategoties { get; set; }
        public IList<string> Services { get; set; }
        public string ServiceCategorySelected { get; set; } = "Категории";
        public string ServiceSelected { get; set; } = "Услуги";
        public ObservableCollection<WorkerService> ServicesWorkers { get; private set; }

        #region Commnand
        public ICommand SelectedCategotyServiceCommand { get; private set; }
        public ICommand SelectedServiceCommand { get; private set; }
        #endregion
    }
}