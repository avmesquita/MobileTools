using MobileTools.Services.Network;
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
	public partial class PingPage : ContentPage
	{
		public PingPage()
		{
			InitializeComponent();
		}

		private void btnMainPage_Clicked(object sender, EventArgs e)
		{
			this.Navigation.PushModalAsync(new MainPage());
		}

		private void btnPing_Clicked(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(edtHostname.Text))
			{
				var pings = new PingService().Ping(edtHostname.Text.Trim(), 10);

				gridPing.RowDefinitions = new RowDefinitionCollection();

				gridPing.ColumnDefinitions = new ColumnDefinitionCollection();

				int i = 0;
				foreach (var ping in pings)
				{
					gridPing.Children.Add(new Label
					{
						Padding = 2,
						Text = ping.ToString(),
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand
					}, 0, i);
					i++;
				}
			}
			else 
			{
				gridPing.IsVisible = false;
				slMsg.IsVisible = true;
				msg.Text = "[IP/Hostname not identified]";			
			}
		}
	}
}