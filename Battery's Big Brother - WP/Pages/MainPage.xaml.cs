using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BBB_WP.Resources;
using BBB_WP_Common;

namespace BBB_WP
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			BuildLocalizedApplicationBar();

			var agentControl = new AgentControl();
			agentControl.StartAgent();

			var batteryLevel = BBB_WP_Common.Device.DeviceInfo.RemainingChargePercent;
			var dischargeTime = BBB_WP_Common.Device.DeviceInfo.RemainingDischargeTime;
			var isPlugged = BBB_WP_Common.Device.DeviceInfo.IsPluggedToPower;

			setRectangleBattery(batteryLevel);
			setTextStatus(batteryLevel, dischargeTime, isPlugged);
			//tbBatteryLevel.Text = BBB_WP_Common.Device.DeviceInfo.RemainingChargePercent.ToString();
		}

		private void setRectangleBattery(int batteryLevel)
		{
			var baseHeight = 210.0;

			var actualHeight = baseHeight * (batteryLevel / 100);
			rctBatteryLevel.Height = actualHeight;
		}

		private void setTextStatus(int batteryLevel, TimeSpan dischargeTime, bool isPlugged)
		{
			tbTestStatusLevel.Text = batteryLevel + "%";
			tbTestStatusText.Text = dischargeTime.ToString(CommonResources.TileContentTemplate);
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