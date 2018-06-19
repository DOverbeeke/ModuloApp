using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyReservationsPage2 : ContentPage {
		public MyReservationsPage2(List<Models.ReservationTestObject> reslist) {
			InitializeComponent();

			Title = "ALL Reservations!! :D";

			LView.ItemsSource = reslist;
		}

		private void ItemTapped(object sender, EventArgs e) {

		}

		private void TapGridTapped(object sender, EventArgs e) {
			AlertFrame.IsVisible = false;
			TabGrid.IsVisible = false;
		}

		private void CancelResClicked(object sender, EventArgs e) {
			Button b = sender as Button;
			var bc = b.BindingContext as Models.ReservationTestObject;
			ConfirmButton.BindingContext = bc;
			RoomAlertLabel.Text = bc.Room.Name;
			BeginDateTimeAlertLabel.Text = bc.StartDateTime.ToString("dd MMM yyyy\r\nHH:mm");
			EndDateTimeAlertLabel.Text = bc.EndDateTime.ToString("dd MMM yyyy\r\nHH:mm");

			RoomAlertLabel.HorizontalTextAlignment = TextAlignment.Center;
			BeginDateTimeAlertLabel.HorizontalTextAlignment = TextAlignment.Center;
			EndDateTimeAlertLabel.HorizontalTextAlignment = TextAlignment.Center;

			AlertFrame.IsVisible = true;
			TabGrid.IsVisible = true;
		}

		private void ConfirmClicked(object sender, EventArgs e) {
			Button b = sender as Button;
			var bc = b.BindingContext as Models.ReservationTestObject;
			Navigation.PushAsync(new DeleteReservationPage(bc.Id));
			Navigation.RemovePage(this);
		}
		private void CancelClicked(object sender, EventArgs e) {
			AlertFrame.IsVisible = false;
			TabGrid.IsVisible = false;
		}
	}
}