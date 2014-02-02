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

			var images = getTileImageUri(BatteryLevel);

			var tile = ShellTile.ActiveTiles.FirstOrDefault();

			if (tile != null)
			{
				var tileData = new IconicTileData();
				tileData.Title = title;
				tileData.Count = count;
				tileData.WideContent1 = header;
				tileData.WideContent2 = content;

				tileData.IconImage = images.Item1;
				tileData.SmallIconImage = images.Item2;

				tile.Update(tileData);
			}
		}

		/// <summary>
		/// Return Uri of tile images based on battery level
		/// </summary>
		/// <param name="batteryLevel">Battery level in percent</param>
		/// <returns>Tuple.Item1 - IconImage, Tuple.Item2 - SmallIconImage</returns>
		Tuple<Uri, Uri> getTileImageUri(int batteryLevel)
		{
			Uri uriImage = new Uri("/Assets/Tiles/IconImage25.png", UriKind.Relative);
			Uri uriSmallImage = new Uri("/Assets/Tiles/SmallIconImage25.png", UriKind.Relative);

			return new Tuple<Uri, Uri>(uriImage, uriSmallImage);
		}
	}
}
