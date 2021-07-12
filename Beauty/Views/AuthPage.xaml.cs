using System;
using System.Collections.Generic;
using Beauty.ViewModels;
using Xamarin.Forms;

namespace Beauty.Views
{
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
            Page.BindingContext = new AuthPageVM(Page);
        }
    }
}
