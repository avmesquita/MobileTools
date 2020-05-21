using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTools
{
	public partial class App : Application
	{
		public static Models.UserConfiguration userData = null;

		public App()
		{
			InitializeComponent();

			LoadUserConfiguration();

			MainPage = new MainPage();
		}

		protected void LoadUserConfiguration()
		{
			userData = new Services.Database.MobileToolsDatabase().GetUserConfigurationAsync().Result;
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
