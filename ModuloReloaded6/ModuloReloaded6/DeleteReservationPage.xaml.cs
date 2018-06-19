using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeleteReservationPage : ContentPage {
		public DeleteReservationPage(string reservation_id) {
			InitializeComponent();

			Title = "Deleting Reservation!";

			string url = "http://ictlab.michelvanleeuwen.nl/public/api/reservations/" + reservation_id;
			API.APICommunication.APIDelete(url, ApiSuccess, ApiResIsNull, APIException);
		}

		private void ApiSuccess(string result) {
			var p = new DeletingReservationDonePage();
			Navigation.PushAsync(p);
			Navigation.InsertPageBefore(new DeleteToReservationsPage(), p);
			Navigation.RemovePage(this);
		}
		private void ApiResIsNull() {
			Console.WriteLine("nuuuuuuuuuuuuull DeleteReservationPage");
		}
		private void APIException(string exception) {
			Console.WriteLine("exceptiooooon DeleteReservationPage: " + exception);
		}
	}
}