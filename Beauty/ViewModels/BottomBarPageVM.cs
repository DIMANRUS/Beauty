using Beauty.ViewModels.Shared;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Beauty.ViewModels {
    class BottomBarPageVM : BaseVM {
        public BottomBarPageVM() =>
            Task.Run(async () => {
                UserRole = await SecureStorage.GetAsync("UserRole");
                NotifyPropertyChanged(nameof(UserRole));
            });
        public string UserRole { get; private set; }
    }
}
