using System;

using Xamarin.Forms;

namespace TWG.ViewModels
{
    public class CustNavigationPageViewModel : ContentPage
    {
        public CustNavigationPageViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

