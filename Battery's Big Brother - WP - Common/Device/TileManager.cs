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

		public void UpdateTile(int BatteryLevel, TimeSpan DischargeTime, bool isPlugged)
		{
			var title = CommonResources.TileTitle;
			var count = BatteryLevel;
			var header = CommonResources.TileHeader;//"Осталось врпемени";
			var content = DischargeTime.ToString(CommonResources.TileContentTemplate);
			if (isPlugged)
			{
				header = CommonResources.TileHeaderPlugged;
				content = "";
			}

			var images = GetTileImagesUri(BatteryLevel);

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
		public Tuple<Uri, Uri> GetTileImagesUri(int batteryLevel)
		{
			var baseUrl = "/Assets/Tiles/";
			var imagePart = "IconImage";
			var smallImagePart = "SmallIconImage";

			var level = 100;

			if (batteryLevel < 80)
				level = 75;
			if (batteryLevel < 60)
				level = 50;
			if (batteryLevel < 40)
				level = 25;
			if (batteryLevel < 20)
				level = 0;
			
			Uri uriImage = new Uri(baseUrl + imagePart + level + ".png", UriKind.Relative);
			Uri uriSmallImage = new Uri(baseUrl + smallImagePart + level + ".png", UriKind.Relative);

			return new Tuple<Uri, Uri>(uriImage, uriSmallImage);
		}
	}
}
