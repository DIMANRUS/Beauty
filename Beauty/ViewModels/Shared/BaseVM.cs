﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;

namespace Beauty.ViewModels.Shared {
    public class BaseVM : INotifyPropertyChanged {
        public BaseVM()
        {
            Task.Run(async () => {
                UserRole = await SecureStorage.GetAsync("UserRole");
                NotifyPropertyChanged(nameof(UserRole));
            });
        }
        public string UserRole { get; private set; } = "USER";
        public ICommand PageLoadingCommand { get; protected set; }
        private LayoutState _layoutState = LayoutState.None;
        public LayoutState CurrentState { get => _layoutState; protected set { _layoutState = value; NotifyPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}