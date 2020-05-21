using MobileTools.Services.NASA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTools.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PodPage : ContentPage
	{
		public PodPage()
		{
			InitializeComponent();

			edtDate.MaximumDate = DateTime.Now;			
			edtDate.Date = DateTime.Now;

			var image = new NasaService().getAstronomicPicOfDay();
			var img = ImageSource.FromStream(() => new MemoryStream(image));
			PodPic.Source = img;			
		}

		private void btnBack_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new MainPage());
		}

		private void OnDateChanged_Event(object sender, DateChangedEventArgs e)
		{
			var image = new NasaService().getAstronomicPicOfDay(false,edtDate.Date);
			var img = ImageSource.FromStream(() => new MemoryStream(image));
			PodPic.Source = img;
		}
	}
}