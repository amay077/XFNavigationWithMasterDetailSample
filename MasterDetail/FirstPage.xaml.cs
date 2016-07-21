using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterDetail
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
            btnNext.Clicked += (s, e) => this.Navigation.PushAsync(new RootPage());
        }
    }
}

