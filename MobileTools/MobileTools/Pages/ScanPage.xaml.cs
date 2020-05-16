using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MobileTools.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScanPage : ContentPage
	{
		public ScanPage()
		{
			InitializeComponent();
		}

		private void btnMainPage_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new MainPage());
		}

		private void btnScan_Clicked(object sender, EventArgs e)
		{
			ZXingScannerPage scanPage = new ZXingScannerPage();
			scanPage.IsScanning = true;
			scanPage.OnScanResult += (result) =>
			{
				scanPage.IsScanning = false;
				ZXing.BarcodeFormat barcodeFormat = result.BarcodeFormat;
				string type = barcodeFormat.ToString();
				Device.BeginInvokeOnMainThread(() =>
				{
					Navigation.PopModalAsync();

					this.IsVisible = true;

					edtCode.Text = result.Text.Trim();
				});
			};
			this.IsVisible = false;

			Navigation.PushModalAsync(scanPage);
		}
	}
}