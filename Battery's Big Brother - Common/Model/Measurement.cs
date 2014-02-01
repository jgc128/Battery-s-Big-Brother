using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB_Common.Model
{
	public class Measurement
	{
		public string Id { get; set; }

		public string DeviceId { get; set; }

		public int BatteryLevel { get; set; }

		public DateTime Date { get; set; }
	}
}
