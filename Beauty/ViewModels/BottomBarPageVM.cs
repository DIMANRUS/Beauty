using Beauty.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Beauty.ViewModels {
    class BottomBarPageVM : BaseVM {
        string _userRole;
        public BottomBarPageVM() {
            Task.Run(async () => { 
                UserRole = await SecureStorage.GetAsync("UserRole"); 
                NotifyPropertyChanged(nameof(UserRole)); });
        }
        public string UserRole { get; private set; }
    }
}
