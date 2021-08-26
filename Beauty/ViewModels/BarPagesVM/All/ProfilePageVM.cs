using Beauty.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Beauty.Pages;

namespace Beauty.ViewModels.BarPagesVM.All {
    class ProfilePageVM : BaseVM {
        public ProfilePageVM() {
            ExitCommand = new Command(() => {
                SecureStorage.RemoveAll();
                Application.Current.MainPage = new AuthPage();
            });
            PageLoadingCommand = new Command(() =>
                _page = Application.Current.MainPage);
        }

        private Page _page;
        public string UserName { get; private set; }

        public ICommand ExitCommand { get; private set; }
        public ICommand PageLoadingCommand { get; private set; }
    }
}