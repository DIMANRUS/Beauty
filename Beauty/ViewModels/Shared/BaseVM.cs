using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.CommunityToolkit.UI.Views;

namespace Beauty.ViewModels.Shared {
    public class BaseVM : INotifyPropertyChanged {
        public ICommand PageLoadingCommand { get; protected set; }
        private LayoutState _layoutState = LayoutState.None;
        public LayoutState CurrentState { get => _layoutState; protected set { _layoutState = value; NotifyPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}