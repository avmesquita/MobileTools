using System;
using System.Collections.Generic;
using System.Text;
using MobileTools.Models;
using Xamarin.Essentials;

namespace MobileTools.Services.GPS
{
	public class GeoLocationService : IDisposable
	{
		public async System.Threading.Tasks.Task<GeoLocation> GetGeoLocationAsync()
		{
			try
			{
				var location = await Xamarin.Essentials.Geolocation.GetLastKnownLocationAsync();

				if (location != null)
				{
					return new GeoLocation()
					{
						Latitude = location.Latitude,
						Longitude = location.Longitude,
						Height = location.Altitude
					};
				}
				return null;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public GeoLocation GetGeoLocation()
		{
			try
			{
				var geo = this.GetGeoLocationAsync();

				return geo.Result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Dispose()
		{
			
		}
	}
}
