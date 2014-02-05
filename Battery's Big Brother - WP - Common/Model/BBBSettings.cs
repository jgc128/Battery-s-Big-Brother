using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB_WP_Common.Model
{
	public class BBBSettings
	{
		public bool IsPushOnFullChargedEnabled { get; set; }

		public bool IsPushOnMinimumChargeEnabled { get; set; }

		public bool IsMeasurementServiceEnabled { get; set; }


		public BBBSettings()
		{
			IsPushOnFullChargedEnabled = true;
			IsPushOnMinimumChargeEnabled = true;
			IsMeasurementServiceEnabled = true;
		}
	}
}
