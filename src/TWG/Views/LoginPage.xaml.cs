﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TWG.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
