using BBB_Common.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB_WP_Common.Service
{
	public class MeasurementService
	{
		static MobileServiceClient mobileService = new MobileServiceClient(
			"https://battery-s-big-brother.azure-mobile.net/",
			"FfOipHqfewlJRhjoQyQZaBCnhIyLls25"
		);

		public MeasurementService()
		{
 
		}

		public async Task AddMeasure(string DeviceId, int BatteryLevel, bool IsPlugged)
		{
			await mobileService.GetTable<Measurement>().InsertAsync(new Measurement()
			{
				DeviceId = DeviceId,
				BatteryLevel = BatteryLevel,
				Date = DateTime.Now,
				IsPlugged = IsPlugged
			});
		}
		
	}
}
