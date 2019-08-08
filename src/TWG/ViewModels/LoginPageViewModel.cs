using System;

using Xamarin.Forms;

namespace TWG.ViewModels
{
    public class LoginPageViewModel : ContentPage
    {
        public LoginPageViewModel()
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

