using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddingReservationDonePage : ContentPage {
		public AddingReservationDonePage() {
			InitializeComponent();
		}

		private void BackClicked(object sender, EventArgs e) {
			Navigation.PopAsync();
		}
		private void ShowClicked(object sender, EventArgs e) {
			Navigation.InsertPageBefore(new ReservationsLoadingPage2(), Navigation.NavigationStack[0]);
			Navigation.RemovePage(this);
			Navigation.RemovePage(Navigation.NavigationStack[1]);
		}
	}
}