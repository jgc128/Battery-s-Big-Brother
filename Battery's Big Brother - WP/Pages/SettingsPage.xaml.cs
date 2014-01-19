using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BBB_WP_Common;

namespace BBB_WP.Pages
{
	public partial class SettingsPage : PhoneApplicationPage
	{
		AgentControl agentControl;

		public SettingsPage()
		{
			InitializeComponent();

			agentControl = new AgentControl();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			cbAgentEnabled.IsChecked = agentControl.IsAgentEnabled;
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);

			if (cbAgentEnabled.IsChecked == true)
				agentControl.StartAgent();
			else
				agentControl.RemoveAgent();
		}
	}
}