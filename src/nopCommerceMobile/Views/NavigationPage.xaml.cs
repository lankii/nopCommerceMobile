﻿using System;
using nopCommerceMobile.ViewModels;
using nopCommerceMobile.ViewModels.Base;
using nopCommerceMobile.ViewModels.Navigation;
using nopCommerceMobile.Views.Customer;
using Xamarin.Forms;

namespace nopCommerceMobile.Views
{
    public abstract class NavigationPageXaml : ModelBoundContentPage<NavigationBaseViewModel> { }
    public partial class NavigationPage : NavigationPageXaml
    {
        public static NavigationPage Page;

        public NavigationPage()
        {
            InitializeComponent();
            Page = this;
            if (BindingContext == null)
                BindingContext = new NavigationBaseViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!ViewModel.SelectedNavigationPage.HasValue)
                SetHomePage();
            else
                Page.SetPageContentPage();

            await ViewModel.InitializeAsync();
        }

        private void SetHomePage()
        {
            ViewModel.SelectedNavigationPage = NavigationPageEnum.Home;
        }

        public void SetPageContentPage()
        {
            var primaryColor = Color.FromHex("#1e5474");

            //set selected/unselected colors
            ViewModel.HomePageTabColor = ViewModel.SelectedNavigationPage == NavigationPageEnum.Home ? primaryColor : Color.Default;
            ViewModel.AccountTabColor = ViewModel.SelectedNavigationPage == NavigationPageEnum.Account ? primaryColor : Color.Default;

            if (ViewModel.SelectedNavigationPage == NavigationPageEnum.Home)
                PageContainer.Content = new HomeView();

            if (ViewModel.SelectedNavigationPage == NavigationPageEnum.Account)
                PageContainer.Content = new CustomerView();
        }

        private void HomePageTabTapped(object sender, EventArgs e)
        {
            ViewModel.SelectedNavigationPage = NavigationPageEnum.Home;
        }

        private void AccountTabTapped(object sender, EventArgs e)
        {
            ViewModel.SelectedNavigationPage = NavigationPageEnum.Account;
        }
    }
}