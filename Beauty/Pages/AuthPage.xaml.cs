using System;
using System.Collections.Generic;
using Beauty.ViewModels;
using Xamarin.Forms;

namespace Beauty.Pages
{
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
            page.BindingContext = new AuthPageVM();
        }
    }
}
