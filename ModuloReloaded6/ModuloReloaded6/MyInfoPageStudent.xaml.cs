using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyInfoPageStudent : ContentPage {
		public MyInfoPageStudent() {
			InitializeComponent();
			App a = App.Current as App;
			Models.User user = a.LoggedInUser;
			NameLabel.Text = user.FirstName + user.LastName;
			StudNoLabel.Text = user.Id;
			ClassLabel.Text = user.Class;
			//button.HeightRequest = grid.RowDefinitions[Grid.GetRow(button)].Height.Value;
		}

		//private void Button_Clicked(object sender, EventArgs e) {
		//	DisplayAlert("No.", "No.", "Oh");
		//}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e) {
			DisplayAlert("No.", "No.", "Oh");
		}
	}
}