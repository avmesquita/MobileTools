using MobileTools.Models;
using MobileTools.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTools.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserSettingsPage : ContentPage
	{
		public UserSettingsPage()
		{
			InitializeComponent();

			var user = new MobileToolsDatabase().GetUserConfigurationAsync().Result;
			if (user != null)
			{
				edtGoogleApiKey.Text = user.GoogleApiKey;
				edtNasaApiKey.Text = user.NasaApiKey;
			}

		}

		private void btnSave_Clicked(object sender, EventArgs e)
		{
			UserConfiguration user = App.userData;

			if (user == null)
			{
				user = new UserConfiguration()
				{
					Guid = Guid.NewGuid(),
					GoogleApiKey = edtGoogleApiKey.Text,
					NasaApiKey = edtNasaApiKey.Text
				};
			}
			else 
			{
				user.GoogleApiKey = edtGoogleApiKey.Text;
				user.NasaApiKey = edtNasaApiKey.Text;
			}

			new MobileToolsDatabase().SaveUserConfigurationAsync(user);

			App.userData = user;
		}

		private void btnBack_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new MainPage());
		}
	}
}