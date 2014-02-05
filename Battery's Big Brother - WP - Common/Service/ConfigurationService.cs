using BBB_WP_Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BBB_WP_Common.Service
{
	public class ConfigurationService<T> where T : new ()
	{
		private static string configurationFilename = "configuration.xml";
		private static Mutex mutex = new Mutex(false, "BackgroundAgentDemo1");


		protected T _settings;
		public T Settings
		{
			get { return _settings; }
		}

		public void LoadSettings()
		{
			mutex.WaitOne();

			_settings = new T();

			try
			{
				using (var isoStrore = IsolatedStorageFile.GetUserStoreForApplication())
				{
					var fileStream = isoStrore.OpenFile(configurationFilename, FileMode.OpenOrCreate, FileAccess.Read);
					using (StreamReader reader = new StreamReader(fileStream))
					{
						if (!reader.EndOfStream)
						{
							var jsonString = reader.ReadToEnd();
							_settings = JsonConvert.DeserializeObject<T>(jsonString);
						}
					}
				}
			}
			finally
			{
				mutex.ReleaseMutex();
			}
		}

		public void SaveSettings()
		{
			mutex.WaitOne();

			try
			{
				using (var isoStrore = IsolatedStorageFile.GetUserStoreForApplication())
				{
					var fileStream = isoStrore.OpenFile(configurationFilename, FileMode.OpenOrCreate, FileAccess.Write);
					using (StreamWriter writer = new StreamWriter(fileStream))
					{
						var jsonString = JsonConvert.SerializeObject(_settings);
							
						writer.Write(jsonString);
					}
				}
			}
			finally
			{
				mutex.ReleaseMutex();
			}
		}
	}
}
