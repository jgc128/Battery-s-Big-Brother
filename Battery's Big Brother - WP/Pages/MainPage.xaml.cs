﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BBB_WP.Resources;

namespace BBB_WP
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			BuildLocalizedApplicationBar();
		}

		private void BuildLocalizedApplicationBar()
		{
		    // Set the page's ApplicationBar to a new instance of ApplicationBar.
		    ApplicationBar = new ApplicationBar();

		    // Create a new button and set the text value to the localized string from AppResources.
			ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/feature.settings.png", UriKind.Relative));
		    appBarButton.Text = AppResources.MainPageAppBarSettingsButtonText;
			appBarButton.Click += appBarButton_Click;
		    ApplicationBar.Buttons.Add(appBarButton);

			//// Create a new menu item with the localized string from AppResources.
			//ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
			//ApplicationBar.MenuItems.Add(appBarMenuItem);
		}

		void appBarButton_Click(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/Pages/SettingsPage.xaml", UriKind.Relative));
		}
	}
}