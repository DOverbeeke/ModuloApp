using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net.Http;

namespace ModuloReloaded6 {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddReservationPage : ContentPage {
		public AddReservationPage(string room_id, string amount_people, string begin_time, string end_time) {
			InitializeComponent();

			App app = App.Current as App;
			var user = app.LoggedInUser;
			string url = "http://ictlab.michelvanleeuwen.nl/public/api/reservations";
			var values = new Dictionary<string, string> {
				{ "user_id", user.Id },
				{ "room_id", room_id },
				{ "begin_time", begin_time },
				{ "end_time", end_time },
				{ "amount_people", amount_people }
			};

			var content = new FormUrlEncodedContent(values);

			API.APICommunication.APIPost(url, content, ApiSuccess, ApiResIsNull, APIException);
		}

		private void ApiSuccess(string result) {
			Navigation.PushAsync(new AddingReservationDonePage());
			Navigation.RemovePage(this);
		}
		private void ApiResIsNull() {
			Console.WriteLine("nuuuuuuuuuuuuull ReservationsLoadingPage2");
		}
		private void APIException(string exception) {
			Console.WriteLine("exceptiooooon ReservationsLoadingPage2: " + exception);
		}

	}
}