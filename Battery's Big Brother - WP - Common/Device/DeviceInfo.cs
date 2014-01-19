using Microsoft.Phone.Info;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Windows.Phone.Devices.Power;

namespace BBB_WP_Common.Device
{
	public static class DeviceInfo
	{
		public static string DeviceName
		{
			get
			{
				return DeviceStatus.DeviceName;
			}
		}
		public static bool IsPluggedToPower
		{
			get
			{
				return DeviceStatus.PowerSource == PowerSource.External;
			}
		}

		static string deviceId;
		public static string DeviceId
		{
			get
			{
				if (String.IsNullOrEmpty(deviceId))
				{
					var deviceIdInByte = (byte[])DeviceExtendedProperties.GetValue("DeviceUniqueId");
					deviceId = Convert.ToBase64String(deviceIdInByte);
				}

				return deviceId;
			}
		}

		public static int RemainingChargePercent
		{
			get
			{
				return Battery.GetDefault().RemainingChargePercent;
			}
		}
		public static TimeSpan RemainingDischargeTime
		{
			get
			{
				return Battery.GetDefault().RemainingDischargeTime;
			}
		}
	}
}
