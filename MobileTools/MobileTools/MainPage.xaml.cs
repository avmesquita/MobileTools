using MobileTools.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileTools
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void btnAbout_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new AboutPage());
		}

		private void btnBarcode_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new ScanPage());
		}

		private void btnGPS_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new GPSPage());
		}
	}
}
