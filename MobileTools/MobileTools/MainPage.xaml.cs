using MobileTools.Models;
using MobileTools.Pages;
using MobileTools.Services.Database;
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

		private void btnPing_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new PingPage());
		}

		private void btnPoD_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new PodPage());
		}

		private void btnQuit_Clicked(object sender, EventArgs e)
		{
			System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
		}

		private void btnSettings_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new UserSettingsPage());
		}
	}
}
