using System.Diagnostics;
using System.Windows;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System;
using BBB_WP_Background_Agent.Resources;


namespace BBB_WP_Background_Agent
{
	public class ScheduledAgent : ScheduledTaskAgent
	{
		/// <remarks>
		/// ScheduledAgent constructor, initializes the UnhandledException handler
		/// </remarks>
		static ScheduledAgent()
		{
			// Subscribe to the managed exception handler
			Deployment.Current.Dispatcher.BeginInvoke(delegate
			{
				Application.Current.UnhandledException += UnhandledException;
			});
		}

		/// Code to execute on Unhandled Exceptions
		private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
		{
			if (Debugger.IsAttached)
			{
				// An unhandled exception has occurred; break into the debugger
				Debugger.Break();
			}
		}

		/// <summary>
		/// Agent that runs a scheduled task
		/// </summary>
		/// <param name="task">
		/// The invoked task
		/// </param>
		/// <remarks>
		/// This method is called when a periodic or resource intensive task is invoked
		/// </remarks>
		protected override void OnInvoke(ScheduledTask task)
		{

			updateLiveTile();

			// If debugging is enabled, launch the agent again in one minute.
			#if DEBUG
			ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(20));
			#endif

			NotifyComplete();
		}

		private void updateLiveTile()
		{
			// Get info
			var batteryLevel = BBB_WP_Common.Device.DeviceInfo.RemainingChargePercent;
			var dischargeTime = BBB_WP_Common.Device.DeviceInfo.RemainingDischargeTime;

			// Set data
			var title = AppResources.TileTitle;
			var count = batteryLevel;
			var header = AppResources.TileHeader;//"Осталось врпемени";
			var content = dischargeTime.ToString(AppResources.TileContentTemplate);
			if (BBB_WP_Common.Device.DeviceInfo.IsPluggedToPower)
			{
				header = AppResources.TileHeaderPlugged;
				content = "";
			}


			var tile = ShellTile.ActiveTiles.FirstOrDefault();

			if (tile != null)
			{
				var tileData = new IconicTileData();
				tileData.Title = title;
				tileData.Count = count;
				tileData.WideContent1 = header;
				tileData.WideContent2 = content;

				tile.Update(tileData);
			}
		}
	}
}