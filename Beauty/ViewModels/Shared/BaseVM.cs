using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;

namespace Beauty.ViewModels.Shared {
    public class BaseVm : INotifyPropertyChanged {
        protected BaseVm() {
            Task.Run(async () => {
                UserRole = await SecureStorage.GetAsync("UserRole");
                NotifyPropertyChanged(nameof(UserRole));
            });
        }
        #region Private Fields

        private string _userRole;
        private LayoutState _layoutState = LayoutState.None;
        #endregion
        #region Properties
        public string UserRole {
            get => _userRole;
            set => Set(ref _userRole, value);
        }
        public ICommand PageLoadingCommand { get; protected set; }
        public LayoutState CurrentState { get => _layoutState; set => Set(ref _layoutState, value); }
        #endregion
        #region NPC
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "") {
            if (value is null)
                return;
            field = value;
            NotifyPropertyChanged(propertyName);
        }
        #endregion
    }
}