using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB_WP_Common.Device
{
	public class TileManager
	{

		public void UpdateTile(int BatteryLevel, TimeSpan DischargeTime)
		{
			var title = CommonResources.TileTitle;
			var count = BatteryLevel;
			var header = CommonResources.TileHeader;//"Осталось врпемени";
			var content = DischargeTime.ToString(CommonResources.TileContentTemplate);
			if (BBB_WP_Common.Device.DeviceInfo.IsPluggedToPower)
			{
				header = CommonResources.TileHeaderPlugged;
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
