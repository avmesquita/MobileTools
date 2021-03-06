﻿using MobileTools.Services.GPS;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MobileTools.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GPSPage : ContentPage
	{
		public GPSPage()
		{
			InitializeComponent();
			MapContent.IsVisible = false;
		}

		private void btnMainPage_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new MainPage());
		}

		private void btnGPS_Clicked(object sender, EventArgs e)
		{
			var geo = new GeoLocationService().GetGeoLocation();
			if (geo != null)
			{
				edtLatitude.Text = geo.Latitude.ToString();
				edtLongitude.Text = geo.Longitude.ToString();
				edtHeight.Text = geo.Height.ToString();

				try
				{
					if (!string.IsNullOrEmpty(edtLatitude.Text) && !string.IsNullOrEmpty(edtLongitude.Text))
					{
						double latitude = Double.Parse(edtLatitude.Text);
						double longitude = Double.Parse(edtLongitude.Text);

						var map = new Map(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(latitude, longitude), Distance.FromKilometers(2)));
						var pin = new Pin()
						{
							Position = new Xamarin.Forms.Maps.Position(latitude, longitude),
							Label = "YOU"
						};
						map.Pins.Add(pin);
						MapContent.Content = map;
						MapContent.IsVisible = true;
					}
				}
				catch (Exception ex)
				{
					slMsg.IsVisible = true;
					msg.Text = ex.Message.ToString();
					MapContent.IsVisible = false;
				}
			}
		}
	}
}